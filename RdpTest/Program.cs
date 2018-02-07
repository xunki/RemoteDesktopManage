using System;
using System.Windows.Forms;

namespace RdpTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 检查是否已启动
            

            #endregion

            Application.Run(new MainForm());
        }
    }
}
