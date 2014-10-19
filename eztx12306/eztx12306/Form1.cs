using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HtmlAgilityPack;
using System.Xml;

namespace eztx12306
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread t = null;
        //submitQuery
        private void load12306()
        {
            this.toolStripStatusLabel1.Text = "正在读取中...";
            this.myWebBrowser1.Navigate(new Uri("http://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init"));//dynamic.12306.cn/otsweb/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(load12306));
            t.IsBackground=true;
            t.Start();
        }

        private void myWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            t.Abort();
            this.toolStripStatusLabel1.Text = "载入完毕";
        }

        private void startQuery()
        {
            //Thread yuDing = new Thread(new ThreadStart());
            this.timer1.Interval = 6000;
            this.timer1.Enabled = true;
        }

        private void clickQuery()
        {
            //点击查询
            this.myWebBrowser1.Document.Window.Frames["main"].Document.GetElementById("submitQuery").InvokeMember("click");
        }

        /// <summary>
        /// 分析标题，并根据用户想要席别传入参值
        /// </summary>
        /// <param name="args"></param>
        private void findXibieName(string args)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            string htmld = myWebBrowser1.Document.Window.Frames["main"].Document.Body.InnerHtml;
            
            htmlDoc.LoadHtml(htmld);


            string allZuoCiXpath="//*[@id=\"gridbox\"]/table/tbody/tr[1]/td/div/table/tbody/tr/td[1]/table/tbody/tr[3]/td";
            HtmlNodeCollection allZuoCi = htmlDoc.DocumentNode.SelectNodes(allZuoCiXpath);
            List<string> zuoCiLi = new List<string>();
            for(int i=0;i<allZuoCi.Count;i++)
            {
                if (allZuoCi[i].InnerText.Trim() != "发站" && allZuoCi[i].InnerText.Trim() != "到站" && allZuoCi[i].InnerText.Trim() != "历时" && allZuoCi[i].InnerText.Trim() != "其他")
                {
                    if (allZuoCi[i].InnerText.Trim().Equals(args))
                    {
                        findXibie(i+2);
                    }

                    zuoCiLi.Add(allZuoCi[i].InnerText);
                }
            }
            this.comboBox1.DataSource = zuoCiLi;
        }

        /// <summary>
        /// 进行分析是否有用户想要席别的票
        /// </summary>
        /// <param name="args"></param>
        private void findXibie(int args)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            string htmld = myWebBrowser1.Document.Window.Frames["main"].Document.Body.InnerHtml;

            htmlDoc.LoadHtml(htmld);

            HtmlNodeCollection trs = htmlDoc.DocumentNode.SelectNodes("//table[@class=\"obj row20px\"]/tbody/tr");// //tr[@result=\"1\"]  @class or @id

            //得到车次
            HtmlNode hns = htmlDoc.DocumentNode.SelectSingleNode("//span[@id]");
            string trainId = "车次：" + hns.InnerText;
            //MessageBox.Show(trainId);
            foreach (HtmlNode tr in trs)//tr有俩节点，一个class，一个idd
            {
                if (!string.IsNullOrEmpty(tr.InnerText.Trim()))
                {
                    HtmlNode tds = tr.SelectSingleNode("td["+args+"]");
                    if (tds.InnerText.Trim().Equals("有"))
                    {
                        MessageBox.Show("有票了"+args);
                    }
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            clickQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //startQuery();
            findXibieName("无座");
        }
    }
}
