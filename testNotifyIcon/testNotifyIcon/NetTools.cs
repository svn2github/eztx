using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;

namespace testNotifyIcon
{
    public class NetTools
    {
        private string hostMAC = "";
        //private string hostMAC = "F0-DE-F1-9B-0E-E9";

        public string HostMAC
        {
            get
            {
                if (string.IsNullOrEmpty(hostMAC))
                {
                    hostMAC = this.getHostMAC();
                }
                return hostMAC;
            }
            set { hostMAC = value; }
        }
        private Stream getRequestStream(HttpWebRequest req)
        {
            try
            {
                Stream reqStream = req.GetRequestStream();
                return reqStream;
            }
            catch
            {
                return null;
            }
        }
        public bool getUserStatus()
        {

            string param = "a=login&b=" + HostMAC;
            byte[] bs = Encoding.ASCII.GetBytes(param);

            HttpWebRequest req = null;
            Stream reqStream = null;

            while (reqStream == null)
            {

                req = (HttpWebRequest)HttpWebRequest.Create("http://timesheet.attic-architect.com/login.php");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;

                reqStream = getRequestStream(req);
            }

            reqStream.Write(bs, 0, bs.Length);
            /*
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                
            }
            catch {
                return false;
            }
            */
            using (HttpWebResponse wr = (HttpWebResponse)req.GetResponse())
            {
                StreamReader reader = new StreamReader(wr.GetResponseStream());
                Stream resp = wr.GetResponseStream();

                string _s = reader.ReadToEnd();

                if (int.Parse(_s) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private string getHostMAC()
        {
            //可以通过比较 NetworkInterface 的 NetworkInterfaceType 筛选不需要的内容
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in nis)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && ni.OperationalStatus == OperationalStatus.Up)
                {
                    PhysicalAddress pa = ni.GetPhysicalAddress();
                    string _m = pa.ToString();

                    _m = _m.Insert(2, "-");
                    _m = _m.Insert(5, "-");
                    _m = _m.Insert(8, "-");
                    _m = _m.Insert(11, "-");
                    _m = _m.Insert(14, "-");
                    return _m.ToUpper();
                }

            }
            return "00-00-00-00-00-00";
        }
    }
}
