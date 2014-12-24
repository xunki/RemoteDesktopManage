using System;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Dapper;
using Wisder.W3Common.WMetroControl.Forms;
using Wisder.W3Common.WMetroControl.MessageBox;

namespace 远程桌面管理器
{
    public partial class IpAddressForm : MetroForm
    {
        public IpAddressForm()
        {
            InitializeComponent();
        }

        private long _modifyId = 0;

        private void IpAddressForm_Load(object sender, System.EventArgs e)
        {
            panelAdd.Left = Left1;
            panelAdd.BringToFront();
            //取消显示上下按钮
            numPort.Controls.RemoveAt(0);

            grid.StyleManager = this.StyleManager;

            LoadIpInfo();
        }
        /// <summary>
        /// 加载地址库信息
        /// </summary>
        private void LoadIpInfo()
        {
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                grid.DataSource = conn.GetDataTable("SELECT FId,FFullUrl IP信息 FROM ConnectLib");
            }
            grid.Columns["FId"].Visible = false;
            grid.Columns["IP信息"].Width = grid.Width;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (InfoIsError) return;

            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                if (_modifyId > 0)
                {
                    conn.Execute("UPDATE ConnectLib SET FIpAddress=@ipAddress,FIpPort=@port,FLoginUser=@user,FPassword=@pwd,FFullUrl=@fullUrl WHERE FId=@id",
                        new { ipAddress = txtIp.Text, port = numPort.Text, user = txtUser.Text, pwd = txtPwd.Text, id = _modifyId, 
                            fullUrl = txtIp.Text + (numPort.Value > 0 ? (":" + numPort.Text) : "") });
                }
                else
                {
                    conn.Execute(
                        @"INSERT INTO ConnectLib('FIpAddress','FIpPort','FLoginUser','FPassword','FFullUrl') VALUES (@ipAddress,@port,@user,@pwd,@fullUrl)",
                        new { ipAddress = txtIp.Text, port = numPort.Text, user = txtUser.Text, pwd = txtPwd.Text,
                              fullUrl = txtIp.Text + (numPort.Value > 0 ? (":" + numPort.Text) : "")
                        });
                }
            }
            DialogResult = DialogResult.OK;
        }

        private bool InfoIsError
        {
            get
            {
                if (txtIp.Text.Trim().Length <= 0)
                {
                    MetroMessageBox.Show(this, "请填写IP地址！");
                    txtIp.Focus();
                    txtIp.SelectAll();
                    return true;
                }
                if (txtUser.Text.Trim().Length <= 0)
                {
                    MetroMessageBox.Show(this, "请填写登录用户！");
                    txtUser.Focus();
                    txtUser.SelectAll();
                    return true;
                }
                if (txtPwd.Text.Trim().Length <= 0)
                {
                    MetroMessageBox.Show(this, "请填写登录密码！");
                    txtPwd.Focus();
                    txtPwd.SelectAll();
                    return true;
                }
                return false;
            }
        }

        #region 界面切换特效
        private void btnShowAdd_Click(object sender, EventArgs e)
        {
            ShowAdd();
        }

        private void btnShowManage_Click(object sender, EventArgs e)
        {
            ShowManage();
        }

        private const int Left1 = -308;
        private const int Left2 = 23;
        private void ShowAdd()
        {
            this.BeginInvoke(new Action(() =>
            {
                while (true)
                {
                    if (panelAdd.Left < Left2)
                        panelAdd.Left += 4;
                    else
                    {
                        panelAdd.Left = Left2;
                        break;
                    }
                }
            }));
            txtIp.Select();
        }
        private void ShowManage()
        {
            this.BeginInvoke(new Action(() =>
            {
                while (true)
                {
                    if (panelAdd.Left > Left1)
                        panelAdd.Left -= 4;
                    else
                    {
                        panelAdd.Left = Left1;
                        break;
                    }
                }
            }));
        }
        #endregion

        #region 右键地址库
        private void 确认无误删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    conn.Execute("DELETE FROM ConnectLib WHERE FId=@id", new { id = row.Cells["FId"].Value });
                    grid.Rows.Remove(row);
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                var id = grid.SelectedRows[0].Cells["FId"].Value;
                LoadIpInfoById(id);
            }
        }

        private void LoadIpInfoById(object id)
        {
            _modifyId = Convert.ToInt64(id);
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                var ipInfo = conn.Query<IpAddress>("SELECT * FROM ConnectLib WHERE FId=@id", new { id = _modifyId }).FirstOrDefault();
                if (ipInfo == null)
                {
                    LoadIpInfo();
                    return;
                }
                txtIp.Text = ipInfo.FIpAddress;
                numPort.Text = ipInfo.FIpPort;
                txtUser.Text = ipInfo.FLoginUser;
                txtPwd.Text = ipInfo.FPassword;
            }
            ShowAdd();
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIpInfo();
        }

        #region 回车切换
        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numPort.Focus();
                numPort.Select(0, numPort.Text.Length);
            }
        }

        private void numPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUser.Focus();
                txtUser.SelectAll();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
                txtPwd.SelectAll();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Select();
            }
        }

        #endregion
    }
}
