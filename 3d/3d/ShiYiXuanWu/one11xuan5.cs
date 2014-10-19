using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3d
{
    public partial class one11xuan5 : Form
    {
        one11xuan5computing o115c = new one11xuan5computing();

        public static string oldFenGe = " ";
        public static string normalFenGe = " ";
        private static int countCbxOld = 0;
        private string data = Properties.Resources._11xuan5;

        public one11xuan5()
        {
            InitializeComponent();
            getMainData();
            this.fenGeCombx.SelectedIndex = 0;
            this.timer1.Interval = 1;
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// 生成主数据
        /// </summary>
        private void getMainData()
        {
            one11xuan5computing.mainData.Clear();
            clearOnlyNumData();
            data = data.Replace(oldFenGe, normalFenGe);
            oldFenGe = normalFenGe;
            string[] dataSp = data.Split('\n');
            one11xuan5computing.mainData.AddRange(dataSp);
            generalOnlyNumData();
        }

        /// <summary>
        /// 清空单个数的所有数据组
        /// </summary>
        private void clearOnlyNumData()
        {
            one11xuan5computing.data1.Clear();
            one11xuan5computing.data2.Clear();
            one11xuan5computing.data3.Clear();
            one11xuan5computing.data4.Clear();
            one11xuan5computing.data5.Clear();
            one11xuan5computing.data6.Clear();
            one11xuan5computing.data7.Clear();
            one11xuan5computing.data8.Clear();
            one11xuan5computing.data9.Clear();
            one11xuan5computing.data10.Clear();
            one11xuan5computing.data11.Clear();
        }

        /// <summary>
        /// 生成单个数的所有数据组，比如所有带1的一组，所有带2的一组，以此类推
        /// </summary>
        private void generalOnlyNumData()
        {
            one11xuan5computing.data1.AddRange(o115c.getOneNumData(new string[] { "1" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data2.AddRange(o115c.getOneNumData(new string[] { "2" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data3.AddRange(o115c.getOneNumData(new string[] { "3" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data4.AddRange(o115c.getOneNumData(new string[] { "4" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data5.AddRange(o115c.getOneNumData(new string[] { "5" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data6.AddRange(o115c.getOneNumData(new string[] { "6" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data7.AddRange(o115c.getOneNumData(new string[] { "7" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data8.AddRange(o115c.getOneNumData(new string[] { "8" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data9.AddRange(o115c.getOneNumData(new string[] { "9" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data10.AddRange(o115c.getOneNumData(new string[] { "10" }, new string[] { "1" }, one11xuan5computing.mainData));
            one11xuan5computing.data11.AddRange(o115c.getOneNumData(new string[] { "11" }, new string[] { "1" }, one11xuan5computing.mainData));
        }

        private void fenGeCombx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fenGe = this.fenGeCombx.Text;
            if (this.fenGeCombx.Text.Contains("号"))
            {
                fenGe = fenGe.Split('号')[1];
            }
            else
            {
                fenGe = " ";
            }
            normalFenGe = fenGe;
            getMainData();
        }

        private List<string> yiHaoZu()
        {
            string oneNum = "";
            string oneZu = "";
            foreach (Control ctl in oneZuGpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked == true)
                {
                    if (ctl.Name.Contains("oneNum"))
                    {
                        oneNum += ctl.Text + ",";
                    }
                    if (ctl.Name.Contains("oneZu"))
                    {
                        oneZu += ctl.Text + ",";
                    }
                }
            }

            if (oneNum.Length == 0 || oneZu.Length == 0)
            {
                return one11xuan5computing.mainData;
            }

            oneNum = oneNum.Substring(0, oneNum.Length - 1);
            oneZu = oneZu.Substring(0, oneZu.Length - 1);
            string[] oneNums = oneNum.Split(',');
            string[] oneZus = oneZu.Split(',');
            return o115c.oneZuComputing(oneNums, oneZus, one11xuan5computing.mainData);
        }

        public string sendData()
        {
            string res = "";
            List<string> li = new List<string>();
            li.AddRange(yiHaoZu());
            li = li.Distinct().ToList();//去除重复项
            for (int i = 0; i < li.Count; i++)
            {
                res += (li[i] + "\n");
            }
            if (res.Length != 0)
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;
        }

        #region 页面Groupbox重绘

        private void oneZuGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(oneZuGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(oneZuGpb.Text, oneZuGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(oneZuGpb.Text, oneZuGpb.Font).Width + 8, 7, oneZuGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, oneZuGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, oneZuGpb.Height - 2, oneZuGpb.Width - 2, oneZuGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, oneZuGpb.Width - 2, 7, oneZuGpb.Width - 2, oneZuGpb.Height - 2);//右边那条竖线
        }

        #endregion

        //监控胆码组的复选框
        private void timer1_Tick(object sender, EventArgs e)
        {
            visibleZuCbx(this.oneZuGpb, "oneNum", "oneZu");
        }

        private void visibleZuCbx(Control Gpb, string oneNumName, string oneZuName)
        {
            int countOneNum = 0;

            if (countCbxOld == 0)
            {
                foreach (Control ctl in Gpb.Controls)
                {
                    if (ctl is CheckBox && ctl.Name.Contains(oneZuName))
                    {
                        ctl.Enabled = false;
                    }
                }
            }

            //判断有勾了几个数
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && (ctl as CheckBox).Checked && ctl.Name.Contains(oneNumName))
                {
                    countOneNum++;
                }
            }

            //把所有Enable=false的勾去掉
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && ctl.Name.Contains(oneZuName) && ctl.Enabled == false)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }

            if (countOneNum == countCbxOld)
            {
                return;
            }
            countCbxOld = countOneNum;
            foreach (Control ctl in Gpb.Controls)
            {
                if (ctl is CheckBox && ctl.Name.Contains(oneZuName))
                {
                    ctl.Enabled = false;
                    for (int i = 0; i <= countOneNum; i++)
                    {
                        if (ctl.Name.Contains(i.ToString()))
                        {
                            ctl.Enabled = true;
                        }
                    }
                }

            }
        }
    }
}
