using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
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
            Application.ThreadException += (sender, e) => { MessageBox.Show(e.Exception.ToString(), "发生异常"); };

            MainForm mainForm;
            try
            {
                //检查本程序如果有已启动的其他实例，则弹出该界面窗口
                var currProcess = Process.GetCurrentProcess();
                var process = Process.GetProcessesByName(currProcess.ProcessName);
                if (process.Length > 1)
                {
                    var hWnd = FindWindow(null, "远程桌面管理");
                    GetWindowThreadProcessId(hWnd, out var pid);

                    foreach (var p in process)
                    {
                        if (pid == p.Id) continue;

                        //先最小化再最大化，否则有时无法激活
                        ShowWindowAsync(hWnd, 6);
                        ShowWindowAsync(hWnd, 3);
                        return;
                    }
                }
                mainForm = new MainForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "启动发生异常");
                return;
            }

            //启动主界面
            Application.Run(mainForm);
        }

        ///<summary>
        /// 该函数设置由不同线程产生的窗口的显示状态
        /// </summary>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);


        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr window, out int process);

        /// <summary>
        /// 根据窗口标题查找窗体
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}