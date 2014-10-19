using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace EZservercfg
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(setCFG));
            t.Start();
        }

        private static void setCFG()
        {
            Console.WriteLine("正在配置服务器参数，请稍后...");
            XmlDocument xd = new XmlDocument();
            xd.Load(@"apps\web\ROOT\WEB-INF\breadthframework.xml");
            //XmlNode xmlNode = xd.SelectSingleNode("breadthframework");//得到根节点
            //XmlNodeList nodelist = xmlNode.ChildNodes;//得到根节点的所有子节点

            //修改setting中name为system的节点
            XmlNodeList xnl1 = xd.SelectNodes("breadthframework//settings[@name='system']//set");
            foreach (XmlNode xn in xnl1)
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement
                if (xe.Attributes["name"].Value.Equals("domain"))
                {
                    Console.WriteLine("原地址：" + xe.Attributes["value"].Value);
                    xe.SetAttribute("value", "http://" + getIP.GetLocalIp() + ":8100");
                    Console.WriteLine("已修改为：" + xe.Attributes["value"].Value);
                }

                if (xe.Attributes["name"].Value.Equals("imageServer"))
                {
                    Console.WriteLine("原地址：" + xe.Attributes["value"].Value);
                    xe.SetAttribute("value", "http://" + getIP.GetLocalIp());
                    Console.WriteLine("已修改为：" + xe.Attributes["value"].Value);
                }
            }

            Thread.Sleep(200);

            //修改setting中name为database的节点
            XmlNodeList xnl2 = xd.SelectNodes("breadthframework//settings[@name='database']//set");
            foreach (XmlNode xn in xnl2)
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement
                if (xe.Attributes["name"].Value.Equals("url"))
                {
                    Console.WriteLine("原地址：" + xe.Attributes["value"].Value);
                    string oldStr = xe.Attributes["value"].Value;
                    string oldRp = oldStr.Substring(oldStr.IndexOf("//") + 2, oldStr.LastIndexOf("/") - oldStr.IndexOf("//") - 2);
                    string newStr = oldStr.Replace(oldRp, getIP.GetLocalIp() + ":2222");
                    Console.WriteLine(oldStr);
                    xe.SetAttribute("value", newStr);
                    Console.WriteLine("已修改为：" + xe.Attributes["value"].Value);
                }
            }

            Thread.Sleep(200);

            //修改setting中name为vfs的节点
            XmlNodeList xnl3 = xd.SelectNodes("breadthframework//settings[@name='vfs']//set[@name='root']//parameter");
            foreach (XmlNode xn in xnl3)
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement
                if (xe.Attributes["name"].Value.Equals("path"))
                {
                    Console.WriteLine("原地址：" + xe.Attributes["value"].Value);
                    string oldStr = xe.Attributes["value"].Value;
                    string newStr = "/"+Environment.CurrentDirectory+"/apps/web/vfs/";
                    Console.WriteLine(newStr);
                    xe.SetAttribute("value", newStr.Replace("\\","/"));
                    Console.WriteLine("已修改为：" + xe.Attributes["value"].Value);
                }
            }

            xd.Save(@"apps\web\ROOT\WEB-INF\breadthframework.xml");
            Thread.Sleep(200);
            Console.WriteLine("配置完成。");
            Thread.Sleep(1000);
        }
    }
}
