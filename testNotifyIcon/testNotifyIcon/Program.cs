using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace testNotifyIcon
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
            
            bool Running = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "ATTIC Etimesheet", out Running);

            if (!Running)
            {
                //MessageBox.Show("已经运行");
                return;
            }

            Application.Run(new Form1());//new Form1()
            mutex.ReleaseMutex();
        }
    }
}
