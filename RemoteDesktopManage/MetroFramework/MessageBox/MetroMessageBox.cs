using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace MetroFramework.MessageBox
{
    /// <summary>
    /// Metro风格的消息通知
    /// </summary>
    public static class MetroMessageBox
    {
        /// <summary>
        /// 显示了Metro风格的消息通知到指定的所有者窗口
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message)
        {
            return Show(owner, message, string.Empty); 
        }

        /// <summary>
        /// 显示了Metro风格的消息通知到指定的所有者窗口
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title,
            MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return Show(owner, message, title, buttons, MessageBoxIcon.None);
        }

        /// <summary>
        /// 显示了Metro风格的消息通知到指定的所有者窗口
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultbutton"></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton = MessageBoxDefaultButton.Button1)
        {
            var result = DialogResult.None;

            if (owner != null)
            {
                Form _owner = (Form)owner;

                //int _minWidth = 500;
                //int _minHeight = 350;

                //if (_owner.Size.Width < _minWidth ||
                //    _owner.Size.Height < _minHeight)
                //{
                //    if (_owner.Size.Width < _minWidth && _owner.Size.Height < _minHeight) {
                //            _owner.Size = new Size(_minWidth, _minHeight);
                //    }
                //    else
                //    {
                //        if (_owner.Size.Width < _minWidth) _owner.Size = new Size(_minWidth, _owner.Size.Height);
                //        else _owner.Size = new Size(_owner.Size.Width, _minHeight);
                //    }

                //    int x = Convert.ToInt32(Math.Ceiling((decimal)(Screen.PrimaryScreen.WorkingArea.Size.Width / 2) - (_owner.Size.Width / 2)));
                //    int y = Convert.ToInt32(Math.Ceiling((decimal)(Screen.PrimaryScreen.WorkingArea.Size.Height / 2) - (_owner.Size.Height / 2)));
                //    _owner.Location = new Point(x, y);
                //}

                switch (icon)
                {
                    case MessageBoxIcon.Error:
                        SystemSounds.Hand.Play(); break;
                    case MessageBoxIcon.Exclamation:
                        SystemSounds.Exclamation.Play(); break;
                    case MessageBoxIcon.Question:
                        SystemSounds.Beep.Play(); break;
                    default:
                        SystemSounds.Asterisk.Play(); break;
                }

                var control = new MetroMessageBoxControl();
                control.BackColor = _owner.BackColor;
                control.Properties.Buttons = buttons;
                control.Properties.DefaultButton = defaultbutton;
                control.Properties.Icon = icon;
                control.Properties.Message = message;
                control.Properties.Title = title;
                control.Padding = new Padding(0, 0, 0, 0);
                control.ControlBox = false;
                control.ShowInTaskbar = false;
                //_owner.Controls.Add(_control);
                //if (_owner is IMetroForm)
                //{
                //    //if (((MetroForm)_owner).DisplayHeader)
                //    //{
                //    //    _offset += 30;
                //    //}
                //    _control.Theme = ((MetroForm)_owner).Theme;
                //    _control.Style = ((MetroForm)_owner).Style;
                //}

                control.Size = new Size(_owner.Size.Width, control.Height);
                control.Location = new Point(_owner.Location.X, _owner.Location.Y + (_owner.Height - control.Height) / 2);
                control.ArrangeApperance();
                int _overlaySizes = Convert.ToInt32(Math.Floor(control.Size.Height * 0.28));
                //_control.OverlayPanelTop.Size = new Size(_control.Size.Width, _overlaySizes - 30);
                //_control.OverlayPanelBottom.Size = new Size(_control.Size.Width, _overlaySizes);

                control.ShowDialog();
                control.BringToFront();
                control.SetDefaultButton();

                Action<MetroMessageBoxControl> _delegate = new Action<MetroMessageBoxControl>(ModalState);
                IAsyncResult _asyncresult = _delegate.BeginInvoke(control, null, _delegate);
                bool _cancelled = false;

                try
                {
                    while (!_asyncresult.IsCompleted)
                    { Thread.Sleep(1); Application.DoEvents(); }
                }
                catch
                {
                    _cancelled = true;

                    if (!_asyncresult.IsCompleted)
                    {
                        try { _asyncresult = null; }
                        catch { }
                    }

                    _delegate = null;
                }

                if (!_cancelled)
                {
                    result = control.Result;
                    //_owner.Controls.Remove(_control);
                    control.Dispose(); control = null;
                }

            }

            return result;
        }

        private static void ModalState(MetroMessageBoxControl control)
        {
            while (control.Visible)
            { }
        }

    }
}
