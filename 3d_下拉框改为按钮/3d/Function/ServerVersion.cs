using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Xml;

namespace _3d.Function
{
    /// <summary>
    /// 用于链接远程服务器,并获取信息
    /// </summary>
    public class ServerVersion
    {
        public string GetServerVersion() {

            WebConnect wc = new WebConnect();
            string pageXML = wc.getOnlineXML(Global.soft_server_url + "\\UpdateList.xml");
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(pageXML);
            XmlNode xn2 = doc2.SelectSingleNode("//Files/File");
            return xn2.Attributes["Ver"].InnerText;
        }
    }
}