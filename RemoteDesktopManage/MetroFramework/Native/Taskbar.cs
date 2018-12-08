
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace MetroFramework.Native
{
    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

    internal class Taskbar
    {
        private const string ClassName = "Shell_TrayWnd";

        private Rectangle bounds = Rectangle.Empty;
        public Rectangle Bounds
        {
            get { return bounds; }
            private set { bounds = value; }
        }

        private TaskbarPosition position = TaskbarPosition.Unknown;
        public TaskbarPosition Position
        {
            get { return position; }
            private set { position = value; }
        }

        public Point Location
        {
            get
            {
                return this.Bounds.Location;
            }
        }

        public Size Size
        {
            get
            {
                return this.Bounds.Size;
            }
        }

        private bool alwaysOnTop = false;
        public bool AlwaysOnTop
        {
            get { return alwaysOnTop; }
            private set { alwaysOnTop = value; }
        }

        private bool autoHide = false;
        public bool AutoHide
        {
            get { return autoHide; }
            private set { autoHide = value; }
        }

        [SecuritySafeCritical]
        public Taskbar()
        {
            IntPtr taskbarHandle = WinApi.FindWindow(Taskbar.ClassName, null);

            WinApi.APPBARDATA data = new WinApi.APPBARDATA();
            data.cbSize = (uint)Marshal.SizeOf(typeof(WinApi.APPBARDATA));
            data.hWnd = taskbarHandle;
            IntPtr result = WinApi.SHAppBarMessage(WinApi.ABM.GetTaskbarPos, ref data);
            if (result == IntPtr.Zero)
                throw new InvalidOperationException();

            this.Position = (TaskbarPosition)data.uEdge;
            this.Bounds = Rectangle.FromLTRB(data.rc.Left, data.rc.Top, data.rc.Right, data.rc.Bottom);

            data.cbSize = (uint)Marshal.SizeOf(typeof(WinApi.APPBARDATA));
            result = WinApi.SHAppBarMessage(WinApi.ABM.GetState, ref data);
            int state = result.ToInt32();
            this.AlwaysOnTop = (state & WinApi.AlwaysOnTop) == WinApi.AlwaysOnTop;
            this.AutoHide = (state & WinApi.Autohide) == WinApi.Autohide;
        }

    }
}
