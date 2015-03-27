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
    public partial class AdminCtrl : Form
    {
        LinkMySql lms = new LinkMySql();

        public AdminCtrl()
        {
            InitializeComponent();
        }

        private void AdminCtrl_Load(object sender, EventArgs e)
        {
            this.provinceCbx.Text = "显示全部";
            tabCtrl();
            bindQuYuCbx();
        }

        /// <summary>
        /// 绑定区域代理的combobox数据
        /// </summary>
        private void bindQuYuCbx()
        {
            qyCbx.DataSource = null;
            DataTable tb = lms.conn("select user_name,user_realname from " + Global.sqlUserTable + " where user_vali='5' and isdel='1'");
            qyCbx.DataSource = tb;
            qyCbx.DisplayMember = "user_realname";
            qyCbx.ValueMember = "user_name";
        }

        /// <summary>
        /// 关闭的时候释放窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminCtrl_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        #region 防止页面空间过多变卡

        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);
        private void AdminCtrl_ResizeBegin(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
        }

        private void AdminCtrl_ResizeEnd(object sender, EventArgs e)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        #endregion

        //设置tabcontrol控件的选项卡名称之类
        private void tabCtrl()
        {
            this.radioButton2.Checked = true;
            this.tabControl1.TabPages[0].Text = "登录权限";
            this.tabControl1.TabPages[1].Text = "添加用户";
            this.tabControl1.TabPages[2].Text = "公告设置";
            this.tabControl1.TabPages[0].Select();
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
                case 1:
                    ac.MaximizeBox = false;
                    ac.FormBorderStyle = FormBorderStyle.FixedSingle;
                    break;
                case 2:
                    getGgT();
                    break;
            }
        }

        #region 第一个选项卡

        //第一页前面主条件选择框
        private void provinceCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provinceCbx.Text.Equals("显示全部"))
            {
                onlineCbx.Visible = false;
                dgvGetInfo();
            }
            if (provinceCbx.Text.Equals("省区"))
            {
                onlineCbx.Visible = true;
                onlineCbx.DataSource = null;
                DataTable tb = lms.conn("select user_province from " + Global.sqlUserTable + " group by user_province");
                onlineCbx.DataSource = tb;
                onlineCbx.DisplayMember = "user_province";
            }
            if (provinceCbx.Text.Equals("在线状态"))
            {
                onlineCbx.Visible = true;
                onlineCbx.DataSource = null;
                string[] stu = { "在线", "离线" };
                onlineCbx.Items.Clear();
                onlineCbx.Items.AddRange(stu);
            }
            if (provinceCbx.Text.Equals("区域代理"))
            {
                onlineCbx.Visible = true;
                onlineCbx.DataSource = null;
                DataTable tb = lms.conn("select user_name from " + Global.sqlUserTable + " where user_vali='5' and isdel='1'");
                onlineCbx.DataSource = tb;
                onlineCbx.DisplayMember = "user_name";
            }
            this.searchInput.Text = "";
        }

        //第一页后面条件选择框
        private void onlineCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGetInfo();
        }

        //第一个选项卡中点击datagridview控件时进行的操作
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClickRefresh();
        }

        private void CellClickRefresh()
        {
            enableKongJian();
            string a = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string b = dataGridView1.CurrentRow.Cells["当前是否在线"].Value.ToString();
            string c = dataGridView1.CurrentRow.Cells["允许登录"].Value.ToString();
            string d = dataGridView1.CurrentRow.Cells["用户权限"].Value.ToString();
            string e1 = dataGridView1.CurrentRow.Cells["用户备注"].Value.ToString();
            if (a.Equals(""))
                disableKongJian();
            this.label1.Text = "用户 " + a + " ";
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
            this.label28.Text = "当前用户 " + a + " 权限隶属于[" + d + "]";

            if (d.Equals("普通用户"))
            {
                this.qyCbx.Visible = true;
                this.qyButton.Visible = true;
                this.qySetButton.Visible = true;
            }
            else
            {
                this.qyCbx.Visible = false;
                this.qyButton.Visible = false;
                this.qySetButton.Visible = false;
            }

            this.setCtntTbx.Text = e1;
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
            this.button2.Visible = true;
            this.button4.Visible = true;
            this.label26.Visible = true;
            this.label28.Visible = true;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.button9.Visible = true;
            this.button10.Visible = true;
            this.button11.Visible = true;
            this.setCtntLbl.Visible = true;
            this.setCtntTbx.Visible = true;
            this.setCtntBtn.Visible = true;
            this.yewuButton.Visible = true;
            this.marketButton.Visible = true;
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
            this.button2.Visible = false;
            this.button4.Visible = false;
            this.label26.Visible = false;
            this.label28.Visible = false;
            this.button7.Visible = false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button11.Visible = false;
            this.setCtntLbl.Visible = false;
            this.setCtntTbx.Visible = false;
            this.setCtntBtn.Visible = false;
            this.yewuButton.Visible = false;
            this.marketButton.Visible = false;
        }

        //第一个选项卡中的“修改”按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            modifyAllowLogin();
        }

        private void dgvGetInfoT()
        {
            Thread dgv = new Thread(new ThreadStart(dgvGetInfo));
            dgv.IsBackground = true;
            dgv.Start();
        }

        //第一个选项卡中Datagridview窗体的信息获取  开始
        private void dgvGetInfo()
        {
            try
            {
                string prov = provinceCbx.Text;
                string ol = onlineCbx.Text;
                if (prov.Equals("显示全部"))
                {
                    dgvGetInfoSqlExecute("where isdel='1'");
                }
                if (prov.Equals("省区"))
                {
                    dgvGetInfoSqlExecute("where user_province like '%" + ol + "%' and isdel='1'");
                }
                if (prov.Equals("在线状态"))
                {
                    if (ol.Equals("在线"))
                        ol = "(online='1' or online='2')";
                    else
                        ol = "online='0'";
                    dgvGetInfoSqlExecute("where " + ol + " and isdel='1'");
                }
                if (prov.Equals("区域代理"))
                {
                    dgvGetInfoSqlExecute("where parent_name = '" + ol + "' and isdel='1'");
                }
            }
            catch
            {

            }
            bindQuYuCbx();
        }

        /// <summary>
        /// 刷新datagridview时执行的sql
        /// 参数where是查询条件
        /// </summary>
        private void dgvGetInfoSqlExecute(string where)
        {
            //设定给datagridview的select列名
            string displaySqlSelect = "user_name as '用户名',user_realname as '姓名',user_id as '身份证号',user_phone as '手机/电话',user_qq as 'QQ/MSN',user_province as '所在地区'," +
            "CASE user_vali when '1' then'总代理' when '3' then '省级代理' when '4' then '市级代理' when '5' then '区域代理' when '6' then '市场专员' when '7' then '业务员' ELSE '普通用户' end AS '用户权限'," +
            "CASE allowlogin when '1' then'是' ELSE'否' end AS '允许登录',machinecode as '机器码',lastloginplace as '上次登录地点',lastlogintime as '上次登录时间'," +
            "registplace as '注册地点',registtime as '注册时间',case online when '1' then '在线' when '2' then '在线' else '离线' end as '当前是否在线',`content` as '用户备注',parent_realname as '区域领导'," +
            "soft_version as '软件版本' ";

            DataTable tb = lms.conn("select " + displaySqlSelect + " from " + Global.sqlUserTable + " " + where + "");

            dataGridView1.DataSource = tb;
            dataGridView1.DataMember = tb.TableName;

            DataTable cu = lms.conn("select count(user_id) as 总计 from " + Global.sqlUserTable + " " + where + "");
            DataRow dr = cu.Rows[0];
            this.sumUserLabel.Text = "共有 " + dr[0].ToString() + " 位用户";
        }
        //第一个选项卡中Datagridview窗体的信息获取  结束

        //选项卡一，按姓名搜索    开始
        private void searchUser()
        {
            string searchTag = this.searchInput.Text.Trim();
            if (searchTag.Length == 0)
            {
                return;
            }

            string where = "where (user_realname LIKE '%" + searchTag + "%' or user_name LIKE '%" + searchTag + "%')  and isdel='1'";
            dgvGetInfoSqlExecute(where);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchUser();
        }
        //选项卡一，按姓名搜索    结束

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
                lms.conn("update " + Global.sqlUserTable + " set allowlogin='" + radioValue + "' where user_name='" + user_name + "'");
                MessageBox.Show("修改用户权限成功！", "恭喜");
            }
            catch
            {
                MessageBox.Show("修改用户权限失败，请稍后再试！", "友情提示");
            }
            dgvGetInfo();
            CellClickRefresh();
        }

        //第一个选项卡中“手动下线”的按钮点击
        private void button7_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            try
            {
                lms.conn("update " + Global.sqlUserTable + " set online='0' where user_name='" + user_name + "'");
                MessageBox.Show("手动设置用户: " + user_realname + " 下线成功！", "恭喜");
            }
            catch
            {
                MessageBox.Show("手动设置用户下线失败，请稍后再试！", "友情提示");
            }

            dgvGetInfo();
            CellClickRefresh();
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        private void setProxy(string msgAsk, string msgSuccess, string sql, int user_vali)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            try
            {
                DialogResult dr = MessageBox.Show(msgAsk, "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    lms.conn(sql);
                    if(user_vali!=5)
                        lms.conn("update " + Global.sqlUserTable + " set `parent_name`='',parent_realname='' where `parent_name`='" + user_name + "'");
                    MessageBox.Show(msgSuccess, "设置成功");
                    dgvGetInfo();
                    CellClickRefresh();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("设置失败，请稍后再试！\r\n 错误信息：" + e.Message, "友情提示");
            }
        }

        //第一个选项卡中“提升省代”的按钮点击
        private void button8_Click(object sender, EventArgs e)
        {
            int user_vali = 3;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();

            string msgAsk = "您确定将用户: " + user_realname + " 设置为省级代理？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "提示用户: " + user_realname + " 权限至[省级代理]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        //第一个选项卡中“提升为区域代理”的按钮点击
        private void button11_Click(object sender, EventArgs e)
        {
            int user_vali = 5;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();

            string msgAsk = "您确定将用户: " + user_realname + " 设置为区域代理？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "提示用户: " + user_realname + " 权限至[区域代理]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        //第一个选项卡中“提升为市级代理”的按钮点击
        private void button10_Click(object sender, EventArgs e)
        {
            int user_vali = 4;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();

            string msgAsk = "您确定将用户: " + user_realname + " 设置为市级代理？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "提示用户: " + user_realname + " 权限至[市级代理]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        //第一个选项卡中“降级为普通用户”的按钮点击
        private void button9_Click(object sender, EventArgs e)
        {
            int user_vali = 2;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值

            string msgAsk = "您确定将用户: " + user_realname + " 降级为普通用户？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "设置用户: " + user_realname + " 权限至[普通用户]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        /// <summary>
        /// 设为市场专员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void marketButton_Click(object sender, EventArgs e)
        {
            int user_vali = 6;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值

            string msgAsk = "您确定将用户: " + user_realname + " 设置为市场专员？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "设置用户: " + user_realname + " 权限至[市场专员]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        /// <summary>
        /// 设为业务员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yewuButton_Click(object sender, EventArgs e)
        {
            int user_vali = 7;
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值

            string msgAsk = "您确定将用户: " + user_realname + " 设置为业务员？";
            string sql = "update " + Global.sqlUserTable + " set user_vali='" + user_vali + "' where user_name='" + user_name + "'";
            string msgSuccess = "设置用户: " + user_realname + " 权限至[业务员]成功！";

            setProxy(msgAsk, msgSuccess, sql, user_vali);
        }

        /// <summary>
        /// 第一页给当前选中用户属于区域代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qySetButton_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string parent_name = qyCbx.SelectedValue.ToString();//用户名
            string parent_realname = qyCbx.Text;//姓名
            try
            {
                lms.conn("update " + Global.sqlUserTable + " set `parent_name`='" + parent_name + "',parent_realname='" + parent_realname + "' where user_name='" + user_name + "'");
                MessageBox.Show("设置成功，成功将用户 " + user_realname + " 添加至 " + parent_realname + " 旗下！", "恭喜");
            }
            catch
            {
                MessageBox.Show("设置失败，请稍后再试！", "友情提示");
            }
            dgvGetInfo();
            CellClickRefresh();
        }

        /// <summary>
        /// 第一页给当前选中用户取消属于区域代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qyButton_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string user_realname = dataGridView1.CurrentRow.Cells["姓名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            try
            {
                lms.conn("update " + Global.sqlUserTable + " set `parent_name`='',`parent_realname`='' where user_name='" + user_name + "'");
                MessageBox.Show("设置成功，成功将用户 " + user_realname + " 取消归属！", "恭喜");
            }
            catch
            {
                MessageBox.Show("设置失败，请稍后再试！", "友情提示");
            }
            dgvGetInfo();
            CellClickRefresh();
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
                    lms.conn("update " + Global.sqlUserTable + " set isdel='-1' where user_name='" + user_name + "'");

                    MessageBox.Show("删除成功！", "提示");

                    dgvGetInfo();
                    CellClickRefresh();
                }
                catch { MessageBox.Show("删除失败，请稍后重试！", "提示"); }
            }
        }

        //第一个选项卡中“修改用户信息”的按钮点击
        private void button4_Click(object sender, EventArgs e)
        {
            ModifyInfoByAdmin miba = new ModifyInfoByAdmin(dataGridView1.CurrentRow.Cells["用户名"].Value.ToString());
            DialogResult dr = miba.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dgvGetInfo();
                CellClickRefresh();
            }
            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        //第一个选项卡中“设置用户备注”的按钮点击
        private void setCtntBtn_Click(object sender, EventArgs e)
        {
            string user_name = dataGridView1.CurrentRow.Cells["用户名"].Value.ToString();//得到当前用户选中的那行的第一列的值
            string contentValue = this.setCtntTbx.Text;
            try
            {
                lms.conn("update " + Global.sqlUserTable + " set `content`='" + contentValue + "' where user_name='" + user_name + "'");
                MessageBox.Show("设置用户备注成功！", "恭喜");
            }
            catch
            {
                MessageBox.Show("设置用户备注失败，请稍后再试！", "友情提示");
            }

            dgvGetInfo();
            CellClickRefresh();
        }
        #endregion

        #region 第二个选项卡

        //第二个选项卡中“添加用户”按钮的点击
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
            {
                writeToDB();
            }
        }

        //第二个选项卡检查添加用户textbox控件
        private Boolean checkTextBox()
        {
            bool tf = false;
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空", "温馨提示");
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

        //第二个选项卡添加用户写入数据库
        private void writeToDB()
        {
            string user_name = textBox1.Text;
            string user_pass = textBox2.Text;
            if (user_pass.Equals(""))
                user_pass = "123456";
            ToMD5 md5 = new ToMD5();//将密码加密为md5
            user_pass = md5.Encrypt(user_pass);
            string user_realname = textBox4.Text;
            string user_id = textBox5.Text;
            string user_phone = textBox9.Text;
            string user_qq = textBox10.Text;
            string user_province = textBox7.Text + "省" + textBox6.Text + "市";
            if (textBox7.Text.Equals("") && textBox6.Text != "")
                user_province = textBox6.Text + "市";
            if (user_province.Equals("省市"))
                user_province = "暂无";
            string machinecode = textBox3.Text;
            string registtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string registplace = getIP.GetWebCity();
            int i = registplace.LastIndexOf(":") + 1;
            int j = registplace.IndexOf("市");
            registplace = registplace.Substring(i, j - i + 1);
            string allowlogin = "";
            if (this.radioButton1.Checked == true)
                allowlogin = "1";
            if (this.radioButton2.Checked == true)
                allowlogin = "0";

            try
            {
                DataTable dtMCode = lms.conn("select * from " + Global.sqlUserTable + " where user_name='" + user_name + "'");
                if (dtMCode.Rows.Count == 0)
                {
                    try
                    {
                        lms.conn("insert into " + Global.sqlUserTable + "(user_name,user_pass,user_realname,user_id,user_phone,user_qq,user_province,allowlogin,machinecode,registtime,registplace) values('" + user_name + "','" + user_pass + "','" + user_realname + "','" + user_id + "','" + user_phone + "','" + user_qq + "','" + user_province + "','" + allowlogin + "','" + machinecode + "','" + registtime + "','" + registplace + "')");
                        MessageBox.Show("添加成功", "温馨提示");
                        clrTbx();
                    }
                    catch
                    {
                        MessageBox.Show("添加失败，请检查输入然后重试此操作。", "提示");
                    }
                }
                else
                    MessageBox.Show("用户名已存在，请换一个用户名再试", "温馨提示");
            }
            catch
            {
                MessageBox.Show("添加失败，请稍后重试。", "温馨提示");
            }
        }

        //第二个选项卡当添加完用户以后自动清空页面的textbox
        private void clrTbx()
        {
            foreach (Control ctl in this.tabControl1.TabPages[1].Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = string.Empty;
                }
            }
            textBox2.Text = "123456";
            radioButton2.Checked = true;
        }

        #region 第二个选项卡中添加用户的textbox_changed
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                // 將 TextBox1.Text 的中文字刪除
                for (int i = textBox2.Text.Length - 1; i >= 0; i--)
                {
                    // 利用正則表達式，其中 \u4E00-\u9fa5 表示中文
                    if (!(System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Substring(i, 1), @"^[A-Za-z0-9]+$")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.Substring(i, 1), @" ")))
                    {
                        textBox2.Text = textBox2.Text.Remove(i, 1);
                    }
                }
                textBox2.SelectionStart = textBox2.Text.Length;
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
        #endregion

        #endregion

        #region 第三个选项卡

        //第三个选项卡中获取现有的公告信息
        private void getGgT()
        {
            Thread t = new Thread(new ThreadStart(getGg));
            t.IsBackground = true;
            t.Start();
        }

        private void getGg()
        {
            DataTable dt = lms.conn("select * from msg");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                SetMsgText8Box(dr["msg_login"].ToString());
                SetMsgText11Box(dr["msg_main"].ToString());
            }
        }

        private delegate void WriteMsgTextDelegate(string args);

        private void SetMsgText8Box(string args)
        {
            if (this.textBox8.IsHandleCreated)
            {
                this.textBox8.Invoke(new WriteMsgTextDelegate(WriteMsgText8Box), args);
            }
        }

        private void WriteMsgText8Box(string args)
        {
            this.textBox8.Text = args;
        }

        private void SetMsgText11Box(string args)
        {
            if (this.textBox11.IsHandleCreated)
            {
                this.textBox11.Invoke(new WriteMsgTextDelegate(WriteMsgText11Box), args);
            }
        }

        private void WriteMsgText11Box(string args)
        {
            this.textBox11.Text = args;
        }

        //第三个选项卡中设置公告信息
        private void setGg()
        {
            string msg_login = this.textBox8.Text;
            string msg_main = this.textBox11.Text;
            try
            {
                lms.conn("update msg set msg_login='" + msg_login + "',msg_main='" + msg_main + "'");
                MessageBox.Show("修改成功", "温馨提示");
            }
            catch
            {
                MessageBox.Show("修改失败，请稍后再试！", "温馨提示");
            }
        }

        //第三个选项卡中“修改并提交”公告按钮点击
        private void button5_Click(object sender, EventArgs e)
        {
            setGg();
        }

        //第三个选项卡中“清空”按钮的点击
        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox11.Text = "";
            this.textBox8.Text = "";
        }

        #endregion


    }
}
