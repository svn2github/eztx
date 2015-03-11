using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;

namespace _3d.Function
{
    /// <summary>
    /// 用于链接远程服务器,并获取信息
    /// </summary>
    public class WebConnect
    {

        public string sendStringMessage(string url, string value)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
            return this.PostConnect(url, data, "POST");
        }

        public string sendStringMessage(string url)
        {
            return this.PostConnect(url, new byte[0], "GET");
        }

        private string PostConnect(string url, byte[] data, string method)
        {
            byte[] d = this.SendPostConnect(url, data, method);
            string s = System.Text.Encoding.UTF8.GetString(d);

            return s;
        }

        private byte[] SendPostConnect(string url, byte[] data, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;

            if (method.Equals("POST"))
            {
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();

                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            // Get response
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return null;
            }

            byte[] b = new byte[1024000];

            Stream st = response.GetResponseStream();

            MemoryStream ms = new MemoryStream();

            int i = st.Read(b, 0, b.Length);

            while (i > 0)
            {
                ms.Write(b, 0, i);

                i = st.Read(b, 0, b.Length);
            }

            st.Flush();
            byte[] d = ms.ToArray();

            return d;
        }

        /// <summary>
        /// 获取在线XML文档
        /// </summary>
        /// <param name="url">传入在线XML地址，如：www.baidu.com/abc.xml</param>
        /// <returns></returns>
        public string getOnlineXML(string url) {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
            string pageHtml = Encoding.Default.GetString(pageData);
            return pageHtml;
        }
    }
}