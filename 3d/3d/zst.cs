using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.IO;
using HtmlAgilityPack;
using System.Collections;

namespace _3d
{
    public partial class zst : Form
    {
        public zst()
        {
            InitializeComponent();
            this.displayZSTBtn.Focus();
        }

        //生成标准html
        private string generalHTML(){
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<meta http-equiv=\"content-type\" content=\"text/html;charset=gb2312\">");
            sb.Append("<meta name=\"description\" content=\"恩泽天下\">");
            sb.Append("<meta name=\"keywords\" content=\"恩泽天下\">");
            sb.Append("<title>恩泽天下</title>");
            sb.Append("<LINK href=\"css/style.css\" type=text/css rel=stylesheet>");
            sb.Append("<script type=\"text/javascript\" src=\"test2.js\"></script>");
            sb.Append("</head>");
            sb.Append("<body></body></html>");
            return sb.ToString();
        }
        
        //生成html文件
        private void setZST_html(int selectNumber, string titleName)
        {
            string urlHTML = Application.StartupPath + "\\zst\\eztx.html";
            string urlCSS = Application.StartupPath + "\\zst\\css\\style.css";
            string urlHTMLFolder = Application.StartupPath + "\\zst";
            string urlCSSFolder = Application.StartupPath + "\\zst\\css";
            string urlJSFolder = Application.StartupPath + "\\zst\\js";
            string urlImagesFolder = Application.StartupPath + "\\zst\\images";
            //string url2 = Application.StartupPath + "\\zst\\eztx123.html";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            Directory.CreateDirectory(urlHTMLFolder);
            Directory.CreateDirectory(urlCSSFolder);
            Directory.CreateDirectory(urlJSFolder);
            Directory.CreateDirectory(urlImagesFolder);
            Tools.writeFile(urlCSS, _3d.Properties.Resources.style);
            saveImagesFromResources(urlImagesFolder);
            doc.LoadHtml(generalHTML());

            titleName = "<p style='font-size:20px;text-align:center;font-weight:bolder;'>" + titleName + "</p>";

            HtmlNode link = doc.DocumentNode.SelectSingleNode("//body");//直接从全文中取body节点

            if (this.comboBox1.SelectedIndex == 0)
            {
                link.InnerHtml = xiaoKaiDaJie(titleName);
            }

            if (this.comboBox1.SelectedIndex == 1)
            {
                link.InnerHtml = liangMaChaZST(titleName);
            }

            if (this.comboBox1.SelectedIndex == 2)
            {
                link.InnerHtml = kuaDu(titleName);
            }

            if (this.comboBox1.SelectedIndex == 3)
            {
                link.InnerHtml = heZhiWeiZST(titleName);
            }

            if (this.comboBox1.SelectedIndex == 4)
            {
                link.InnerHtml = dingWeiZouShi(titleName);
            }

            doc.Save(urlHTML);//保存
        }

        /// <summary>
        /// 把所有Resources中的image释放出来
        /// </summary>
        /// <param name="url"></param>
        private void saveImagesFromResources(string url){
            Image img = (Image)_3d.Properties.Resources.兑;
            img.Save(url+"\\兑.jpg");

            img = (Image)_3d.Properties.Resources.艮;
            img.Save(url + "\\艮.jpg");

            img = (Image)_3d.Properties.Resources.坎;
            img.Save(url + "\\坎.jpg");

            img = (Image)_3d.Properties.Resources.坤;
            img.Save(url + "\\坤.jpg");

            img = (Image)_3d.Properties.Resources.离;
            img.Save(url + "\\离.jpg");

            img = (Image)_3d.Properties.Resources.乾;
            img.Save(url + "\\乾.jpg");

            img = (Image)_3d.Properties.Resources.巽;
            img.Save(url + "\\巽.jpg");

            img = (Image)_3d.Properties.Resources.阳;
            img.Save(url + "\\阳.jpg");

            img = (Image)_3d.Properties.Resources.阴;
            img.Save(url + "\\阴.jpg");

            img = (Image)_3d.Properties.Resources.震;
            img.Save(url + "\\震.jpg");

            img = (Image)_3d.Properties.Resources._1;
            img.Save(url + "\\1.gif");

            img = (Image)_3d.Properties.Resources._2;
            img.Save(url + "\\2.gif");

            img = (Image)_3d.Properties.Resources._3;
            img.Save(url + "\\3.gif");

            img = (Image)_3d.Properties.Resources._4;
            img.Save(url + "\\4.gif");

            img = (Image)_3d.Properties.Resources._5;
            img.Save(url + "\\5.gif");

            img = (Image)_3d.Properties.Resources._6;
            img.Save(url + "\\6.gif");

            img = (Image)_3d.Properties.Resources.blueback;
            img.Save(url + "\\blueback.gif");

            img = (Image)_3d.Properties.Resources.ch_back;
            img.Save(url + "\\ch_back.gif");

            img = (Image)_3d.Properties.Resources.ch_back2;
            img.Save(url + "\\ch_back2.gif");

            img = (Image)_3d.Properties.Resources.ch_back_red;
            img.Save(url + "\\ch_back_red.gif");

            img = (Image)_3d.Properties.Resources.hzback;
            img.Save(url + "\\hzback.gif");

            img = (Image)_3d.Properties.Resources.redback;
            img.Save(url + "\\redback.gif");
        }

        #region 小号开头，大号结尾 开始
        private string xiaoKaiDaJie(string titleName)
        {
            StringBuilder sb = new StringBuilder();
            //头部 开始
            sb.Append(titleName);
            sb.Append("<table cellSpacing=1 cellPadding=0 bgColor=#d0d0d0 border=0>");
            sb.Append("<TR>	");
            sb.Append("<td width='60' class='head bold' rowspan='2'>期号</td>");
            sb.Append("<TD class='head bold' width=35 rowSpan=2>出号</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>小号开头</TD>");
            sb.Append("<TD class='head bold' width=60 colSpan=3>上中下路</TD>");
            sb.Append("<TD class='head bold' width=205 colSpan=12>大号结尾</TD>");
            sb.Append("<TD class='head bold' width=60 colSpan=3>上中下路</TD>");
            sb.Append("</TR>");
            sb.Append("<TR>	");

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "单", "双", "上", "中", "下" };
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }

            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            sb.Append("</TR>");
            //头部 结束


            sb.Append(xiaoKaiDaJie_trs());

            sb.Append("</table>");
            return sb.ToString();
        }

        //生成每行的小号开头、大号结尾
        private string xiaoKaiDaJie_trs()
        {
            StringBuilder sb = new StringBuilder();
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);

            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return sb.ToString();
            }

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//, "单", "双", "上", "中", "下"
            int[] countSmallLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//用来算小号暗格
            int[] countLargeLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//用来算大号暗格
            int[] upNumber = { 0, 1, 4, 7 };//上
            int[] middleNumber = { 2,5,8 };//中
            int[] downNumber = { 3,6,9 };//下

            //画每行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string issue=dr["issue"].ToString();
                string numGroup = dr["num_group"].ToString();

                sb.Append("<tr>");
                sb.Append("<TD class='yellow bold' width=35>" + issue + "</TD>");//期号
                sb.Append("<TD class='white enfont red' width=35>" + numGroup + "</TD>");//开奖号码

                numGroup = Tools.sort3D(numGroup);//从小到大排序
                int smallNum = Convert.ToInt16(numGroup.Substring(0, 1));
                int largeNum = Convert.ToInt16(numGroup.Substring(2, 1));

                //小号区域  开始
                for (int j = 0; j < tdText.Length; j++)//绘制小号0~9
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (smallNum==_tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countSmallLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countSmallLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (smallNum % 2 == 0)
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'><img src='images/5.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }

                //绘制上中下
                if (upNumber.Contains(smallNum))
                {
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                else if (middleNumber.Contains(smallNum))
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                else
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                }
                //小号区域  结束

                //大号区域  开始
                for (int j = 0; j < tdText.Length; j++)//绘制大号0~9
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (largeNum == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countLargeLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countLargeLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (largeNum % 2 == 0)
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'><img src='images/5.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }

                //绘制上中下
                if (upNumber.Contains(largeNum))
                {
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                else if (middleNumber.Contains(largeNum))
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                else
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/4.gif'></td>");
                }
                //大号区域  结束


                sb.Append("</tr>");
            }

            return sb.ToString();
        }
        #endregion 小号开头，大号结尾 结束

        #region 两码差 开始
        private string liangMaChaZST(string titleName)
        {
            StringBuilder sb = new StringBuilder();
            //头部 开始
            sb.Append(titleName);
            sb.Append("<table cellSpacing=1 cellPadding=0 bgColor=#d0d0d0 border=0>");
            sb.Append("<TR>	");
            sb.Append("<td width='60' class='head bold' rowspan='2'>期号</td>");
            sb.Append("<TD class='head bold' width=35 rowSpan=2>出号</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=13 align='center' height=22>两码差传递</TD>");
            sb.Append("<TD class='head bold' height=22>上</TD>");
            sb.Append("<TD class='head bold' height=22>中</TD>");
            sb.Append("<TD class='head bold' height=22>下</TD>");
            sb.Append("<td class='head bold' rowspan='2'>两码差公式<br />走0打组三<br />走1打半顺<br />走2打杂六</td>");
            sb.Append("</TR>");
            sb.Append("<TR>	");

            string[] tdText = { "两码差", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "单", "双" };
            for (int i = 0; i < tdText.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append("<TD class='head bold' width=35>" + tdText[i] + "</TD>");
                    continue;
                }
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            sb.Append("<TD class=head width=50 height=20>0147</TD>");
            sb.Append("<TD class=head width=50 height=20>258</TD>");
            sb.Append("<TD class=head width=50 height=20>369</TD>");
            //头部 结束


            sb.Append(liangMaChaZST_trs());

            sb.Append("</table>");
            return sb.ToString();
        }

        private string liangMaChaZST_trs() {
            StringBuilder sb = new StringBuilder();
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);

            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return sb.ToString();
            }

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//, "单", "双", "上", "中", "下"
            int[] countLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//用来算小号暗格

            //画每行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string issue = dr["issue"].ToString();
                string numGroup = dr["num_group"].ToString();
                int a = Convert.ToInt16(numGroup.Substring(0, 1));
                int b = Convert.ToInt16(numGroup.Substring(1, 1));
                int c = Convert.ToInt16(numGroup.Substring(2, 1));
                
                //从小到大排序两码差并拿到最小的两码差
                string liangMaCha = Tools.sort3D(Math.Abs(b - a) + "" + Math.Abs(c - b) + "" + Math.Abs(c - a) + "");
                int smallLiangMaCha = Convert.ToInt16(liangMaCha.Substring(0, 1));

                int[] upNumber = { 0, 1, 4, 7 };//上
                int[] middleNumber = { 2, 5, 8 };//中
                int[] downNumber = { 3, 6, 9 };//下

                sb.Append("<tr>");
                sb.Append("<TD class='yellow bold' width=35>" + issue + "</TD>");//期号
                sb.Append("<TD class='white enfont red' width=35>" + numGroup + "</TD>");//开奖号码
                sb.Append("<TD class='white enfont red' width=35>" + liangMaCha + "</TD>");//两码差

                for (int j = 0; j < tdText.Length; j++)//绘制小号0~9
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (smallLiangMaCha == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (smallLiangMaCha % 2 == 0)
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'><img src='images/5.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }

                //绘制上、中、下
                if (upNumber.Contains(smallLiangMaCha))
                {
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'></td>");
                }
                else if (middleNumber.Contains(smallLiangMaCha))
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                }
                sb.Append("</tr>");
            }

            return sb.ToString();
        }

        #endregion  两码差 结束

        #region 跨度 开始
        private string kuaDu(string titleName)
        {
            StringBuilder sb = new StringBuilder();
            //头部 开始
            sb.Append(titleName);
            sb.Append("<table cellSpacing=1 cellPadding=0 bgColor=#d0d0d0 border=0>");
            sb.Append("<TR>	");
            sb.Append("<td width='60' class='head bold' rowspan='2'>期号</td>");
            sb.Append("<TD class='head bold' width=35 rowSpan=2>出号</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>跨度</TD>");
            sb.Append("<TD class='head bold' height=22>上</TD>");
            sb.Append("<TD class='head bold' height=22>中</TD>");
            sb.Append("<TD class='head bold' height=22>下</TD>");
            sb.Append("<td class='head bold' rowspan='2'>跨度公式<br />单跨—135，双跨—246</td>");
            sb.Append("</TR>");
            sb.Append("<TR>	");

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "单", "双" };
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            sb.Append("<TD class=head width=50 height=20>0147</TD>");
            sb.Append("<TD class=head width=50 height=20>258</TD>");
            sb.Append("<TD class=head width=50 height=20>369</TD>");
            //头部 结束


            sb.Append(kuaDu_trs());

            sb.Append("</table>");
            return sb.ToString();
        }

        private string kuaDu_trs()
        {
            StringBuilder sb = new StringBuilder();
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);

            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return sb.ToString();
            }

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//, "单", "双", "上", "中", "下"
            int[] countLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //画每行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string issue = dr["issue"].ToString();
                string numGroup = dr["num_group"].ToString();
                
                sb.Append("<tr>");
                sb.Append("<TD class='yellow bold' width=35>" + issue + "</TD>");//期号
                sb.Append("<TD class='white enfont red' width=35>" + numGroup + "</TD>");//开奖号码
                numGroup = Tools.sort3D(numGroup);
                int a = Convert.ToInt16(numGroup.Substring(0, 1));
                int b = Convert.ToInt16(numGroup.Substring(1, 1));
                int c = Convert.ToInt16(numGroup.Substring(2, 1));
                int _kuaDu = c - a;

                int[] upNumber = { 0, 1, 4, 7 };//上
                int[] middleNumber = { 2, 5, 8 };//中
                int[] downNumber = { 3, 6, 9 };//下

                for (int j = 0; j < tdText.Length; j++)//绘制小号0~9
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (_kuaDu == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (_kuaDu % 2 == 0)
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'><img src='images/5.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }

                //绘制上、中、下
                if (upNumber.Contains(_kuaDu))
                {
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'></td>");
                }
                else if (middleNumber.Contains(_kuaDu))
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/4.gif'></td>");
                }

                sb.Append("</tr>");
            }

            return sb.ToString();
        }


        #endregion 跨度 结束

        #region 和值尾 开始

        private string heZhiWeiZST(string titleName)
        {
            StringBuilder sb = new StringBuilder();
            //头部 开始
            sb.Append(titleName);
            sb.Append("<table cellSpacing=1 cellPadding=0 bgColor=#d0d0d0 border=0>");
            sb.Append("<TR>	");
            sb.Append("<td width='60' class='head bold' rowspan='2'>期号</td>");
            sb.Append("<TD class='head bold' width=35 rowSpan=2>出号</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>和值</TD>");
            sb.Append("</TR>");
            sb.Append("<TR>	");

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "单", "双" };
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            //头部 结束

            sb.Append(heZhiWeiZST_trs());

            sb.Append("</table>");
            return sb.ToString();
        }

        private string heZhiWeiZST_trs()
        {
            StringBuilder sb = new StringBuilder();
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);

            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return sb.ToString();
            }

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//, "单", "双", "上", "中", "下"
            int[] countLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //画每行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string issue = dr["issue"].ToString();
                string numGroup = dr["num_group"].ToString();

                sb.Append("<tr>");
                sb.Append("<TD class='yellow bold' width=35>" + issue + "</TD>");//期号
                sb.Append("<TD class='white enfont red' width=35>" + numGroup + "</TD>");//开奖号码
                numGroup = Tools.sort3D(numGroup);
                int a = Convert.ToInt16(numGroup.Substring(0, 1));
                int b = Convert.ToInt16(numGroup.Substring(1, 1));
                int c = Convert.ToInt16(numGroup.Substring(2, 1));
                int _heZhiWei = a + b + c;
                if (_heZhiWei > 10)
                {
                    _heZhiWei=Convert.ToInt16((_heZhiWei + "").Substring(1, 1));//大于10取个位
                }

                for (int j = 0; j < tdText.Length; j++)//绘制小号0~9
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (_heZhiWei == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (_heZhiWei % 2 == 0)
                {
                    sb.Append("<td class='yellow'></td>");
                    sb.Append("<td class='yellow'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='yellow'><img src='images/5.gif'></td>");
                    sb.Append("<td class='yellow'></td>");
                }
                sb.Append("</tr>");
            }

            return sb.ToString();
        }

        #endregion 和值尾 结束

        #region 定位走式 开始

        private string dingWeiZouShi(string titleName)
        {
            StringBuilder sb = new StringBuilder();
            //头部 开始
            sb.Append(titleName);
            sb.Append("<table cellSpacing=1 cellPadding=0 bgColor=#d0d0d0 border=0>");
            sb.Append("<TR>	");
            sb.Append("<td width='60' class='head bold' rowspan='2'>期号</td>");
            sb.Append("<TD class='head bold' width=35 rowSpan=2>出号</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>百位</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>十位</TD>");
            sb.Append("<TD class='head bold' width=200 colSpan=12 height=22>个位</TD>");
            sb.Append("</TR>");
            sb.Append("<TR>	");

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "单", "双" };
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            for (int i = 0; i < tdText.Length; i++)
            {
                sb.Append("<TD class=head width=20 height=20>" + tdText[i] + "</TD>");
            }
            //头部 结束


            sb.Append(dingWeiZouShi_trs());

            sb.Append("</table>");
            return sb.ToString();
        }

        private string dingWeiZouShi_trs()
        {
            StringBuilder sb = new StringBuilder();
            bool isTrue = true;
            DataTable dt = LinkMyMDB.ReadAllData("numberGroup", ref isTrue);

            if (isTrue == false || dt == null || dt.Rows.Count == 0)
            {
                return sb.ToString();
            }

            string[] tdText = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//, "单", "双"
            int[] countBaiLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] countShiLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] countGeLine = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //画每行
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string issue = dr["issue"].ToString();
                string numGroup = dr["num_group"].ToString();
                int a = Convert.ToInt16(numGroup.Substring(0, 1));
                int b = Convert.ToInt16(numGroup.Substring(1, 1));
                int c = Convert.ToInt16(numGroup.Substring(2, 1));

                sb.Append("<tr>");
                sb.Append("<TD class='yellow bold' width=35>" + issue + "</TD>");//期号
                sb.Append("<TD class='white enfont red' width=35>" + numGroup + "</TD>");//开奖号码

                //绘制百位区 开始
                for (int j = 0; j < tdText.Length; j++)
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (a == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countBaiLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countBaiLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (a % 2 == 0)
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='white whiteWord'><img src='images/5.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                //绘制百位区 结束

                //绘制十位区 开始
                for (int j = 0; j < tdText.Length; j++)
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (b == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countShiLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countShiLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (b % 2 == 0)
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='white whiteWord'><img src='images/5.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                //绘制十位区 结束

                //绘制个位区 开始
                for (int j = 0; j < tdText.Length; j++)
                {
                    int _tdText = Convert.ToInt16(tdText[j]);
                    if (c == _tdText)
                    {
                        sb.Append("<TD class='yellow ch_background_white' height=26>" + _tdText + "</TD>");
                        countGeLine[j] = 1;//如果有号了，那么从1开始重新计数
                    }
                    else
                    {
                        sb.Append("<TD class='yellow whiteWord' height=26>" + (countGeLine[j]++) + "</TD>");
                    }
                }

                //绘制单、双两格
                if (c % 2 == 0)
                {
                    sb.Append("<td class='white whiteWord'></td>");
                    sb.Append("<td class='white whiteWord'><img src='images/2.gif'></td>");
                }
                else
                {
                    sb.Append("<td class='white whiteWord'><img src='images/5.gif'></td>");
                    sb.Append("<td class='white whiteWord'></td>");
                }
                //绘制个位区 结束

                sb.Append("</tr>");
            }

            return sb.ToString();
        }

        #endregion 定位走式 结束

        //“显示走势图”按钮
        private void displayZSTBtn_Click(object sender, EventArgs e)
        {
            setZST_html(this.comboBox1.SelectedIndex, this.comboBox1.SelectedItem.ToString());

            string url = "file:///" + Application.StartupPath + "\\zst\\eztx.html";
            //string url2 = "file:///" + Application.StartupPath + "\\zst\\eztx123.html";
            this.webBrowser1.Navigate(url);
            this.webBrowser1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displayZSTBtn.Focus();
            this.displayZSTBtn.Enabled = true;
            this.webBrowser1.Focus();
        }
    }
}
