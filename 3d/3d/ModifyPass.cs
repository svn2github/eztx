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
    public partial class ModifyPass : Form
    {
        Login login = new Login();

        LinkMySql lms = new LinkMySql();

        public ModifyPass()
        {
            InitializeComponent();
        }

        private void ModifyPass_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Global.user_name;
            this.label5.Text = "";
            this.label6.Text = "";
            this.label7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userPassVali() == true)
            {
                MessageBox.Show("修改密码成功！", "恭喜");
                this.Close();
            }
            
        }

        private Boolean userPassVali()
        {
            bool tf = false;
            DataTable dt1 = lms.conn("select * from "+Global.sqlUserTable+" where user_name='" + Global.user_name + "'");
            DataRow dr1=dt1.Rows[0];
            string oldPass=textBox2.Text;
            string newPass = textBox3.Text;
            ToMD5 md5=new ToMD5();
            oldPass=md5.Encrypt(oldPass);
            newPass = md5.Encrypt(newPass);
            if (oldPass.Equals(dr1["user_pass"].ToString()))
            {
                label5.Text = "";
                if (label5.Text.Equals("") && label6.Text.Equals("") && label7.Text.Equals(""))
                {
                    lms.conn("update "+Global.sqlUserTable+" set user_pass='" + newPass + "' where user_name='" + Global.user_name + "'");
                    tf = true;
                }
            }
            else {
                label5.ForeColor = Color.Red;
                label5.Text = "原密码输入有误，请检查！";
            }
            return tf;
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
            else
            {
                label6.ForeColor = Color.Red;
                label6.Text = "密码长度不得少于6位，请检查！";
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
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Substring(i, 1), @"^[A-Za-z0-9]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.Substring(i, 1), @" ")))
                    {
                        textBox4.Text = textBox4.Text.Remove(i, 1);
                    }
                }
                textBox4.SelectionStart = textBox4.Text.Length;
            }
            if (textBox4.Text.Equals(textBox3.Text))
            {
                label7.Text = "";

            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "两次密码输入不一致，请检查！";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
