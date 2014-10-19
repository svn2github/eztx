using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace execute
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("execute.Resources.3d.exe");
            byte[] bs = new byte[stream.Length];
            stream.Read(bs, 0, (int)stream.Length);
            Assembly asm = Assembly.Load(bs);
            MethodInfo info = asm.EntryPoint;
            ParameterInfo[] parameters = info.GetParameters();
            if ((parameters != null) && (parameters.Length > 0))
                info.Invoke(null, (object[])args);
            else
                info.Invoke(null, null);

            ClearMemory();
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary> 
        /// 释放内存
        /// </summary> 
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
    }
}
