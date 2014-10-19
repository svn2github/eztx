using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace testFonts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webLoadT();
        }

        private void webLoadT()
        {
            Thread wlt = new Thread(new ThreadStart(webLoad));
            wlt.Name = "webLoadThread";
            wlt.Start();
        }

        private void webLoad()
        {
            setLoadResult("正在载入中");
            this.webBrowser1.Navigate(new Uri("http://eztx.cn/soft/answer.html"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getDataT();
        }

        private void getDataT()
        {
            Thread gdt = new Thread(new ThreadStart(getData));
            gdt.Name = "getDataThread";
            gdt.Start();
        }

        private void getData()
        {
            //指定请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://eztx.cn/soft/answer.html");

            //得到返回
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //得到流
            Stream recStream = response.GetResponseStream();

            //指定转换为utf-8编码
            StreamReader sr = new StreamReader(recStream, UTF8Encoding.UTF8);

            //以字符串方式得到网页内容
            String content = sr.ReadToEnd();


            content = content.Substring(content.IndexOf("<body>") + 6, content.IndexOf("</body>") - content.IndexOf("<body>") - 6);

            setTextBoxResult(content);

            //XmlNodeList pList = doc.SelectNodes("/body");

            //MessageBox.Show(pList.Count.ToString());
        }

        private delegate void WriteResultLabel(string args);

        private void setLoadResult(string args)
        {
            if (this.statusStrip1.InvokeRequired)//此句在不确定是否会报跨线程异常可以使用
                this.statusStrip1.Invoke(new WriteResultLabel(WriteLoadResult), args);
        }

        private void WriteLoadResult(string args)
        {
            this.toolStripStatusLabel1.Text = args;
        }

        private void setTextBoxResult(string args)
        {
            this.statusStrip1.Invoke(new WriteResultLabel(writeTextBoxResult),args);
        }

        private void writeTextBoxResult(string args)
        {
            this.textBox1.Text = args;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)    //当前Tab页的样式   
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshFore = Brushes.Black;
            }
            else    //其余Tab页的样式   
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Blue);
                bshFore = new SolidBrush(Color.Black);
            }
            //画样式   
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Focus();
        }

        private void customTabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //获取TabControl主控件的工作区域
            Rectangle rec = customTabControl1.ClientRectangle;

            //新建一个StringFormat对象，用于对标签文字的布局设置
            StringFormat StrFormat = new StringFormat();
            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中
            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中
            //绘制标签样式

            // 标签背景填充颜色，也可以是图片
            SolidBrush bru = new SolidBrush(Color.WhiteSmoke);

            // 标签字体颜色
            SolidBrush bruFont = new SolidBrush(Color.DarkBlue);

            Font font = new System.Drawing.Font("微软雅黑", 9F);//设置标签字体样式

            //绘制主控件的背景
            //e.Graphics.DrawImage(backImage, 0, 0, tclDemo.Width, tclDemo.Height);

            for (int i = 0; i < customTabControl1.TabPages.Count; i++)
            {
                //获取标签头的工作区域
                Rectangle recChild = customTabControl1.GetTabRect(i);

                //绘制标签头背景颜色
                e.Graphics.FillRectangle(bru, recChild);

                //绘制标签头的文字
                e.Graphics.DrawString(customTabControl1.TabPages[i].Text, font, bruFont, recChild, StrFormat);

                customTabControl1.TabPages[i].BorderStyle = BorderStyle.None;
            }

        }

        
    }
}
