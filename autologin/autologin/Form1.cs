using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace autologin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string UserName = textBox1.Text;
            string UserPass = textBox2.Text;
            string url = Application.StartupPath;

            if (checkBox1.Checked == true)
            {
                if (!File.Exists(url + "\\UserProfile.xml"))
                {

                    MessageBox.Show(url);
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                    doc.AppendChild(dec);
                    //创建一个根节点（一级）
                    //创建节点（二级）
                    XmlNode node = doc.CreateElement("UserProfile");
                    //创建节点（三级）
                    XmlElement element1 = doc.CreateElement("UserName");
                    element1.InnerText = UserName;
                    node.AppendChild(element1);

                    XmlElement element2 = doc.CreateElement("UserPass");
                    element2.InnerText = UserPass;
                    node.AppendChild(element2);
                    doc.AppendChild(node);

                    doc.Save(url + "\\UserProfile.xml");
                }

                if (File.Exists(url + "\\UserProfile.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(url + "\\UserProfile.xml");
                    XmlNode xmlNode = doc.SelectSingleNode("UserProfile/UserName");//得到根节点
                    XmlNode xmlNode2 = doc.SelectSingleNode("UserProfile/UserPass");//得到根节点
                    xmlNode.InnerText = UserName;
                    xmlNode2.InnerText = UserPass;
                    doc.Save(url + "\\UserProfile.xml");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = Application.StartupPath + "\\UserProfile.xml";
            if (File.Exists(url))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                XmlNode xmlNode = doc.SelectSingleNode("UserProfile/UserName");//得到根节点
                XmlNode xmlNode2 = doc.SelectSingleNode("UserProfile/UserPass");//得到根节点
                if (!string.IsNullOrEmpty(xmlNode.InnerText) && !string.IsNullOrEmpty(xmlNode2.InnerText))
                {
                    textBox1.Text = xmlNode.InnerText;
                    textBox2.Text = xmlNode2.InnerText;
                    this.checkBox1.Checked = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
