using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string timeHour = tbxHour.Text;
            timeHour = Convert.ToInt32(timeHour).ToString("D2");
            string timeMin = tbxMin.Text;
            timeMin=Convert.ToInt32(timeMin).ToString("D2");
            string timeContent = tbxContent.Text;
            if (!string.IsNullOrEmpty(timeHour) && !string.IsNullOrEmpty(timeMin))
            {
                dataGridView1.Rows.Add(timeHour+"时"+timeMin+"分",timeContent);
                timer2.Start();
            }
            dgvBindData();
        }

        
        private void dgvBindData()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.NotifyCurrentCellDirty(false);
            this.dataGridView1.AllowUserToAddRows = false;

            //服务器时间
            //SNTPTimeClient client = new SNTPTimeClient("210.72.145.44", "123");
            //client.Connect();
            //string strTest = client.ToString();
        }

        private void tbxHour_TextChanged(object sender, EventArgs e)
        {
            if (tbxHour.Text.Length == 2)
                tbxMin.Focus();
            else
                tbxHour.Focus();
        }

        private void tbxMin_TextChanged(object sender, EventArgs e)
        {
            if (tbxMin.Text.Length == 2)
                btAdd.Focus();
            else
                tbxMin.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            label1.Text = "当前时间:" + DateTime.Now.ToString("HH时mm分ss秒");
            
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<dataGridView1.Rows.Count;i++ )
            {
                dataGridView1.Rows[i].Cells[0].Value = "";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 1000;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (label1.Text.IndexOf(dataGridView1.Rows[i].Cells[0].Value.ToString()) > 0 && dataGridView1.Rows[i].Cells[2].Value==null)
                {
                    timer2.Stop();
                    DialogResult dr=MessageBox.Show("闹钟响了","提示",MessageBoxButtons.OK);
                    if(dr==DialogResult.OK)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "√";
                        tanChuang tc = new tanChuang();
                        tc.Show();
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
        }

    }
}
