using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using _3d.Function;

namespace _3d
{
    public partial class Regist : Form
    {
        

        public Regist()
        {
            InitializeComponent();
        }

        private void Regist_Load(object sender, EventArgs e)
        {
            MachineCode mc = new MachineCode();
            //string a = mc.GetCpuInfo();
            string b = mc.GetHDid();
            //string c = mc.GetMoAddress();
            string d = mc.GetCpuID();
            //string ee = mc.GetHardDiskID();
            //string f = mc.GetHostName();
            string g = mc.GetMacAddress();
            string machinecode = d + g;
            for (int i = 4; i < machinecode.Length; i += 5)
                machinecode = machinecode.Insert(i, "-");
            textBox8.Text = machinecode;
        }

        #region textbox_changed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox1.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if ((System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Trim().Substring(i, 1), @"^[\u4E00-\u9fa5]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Trim().Substring(i, 1), @" ")))
                    {
                        textBox1.Text = textBox1.Text.Trim().Remove(i, 1);
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Trim().Length;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox2.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Trim().Substring(i, 1), @"^[A-Za-z0-9]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Trim().Substring(i, 1), @" ")))
                    {
                        textBox2.Text = textBox2.Text.Trim().Remove(i, 1);
                    }
                }
                textBox2.SelectionStart = textBox2.Text.Trim().Length;
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox3.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Trim().Substring(i, 1), @"^[A-Za-z0-9]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Trim().Substring(i, 1), @" ")))
                    {
                        textBox3.Text = textBox3.Text.Trim().Remove(i, 1);
                    }
                }
                textBox3.SelectionStart = textBox3.Text.Trim().Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox4.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Trim().Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox4.Text = textBox4.Text.Trim().Remove(i, 1);
                    }
                }
                textBox4.SelectionStart = textBox4.Text.Trim().Length;
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox5.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text.Trim().Substring(i, 1), @"^[A-Za-z0-9]+$"))
                    {
                        textBox5.Text = textBox5.Text.Trim().Remove(i, 1);
                    }
                }
                textBox5.SelectionStart = textBox5.Text.Trim().Length;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox6.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text.Trim().Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox6.Text = textBox6.Text.Trim().Remove(i, 1);
                    }
                }
                textBox6.SelectionStart = textBox6.Text.Trim().Length;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim().Length > 0)
            {
                // 將 TextBox1.Text.Trim() 的中文字刪除
                for (int i = textBox7.Text.Trim().Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text.Trim().Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox7.Text = textBox7.Text.Trim().Remove(i, 1);
                    }
                }
                textBox7.SelectionStart = textBox7.Text.Trim().Length;
            }
        }

        #endregion

        //“返回”按钮点击
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //“申请”按钮点击
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
            {
                writeToDB();
            }
        }

        //检查textbox输入
        private Boolean checkTextBox()
        {
            bool tf = false;
            if (textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("用户名不能为空", "温馨提示");
            }
            else
                if (textBox1.Text.Trim().Length < 6 || textBox1.Text.Trim().Length > 10)
                    MessageBox.Show("用户名长度必须大于6位且小于10位", "温馨提示");
                else

                    if (textBox2.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("密码不能为空", "温馨提示");
                    }
                    else
                        if (textBox2.Text.Trim().Length < 6)
                        {
                            MessageBox.Show("密码不能少于6位", "温馨提示");
                        }
                        else
                            if (textBox3.Text.Trim() != textBox2.Text.Trim())
                            {
                                MessageBox.Show("两次输入密码不一致，请重新输入", "温馨提示");
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox2.Focus();
                                this.Show();
                            }
                            else
                                if (textBox4.Text.Trim().Length == 0)
                                {
                                    MessageBox.Show("请输入您的真实姓名", "温馨提示");
                                }
                                else
                                    if (textBox5.Text.Trim().Length ==0)
                                    {
                                        MessageBox.Show("请填写您的身份证号!", "温馨提示");
                                    }
                                    else
                                    if (textBox5.Text.Trim().Length > 18)
                                    {
                                        MessageBox.Show("身份证号不能大于18位", "温馨提示");
                                    }
                                    else
                                        if (textBox5.Text.Trim().Length < 15 && textBox5.Text.Trim().Length > 0)
                                        {
                                            MessageBox.Show("身份证号不能小于15位", "温馨提示");
                                        }
                                        else
                                            if (textBox5.Text.Trim().Length == 16 || textBox5.Text.Trim().Length == 17)
                                            {
                                                MessageBox.Show("请检查您的身份证号位数！", "温馨提示");
                                            }
                                            else
                                                if (textBox9.Text.Trim().Length == 0)
                                                {
                                                    MessageBox.Show("请输入您的手机号！", "温馨提示");
                                                }
                                                else
                                                    if (textBox9.Text.Trim().Length !=11)
                                                    {
                                                        MessageBox.Show("请检查您的手机号位数！", "温馨提示");
                                                    }
                                                    else
                                                        if (textBox10.Text.Trim().Length == 0)
                                                        {
                                                            MessageBox.Show("请输入您的QQ号或者MSN号！", "温馨提示");
                                                        }
                                                        else
                                                            if (textBox7.Text.Trim().Length == 0&&textBox6.Text.Trim().Length == 0)
                                                            {
                                                                MessageBox.Show("请输入您来自的地区！", "温馨提示");
                                                            }
                                                                else
                                                tf = true;
            return tf;
        }

        //写入数据库
        private void writeToDB()
        {

            string user_name = textBox1.Text.Trim();
            string user_pass = textBox2.Text.Trim();
            ToMD5 md5 = new ToMD5();//将密码加密为md5
            user_pass = md5.Encrypt(user_pass);
            string user_realname = textBox4.Text.Trim();
            string user_id = textBox5.Text.Trim();
            string user_phone = textBox9.Text.Trim();
            string user_qq = textBox10.Text.Trim();
            string user_province = "";
            string province = textBox7.Text.Trim();
            string city = textBox6.Text.Trim();
            if (province.Contains("省"))
                province = province.Substring(0, province.IndexOf("省"));
            if (city.Contains("市"))
                city = city.Substring(0, city.IndexOf("市"));
            user_province = province + "省" + city + "市";
            if (textBox7.Text.Trim().Equals("") && textBox6.Text.Trim() != "")
                user_province = textBox6.Text.Trim() + "市";
            if (user_province.Equals("省市"))
                user_province = "暂无";
            if (user_province.IndexOf("市") - user_province.IndexOf("省") == 1)
            {
                user_province = user_province.Substring(0, user_province.IndexOf("省")+1);
            }
            string machinecode = textBox8.Text.Trim();
            string registtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                DataTable dtMCode = LinkMySql.MySqlQuery("select * from " + Global.sqlUserTable + " where user_name='" + user_name + "'");

                if (dtMCode.Rows.Count == 0)
                {
                    LinkMySql.MySqlExcute("insert into "+Global.sqlUserTable+"(user_name,user_pass,user_realname,user_id,user_phone,user_qq,user_province,machinecode,registtime,registplace) values('" + user_name + "','" + user_pass + "','" + user_realname + "','" + user_id + "','" + user_phone + "','" + user_qq + "','" + user_province + "','" + machinecode + "','" + registtime + "','" + getIP.GetWebCity() + "')");
                    MessageBox.Show("申请成功，请联系管理等待开通。", "恭喜");
                    this.Close();
                }
                else
                    MessageBox.Show("用户名已存在，请换一个用户名再试！", "温馨提示");
            }
            catch
            {
                MessageBox.Show("申请失败，请稍后重试！", "温馨提示");
            }
        }
    }
}