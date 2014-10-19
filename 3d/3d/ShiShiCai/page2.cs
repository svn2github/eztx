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
    public partial class Form3 : Form
    {
        Form1 f1 = new Form1();
        public Form3()
        {
            InitializeComponent();
        }

        #region 主数据组

        private string[] f1Data;

        public void getF1Data(string[] args)
        {
            f1Data = args;//从main中得到f1的数据并将其赋值给本页面
        }

        private string[] noLocHeExecute()//不定位两码和
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = f1Data;
            List<string> noLocItems1 = new List<string>();
            List<string> noLocItems2 = new List<string>();
            string noLocChuGeShu = "";
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            if ((ct as CheckBox).Checked)
                            {
                                noLocChuGeShu += (ct as CheckBox).Text;
                            }
                        }
                    }
                }
            }

            string a = "";
            foreach (Control c in this.noLoc2He1.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).Checked)
                    {

                        a += ((c as CheckBox).Text);
                    }
                }
            }

            string b = "";
            foreach (Control c in this.noLoc2He2.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).Checked)
                    {

                        b += ((c as CheckBox).Text);
                    }
                }
            }

            //没选出条件
            if (
                noLocChuGeShu.Length == 0
                ||
                ((noLocChuGeShu.Length > 0 && a.Length == 0) && (noLocChuGeShu.Length > 0 && b.Length == 0))
                )
            {
                result.AddRange(allNum);
            }

            #region 选择出1
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("1"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems2.Count > 0 && noLocItems1.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[j])
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                            ||
                            (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }

                }

            }
            #endregion

            #region 选择出0
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("0"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(
                            noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (noLocItems2.Count > 0 && noLocItems1.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(
                            noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(
                            noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            )
                        {
                            if (
                                !(
                                noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

            }
            #endregion

            #region 选择出2
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("2"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                            ||
                            v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                            ||
                            v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                            )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("01") || noLocChuGeShu.Equals("10")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                //如果只选了一组并选择出0,1个，等于没选
                if ((noLocItems1.Count > 0 && noLocItems2.Count == 0) || (noLocItems1.Count == 0 && noLocItems2.Count > 0))
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        result.Add(allNum[i]);
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();

                            if (
                                !(
                                noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                )
                            {
                                if (
                                    !(
                                    noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                    ||
                                    noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                    ||
                                    noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                    )
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }

                            if (
                            (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                            ||
                            (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                            )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
            }


            #endregion

            #region 选择出0,2
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("02") || noLocChuGeShu.Equals("20")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                        !(
                        noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                        ||
                        noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                        ||
                        noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                        )
                        )
                        {
                            if (
                                !(
                                noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }

                        if (
                        v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                        )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }
            }


            #endregion

            #region 选择出1,2
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("12") || noLocChuGeShu.Equals("21")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码和1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码和2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();

                        if (
                            (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                            ||
                            (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                        v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                        )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }



            }
            #endregion

            #region 选择出0,1,2
            if (noLocChuGeShu.Contains("0") && noLocChuGeShu.Contains("1") && noLocChuGeShu.Contains("2"))
            {
                result.AddRange(allNum);
            }
            #endregion

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();//排序
            return result1.ToArray();
        }

        private string[] noLocChaExecute()//不定位两码差
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = noLocHeExecute();
            List<string> noLocItems1 = new List<string>();
            List<string> noLocItems2 = new List<string>();
            string noLocChuGeShu = "";
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            if ((ct as CheckBox).Checked)
                            {
                                noLocChuGeShu += (ct as CheckBox).Text;
                            }
                        }
                    }
                }
            }

            string a = "";
            foreach (Control c in this.noLoc2Cha1.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).Checked)
                    {

                        a += ((c as CheckBox).Text);
                    }
                }
            }

            string b = "";
            foreach (Control c in this.noLoc2Cha2.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).Checked)
                    {

                        b += ((c as CheckBox).Text);
                    }
                }
            }

            //没选出条件
            if (
                noLocChuGeShu.Length == 0
                ||
                ((noLocChuGeShu.Length > 0 && a.Length == 0) && (noLocChuGeShu.Length > 0 && b.Length == 0))
                )
            {
                result.AddRange(allNum);
            }

            #region 选择出0
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("0"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !(
                                noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems2.Count > 0 && noLocItems1.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !(
                                noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                                string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                if (
                                   !(
                                noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                    &&
                                    !(
                                noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }

                }
            }
            #endregion

            #region 选择出1
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("1"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems2.Count > 0 && noLocItems1.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[j])
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                                string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                if (
                                (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                            ||
                            (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }

                }
            }
            #endregion

            #region 选择出2
            if (noLocChuGeShu.Length > 0 && noLocChuGeShu.Equals("2"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                            ||
                            v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                            ||
                            v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                            )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("01") || noLocChuGeShu.Equals("10")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                (!(
                                noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))
                                ||
                                (v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j]))
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems2.Count > 0 && noLocItems1.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                (!(
                                noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))
                                ||
                                (
                                v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[j])
                                ||
                                v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[j])
                                )
                                )
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (noLocItems1.Count > 0 && noLocItems2.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < noLocItems1.Count; j++)
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                                string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                                if (
                                    !(
                                    noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                    ||
                                    noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                                    ||
                                    noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                                    )
                                    )
                                {
                                    if (
                                        !(
                                        noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                                        ||
                                        noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                        ||
                                        noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                                        )
                                        )
                                    {
                                        result.Add(allNum[i]);
                                    }
                                }

                                if (
                                (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                                &&
                                    !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                    ||
                                    (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                    ||
                                    (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                                ||
                                (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                                &&
                                    !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                    ||
                                    (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                    ||
                                    (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                                )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }

                }
            }
            #endregion

            #region 选择出0,2
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("02") || noLocChuGeShu.Equals("20")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                           !(
                        noLocItems1.Contains(v1.Substring(v1.Length - 1, 1))
                        ||
                        noLocItems1.Contains(v2.Substring(v2.Length - 1, 1))
                        ||
                        noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))
                        )
                            &&
                            !(
                        noLocItems2.Contains(v1.Substring(v1.Length - 1, 1))
                        ||
                        noLocItems2.Contains(v2.Substring(v2.Length - 1, 1))
                        ||
                        noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))
                        )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                        v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                        )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 选择出1,2
            if (noLocChuGeShu.Length > 0 && (noLocChuGeShu.Equals("12") || noLocChuGeShu.Equals("21")))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                    {
                        foreach (Control ct in ctl.Controls)
                        {
                            if (ct is GroupBox && ct.Text.Equals("两码差1"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        if ((c as CheckBox).Checked)
                                        {

                                            noLocItems1.Add((c as CheckBox).Text);
                                        }
                                    }
                                }
                            }

                            if (ct is GroupBox && ct.Text.Equals("两码差2"))
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (c is CheckBox)
                                        if ((c as CheckBox).Checked)
                                            noLocItems2.Add((c as CheckBox).Text);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < allNum.Count(); i++)
                {
                    for (int j = 0; j < noLocItems1.Count; j++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();

                        if (
                            (((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1)))))
                            ||
                            (((noLocItems2.Contains(v1.Substring(v1.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (noLocItems2.Contains(v3.Substring(v3.Length - 1, 1))))
                            &&
                                !((noLocItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v2.Substring(v2.Length - 1, 1)))
                                ||
                                (noLocItems1.Contains(v3.Substring(v3.Length - 1, 1)))))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                        v1.Substring(v1.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v2.Substring(v2.Length - 1, 1).Equals(noLocItems1[j])
                        ||
                        v3.Substring(v3.Length - 1, 1).Equals(noLocItems1[j])
                        )
                        {
                            for (int k = 0; k < noLocItems2.Count; k++)
                            {
                                if (
                                    v1.Substring(v1.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v2.Substring(v2.Length - 1, 1).Equals(noLocItems2[k])
                                    ||
                                    v3.Substring(v3.Length - 1, 1).Equals(noLocItems2[k])
                                    )
                                {
                                    result.Add(allNum[i]);
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 选择出0,1,2
            if (noLocChuGeShu.Contains("0") && noLocChuGeShu.Contains("1") && noLocChuGeShu.Contains("2"))
            {
                result.AddRange(allNum);
            }
            #endregion

            List<string> result1 = result.Distinct().ToList();//去除重复项
            return result1.ToArray();
        }

        private string[] locHeExecute()//定位两码和
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = noLocChaExecute();
            List<string> locItems1 = new List<string>();//百十
            List<string> locItems2 = new List<string>();//百个
            List<string> locItems3 = new List<string>();//十个
            string locChuGeShu = "";
            foreach (Control ctl in this.loc2HeGpb.Controls)
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked)
                    {
                        locChuGeShu += (ctl as CheckBox).Text;
                    }
                }
            }

            string a = "";
            foreach (Control ct in this.locBaiShi.Controls)
            {
                if (ct is CheckBox)
                {
                    if ((ct as CheckBox).Checked)
                    {

                        a += ((ct as CheckBox).Text);
                    }
                }
            }

            string b = "";
            foreach (Control ct in this.locBaiGe.Controls)
            {
                if (ct is CheckBox)
                {
                    if ((ct as CheckBox).Checked)
                    {

                        b += ((ct as CheckBox).Text);
                    }
                }
            }

            string c = "";
            foreach (Control v in this.locShiGe.Controls)
            {
                if (v is CheckBox)
                {
                    if ((v as CheckBox).Checked)
                    {

                        c += ((v as CheckBox).Text);
                    }
                }
            }

            //没选出条件
            if (
                locChuGeShu.Length == 0
                ||
                ((locChuGeShu.Length > 0 && a.Length == 0) && (locChuGeShu.Length > 0 && b.Length == 0) && (locChuGeShu.Length > 0 && c.Length == 0))
                )
            {
                result.AddRange(allNum);
            }

            #region 选择出0
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("0"))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("1"))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出2
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("2"))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出3
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("3"))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            #endregion

            #region 选择出0,1

            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("01") || locChuGeShu.Equals("10")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,2
            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("02") || locChuGeShu.Equals("20")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,3
            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("03") || locChuGeShu.Equals("30")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                                !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                                )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            #endregion

            #region 选择出0,1,2

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("2")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1,2,3

            if (locChuGeShu.Length == 4 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,2
            if (locChuGeShu.Length == 2 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("2")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,3
            if (locChuGeShu.Length == 2 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,2,3
            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出2,3
            if (locChuGeShu.Length == 2 && (locChuGeShu.Equals("23") || locChuGeShu.Equals("32")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1,3

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,2,3

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShi.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locShiGe.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        private string[] locChaExecute()//定位两码差
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = locHeExecute();
            List<string> locItems1 = new List<string>();//百十
            List<string> locItems2 = new List<string>();//百个
            List<string> locItems3 = new List<string>();//十个
            string locChuGeShu = "";
            foreach (Control ctl in this.loc2ChaGpb.Controls)
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked)
                    {
                        locChuGeShu += (ctl as CheckBox).Text;
                    }
                }
            }

            string a = "";
            foreach (Control ct in this.locBaiShiCha.Controls)
            {
                if (ct is CheckBox)
                {
                    if ((ct as CheckBox).Checked)
                    {

                        a += ((ct as CheckBox).Text);
                    }
                }
            }

            string b = "";
            foreach (Control ct in this.locBaiGeCha.Controls)
            {
                if (ct is CheckBox)
                {
                    if ((ct as CheckBox).Checked)
                    {

                        b += ((ct as CheckBox).Text);
                    }
                }
            }

            string c = "";
            foreach (Control v in this.locGeShiCha.Controls)
            {
                if (v is CheckBox)
                {
                    if ((v as CheckBox).Checked)
                    {

                        c += ((v as CheckBox).Text);
                    }
                }
            }

            //没选出条件
            if (
                locChuGeShu.Length == 0
                ||
                ((locChuGeShu.Length > 0 && a.Length == 0) && (locChuGeShu.Length > 0 && b.Length == 0) && (locChuGeShu.Length > 0 && c.Length == 0))
                )
            {
                result.AddRange(allNum);
            }

            #region 选择出0
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("0"))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("1"))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出2
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("2"))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出3
            if (locChuGeShu.Length > 0 && locChuGeShu.Equals("3"))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            #endregion

            #region 选择出0,1

            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("01") || locChuGeShu.Equals("10")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,2
            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("02") || locChuGeShu.Equals("20")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,3
            if (locChuGeShu.Length > 0 && (locChuGeShu.Equals("03") || locChuGeShu.Equals("30")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                                !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                ||
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                ||
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                                )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }
            }
            #endregion

            #region 选择出0,1,2

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("2")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1,2,3

            if (locChuGeShu.Length == 4 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems1.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems2.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < locItems3.Count; j++)
                        {
                            string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                            string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                            if (
                                !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }

                            if (
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,2
            if (locChuGeShu.Length == 2 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("2")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count == 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            ||
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                    }
                }

                if (locItems1.Count > 0 && locItems2.Count == 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems1.Contains(v1.Substring(v1.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count == 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems2.Contains(v2.Substring(v2.Length - 1, 1)) && !locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1)) && !locItems2.Contains(v2.Substring(v2.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,3
            if (locChuGeShu.Length == 2 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出1,2,3
            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("1") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出2,3
            if (locChuGeShu.Length == 2 && (locChuGeShu.Equals("23") || locChuGeShu.Equals("32")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,1,3

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("1") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (
                            (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                                )
                            )
                            ||
                            (
                            (
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            &&
                                !(
                                locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                                )
                                &&
                                !(
                                locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                                )
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            #region 选择出0,2,3

            if (locChuGeShu.Length == 3 && (locChuGeShu.Contains("0") && locChuGeShu.Contains("2") && locChuGeShu.Contains("3")))
            {
                foreach (Control ctl in this.locBaiShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems1.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locBaiGeCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems2.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                foreach (Control ctl in this.locGeShiCha.Controls)
                {
                    if (ctl is CheckBox)
                    {
                        if ((ctl as CheckBox).Checked)
                        {
                            locItems3.Add((ctl as CheckBox).Text);
                        }
                    }
                }

                if (locItems1.Count > 0 && locItems2.Count > 0 && locItems3.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        string v1 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(1, 1))).ToString();
                        string v2 = (Convert.ToInt32(allNum[i].Substring(0, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        string v3 = (Convert.ToInt32(allNum[i].Substring(1, 1)) - Convert.ToInt32(allNum[i].Substring(2, 1))).ToString();
                        if (
                            !(locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            ||
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            ||
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1)))
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                            ||
                            (locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            !locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            )
                            ||
                            (locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            &&
                            !locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            )
                            )
                        {
                            result.Add(allNum[i]);
                        }

                        if (
                            locItems1.Contains(v1.Substring(v1.Length - 1, 1))
                            &&
                            locItems2.Contains(v2.Substring(v2.Length - 1, 1))
                            &&
                            locItems3.Contains(v3.Substring(v3.Length - 1, 1))
                            )
                        {
                            result.Add(allNum[i]);
                        }
                    }
                }

            }
            #endregion

            List<string> result1 = result.Distinct().ToList();//去除重复项
            result1.Sort();
            return result1.ToArray();
        }

        public string[] sumZhi()//和值
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            string[] allNum = locChaExecute();

            if (this.killHeZhi.Checked == false)
            {
                List<int> nums = new List<int>();
                foreach (Control ctls in this.sumZhiGbp.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums.Add(Convert.ToInt16(ctls.Text));
                    }
                }
                if (nums.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < nums.Count(); j++)
                        {
                            int allNumSum = Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1));
                            if (
                                allNumSum == nums[j]
                            )
                            {
                                result.Add(allNum[i]);
                            }
                        }
                    }
                }
                else
                {
                    result.AddRange(allNum);
                }
                List<string> result1 = result.Distinct().ToList();//去除重复项
                return result1.ToArray();
            }
            else
            {
                List<int> nums = new List<int>();
                result.AddRange(allNum);
                foreach (Control ctls in this.sumZhiGbp.Controls)
                {
                    if ((ctls as CheckBox).Checked == true)
                    {
                        nums.Add(Convert.ToInt16(ctls.Text));
                    }
                }
                if (nums.Count > 0)
                {
                    for (int i = 0; i < allNum.Count(); i++)
                    {
                        for (int j = 0; j < nums.Count(); j++)
                        {
                            int allNumSum = Convert.ToInt32(allNum[i].Substring(0, 1)) + Convert.ToInt32(allNum[i].Substring(1, 1)) + Convert.ToInt32(allNum[i].Substring(2, 1));
                            if (
                                allNumSum == nums[j]
                            )
                            {
                                result.Remove(allNum[i]);
                            }
                        }
                    }
                }
                List<string> result1 = result.Distinct().ToList();//去除重复项
                return result1.ToArray();
            }
        }

        #endregion

        #region f3重绘事件

        private void noLocGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLocGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLocGpb.Text, noLocGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLocGpb.Text, noLocGpb.Font).Width + 8, 7, noLocGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLocGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLocGpb.Height - 2, noLocGpb.Width - 2, noLocGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLocGpb.Width - 2, 7, noLocGpb.Width - 2, noLocGpb.Height - 2);//右边那条竖线
        }

        private void noLocGpb2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLocGpb2.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLocGpb2.Text, noLocGpb2.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLocGpb2.Text, noLocGpb2.Font).Width + 8, 7, noLocGpb2.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLocGpb2.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLocGpb2.Height - 2, noLocGpb2.Width - 2, noLocGpb2.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLocGpb2.Width - 2, 7, noLocGpb2.Width - 2, noLocGpb2.Height - 2);//右边那条竖线
        }

        private void noLoc2He1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLoc2He1.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLoc2He1.Text, noLoc2He1.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLoc2He1.Text, noLoc2He1.Font).Width + 8, 7, noLoc2He1.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLoc2He1.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLoc2He1.Height - 2, noLoc2He1.Width - 2, noLoc2He1.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLoc2He1.Width - 2, 7, noLoc2He1.Width - 2, noLoc2He1.Height - 2);//右边那条竖线
        }

        private void noLoc2He2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLoc2He2.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLoc2He2.Text, noLoc2He2.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLoc2He2.Text, noLoc2He2.Font).Width + 8, 7, noLoc2He2.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLoc2He2.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLoc2He2.Height - 2, noLoc2He2.Width - 2, noLoc2He2.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLoc2He2.Width - 2, 7, noLoc2He2.Width - 2, noLoc2He2.Height - 2);//右边那条竖线
        }

        private void noLoc2Cha1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLoc2Cha1.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLoc2Cha1.Text, noLoc2Cha1.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLoc2Cha1.Text, noLoc2Cha1.Font).Width + 8, 7, noLoc2Cha1.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLoc2Cha1.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLoc2Cha1.Height - 2, noLoc2Cha1.Width - 2, noLoc2Cha1.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLoc2Cha1.Width - 2, 7, noLoc2Cha1.Width - 2, noLoc2Cha1.Height - 2);//右边那条竖线
        }

        private void noLoc2Cha2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(noLoc2Cha2.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(noLoc2Cha2.Text, noLoc2Cha2.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(noLoc2Cha2.Text, noLoc2Cha2.Font).Width + 8, 7, noLoc2Cha2.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, noLoc2Cha2.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, noLoc2Cha2.Height - 2, noLoc2Cha2.Width - 2, noLoc2Cha2.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, noLoc2Cha2.Width - 2, 7, noLoc2Cha2.Width - 2, noLoc2Cha2.Height - 2);//右边那条竖线
        }

        private void loc2HeGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(loc2HeGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(loc2HeGpb.Text, loc2HeGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(loc2HeGpb.Text, loc2HeGpb.Font).Width + 8, 7, loc2HeGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, loc2HeGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, loc2HeGpb.Height - 2, loc2HeGpb.Width - 2, loc2HeGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, loc2HeGpb.Width - 2, 7, loc2HeGpb.Width - 2, loc2HeGpb.Height - 2);//右边那条竖线
        }

        private void loc2ChaGpb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(loc2ChaGpb.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(loc2ChaGpb.Text, loc2ChaGpb.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(loc2ChaGpb.Text, loc2ChaGpb.Font).Width + 8, 7, loc2ChaGpb.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, loc2ChaGpb.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, loc2ChaGpb.Height - 2, loc2ChaGpb.Width - 2, loc2ChaGpb.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, loc2ChaGpb.Width - 2, 7, loc2ChaGpb.Width - 2, loc2ChaGpb.Height - 2);//右边那条竖线
        }

        private void locBaiShi_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locBaiShi.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locBaiShi.Text, locBaiShi.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locBaiShi.Text, locBaiShi.Font).Width + 8, 7, locBaiShi.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locBaiShi.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locBaiShi.Height - 2, locBaiShi.Width - 2, locBaiShi.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locBaiShi.Width - 2, 7, locBaiShi.Width - 2, locBaiShi.Height - 2);//右边那条竖线
        }

        private void locBaiGe_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locBaiGe.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locBaiGe.Text, locBaiGe.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locBaiGe.Text, locBaiGe.Font).Width + 8, 7, locBaiGe.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locBaiGe.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locBaiGe.Height - 2, locBaiGe.Width - 2, locBaiGe.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locBaiGe.Width - 2, 7, locBaiGe.Width - 2, locBaiGe.Height - 2);//右边那条竖线
        }

        private void locShiGe_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locShiGe.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locShiGe.Text, locShiGe.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locShiGe.Text, locShiGe.Font).Width + 8, 7, locShiGe.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locShiGe.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locShiGe.Height - 2, locShiGe.Width - 2, locShiGe.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locShiGe.Width - 2, 7, locShiGe.Width - 2, locShiGe.Height - 2);//右边那条竖线
        }

        private void locBaiShiCha_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locBaiShiCha.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locBaiShiCha.Text, locBaiShiCha.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locBaiShiCha.Text, locBaiShiCha.Font).Width + 8, 7, locBaiShiCha.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locBaiShiCha.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locBaiShiCha.Height - 2, locBaiShiCha.Width - 2, locBaiShiCha.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locBaiShiCha.Width - 2, 7, locBaiShiCha.Width - 2, locBaiShiCha.Height - 2);//右边那条竖线
        }

        private void locBaiGeCha_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locBaiGeCha.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locBaiGeCha.Text, locBaiGeCha.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locBaiGeCha.Text, locBaiGeCha.Font).Width + 8, 7, locBaiGeCha.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locBaiGeCha.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locBaiGeCha.Height - 2, locBaiGeCha.Width - 2, locBaiGeCha.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locBaiGeCha.Width - 2, 7, locBaiGeCha.Width - 2, locBaiGeCha.Height - 2);//右边那条竖线
        }

        private void locGeShiCha_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(locGeShiCha.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(locGeShiCha.Text, locGeShiCha.Font, new SolidBrush(Color.DarkBlue), 10, -3);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(locGeShiCha.Text, locGeShiCha.Font).Width + 8, 7, locGeShiCha.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, locGeShiCha.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, locGeShiCha.Height - 2, locGeShiCha.Width - 2, locGeShiCha.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, locGeShiCha.Width - 2, 7, locGeShiCha.Width - 2, locGeShiCha.Height - 2);//右边那条竖线
        }

        private void sumZhiGbp_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(sumZhiGbp.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(sumZhiGbp.Text, sumZhiGbp.Font, new SolidBrush(Color.DarkBlue), 10, 0);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(sumZhiGbp.Text, sumZhiGbp.Font).Width + 8, 7, sumZhiGbp.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, sumZhiGbp.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, sumZhiGbp.Height - 2, sumZhiGbp.Width - 2, sumZhiGbp.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, sumZhiGbp.Width - 2, 7, sumZhiGbp.Width - 2, sumZhiGbp.Height - 2);//右边那条竖线
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox2.BackColor);
            //颜色可以使用new SolidBrush(Color.FromArgb(51, 94, 168))来达到自定义，也可以直接Brushes.DarkBlue，字体可以使用new Font()来定义
            e.Graphics.DrawString(groupBox2.Text, groupBox2.Font, new SolidBrush(Color.DarkBlue), 10, 0);//设置文字(内容，字体，颜色，X坐标，Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 8, 7);//设置文字左边的线条(起点X坐标，起点Y坐标，终点X坐标，终点Y坐标)
            e.Graphics.DrawLine(Pens.DarkGray, e.Graphics.MeasureString(groupBox2.Text, groupBox2.Font).Width + 8, 7, groupBox2.Width - 2, 7);//设置文字后面那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, 7, 1, groupBox2.Height - 2);//左边那条线
            e.Graphics.DrawLine(Pens.DarkGray, 1, groupBox2.Height - 2, groupBox2.Width - 2, groupBox2.Height - 2);//下面那条线
            e.Graphics.DrawLine(Pens.DarkGray, groupBox2.Width - 2, 7, groupBox2.Width - 2, groupBox2.Height - 2);//右边那条竖线
        }

        #endregion

        #region 全选勾选功能、清空区域功能、检查是否勾选出几个

        //清空全部CheckBox
        public void clearCheckBox()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox)
                {
                    foreach (Control ctl2 in ctl.Controls)
                    {
                        if (ctl2 is CheckBox)
                        {
                            (ctl2 as CheckBox).Checked = false;
                        }
                        if (ctl2 is GroupBox)
                        {
                            foreach (Control ctl3 in ctl2.Controls)
                            {
                                if (ctl3 is CheckBox)
                                {
                                    (ctl3 as CheckBox).Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        //不定位两码和清
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox && ctl.Text.Equals("不定位两码和"))
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            (ct as CheckBox).Checked = false;
                        }

                        if (ct is GroupBox)
                        {
                            foreach (Control cti in ct.Controls)
                            {
                                if (cti is CheckBox)
                                {
                                    (cti as CheckBox).Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        //不定位两码差清
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is GroupBox && ctl.Text.Equals("不定位两码差"))
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            (ct as CheckBox).Checked = false;
                        }

                        if (ct is GroupBox)
                        {
                            foreach (Control cti in ct.Controls)
                            {
                                if (cti is CheckBox)
                                {
                                    (cti as CheckBox).Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        //两码和1全选
        private void noLoc2He1AllCh_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.noLoc2He1.Controls)
            {
                if (ctl is CheckBox && noLoc2He1AllCh.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码和2全选
        private void noLoc2He2AllCh_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.noLoc2He2.Controls)
            {
                if (ctl is CheckBox && noLoc2He2AllCh.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码差1全选
        private void noLoc2Cha1AllCh_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.noLoc2Cha1.Controls)
            {
                if (ctl is CheckBox && noLoc2Cha1AllCh.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码差2全选
        private void noLoc2Cha2AllCh_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.noLoc2Cha2.Controls)
            {
                if (ctl is CheckBox && noLoc2Cha2AllCh.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        #region 和值勾选框

        private void sumNumAllcbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sumNumAllcbx.Checked == true)
            {
                sumNumBigCbx.Enabled = false;
                sumNumBigCbx.Checked = false;
                sumNumSmallCbx.Enabled = false;
                sumNumSmallCbx.Checked = false;
                sumNumJiCbx.Enabled = false;
                sumNumJiCbx.Checked = false;
                sumNumOuCbx.Enabled = false;
                sumNumOuCbx.Checked = false;

                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    (ctl as CheckBox).Checked = true;
                }
            }
            else
            {
                sumNumBigCbx.Enabled = true;
                sumNumSmallCbx.Enabled = true;
                sumNumJiCbx.Enabled = true;
                sumNumOuCbx.Enabled = true;

                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    (ctl as CheckBox).Checked = false;
                }
            }
        }

        private void sumNumBigCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sumNumBigCbx.Checked == true)
            {
                sumNumSmallCbx.Enabled = false;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) >= 14)
                        (ctl as CheckBox).Checked = true;
                }
            }
            else
            {
                sumNumSmallCbx.Enabled = true;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) >= 14)
                        (ctl as CheckBox).Checked = false;
                }
            }
        }

        private void sumNumSmallCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sumNumSmallCbx.Checked == true)
            {
                sumNumBigCbx.Enabled = false;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) <= 13)
                        (ctl as CheckBox).Checked = true;
                }
            }
            else
            {
                sumNumBigCbx.Enabled = true;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) <= 13)
                        (ctl as CheckBox).Checked = false;
                }
            }
        }

        private void sumNumJiCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sumNumJiCbx.Checked == true)
            {
                sumNumOuCbx.Enabled = false;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) % 2 == 1)
                        (ctl as CheckBox).Checked = true;
                }
            }
            else
            {
                sumNumOuCbx.Enabled = true;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) % 2 == 1)
                        (ctl as CheckBox).Checked = false;
                }
            }
        }

        private void sumNumOuCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sumNumOuCbx.Checked == true)
            {
                sumNumJiCbx.Enabled = false;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) % 2 == 0)
                        (ctl as CheckBox).Checked = true;
                }
            }
            else
            {
                sumNumJiCbx.Enabled = true;
                foreach (Control ctl in this.sumZhiGbp.Controls)
                {
                    if (Convert.ToInt16((ctl as CheckBox).Text) % 2 == 0)
                        (ctl as CheckBox).Checked = false;
                }
            }
        }

        #endregion

        //设置“胆码”区域的出号个数是否勾选
        public Boolean chuHaoGeShu()
        {
            string a = "";
            foreach (Control ctl in this.noLoc2He1.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        a += ((ctl as CheckBox).Text);
                }
            }

            string aa = "";
            foreach (Control ctl in this.noLocGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        aa += ((ctl as CheckBox).Text);
                }
            }

            string b = "";
            foreach (Control ctl in this.noLoc2He2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        b += ((ctl as CheckBox).Text);
                }
            }

            string bb = "";
            foreach (Control ctl in this.noLocGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        bb += ((ctl as CheckBox).Text);
                }
            }

            string c = "";
            foreach (Control ctl in this.noLoc2Cha1.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        c += ((ctl as CheckBox).Text);
                }
            }

            string cc = "";
            foreach (Control ctl in this.noLocGpb2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        cc += ((ctl as CheckBox).Text);
                }
            }

            string d = "";
            foreach (Control ctl in this.noLoc2Cha2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        d += ((ctl as CheckBox).Text);
                }
            }

            string dd = "";
            foreach (Control ctl in this.noLocGpb2.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        dd += ((ctl as CheckBox).Text);
                }
            }

            string e = "";
            foreach (Control ctl in this.loc2HeGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        e += ((ctl as CheckBox).Text);
                }
            }

            string e1 = "";
            foreach (Control ctl in this.locBaiShi.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        e1 += ((ctl as CheckBox).Text);
                }
            }

            string e2 = "";
            foreach (Control ctl in this.locBaiGe.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        e2 += ((ctl as CheckBox).Text);
                }
            }

            string e3 = "";
            foreach (Control ctl in this.locShiGe.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        e3 += ((ctl as CheckBox).Text);
                }
            }

            string f = "";
            foreach (Control ctl in this.loc2ChaGpb.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        f += ((ctl as CheckBox).Text);
                }
            }

            string f1 = "";
            foreach (Control ctl in this.locBaiShiCha.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        f1 += ((ctl as CheckBox).Text);
                }
            }

            string f2 = "";
            foreach (Control ctl in this.locBaiGeCha.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        f2 += ((ctl as CheckBox).Text);
                }
            }

            string f3 = "";
            foreach (Control ctl in this.locGeShiCha.Controls) //this可以根据实际情况修改为this.groupBreakFast,this.groupLunch,this.groupDinner
            {
                if (ctl is CheckBox)
                {
                    if ((ctl as CheckBox).Checked == true)
                        f3 += ((ctl as CheckBox).Text);
                }
            }

            if ((a != "" || b != "") && (aa.Equals("") || bb.Equals("")))
            {
                MessageBox.Show("您勾选了两码和，只有在您选择出现个数以后才能生效", "温馨提示");
                return false;
            }
            else if ((c != "" || d != "") && (cc.Equals("") || dd.Equals("")))
            {
                MessageBox.Show("您勾选了两码差，只有在您选择出现个数以后才能生效", "温馨提示");
                return false;
            }
            else if ((!string.IsNullOrEmpty(e1) || !string.IsNullOrEmpty(e2) || !string.IsNullOrEmpty(e3)) && (e.Equals("")))
            {
                MessageBox.Show("您勾选了定位两码和，只有在您选择出现几个以后才能生效", "温馨提示");
                return false;
            }
            else if ((!string.IsNullOrEmpty(f1) || !string.IsNullOrEmpty(f2) || !string.IsNullOrEmpty(f3)) && (f.Equals("")))
            {
                MessageBox.Show("您勾选了定位两码差，只有在您选择出现几个以后才能生效", "温馨提示");
                return false;
            }
            else
            {
                return true;
            }
        }

        //定位两码和清
        private void loc2HeClrBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.loc2HeGpb.Controls)
            {
                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Checked = false;
                }

                if (ctl is GroupBox)
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            (ct as CheckBox).Checked = false;
                        }
                    }
                }
            }
        }

        //定位两码差清
        private void loc2ChaClrBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.loc2ChaGpb.Controls)
            {
                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Checked = false;
                }

                if (ctl is GroupBox)
                {
                    foreach (Control ct in ctl.Controls)
                    {
                        if (ct is CheckBox)
                        {
                            (ct as CheckBox).Checked = false;
                        }
                    }
                }
            }
        }

        //百十全选
        private void locBaiShiChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locBaiShi.Controls)
            {
                if (ctl is CheckBox && locBaiShiChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //百个全选
        private void locBaiGeChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locBaiGe.Controls)
            {
                if (ctl is CheckBox && locBaiGeChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //十个全选
        private void locShiGeChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locShiGe.Controls)
            {
                if (ctl is CheckBox && locShiGeChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码差百十全选
        private void locBaiShiChaChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locBaiShiCha.Controls)
            {
                if (ctl is CheckBox && locBaiShiChaChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码差百个全选
        private void locBaiGeChaChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locBaiGeCha.Controls)
            {
                if (ctl is CheckBox && locBaiGeChaChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        //两码差十个全选
        private void locGeShiChaChAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in this.locGeShiCha.Controls)
            {
                if (ctl is CheckBox && locGeShiChaChAll.Checked == true)
                {
                    ((CheckBox)ctl).Checked = true;
                }
                else
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }
        }

        #endregion
        
    }

}
