using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _3d.Function;
using System.Threading;
using System.Runtime.InteropServices;

namespace _3d
{
    public partial class AdminCtrlProvince : Form
    {
        LinkMySql lms = new LinkMySql();

        public AdminCtrlProvince()
        {
            InitializeComponent();
        }

        private void AdminCtrl_Load(object sender, EventArgs e)
        {
            this.provinceCbx.Text = "显示全部";
            this.dataGridView1.AllowUserToAddRows = false;

            tabCtrl();
        }

        private void AdminCtrler_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        //按照常理只开通他查看他的省的信息，然后他可以设置用户上下线，已经是否能登录软件，撑死再给个修改他的省的用户的信息的功能
        //第一个选项卡中点击datagridview控件时进行的操作
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClickRefresh();
        }

        private void CellClickRefresh()
        {
            try
            {
                enableKongJian();
                string a = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
                string b = dataGridView1.CurrentRow.Cells["当前是否在线"].Value.ToString();
                string c = dataGridView1.CurrentRow.Cells["允许登录"].Value.ToString();
                if (a.Equals(""))
                    disableKongJian();
                this.label1.Text = "用户名:" + a;
                this.label2.Text = "当前" + b;
                this.label3.Text = "是否有权限登陆：";
                if (c.Equals("是"))
                {
                    this.radioButton3.Checked = false;
                    this.radioButton4.Checked = true;
                }
                if (c.Equals("否"))
                {
                    this.radioButton4.Checked = false;
                    this.radioButton3.Checked = true;
                }
            }
            catch {

            }
        }

        //启用第一个选项卡下面的选项控件
        private void enableKongJian()
        {
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.radioButton4.Visible = true;
            this.radioButton3.Visible = true;
            this.button1.Visible = true;
            this.label26.Visible = true;
            this.button7.Visible = true;
        }

        //禁用第一个选项卡下面的选项控件
        private void disableKongJian()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.radioButton4.Visible = false;
            this.radioButton3.Visible = false;
            this.button1.Visible = false;
            this.label26.Visible = false;
            this.button7.Visible = false;
        }

        //第一个选项卡中的“修改”按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            modifyAllowLogin();
            CellClickRefresh();
        }

        private void dgvGetInfoT()
        {
            Thread t = new Thread(new ThreadStart(dgvGetInfo));
            t.IsBackground=true;
            t.Start();
        }

        //第一个选项卡中Datagridview窗体的信息获取
        private void dgvGetInfo()
        {
            string us = "";//
            if (Global.user_province.IndexOf("省") >= 0)
            {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("省") + 1);
            }
            else {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("市") + 1);
            }

            try
            {
                string prov = provinceCbx.Text;
                string ol = onlineCbx.Text;
                if (prov.Equals("显示全部"))
                {
                    dgvGetInfoSqlExecute("where user_province like '%" + us + "%' and user_vali='2'");
                }
                if (prov.Equals("在线状态"))
                {
                    if (ol.Equals("在线"))
                        ol = "(online='1' or online='2')";
                    else
                        ol = "online='0'";
                    dgvGetInfoSqlExecute("where " + ol + " and user_province like '%" + us + "%' and user_vali='2'");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 刷新datagridview时执行的sql
        /// 参数where是查询条件
        /// </summary>
        private void dgvGetInfoSqlExecute(string where)
        {
            //设定给datagridview的select列名
            string displaySqlSelect = "user_name as '用户名',user_realname as '姓名',user_phone as '手机/电话',user_qq as 'QQ/MSN',"+
                "CASE allowlogin when '1' then'是' ELSE'否' end AS '允许登录',case online when '1' then '在线' when '2' then '在线' else '离线' end as '当前是否在线'," +
                "soft_version as '软件版本' ";

            DataTable tb = lms.conn("select " + displaySqlSelect + " from " + Global.sqlUserTable + " " + where + "");

            dataGridView1.DataSource = tb;
            dataGridView1.DataMember = tb.TableName;

            DataTable cu = lms.conn("select count(user_id) as 总计 from "+Global.sqlUserTable+" " + where + "");
            DataRow dr = cu.Rows[0];
            this.sumUserLabel.Text = "共有 " + dr[0].ToString() + " 位用户";
        }

        private void searchUser()
        {
            string us = "";
            if (Global.user_province.IndexOf("省") >= 0)
            {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("省") + 1);
            }
            else
            {
                us = Global.user_province.Substring(0, Global.user_province.IndexOf("市") + 1);
            }

            string searchTag = this.searchInput.Text.Trim();
            if (searchTag.Length == 0)
            {
                return;
            }

            string where = "where (user_realname LIKE '%" + searchTag + "%' or user_name LIKE '%" + searchTag + "%')  and isdel='1' and user_province like '%" + us + "%' and user_vali='2'";
            dgvGetInfoSqlExecute(where);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchUser();
        }

        //第一个选项卡中修改登录权限
        private void modifyAllowLogin()
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string radioValue = "";
            if (this.radioButton4.Checked)
                radioValue = "1";
            if (this.radioButton3.Checked)
                radioValue = "0";
            try
            {
                lms.conn("update "+Global.sqlUserTable+" set allowlogin='" + radioValue + "' where user_name='" + user_name + "'");
                MessageBox.Show("修改用户权限成功！", "恭喜");
            }
            catch
            {
                MessageBox.Show("修改用户权限失败，请稍后再试！", "友情提示");
            }

            dgvGetInfo();
        }

        //第一个选项卡中“手动下线”的按钮点击
        private void button7_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            try
            {
                lms.conn("update "+Global.sqlUserTable+" set online='0' where user_name='" + user_name + "'");
                MessageBox.Show("手动设置用户: " + user_name + " 下线成功！", "恭喜");
            }
            catch
            {
                MessageBox.Show("手动设置用户下线失败，请稍后再试！", "友情提示");
            }

            dgvGetInfo();
            CellClickRefresh();
        }

        //当tabcontrol控件选择变化以后
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminCtrl ac = new AdminCtrl();
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    dgvGetInfoT();
                    break;
            }
        }


        //设置tabcontrol控件的选项卡名称之类
        private void tabCtrl()
        {
            this.tabControl1.TabPages[0].Text = "登录权限";
            this.tabControl1.TabPages[0].Select();
        }

        //第一个选项卡中“删除用户”按钮的点击
        private void button2_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();
            DialogResult dr = MessageBox.Show("确定要删除用户:" + user_name, "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                try
                {
                    lms.conn("delete from "+Global.sqlUserTable+" where user_name='" + user_name + "'");

                    MessageBox.Show("删除成功！", "提示");

                    dgvGetInfo();

                }
                catch { MessageBox.Show("删除失败，请稍后重试！", "提示"); }
            }
        }


        //大条件框
        private void provinceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provinceCbx.Text.Equals("显示全部"))
            {
                onlineCbx.Visible = false;

                dgvGetInfo();
            }
            if (provinceCbx.Text.Equals("在线状态"))
            {
                onlineCbx.Visible = true;
                onlineCbx.DataSource = null;
                string[] stu = { "在线", "离线" };
                onlineCbx.Items.Clear();
                onlineCbx.Items.AddRange(stu);
            }
            this.searchInput.Text = "";
        }

        //后面条件框
        private void onlineCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgvGetInfo();
        }

        #region 防止页面过多变卡

        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);

        private void AdminCtrler_ResizeBegin(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
        }

        private void AdminCtrler_ResizeEnd(object sender, EventArgs e)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        #endregion


        
    }
}
