using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using _3d.Function;

namespace _3d.Others
{
    public partial class AboutSoft : Form
    {
        public AboutSoft()
        {
            InitializeComponent();
        }

        Thread loadUpadateHistoryT;

        Thread loadVersionT;

        private void AboutSoft_Load(object sender, EventArgs e)
        {
            loadUpadateHistoryT = new Thread(new ThreadStart(loadUpadateHistory));
            loadUpadateHistoryT.Start();

            loadVersionT = new Thread(new ThreadStart(loadVersion));
            loadVersionT.Start();
        }

        private void loadUpadateHistory()
        {
            string url = "" + Global.soft_server_url + "\\version.txt?t=" + DateTime.Now.Ticks;//用随机数防止IE缓存
            this.webBrowser1.Navigate(new System.Uri(url, System.UriKind.Absolute));
        }

        private void loadVersion()
        {
            ServerVersion sv = new ServerVersion();
            string localVersion = Global.version;
            string serverVersion = sv.GetServerVersion();

            int verCha = Convert.ToInt32(serverVersion.Replace(".", "")) - Convert.ToInt32(localVersion.Replace(".", ""));

            if (verCha > 0)
            {
                setLabel1Text("当前软件版本为 " + localVersion + " 版，软件有更新");
                SetLinkLabel();
            }
            else
            {
                setLabel1Text("当前软件版本为 " + localVersion + " 版，软件暂时无更新。");
            }
            setLabel2Text("恩泽天下辅助运算软件一直以来秉承服务用户的原则，积极为公益事业尽心尽力。");
        }

        private delegate void AddLinkLabelDelegate();

        private void SetLinkLabel()
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new AddLinkLabelDelegate(AddLinkLabel));
            }
        }

        private void AddLinkLabel()
        {
            LinkLabel ll = new LinkLabel();
            ll.Name = "href";
            ll.Text = "点此更新软件";
            ll.Location = new System.Drawing.Point(this.label1.Location.X + this.label1.Width + 2, this.label1.Location.Y);
            ll.LinkBehavior = LinkBehavior.HoverUnderline;
            ll.Click += new System.EventHandler(this.UpdateSoft);
            this.Controls.Add(ll);
        }

        private delegate void WriteLabelText(string args);

        private void setLabel1Text(string args) {
            if (this.IsHandleCreated)
            {
                this.label1.Invoke(new WriteLabelText(writeLabel1Text),args);
            }
        }

        private void writeLabel1Text(string args)
        {
            this.label1.Text = args;
        }

        private void setLabel2Text(string args)
        {
            if (this.IsHandleCreated)
            {
                this.label2.Invoke(new WriteLabelText(writeLabel2Text), args);
            }
        }

        private void writeLabel2Text(string args)
        {
            this.label2.Text = args;
        }

        private void UpdateSoft(object sender, EventArgs e)
        {
            Process MyProcess = new Process();
            MyProcess.StartInfo.FileName = System.Environment.CurrentDirectory + "\\AutoUpdate.exe";
            MyProcess.StartInfo.Verb = "Open";
            MyProcess.StartInfo.CreateNoWindow = true;
            MyProcess.Start();
            this.Close();
        }

    }
}
