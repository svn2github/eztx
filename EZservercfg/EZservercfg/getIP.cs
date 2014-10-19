using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace EZservercfg
{
    public class getIP
    {
        public static string GetIP()
        {
            Uri uri = new Uri("http://www.ikaka.com/ip/index.asp");
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = 0;
            req.CookieContainer = new System.Net.CookieContainer();
            req.GetRequestStream().Write(new byte[0], 0, 0);
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)(req.GetResponse());
            StreamReader rs = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("GB18030"));
            string s = rs.ReadToEnd();
            rs.Close();
            req.Abort();
            res.Close();
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(s, @"IP：\[(?<IP>[0-9\.]*)\]");
            if (m.Success) return m.Groups["IP"].Value;
            return string.Empty;
        }

        //获得本地IP
        public static string GetLocalIp()
        {
            System.Net.NetworkInformation.TcpConnectionInformation connection = Array.FindAll(
    System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections(),
    o => !System.Net.IPAddress.IsLoopback(o.LocalEndPoint.Address)
).FirstOrDefault();
            string ip = "";
            if (connection != null)
            {
                ip = connection.LocalEndPoint.Address.ToString();
            }
            return ip;

            //第二种
            //string hostName = System.Net.Dns.GetHostName();
            //System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName);
            ////Dns.GetHostByName(hostName);          
            ////ip地址列表
            //System.Net.IPAddress[] addr = ipEntry.AddressList;
            //string IPAddress = addr[0].ToString();
            //return IPAddress;
        }

        public static string GetWebIP()
        {
            //http://city.ip138.com/city1.asp 是获得带城市数据的
            //http://city.ip138.com/city0.asp 是纯IP地址
            //http://iframe.ip138.com/ipcity.asp 新的带城市数据
            //http://www.ip138.com/ips1388.asp
            //http://iframe.ip138.com/ic.asp   new
            string strUrl = "http://ip.qq.com/"; //获得IP的网址了
            Uri uri = new Uri(strUrl);
            WebRequest wr = WebRequest.Create(uri);
            Stream s = wr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string all = sr.ReadLine(); //读取网站的数据
            string ip = "暂无";

            ////以下是截取IP段
            //int i = all.IndexOf("[") + 1;
            //ip = all.Substring(i, all.IndexOf("]") - i).Replace(" ", "");
            ////string ip = tempip.Replace("]", "").Replace(" ", "");

            string bbc = "";
            while (all != null)
            {
                all = sr.ReadLine();
                if (all.IndexOf("您当前的IP为") >= 0)
                {
                    bbc = all;
                    break;
                }
            }
            int i = bbc.IndexOf("<span class") + 18;
            int j = bbc.IndexOf("</span></p>");
            if (i >= 0 && j >= 0)
            {
                string tempcity = (all.Substring(i, j - i));
                ip = tempcity;
            }
            return ip;
        }

        public static string GetWebCity()
        {
            //http://city.ip138.com/city1.asp 是获得带城市数据的
            //http://city.ip138.com/city0.asp 是纯IP地址
            //http://iframe.ip138.com/ipcity.asp 新的带城市数据
            //http://www.ip138.com/ips1388.asp
            //http://iframe.ip138.com/ic.asp
            string strUrl = "http://ip.qq.com/"; //获得城市的网址了
            Uri uri = new Uri(strUrl);
            WebRequest wr = WebRequest.Create(uri);
            Stream s = wr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string all = sr.ReadLine(); //读取网站的数据

            string ip = "暂无";

            //int i = all.LastIndexOf("来自：") + 3;
            //int j = all.IndexOf("</center>");
            //string tempcity = (all.Substring(i, j - i)).Replace(" ", "");
            //ip = tempcity;
            ////以下是截取城市段
            //if (ip == null)
            //    ip = "";
            //return ip;

            string bbc = "";
            while (all != null)
            {
                all = sr.ReadLine();
                if (all.IndexOf("该IP所在地为") >= 0)
                {
                    bbc = all;
                    break;
                }
            }
            int i = bbc.IndexOf("<span>") + 6;
            int j = bbc.IndexOf("</span></p>");
            if (i >= 0 && j >= 0)
            {
                string tempcity = (all.Substring(i, j - i)).Replace("&nbsp;", "");
                ip = tempcity;
            }
            return ip;
        }
    }
}
