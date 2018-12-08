using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AxMSTSCLib;
using Dapper;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MSTSCLib;
using Newtonsoft.Json;
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

            //获取全局默认设置
            var globalConfig = Db.Connection.QueryFirstOrDefault<string>("SELECT FValue FROM MyConfig WHERE FKey='GlobalConfig'");
            GlobalConfig.Instance = JsonConvert.DeserializeObject<GlobalConfig>(globalConfig) ?? new GlobalConfig();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //异步加载远程桌面配置
            BeginInvoke(new Action(LoadHosts));
        }

        /// <summary>
        /// 加载所以远程桌面配置
        /// </summary>
        private void LoadHosts()
        {
            panelBody.Visible = false;
            panelBody.Controls.Clear(); //清空原有

            var hosts = (List<RemoteHost>)Db.Connection.Query<RemoteHost>(
                "SELECT Id,Name,Address,Port,User,Pwd,Sort,ParentId,RemoteProgram,ExtJson FROM RemoteHost");

            //创建分组
            foreach (var hostGroup in hosts.Where(x => x.ParentId == 0).OrderByDescending(x => x.Sort))
            {
                //建立分组
                var hostGroupBox = new HostGroupBox { Dock = DockStyle.Top, Height = 100, Text = hostGroup.Name, ContextMenuStrip = menuGroup, Tag = hostGroup };
                hostGroupBox.GropNameMouseDown += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                        _currSelectGroup = sender;
                };

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
                        ContextMenuStrip = menuHost,
                        StyleManager = metroStyleManager
                    };
                    title.Click += ConnectRemoteHost;
                    title.MouseDown += MenuTitleRightClick;
                    hostGroupBox.AddControl(title);
                }
            }
            panelBody.Visible = true;
        }

        /// <summary>
        /// 连接远程桌面
        /// </summary>
        private void ConnectRemoteHost(object sender, EventArgs e)
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

            #region 远程模式 [桌面/仅程序]
            if (string.IsNullOrEmpty(host.RemoteProgram)) //普通远程桌面模式
            {
                //映射键盘
                rdpClient.SecuredSettings3.KeyboardHookMode = 1;
            }
            else //运行远程程序模式
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
            #endregion

            /* 因为分辨率比例问题，缩放效果并不怎么样
               rdpClient.Width = Screen.PrimaryScreen.Bounds.Width;
               rdpClient.Height = Screen.PrimaryScreen.Bounds.Height;
               rdpClient.AdvancedSettings9.SmartSizing = true;
             */

            //偏好设置
            var clientNonScriptable = (IMsRdpClientNonScriptable5)rdpClient.GetOcx();
            clientNonScriptable.PromptForCredentials = false;
            rdpClient.AdvancedSettings9.EnableCredSspSupport = true;
            rdpClient.ColorDepth = 16;
            rdpClient.ConnectingText = $"正在连接[{host.Name}]，请稍等... {host.FullAddress}";

            //是否共享剪切板
            rdpClient.AdvancedSettings9.RedirectClipboard = host.Ext.ShareClipboard;

            #region 共享本地磁盘 [可配置]
            //是否共享所有本地磁盘 
            rdpClient.AdvancedSettings9.RedirectDrives = host.Ext.ShareAllDisk;

            //共享选中的本地磁盘
            if (!rdpClient.AdvancedSettings9.RedirectDrives)
            {
                var diskList = host.Ext.ShareDiskList;
                if (diskList?.Count > 0)
                {
                    var driveCollection = clientNonScriptable.DriveCollection;
                    for (uint i = 0; i < driveCollection.DriveCount; i++)
                    {
                        var driveByIndex = driveCollection.DriveByIndex[i];
                        var driveName = driveByIndex.Name.Substring(0, driveByIndex.Name.Length - 1);
                        driveByIndex.RedirectionState = diskList.Contains(driveName);
                    }
                }
            }
            #endregion

            #endregion

            //连接远程桌面
            rdpClient.Connect();
        }

        private AxMsRdpClient9NotSafeForScripting GetHost(int pageIndex)
        {
            var page = tabMain.TabPages[pageIndex];
            return (AxMsRdpClient9NotSafeForScripting)page.Controls[0];
        }


        #region 菜单按钮
        /// <summary>
        /// 切换主题
        /// </summary>
        private void btnChangeStyle_Click(object sender, EventArgs e)
        {
            var nextStyle = ((int)metroStyleManager.Style + 1) % 14;
            if (nextStyle == 1) nextStyle++; //忽略白色

            metroStyleManager.Style = (MetroColorStyle)nextStyle;

            Db.Connection.Execute("UPDATE MyConfig SET FValue=@Style WHERE FKey='Style'", new { metroStyleManager.Style });

            Refresh();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHosts();
        }

        /// <summary>
        /// 添加主机
        /// </summary>
        private void btnAddRemoteHost_Click(object sender, EventArgs e)
        {
            var hostForm = new RemoteHostForm { StyleManager = metroStyleManager };
            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHosts();
        }

        /// <summary>
        /// 全局设置
        /// </summary>
        private void btnGlobalSetting_Click(object sender, EventArgs e)
        {
            var globalSettingForm = new GlobalSettingForm { StyleManager = metroStyleManager };
            globalSettingForm.ShowDialog();
        }

        /// <summary>
        /// 关于
        /// </summary>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/wang9563/RemoteDesktopManage");
        }
        #endregion

        #region 页签控制 [拖动/关闭]
        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            var index = InTabPageHead(e.Location, false);
            if (index > 0)
            {
                tabMain.SelectedIndex = index;

                if (e.Button == MouseButtons.Right) //右击，弹出菜单
                    tabMain.ContextMenuStrip = menuTabPage;
                else if (e.Button == MouseButtons.Left) //左击，进行拖动判定
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
            if (e.Button == MouseButtons.Left) //完成拖动
            {
                _tabMoving = false;
                Cursor.Current = Cursors.Default;
            }
            else if (e.Button == MouseButtons.Middle) //关闭页签
            {
                var index = InTabPageHead(e.Location, true);
                if (index <= 0) return;

                CloseHost(index);
            }
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            tabMain.ContextMenuStrip = null;  //离开选项卡后 取消菜单
        }

        private void tmiCloseHost_Click(object sender, EventArgs e)
        {
            CloseHost(tabMain.SelectedIndex);
        }

        private void CloseHost(int pageIndex)
        {
            var page = tabMain.TabPages[pageIndex];
            var host = GetHost(pageIndex);

            if (host.Connected == 1)
                host.Disconnect();
            host.Dispose();
            tabMain.TabPages.Remove(page);

            tabMain.SelectedIndex = pageIndex - (pageIndex == tabMain.TabPages.Count ? 1 : 0);
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

        private void tmiHostEdit_Click(object sender, EventArgs e)
        {
            if (_currSelectHost == null) return;

            var host = (RemoteHost)_currSelectHost.Tag;
            var hostForm = new RemoteHostForm { StyleManager = metroStyleManager, RemoteHost = host };

            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHosts();
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


        private HostGroupBox _currSelectGroup;

        private void tmiGropEdit_Click(object sender, EventArgs e)
        {
            if (_currSelectGroup == null) return;

            var host = (RemoteHost)_currSelectGroup.Tag;
            var hostForm = new RemoteHostForm { StyleManager = metroStyleManager, RemoteHost = host };

            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHosts();
        }

        private void tmiGroupDelete_Click(object sender, EventArgs e)
        {
            if (_currSelectGroup == null) return;

            var host = (RemoteHost)_currSelectGroup.Tag;
            Db.Connection.Execute("DELETE FROM RemoteHost WHERE ParentId=" + host.Id);
            Db.Connection.Execute("DELETE FROM RemoteHost WHERE Id=" + host.Id);

            _currSelectGroup.Parent = null;
            _currSelectGroup = null;
        }
        #endregion

        #region 界面切换与唤醒 [切换映射键盘]
        private int _keyboardHookModeChanged;
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (_keyboardHookModeChanged == 1) return;
            _keyboardHookModeChanged = 1;
            if (tabMain.SelectedIndex <= 0) return;

            var host = GetHost(tabMain.SelectedIndex);
            if (host.RemoteProgram2.RemoteProgramMode) return;

            host.SecuredSettings3.KeyboardHookMode = 1; //在远程服务器上应用组合键。
        }
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (_keyboardHookModeChanged == 2) return;
            _keyboardHookModeChanged = 2;
            if (tabMain.SelectedIndex <= 0) return;

            var host = GetHost(tabMain.SelectedIndex);
            if (host.RemoteProgram2.RemoteProgramMode) return;

            host.SecuredSettings3.KeyboardHookMode = 2; //仅当客户端以全屏模式运行时才将组合键应用于远程服务器。这是默认值。
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            for (var count = tabMain.TabPages.Count; count > 1;)
            {
                CloseHost(--count);
            }
        }


        #endregion

    }
}

