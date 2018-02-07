
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace MetroFramework.Native
{
    [SuppressUnmanagedCodeSecurity]
    internal class SubClass : NativeWindow
    {
        public delegate int SubClassWndProcEventHandler(ref System.Windows.Forms.Message m);
        public event SubClassWndProcEventHandler SubClassedWndProc;
        private bool IsSubClassed = false;

        public SubClass(IntPtr Handle, bool _SubClass)
        {
            base.AssignHandle(Handle);
            this.IsSubClassed = _SubClass;
        }

        public bool SubClassed
        {
            get { return this.IsSubClassed; }
            set { this.IsSubClassed = value; }
        }

        protected override void WndProc(ref Message m)
        {
            if (this.IsSubClassed)
            {
                if (OnSubClassedWndProc(ref m) != 0)
                    return;
            }
            base.WndProc(ref m);
        }

        public void CallDefaultWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        #region HiWord Message Cracker

        public int HiWord(int Number)
        {
            return ((Number >> 16) & 0xffff);
        }

        #endregion

        #region LoWord Message Cracker

        public int LoWord(int Number)
        {
            return (Number & 0xffff);
        }

        #endregion

        #region MakeLong Message Cracker

        public int MakeLong(int LoWord, int HiWord)
        {
            return (HiWord << 16) | (LoWord & 0xffff);
        }

        #endregion

        #region MakeLParam Message Cracker

        public IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }

        #endregion

        private int OnSubClassedWndProc(ref Message m)
        {
            if (SubClassedWndProc != null)
            {
                return this.SubClassedWndProc(ref m);
            }

            return 0;
        }
    }
}
