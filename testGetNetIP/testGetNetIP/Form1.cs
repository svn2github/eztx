using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace testGetNetIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class getIP
        {
            public string GetIP()
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
                //第一种
                string hostname = System.Net.Dns.GetHostName();
                IPHostEntry localhost = System.Net.Dns.GetHostEntry(hostname);
                IPAddress localaddr = localhost.AddressList[0];
                return localaddr.ToString();

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
                string strUrl = "http://city.ip138.com/city0.asp"; //获得IP的网址了
                Uri uri = new Uri(strUrl);
                WebRequest wr = WebRequest.Create(uri);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据
                //以下是截取IP段
                int i = all.IndexOf("[") + 1;
                string tempip = all.Substring(i, 15);
                string ip = tempip.Replace("]", "").Replace(" ", "");

                if (ip == null)
                    ip = "";
                return ip;
            }

            public static string GetWebCity()
            {
                //http://city.ip138.com/city1.asp 是获得带城市数据的
                //http://city.ip138.com/city0.asp 是纯IP地址
                string strUrl = "http://city.ip138.com/city1.asp"; //获得城市的网址了
                Uri uri = new Uri(strUrl);
                WebRequest wr = WebRequest.Create(uri);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int i = all.LastIndexOf("来自：")+3;
                int j = all.IndexOf("</center>");
                string tempcity = (all.Substring(i, j - i)).Replace(" ","");
                string ip = tempcity;
                //以下是截取城市段
                if (ip == null)
                    ip = "";
                return ip;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = getIP.GetWebCity();
        }
    }
}
