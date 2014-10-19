using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace eztxNews
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false; 
        }

        Thread t = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            //mydrivers_news_content("http://news.mydrivers.com/1/253/253019.htm");
            t = new Thread(new ThreadStart(loadPage));
            t.Start();

            Thread tt = new Thread(new ThreadStart(mydrivers_news_links));
            //tt.Start();
            this.textBox2.Text = "test";
        }

        private void loadPage()
        {
            this.toolStripStatusLabel1.Text = "正在载入网页中...";
            webBrowser1.Navigate(new Uri("http://eztx.cn/ma/article_add.php?channelid=1&cid=42"));
            myWebBrowser1.Navigate(new Uri("http://www.baidu.com"));//http://dynamic.12306.cn/otsweb/loginAction.do?method=init
        }

        //得到新闻列表
        private void mydrivers_news_links()
        {
            Thread.Sleep(500);
            //指定请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mydrivers.com");

            //得到返回
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //得到流
            Stream recStream = response.GetResponseStream();

            //指定转换为utf-8编码
            StreamReader sr = new StreamReader(recStream, Encoding.GetEncoding("gb2312"));

            //以字符串方式得到网页内容
            String content = sr.ReadToEnd();

            HtmlAgilityPack.HtmlDocument hdoc = new HtmlAgilityPack.HtmlDocument();
            hdoc.LoadHtml(content);

            //得到一天的//div[@id=\"newslist001\    得到三天的  //div[@class=\"l_warp\"]
            HtmlNode hn = hdoc.DocumentNode.SelectSingleNode("//div[@id=\"newslist001\"]");
            HtmlNodeCollection hnList = hn.SelectNodes("descendant::li/a");//从得到的节点中再次建立newslist节点列表   div/ul/li/a/@href

            int countNews = 0;

            foreach (HtmlNode hnNewsListSon in hnList)
            {
                string hnn = hnNewsListSon.Attributes["href"].Value;

                if (hnn.Contains("news.mydrivers.com"))
                {
                    countNews++;
                    mydrivers_news_content(hnn);
                    this.textBox1.Text = hnn;
                    this.label1.Text = "第 " + countNews + " 条 共 "+hnList.Count+" 条";
                }
            }
        }

        //每个新闻的详细信息
        private void mydrivers_news_content(string link)
        {
            Thread.Sleep(500);

            //指定请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);//link

            //得到返回
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //得到流
            Stream recStream = response.GetResponseStream();

            //指定转换为utf-8编码
            StreamReader sr = new StreamReader(recStream, Encoding.GetEncoding("gb2312"));

            //以字符串方式得到网页内容
            String content = sr.ReadToEnd();

            HtmlAgilityPack.HtmlDocument hdoc = new HtmlAgilityPack.HtmlDocument();
            hdoc.LoadHtml(content);

            HtmlNode hn = hdoc.DocumentNode.SelectSingleNode("//*[@id=\"thread_subject\"]");//  //div[@class=\"posttitle\"]/h2
            string title = hn.InnerText;

            HtmlNode hn2 = hdoc.DocumentNode.SelectSingleNode("//div[@class=\"content\"]");
            //HtmlNodeCollection hn2List = hn2.SelectNodes("p");
            string contents = "";
            //foreach (HtmlNode hcn in hn2List)
            //{
            //    contents += (hcn.InnerText + "\r\n");
            //}
            contents = hn2.InnerHtml;
            this.textBox2.Text = contents.Trim().Replace("/img/", "http://news.mydrivers.com/img/");

        }

        //首先登录网站后台
        private void loginEztx()
        {
            HtmlElement user_name = webBrowser1.Document.GetElementById("userid");//获取百度的搜索框（KW是百度搜索框的ID）
            HtmlElement user_pass = webBrowser1.Document.GetElementById("pwd");//获取百度的搜索框（KW是百度搜索框的ID）
            user_name.SetAttribute("value", "MEZboy");//这边就是给百度的文本框赋值了
            user_pass.SetAttribute("value", "mez@199023");//这边就是给百度的文本框赋值了
            HtmlElement login_btn = webBrowser1.Document.GetElementById("sm1");//获取百度的百度一下按钮(su是按钮的ID)
            login_btn.InvokeMember("click");//模拟点击按钮

            timer1.Interval = 6000;
            //timer1.Enabled = true;
        }

        //写入稿子
        private void pubEztx()
        {
            HtmlElement article_title = webBrowser1.Document.GetElementById("title");//获取百度的搜索框（KW是百度搜索框的ID）
            HtmlElement article_from = webBrowser1.Document.GetElementById("source");//获取百度的搜索框（KW是百度搜索框的ID）
            HtmlElement article_author = webBrowser1.Document.GetElementById("writer");//获取百度的搜索框（KW是百度搜索框的ID）
            article_title.SetAttribute("value", "1111111111");
            article_from.SetAttribute("value", "2222222222");
            article_author.SetAttribute("value", "3333333333");
            Clipboard.SetText(this.textBox2.Text);//将textbox2中的文字添加进剪贴板
            webBrowser1.Document.GetElementById("spsize").Focus();
            SendKeys.Send("{TAB}");
            Thread.Sleep(500);
            SendKeys.Send("^v");
            webBrowser1.Document.InvokeScript("CKEDITOR.tools.callFunction",new object[]{6,"this"});
            webBrowser1.Document.InvokeScript("javascript:void", new object[] {"源码"});
            webBrowser1.Document.InvokeScript("javascript:void('源码')");

            HtmlElementCollection hrefs = webBrowser1.Document.GetElementsByTagName("a");
            for (int i = 0; i < hrefs.Count; i++)//hrefs.Count
            {
                if (hrefs[i].GetAttribute("href") == "javascript:void('源码')")
                {
                    hrefs[i].InvokeMember("click");
                }
            }

            HtmlElement goon = webBrowser1.Document.GetElementById("cke_8");//cke_button
            goon.InvokeMember("click");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            webBrowser1.Navigate(new Uri("http://eztx.cn/ma/article_add.php?channelid=1&cid=42"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginEztx();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pubEztx();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            t.Abort();
            this.toolStripStatusLabel1.Text = "网页载入完毕，此时可以操作";
        }

    }
}
