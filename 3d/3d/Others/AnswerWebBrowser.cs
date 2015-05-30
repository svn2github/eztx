using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _3d.Others
{
    public partial class AnswerWebBrowser : Form
    {
        public AnswerWebBrowser()
        {
            InitializeComponent();
        }
        Thread t;
        private void AnswerWebBrowser_Load(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(loadPage));
            t.Start();
        }

        private void loadPage()
        {
            string url = Global.soft_server_url+"/answer.html?t=" + DateTime.Now.Ticks;//用随机数防止IE缓存
            this.webBrowser1.Navigate(new System.Uri(url, System.UriKind.Absolute));
        }
    }
}
