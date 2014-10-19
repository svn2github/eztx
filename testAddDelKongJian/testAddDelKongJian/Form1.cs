using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testAddDelKongJian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = new Button();
            bt.Text = "生成的按钮";
            bt.Name = "bbq";
            bt.Font = new System.Drawing.Font("微软雅黑", 25, FontStyle.Bold);
            bt.FlatStyle = FlatStyle.Flat;
            bt.BackColor = Color.Black;
            bt.ForeColor = Color.White;
            bt.Size = new System.Drawing.Size(200, 100);
            bt.Location = new Point(this.panel1.Width / 2 - bt.Size.Width / 2, this.panel1.Height / 2 - bt.Size.Height / 2);
            this.panel1.Controls.Add(bt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctls in this.panel1.Controls)
            {
                if (ctls.Name.Equals("bbq"))
                {
                    this.panel1.Controls.Remove(ctls);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contmenus();
        }

        public void Contmenus()
        {
            MenuItem m1 = new MenuItem("添加");
            MenuItem m2 = new MenuItem("修改");
            MenuItem[] menuitems = new MenuItem[] { m1, m2 };
            ContextMenu button1ctm = new ContextMenu(menuitems);
            Point p = new Point(0, button3.Size.Height);
            button1ctm.Show(button3,p);
            m1.Click += new System.EventHandler(tianj_click);//选择添加按钮时，添加事件
            m2.Click += new System.EventHandler(tianj1_click);//同上，选择修改按钮
        }
        public void tianj_click(Object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }
        public void tianj1_click(Object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();//先清理一遍，防止重复；当然也可以把以下加入菜单的东西绑定到界面载入时进行
            ToolStripMenuItem tsm = new ToolStripMenuItem();
            ToolStripMenuItem ddd = new ToolStripMenuItem();
            tsm.Text = "手动添加的";//一级菜单名
            ddd.Text = "ddd";//二级菜单名
            ddd.Click += new EventHandler(BBQ_Click);//二级菜单绑定点击事件
            tsm.DropDownItems.Add(ddd);//一级菜单下的二级菜单
            tsm.DropDownItems.Add("巴拉巴拉");//一级菜单下的二级菜单
            tsm.DropDownItems.Add("巴比克").Click += new EventHandler(BBQ_Click);//一级菜单下的二级菜单的点击事件
            contextMenuStrip1.Items.Add(tsm);//添加一个一级菜单

            contextMenuStrip1.Show(button4, 0, button4.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BBQ_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello，酷狗");
        }

        private void 死斗服ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
        }

    }
}
