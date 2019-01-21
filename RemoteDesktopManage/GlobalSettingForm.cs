using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json;
using RdpTest.Model;

namespace RdpTest
{
    public partial class GlobalSettingForm : MetroForm
    {
        public GlobalSettingForm()
        {
            InitializeComponent();
        }

        private void GlobalSettingForm_Load(object sender, System.EventArgs e)
        {
            gbDisks.Select();

            txtUser.Text = GlobalConfig.Instance.User;
            txtPwd.Text = GlobalConfig.Instance.Pwd;

            chConnectSession0.StyleManager = StyleManager;
            chConnectSession0.Checked = GlobalConfig.Instance.ConnectSession0;

            chShareAllDisk.StyleManager = StyleManager;
            chShareAllDisk.CheckedChanged += (o, args) => gbDisks.Enabled = !chShareAllDisk.Checked;
            chShareAllDisk.Checked = GlobalConfig.Instance.ShareAllDisk;

            flpDisks.Controls.Clear();
            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                flpDisks.Controls.Add(new MetroCheckBox
                {
                    Text = driveInfo.Name,
                    AutoSize = true,
                    StyleManager = StyleManager,
                    Checked = GlobalConfig.Instance.ShareDiskList.Contains(driveInfo.Name)
                });
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var config = new GlobalConfig
            {
                User = txtUser.Text.Trim(),
                Pwd = txtPwd.Text.Trim(),
                ConnectSession0 = chConnectSession0.Checked,
                ShareAllDisk = chShareAllDisk.Checked,
                ShareDiskList = flpDisks.Controls.OfType<MetroCheckBox>().Where(ch => ch.Checked).Select(ch => ch.Text).ToList()
            };

            Db.Connection.Execute("UPDATE MyConfig SET FValue=@json WHERE FKey='GlobalConfig'", new { json = JsonConvert.SerializeObject(config) });
            GlobalConfig.Instance = config;

            DialogResult = DialogResult.OK;
        }

    }
}
