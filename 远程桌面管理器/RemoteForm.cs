using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using Wisder.W3Common.WMetroControl.Controls;
using Wisder.W3Common.WMetroControl.Forms;
using Wisder.W3Common.WMetroControl.MessageBox;

namespace 远程桌面管理器
{
    public partial class RemoteForm : MetroForm
    {
        public RemoteForm()
        {
            InitializeComponent();
        }

        public RemoteHost RemoteHost { get; set; }

        private bool IsModify { get { return RemoteHost != null; } }

        private void RemoteForm_Load(object sender, System.EventArgs e)
        {
            //设置主题
            cbParent.StyleManager = this.StyleManager;
            cbIpAddress.StyleManager = this.StyleManager;
            chIsParent.StyleManager = this.StyleManager;
            //取消显示上下按钮
            numSort.Controls.RemoveAt(0);
            //加载下拉框信息
            LoadComboBoxInfo();
            //是否需要加载信息
            if (IsModify)
            {
                LoadRemoteHost();
            }

            txtName.Focus();
        }

        private void LoadRemoteHost()
        {
            lbStatus.Text = "[修改]";
            //chIsParent.Checked = RemoteHost.FParentId == 0;//父级暂不支持修改
            cbParent.SelectedValue = RemoteHost.FParentId;
            cbIpAddress.SelectedValue = RemoteHost.IpAddress.FId;
            txtName.Text = RemoteHost.FName;
            numSort.Value = RemoteHost.FSort;
        }

        private void LoadComboBoxInfo()
        {
            DataTable dtParent, dtIpAddress;
            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                dtParent = conn.GetDataTable("SELECT FId,FName FROM RemoteHost WHERE FParentId=0");
                dtIpAddress = conn.GetDataTable("SELECT FId,FFullUrl FROM ConnectLib");
            }
            //父级下拉框显示
            cbParent.DisplayMember = "FName";
            cbParent.ValueMember = "FId";
            cbParent.DataSource = dtParent;
            //IP地址下拉框显示
            cbIpAddress.DisplayMember = "FFullUrl";
            cbIpAddress.ValueMember = "FId";
            cbIpAddress.DataSource = dtIpAddress;
        }

        private void cbIsParent_CheckedChanged(object sender, System.EventArgs e)
        {
            cbParent.Visible = cbIpAddress.Visible = !chIsParent.Checked;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (InfoIsError()) return;

            using (var conn = new SQLiteConnection(Common.ConnectionString))
            {
                if (IsModify)
                {
                    conn.Execute("UPDATE RemoteHost SET FName=@name,FConectId=@connectId,FParentId=@parentId,FSort=@sort WHERE FId=@id",
                         new { name = txtName.Text, connectId = cbIpAddress.SelectedValue, parentId = chIsParent.Checked ? 0 : cbParent.SelectedValue, sort = numSort.Text, id = RemoteHost.FId });
                }
                else
                {
                    conn.Execute("INSERT INTO RemoteHost('FName','FConectId','FParentId','FSort') VALUES(@name,@connectId,@parentId,@sort)",
                        new { name = txtName.Text, connectId = cbIpAddress.SelectedValue, parentId = chIsParent.Checked ? 0 : cbParent.SelectedValue, sort = numSort.Text });
                }
            }
            DialogResult = DialogResult.OK;
        }

        private bool InfoIsError()
        {
            if (txtName.Text.Trim().Length <= 0)
            {
                MetroMessageBox.Show(this, "请填写远程主机名称！");
                txtName.Focus();
                txtName.SelectAll();
                return true;
            }
            if (!chIsParent.Checked)
            {
                if (cbParent.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, "请选择父级信息！");
                    return true;
                }
                if (cbIpAddress.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, "请选择IP地址信息！");
                    return true;
                }
            }
            return false;
        }
    }
}
