using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AxMSTSCLib;
using Dapper;
using Wisder.W3Common.WMetroControl;
using Wisder.W3Common.WMetroControl.Controls;
using Wisder.W3Common.WMetroControl.Forms;

namespace 远程桌面管理器
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //创建存储文件
            CreateDb();
            //设置界面主题
            this.StyleManager = metroStyleManager;
            short styleId;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                var value = conn.Query<string>("SELECT FValue FROM MyConfig WHERE FKey='Style'").FirstOrDefault();
                styleId = Convert.ToInt16(value);
            }
            this.StyleManager.Style = (MetroColorStyle)styleId;
            btnSetStyle.Text = string.Format("切换主题[{0}/15]", styleId < 2 ? styleId : styleId - 1);
            //异步加载远程桌面配置
            this.BeginInvoke(new Action(LoadHostConfig));
        }

        private void CreateDb()
        {
            var path = Environment.CurrentDirectory + @"\config.wdb";
            if (!File.Exists(path))
            {
                using (var fs = File.Create(path))
                {
                    fs.Write(db.config, 0, db.config.Count());
                }
            }
        }
        /// <summary>
        /// 加载远程桌面配置
        /// </summary>
        private void LoadHostConfig()
        {
            SetWait(true);
            panelBody.Controls.Clear(); //清空原有

            #region 1.0 获取数据
            RemoteHost[] hosts;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                const string sqlCmd = @"SELECT a.FId,a.FName,a.FConectId,a.FParentId,a.FSort,b.FId,b.FIpAddress,b.FIpPort,b.FLoginUser,b.FPassword,b.FFullUrl
                                    FROM RemoteHost a 
                                    LEFT JOIN ConnectLib b ON a.FConectId=b.FId 
                                    ORDER BY a.FSort ASC,a.FId DESC";
                hosts = conn.Query<RemoteHost, IpAddress, RemoteHost>(sqlCmd, (host, ip) =>
                   {
                       host.IpAddress = ip;
                       return host;
                   }, null, null, false, "FId", null, null).ToArray();
            }
            #endregion

            #region 2.0 加载配置信息
            var group = hosts.Where(x => x.FParentId == 0).OrderByDescending(x => x.FSort).ToArray();
            foreach (var hostGroup in group)
            {
                //建立分组
                var hostBox = new WHostGroupBox { Dock = DockStyle.Top, Height = 100, Text = hostGroup.FName };
                panelBody.Controls.Add(hostBox); //分组Box
                //填充分组内容
                foreach (var host in hosts.Where(x => x.FParentId == hostGroup.FId).OrderBy(x => x.FSort))
                {
                    var ipInfo = host.IpAddress; //IP地址信息
                    if (ipInfo == null) continue;

                    var title = new MetroTile
                    {
                        Name = "title",
                        ActiveControl = null,
                        Height = 60,
                        Text = string.Format("{0}\r\n  {1}", host.FName, ipInfo.FFullUrl),
                        UseSelectable = true,
                        UseVisualStyleBackColor = true,
                        Tag = host,
                        AutoSize = true,
                        ContextMenuStrip = menuTitle,
                        StyleManager = metroStyleManager
                    };
                    title.Click += ConnectRemoteHost;
                    title.MouseDown += menuTitle_Show;
                    hostBox.AddControl(title);
                }
            }
            #endregion

            SetWait(false);
        }

        /// <summary>
        /// 连接远程服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ConnectRemoteHost(object sender, EventArgs e)
        {
            var host = (RemoteHost)((MetroTile)sender).Tag;
            var ipInfo = host.IpAddress;
            var port = ipInfo.Port;//实时计算属性，缓存

            #region 1.0 创建页签
            var page = new TabPage(string.Format("{0}[{1}]", host.FName, ipInfo.FFullUrl));
            tabControl.TabPages.Add(page);
            page.ContextMenuStrip = menuTabPage;
            tabControl.SelectedTab = page;
            #endregion

            #region 2.0 创建远程桌面客户端
            var rdpClient = new AxMsRdpClient
            {
                Dock = DockStyle.None,
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            page.Controls.Add(rdpClient);

            rdpClient.Server = ipInfo.FIpAddress;
            rdpClient.UserName = ipInfo.FLoginUser;

            if (port > 0) rdpClient.AdvancedSettings2.RDPPort = port;
            rdpClient.AdvancedSettings2.ClearTextPassword = ipInfo.FPassword;
            //偏好设置
            rdpClient.ColorDepth = 16;
            rdpClient.ConnectingText = string.Format("正在连接[{0}]，请稍等... {1}",
                host.FName, ipInfo.FFullUrl);
            #endregion

            //连接远程桌面
            rdpClient.Connect();
        }

        #region 页签控制
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 1, count = tabControl.TabPages.Count; i < count; i++) //排除首页
                {
                    var tp = tabControl.TabPages[i];
                    if (tabControl.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabControl.SelectedTab = tp;
                        tabControl.ContextMenuStrip = menuTabPage;  //弹出菜单
                        break;
                    }
                }
            }
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            tabControl.ContextMenuStrip = null;  //离开选项卡后 取消菜单
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var next = tabControl.SelectedIndex - 1;
            tabControl.SelectedTab.Dispose();
            tabControl.SelectedIndex = next;
        }

        private void 全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var page = tabControl.SelectedTab;
            foreach (var control in page.Controls)
            {
                var rdpClient = control as AxMsRdpClient;
                if (rdpClient != null)
                {
                    rdpClient.FullScreen = true;
                }
            }
        }

        private void 独立窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var page = tabControl.SelectedTab;
            var form = new Form { Text = page.Text };
            foreach (Control control in page.Controls)
            {
                form.Controls.Add(control);
            }
            page.Dispose();
            form.Show();
        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex > 0)
            {
                var point = (MouseEventArgs)e;
                for (int i = 1, count = tabControl.TabPages.Count; i < count; i++) //排除首页
                {
                    var page = tabControl.TabPages[i];
                    if (tabControl.GetTabRect(i).Contains(new Point(point.X, point.Y)))
                    {
                        foreach (var control in page.Controls)
                        {
                            var rdpClient = control as AxMsRdpClient;
                            if (rdpClient != null)
                                rdpClient.FullScreen = true;
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        private void btnSetStyle_Click(object sender, EventArgs e)
        {
            var nextStyle = Convert.ToInt32(StyleManager.Style);
            do
            {
                nextStyle = nextStyle == 16 ? 1 : nextStyle + 1;
            } while (nextStyle == 2);//忽略白色
            btnSetStyle.Text = string.Format("切换主题[{0}/15]", nextStyle < 2 ? nextStyle : nextStyle - 1);
            StyleManager.Style = (MetroColorStyle)nextStyle;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                conn.Execute("UPDATE MyConfig SET FValue=@styleId WHERE FKey='Style'", new { styleId = nextStyle });
            }
        }

        private void btnAddIpAddress_Click(object sender, EventArgs e)
        {
            var ipForm = new IpAddressForm { StyleManager = metroStyleManager };
            if (ipForm.ShowDialog() == DialogResult.OK)
                LoadHostConfig();
        }

        private void btnAddRemoteHost_Click(object sender, EventArgs e)
        {
            var hostForm = new RemoteForm { StyleManager = metroStyleManager };
            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHostConfig();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHostConfig();
        }

        #region MetroTitle控制
        private MetroTile _currSelectTitle = null;//当前选择的MetroTitle
        void menuTitle_Show(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var title = (MetroTile)sender;
                _currSelectTitle = title;
            }
        }
        private void 确认无误删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currSelectTitle == null) return;

            var host = (RemoteHost)_currSelectTitle.Tag;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                conn.Execute("DELETE FROM RemoteHost WHERE FId=@id", new { id = host.FId });
            }
            _currSelectTitle.Parent.Controls.Remove(_currSelectTitle);
            _currSelectTitle = null;
        }
        private void 连同父级一起删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currSelectTitle == null) return;

            var host = (RemoteHost)_currSelectTitle.Tag;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                conn.Execute("DELETE FROM RemoteHost WHERE FId=@id", new { id = host.FParentId });
                conn.Execute("DELETE FROM RemoteHost WHERE FParentId=@id", new { id = host.FParentId });
                tran.Commit();
            }
            var parent = _currSelectTitle.Parent.Parent;
            parent.Parent.Controls.Remove(parent);
            _currSelectTitle = null;
        }
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currSelectTitle == null) return;

            var host = (RemoteHost)_currSelectTitle.Tag;
            var hostForm = new RemoteForm { StyleManager = metroStyleManager, RemoteHost = host };

            if (hostForm.ShowDialog() == DialogResult.OK)
                LoadHostConfig();
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                //清理无效远程主机
                conn.Execute(
                    "DELETE FROM RemoteHost WHERE FParentId>0 AND FConectId NOT IN (SELECT FId FROM ConnectLib)");
                //清理无效父级节点
                conn.Execute(
                    "DELETE FROM RemoteHost WHERE FParentId=0 AND FId NOT IN (SELECT FParentId FROM RemoteHost)");
            }
            LoadHostConfig();
        }
    }
}
