using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wisder.W3Common.WMetroControl.Drawing.Html;

namespace 远程桌面管理器
{
    public partial class WHostGroupBox : UserControl
    {
        public WHostGroupBox()
        {
            InitializeComponent();
        }

        private string _text = "";
        [Description("标题信息")]
        public new string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                lbText.Text = string.Format("<b><font face=\"微软雅黑\" size=\"18\">{0}</font></b>", _text);
            }
        }

        public void AddControl(Control control)
        {
            Body.Controls.Add(control);
        }
    }
}
