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
    public partial class ModifyInfo : Form
    {
        Login login = new Login();
        public ModifyInfo()
        {
            InitializeComponent();
        }

        #region textchanged
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
        #endregion

        //“提交修改”按钮点击
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
            {
                writeToDB();
            }
        }

        //清空textbox窗体
        private Boolean checkTextBox()
        {
            bool tf = false;
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空", "温馨提示");
            }
            else
                if (textBox4.Text.Length==0)
                {
                    MessageBox.Show("请输入您的真实姓名", "温馨提示");
                }else
                if (textBox5.Text.Length > 18)
                {
                    MessageBox.Show("身份证号不能大于18位", "温馨提示");
                }
                else
                    if (textBox5.Text.Length < 15&&textBox5.Text.Length>0)
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
            string user_realname = textBox4.Text;
            string user_id = textBox5.Text;
            string user_phone = textBox9.Text;
            string user_qq = textBox10.Text;
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
                LinkMySql.MySqlQuery("update " + Global.sqlUserTable + " set user_realname='" + user_realname + "',user_province='" + user_province + "',user_id='" + user_id + "',user_phone='" + user_phone + "',user_qq='" + user_qq + "' where user_name='" + Global.user_name + "'");
                MessageBox.Show("修改成功", "恭喜");
                this.Close();
            }
            catch {
                MessageBox.Show("修改失败，请稍后重试", "提示");
            }
        }

        private void ModifyInfo_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Global.user_name;

            DataTable dt1 = LinkMySql.MySqlQuery("select user_realname,user_id,user_phone,user_qq,user_province from "+Global.sqlUserTable+" where user_name='" + Global.user_name + "'");
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
                this.textBox6.Text = (user_province.Substring(user_province.IndexOf("省") + 1, user_province.IndexOf("市") - user_province.IndexOf("省")-1));
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

            if (Global.user_vali.Equals("3") || Global.user_vali.Equals("4"))
            {
                this.textBox7.Enabled = false;
                this.textBox6.Enabled = false;
            }
        }
    }
}
