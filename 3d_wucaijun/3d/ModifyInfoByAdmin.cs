using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _3d.Function;

namespace _3d
{
    public partial class ModifyInfoByAdmin : Form
    {
        Login login = new Login();
        LinkMySql lms = new LinkMySql();
        private string un = "";
        public ModifyInfoByAdmin(string user_name)
        {
            InitializeComponent();
            this.textBox1.Text = user_name;
            un = user_name;
        }

        private void ModifyInfoByAdmin_Load(object sender, EventArgs e)
        {
            DataSet ds1 = lms.conn("select * from "+Global.sqlUserTable+" where user_name='" + un + "'");
            DataTable dt1 = ds1.Tables[0];
            DataRow dr1 = dt1.Rows[0];
            string user_realname = dr1["user_realname"].ToString();
            if (user_realname == null || user_realname.Equals(""))
                user_realname = "";

            string user_id = dr1["user_id"].ToString();
            if (user_id == null || user_id.Equals(""))
                user_id = "";

            string user_phone = dr1["user_phone"].ToString();
            if (user_phone == null || user_phone.Equals(""))
                user_phone = "";

            string user_qq = dr1["user_qq"].ToString();
            if (user_qq == null || user_qq.Equals(""))
                user_qq = "";

            string user_province = dr1["user_province"].ToString();
            if (user_province.Equals("暂无"))
                user_province = "";
            if (user_province != "暂无" && user_province.IndexOf("省") > 0 && user_province.IndexOf("市") > 0)
            {
                this.textBox7.Text = (user_province.Substring(0, user_province.IndexOf("省")));
                this.textBox6.Text = (user_province.Substring(user_province.IndexOf("省") + 1, user_province.IndexOf("市") - user_province.IndexOf("省") - 1));
            }
            if (user_province != "暂无" && user_province.IndexOf("省") < 0 && user_province.IndexOf("市") > 0)
            {
                this.textBox6.Text = (user_province.Substring(0, user_province.IndexOf("市")));
            }
            if (user_province != "暂无" && user_province.IndexOf("省") > 0 && user_province.IndexOf("市") < 0)
            {
                this.textBox7.Text = (user_province.Substring(0, user_province.IndexOf("省")));
            }
            
            this.textBox4.Text = user_realname;
            this.textBox5.Text = user_id;
            this.textBox9.Text = dr1["user_phone"].ToString();
            this.textBox10.Text = dr1["user_qq"].ToString();

            string allowlogin = dr1["allowlogin"].ToString();
            if (allowlogin.Equals("1"))
                this.radioButton1.Checked = true;
            if (allowlogin.Equals("0"))
                this.radioButton2.Checked = true;
        }

        //检查页面的textbox文本框
        private Boolean checkTextBox()
        {
            bool tf = false;
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空", "温馨提示");
            }
            else
                if (textBox4.Text.Length == 0)
                {
                    MessageBox.Show("请输入您的真实姓名", "温馨提示");
                }
                else
                    if (textBox5.Text.Length > 18)
                    {
                        MessageBox.Show("身份证号不能大于18位", "温馨提示");
                    }
                    else
                        if (textBox5.Text.Length < 15 && textBox5.Text.Length > 0)
                        {
                            MessageBox.Show("身份证号不能小于15位", "温馨提示");
                        }
                        else
                            if (textBox5.Text.Length == 16 || textBox5.Text.Length == 17)
                            {
                                MessageBox.Show("请检查您的身份证号位数！", "温馨提示");
                            }
                            else
                                tf = true;
            return tf;
        }

        //写入数据库
        private void writeToDB()
        {
            string user_name = textBox1.Text;
            string user_realname = textBox4.Text;
            string user_pass = textBox3.Text;
            if(!user_pass.Equals("")){
            ToMD5 md5 = new ToMD5();
            user_pass = md5.Encrypt(user_pass);
            }
            string user_id = textBox5.Text;
            string user_phone = textBox9.Text;
            string user_qq = textBox10.Text;
            string allowlogin = "";
            if (this.radioButton1.Checked)
                allowlogin = "1";
            if (this.radioButton2.Checked)
                allowlogin = "0";
            string user_province = "";
            string province = textBox7.Text;
            string city = textBox6.Text;
            if (province.Contains("省"))
                province = province.Substring(0, province.IndexOf("省"));
            if (city.Contains("市"))
                city = city.Substring(0, city.IndexOf("市"));
            user_province = province + "省" + city + "市";
            if (textBox7.Text.Equals("") && textBox6.Text != "")
                user_province = textBox6.Text + "市";
            if (user_province.Equals("省市"))
                user_province = "暂无";
            if (user_province.IndexOf("市") - user_province.IndexOf("省") == 1)
            {
                user_province = user_province.Substring(0, user_province.IndexOf("省") + 1);
            }
            try
            {
                if (!user_pass.Equals(""))
                {
                    lms.conn("update "+Global.sqlUserTable+" set user_name='" + user_name + "',user_pass='" + user_pass + "',user_realname='" + user_realname + "',user_province='" + user_province + "',allowlogin='" + allowlogin + "',user_id='" + user_id + "',user_phone='" + user_phone + "',user_qq='" + user_qq + "' where user_name='" + un + "'");
                    MessageBox.Show("修改成功", "恭喜");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                if (user_pass.Equals(""))
                {
                    lms.conn("update "+Global.sqlUserTable+" set user_name='" + user_name + "',user_realname='" + user_realname + "',user_province='" + user_province + "',allowlogin='" + allowlogin + "',user_id='" + user_id + "',user_phone='" + user_phone + "',user_qq='" + user_qq + "' where user_name='" + un + "'");
                    MessageBox.Show("修改成功", "恭喜");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch {
                MessageBox.Show("修改失败，请稍后重试。", "提示");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
            {
                writeToDB();
            }
        }

        #region textChange
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if ((System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.Substring(i, 1), @" ")))
                    {
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                    }
                }
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox4.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox4.Text = textBox4.Text.Remove(i, 1);
                    }
                }
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox5.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text.Substring(i, 1), @"^[A-Za-z0-9]+$"))
                    {
                        textBox5.Text = textBox5.Text.Remove(i, 1);
                    }
                }
                textBox5.SelectionStart = textBox5.Text.Length;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox7.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox7.Text = textBox7.Text.Remove(i, 1);
                    }
                }
                textBox7.SelectionStart = textBox7.Text.Length;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox6.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text.Substring(i, 1), @"^[\u4E00-\u9fa5]+$")))
                    {
                        textBox6.Text = textBox6.Text.Remove(i, 1);
                    }
                }
                textBox6.SelectionStart = textBox6.Text.Length;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox3.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Substring(i, 1), @"^[A-Za-z0-9]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.Substring(i, 1), @" ")))
                    {
                        textBox3.Text = textBox3.Text.Remove(i, 1);
                    }
                }
                textBox3.SelectionStart = textBox3.Text.Length;
            }
            if (textBox3.Text.Length >= 6)
            {
                label6.Text = "";

            }
            if(textBox3.Text.Length==0)
            {
                label6.Text = "为空则不设置";
            }
        }
        #endregion

        private void ModifyInfoByAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}