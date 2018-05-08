using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AxMSTSCLib;
using Dapper;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MSTSCLib;
using RdpTest.Control;
using RdpTest.Model;

namespace RdpTest
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            //设置主题
            StyleManager = metroStyleManager;

            var style = (MetroColorStyle)Db.Connection.QueryFirstOrDefault<int>("SELECT FValue FROM MyConfig WHERE FKey='Style'");
            metroStyleManager.Style = style;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //异步加载远程桌面配置
            BeginInvoke(new Action(LoadHostConfig));
        }

        private void LoadHostConfig()
        {
            panelBody.Visible = false;
            panelBody.Controls.Clear(); //清空原有

            var hosts = (List<RemoteHost>)Db.Connection.Query<RemoteHost>(
                "SELECT Id,Name,Address,Port,User,Pwd,Sort,ParentId,RemoteProgram FROM RemoteHost");

            //创建分组
            foreach (var hostGroup in hosts.Where(x => x.ParentId == 0).OrderByDescending(x => x.Sort))
            {
                //建立分组
                var hostGroupBox = new HostGroupBox { Dock = DockStyle.Top, Height = 100, Text = hostGroup.Name };
                panelBody.Controls.Add(hostGroupBox);

                //填充分组内容
                foreach (var host in hosts.Where(x => x.ParentId == hostGroup.Id).OrderBy(x => x.Sort))
                {
                    var title = new MetroTile
                    {
                        Name = "title",
                        ActiveControl = null,
                        Height = 60,
                        Text = $"{host.Name}\r\n  {host.FullAddress}",
                        UseSelectable = true,
                        UseVisualStyleBackColor = true,
                        Tag = host,
                        AutoSize = true,
                        ContextMenuStrip = menuTitle,
                        StyleManager = metroStyleManager
                    };
                    title.Click += ConnectRemoteHost;
                    title.MouseDown += MenuTitleRightClick;
                    hostGroupBox.AddControl(title);
                }
            }
            panelBody.Visible = true;
        }

        void ConnectRemoteHost(object sender, EventArgs e)
        {
            var host = (RemoteHost)((MetroTile)sender).Tag;

            #region 1.0 创建页签
            var page = new TabPage($"{host.Name}[{host.FullAddress}]");
            tabMain.TabPages.Add(page);
            page.ContextMenuStrip = menuTabPage;
            tabMain.SelectedTab = page;
            #endregion

            #region 2.0 创建远程桌面客户端
            var rdpClient = new AxMsRdpClient9NotSafeForScripting
            {
                Dock = DockStyle.None,
                Width = page.Width,
                Height = page.Height
            };
            page.Controls.Add(rdpClient);

            rdpClient.Server = host.Address;
            if (host.Port != 3389)
                rdpClient.AdvancedSettings2.RDPPort = host.Port;

            rdpClient.UserName = host.User;
            rdpClient.AdvancedSettings2.ClearTextPassword = host.Pwd;

            //进运行远程程序模式
            if (!string.IsNullOrEmpty(host.RemoteProgram))
            {
                rdpClient.RemoteProgram2.RemoteProgramMode = true;
                rdpClient.Width = Screen.PrimaryScreen.Bounds.Width;
                rdpClient.Height = Screen.PrimaryScreen.Bounds.Height;
                rdpClient.OnLoginComplete += (o, args) =>
                {
                    rdpClient.RemoteProgram2.ServerStartProgram(host.RemoteProgram, "", "%SYSTEMROOT%", false, "", false);
                    rdpClient.OnRemoteProgramResult += (o1, args1) =>
                    {
                        if (args1.lError != RemoteProgramResult.remoteAppResultOk)
                        {
                            rdpClient.Dispose();
                            MessageBox.Show(args1.lError.ToString(), "打开远程程序失败");
                        }
                    };

                    tabMain.TabPages.Remove(page);
                };
            }

            //rdpClient.RemoteProgram2.RemoteProgramMode = true;
            //rdpClient.OnLoginComplete += (o, args) =>
            //{
            //    rdpClient.RemoteProgram2.ServerStartProgram("cmd", "", "%SYSTEMROOT%", false, "", false);
            //    tabMain.TabPages.Remove(page);
            //};

            /* 因为分辨率比例问题，缩放效果并不怎么样
               rdpClient.Width = Screen.PrimaryScreen.Bounds.Width;
               rdpClient.Height = Screen.PrimaryScreen.Bounds.Height;
               rdpClient.AdvancedSettings9.SmartSizing = true;
             */

            //偏好设置
            ((IMsRdpClientNonScriptable5)rdpClient.GetOcx()).PromptForCredentials = false;
            rdpClient.AdvancedSettings9.EnableCredSspSupport = true;
            rdpClient.ColorDepth = 16;
            rdpClient.ConnectingText = $"正在连接[{host.Name}]，请稍等... {host.FullAddress}";
            #endregion

            //连接远程桌面
            rdpClient.Connect();
        }

        #region 菜单按钮
        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            var nextStyle = ((int)metroStyleManager.Style + 1) % 14;
            if (nextStyle == 1) nextStyle++; //忽略白色

            metroStyleManager.Style = (MetroColorStyle)nextStyle;

            Db.Connection.Execute("UPDATE MyConfig SET FValue=@Style WHERE FKey='Style'", new { metroStyleManager.Style });

            Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHostConfig();
        }

        private void btnAddRemoteHost_Click(object sender, EventArgs e)
        {
            var hostForm = new RemoteHostForm { StyleManager = metroStyleManager };
            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHostConfig();
        }
        #endregion

        #region 页签控制
        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            var index = InTabPageHead(e.Location, false);
            if (index > 0)
            {
                tabMain.SelectedIndex = index;

                if (e.Button == MouseButtons.Right)
                    tabMain.ContextMenuStrip = menuTabPage;  //弹出菜单
                else
                {
                    _tabMoving = true;
                    _tabBeforeMoveX = e.X;
                }
            }
        }

        /// <summary>
        /// 正在移动 TabPage 位置
        /// </summary>
        private bool _tabMoving;
        private int _tabBeforeMoveX;

        private void tabMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_tabMoving)
            {
                var index = InTabPageHead(e.Location, true);
                if (index <= 0)
                {
                    Cursor.Current = Cursors.No;
                    return;
                }

                var offset = e.X - _tabBeforeMoveX;
                if (offset == 0)
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }

                Cursor.Current = Cursors.NoMoveHoriz;
                if (tabMain.SelectedIndex != index)
                {
                    var currPage = tabMain.SelectedTab;

                    tabMain.Visible = false;
                    tabMain.TabPages.Remove(currPage);
                    tabMain.TabPages.Insert(index, currPage);
                    tabMain.SelectedTab = currPage;
                    tabMain.Visible = true;
                }
            }
        }

        private int InTabPageHead(Point location, bool zoomRange)
        {
            for (int i = 1, count = tabMain.TabPages.Count; i < count; i++) //排除首页
            {
                var rect = tabMain.GetTabRect(i);
                if (zoomRange) //缩小判定范围
                {
                    var offset = rect.Width / 4;
                    rect = new Rectangle(rect.X + offset / 2, rect.Y, rect.Width - offset, rect.Height);
                }

                if (rect.Contains(location))
                {
                    return i;
                }
            }
            return -1;
        }

        private void tabMain_MouseUp(object sender, MouseEventArgs e)
        {
            _tabMoving = false;
            Cursor.Current = Cursors.Default;
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            tabMain.ContextMenuStrip = null;  //离开选项卡后 取消菜单
        }

        private void tmiCloseHost_Click(object sender, EventArgs e)
        {
            var next = tabMain.SelectedIndex - 1;
            var host = (AxMsRdpClient9NotSafeForScripting)tabMain.SelectedTab.Controls[0];

            if (host.Connected == 1)
                host.Disconnect();
            host.Dispose();
            tabMain.SelectedTab.Dispose();

            tabMain.SelectedIndex = next;
        }
        #endregion

        #region MetroTitle控制
        /// <summary>
        /// 当前选择的 Host
        /// </summary>
        private MetroTile _currSelectHost;
        private void MenuTitleRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                _currSelectHost = (MetroTile)sender;
        }

        private void tmiEdit_Click(object sender, EventArgs e)
        {
            if (_currSelectHost == null) return;

            var host = (RemoteHost)_currSelectHost.Tag;
            var hostForm = new RemoteHostForm { StyleManager = metroStyleManager, RemoteHost = host };

            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHostConfig();
        }
        private void tmiDeleteHost_Click(object sender, EventArgs e)
        {
            if (_currSelectHost == null) return;

            var host = (RemoteHost)_currSelectHost.Tag;
            Db.Connection.Execute("DELETE FROM RemoteHost WHERE Id=" + host.Id);

            _currSelectHost.Parent.Controls.Remove(_currSelectHost);
            _currSelectHost = null;
        }

        private void tmiDeleteAll_Click(object sender, EventArgs e)
        {
            if (_currSelectHost == null) return;

            var host = (RemoteHost)_currSelectHost.Tag;
            Db.Connection.Execute("DELETE FROM RemoteHost WHERE ParentId=" + host.ParentId);
            Db.Connection.Execute("DELETE FROM RemoteHost WHERE Id=" + host.ParentId);

            var parent = _currSelectHost.Parent.Parent;
            parent.Parent.Controls.Remove(parent);
            _currSelectHost = null;
        }

        #endregion

    }
}
