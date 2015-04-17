using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;
using System.Net;

namespace _3d
{
    public class MachineCode
    {

        ///   <summary>   
        ///   获取硬盘ID       
        ///   </summary>   
        ///   <returns> string </returns>   
        public string GetHDid()
        {
            string HDid = " ";
            using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive"))
            {
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                    mo.Dispose();
                }
            }
            return HDid.ToString();
        }

        private string RunCmd(string command)
        {
            //实例一个Process类，启动一个独立进程
            Process p = new Process();

            //Process类有一个StartInfo属性，这个是ProcessStartInfo类，包括了一些属性和方法，下面我们用到了他的几个属性：

            p.StartInfo.FileName = "cmd.exe";           //设定程序名
            p.StartInfo.Arguments = "/c " + command;    //设定程式执行参数
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
            p.StartInfo.CreateNoWindow = true;          //设置不显示窗口

            p.Start();   //启动

            //p.StandardInput.WriteLine(command);       //也可以用这种方式输入要执行的命令
            //p.StandardInput.WriteLine("exit");        //不过要记得加上Exit要不然下一行程式执行的时候会当机

            return p.StandardOutput.ReadToEnd();        //从输出流取得命令执行结果
        }


        //取机器名 
        public string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }
        //取CPU编号 
        public String GetCpuID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                String strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;
            }
            catch
            {
                return "";
            }
        }
        public enum NCBCONST
        {
            NCBNAMSZ = 16, /**//* absolute length of a net name */
            MAX_LANA = 254, /**//* lana's in range 0 to MAX_LANA inclusive */
            NCBENUM = 0x37, /**//* NCB ENUMERATE LANA NUMBERS */
            NRC_GOODRET = 0x00, /**//* good return */
            NCBRESET = 0x32, /**//* NCB RESET */
            NCBASTAT = 0x33, /**//* NCB ADAPTER STATUS */
            NUM_NAMEBUF = 30, /**//* Number of NAME's BUFFER */
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct ADAPTER_STATUS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] adapter_address;
            public byte rev_major;
            public byte reserved0;
            public byte adapter_type;
            public byte rev_minor;
            public ushort duration;
            public ushort frmr_recv;
            public ushort frmr_xmit;
            public ushort iframe_recv_err;
            public ushort xmit_aborts;
            public uint xmit_success;
            public uint recv_success;
            public ushort iframe_xmit_err;
            public ushort recv_buff_unavail;
            public ushort t1_timeouts;
            public ushort ti_timeouts;
            public uint reserved1;
            public ushort free_ncbs;
            public ushort max_cfg_ncbs;
            public ushort max_ncbs;
            public ushort xmit_buf_unavail;
            public ushort max_dgram_size;
            public ushort pending_sess;
            public ushort max_cfg_sess;
            public ushort max_sess;
            public ushort max_sess_pkt_size;
            public ushort name_count;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NAME_BUFFER
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
            public byte[] name;
            public byte name_num;
            public byte name_flags;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NCB
        {
            public byte ncb_command;
            public byte ncb_retcode;
            public byte ncb_lsn;
            public byte ncb_num;
            public IntPtr ncb_buffer;
            public ushort ncb_length;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
            public byte[] ncb_callname;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
            public byte[] ncb_name;
            public byte ncb_rto;
            public byte ncb_sto;
            public IntPtr ncb_post;
            public byte ncb_lana_num;
            public byte ncb_cmd_cplt;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] ncb_reserve;
            public IntPtr ncb_event;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LANA_ENUM
        {
            public byte length;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.MAX_LANA)]
            public byte[] lana;
        }
        [StructLayout(LayoutKind.Auto)]
        public struct ASTAT
        {
            public ADAPTER_STATUS adapt;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NUM_NAMEBUF)]
            public NAME_BUFFER[] NameBuff;
        }
        public class Win32API
        {
            [DllImport("NETAPI32.DLL")]
            public static extern char Netbios(ref NCB ncb);
        }

        //取网卡mac
        public string GetMacAddress()
        {
            try
            {
                string mac = "";
                string command = "ipconfig /all";

                Process p = new Process();

                //Process类有一个StartInfo属性，这个是ProcessStartInfo类，包括了一些属性和方法，下面我们用到了他的几个属性：

                p.StartInfo.FileName = "cmd.exe";           //设定程序名
                p.StartInfo.Arguments = "/c " + command;    //设定程式执行参数
                p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
                p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
                p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
                p.StartInfo.RedirectStandardError = true;   //重定向错误输出
                p.StartInfo.CreateNoWindow = true;          //设置不显示窗口

                p.Start();   //启动
                mac = p.StandardOutput.ReadToEnd();
                p.Close();  //关闭

                string word1 = "以太网适配器 本地连接:";
                string word2 = "Ethernet adapter 本地连接:";

                if (mac.IndexOf(word1) >= 0)
                {
                    mac = mac.Substring(mac.IndexOf(word1), mac.Length - mac.IndexOf(word1) - 1).Trim();
                    mac = mac.Substring(mac.IndexOf("物理地址"), mac.IndexOf("DHCP") - mac.IndexOf("物理地址")).Trim();
                    mac = mac.Substring(mac.Length - 17, mac.Length - (mac.Length - 17)).Trim();
                    return mac.Replace("-", "").Trim();
                }

                if (mac.IndexOf(word2) >= 0)
                {
                    mac = mac.Substring(mac.IndexOf(word2), mac.Length - mac.IndexOf(word2) - 1).Trim();
                    mac = mac.Substring(mac.IndexOf("Physical Address"), mac.IndexOf("Dhcp") - mac.IndexOf("Physical Address")).Trim();
                    mac = mac.Substring(mac.Length - 17, mac.Length - (mac.Length - 17)).Trim();
                    return mac.Replace("-", "").Trim();
                }

                mac = mac.Substring(mac.IndexOf("无线局域网适配器 无线网络连接:"), mac.Length - mac.IndexOf("无线局域网适配器 无线网络连接:") - 1).Trim();
                mac = mac.Substring(mac.IndexOf("物理地址"), mac.IndexOf("DHCP") - mac.IndexOf("物理地址")).Trim();
                mac = mac.Substring(mac.Length - 17, mac.Length - (mac.Length - 17)).Trim();

                return mac.Replace("-", "").Trim();
            }
            catch
            {
                string ip = "";
                string mac = "";
                ManagementClass mc;
                string hostInfo = Dns.GetHostName();
                //IP地址  
                //System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;这个过时  
                System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    ip = addressList[i].ToString();
                }
                //mac地址  
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        mac = mo["MacAddress"].ToString();
                    }
                }
                //输出  
                string outPutStr = "IP:{0},\n MAC地址:{1}";
                outPutStr = string.Format(outPutStr, ip, mac);

                return mac.Replace(":", "").Trim();
            }
        }
    }
}
