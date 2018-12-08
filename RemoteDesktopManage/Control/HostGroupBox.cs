using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RdpTest.Control
{
    public partial class HostGroupBox : UserControl
    {
        public HostGroupBox()
        {
            InitializeComponent();

            lbText.MouseDown += (sender, e) => GropNameMouseDown?.Invoke(this, e);
        }

        public event Action<HostGroupBox, MouseEventArgs> GropNameMouseDown;

        private string _text = "";
        [Description("标题信息")]
        public new string Text
        {
            get => _text;
            set
            {
                _text = value;
                lbText.Text = $"<b><font face=\"微软雅黑\" size=\"18\">{_text}</font></b>";
            }
        }

        public void AddControl(System.Windows.Forms.Control control)
        {
            Body.Controls.Add(control);
        }

        public new ContextMenuStrip ContextMenuStrip
        {
            get => lbText.ContextMenuStrip;
            set => lbText.ContextMenuStrip = value;
        }
    }
}
