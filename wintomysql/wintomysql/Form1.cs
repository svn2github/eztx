using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySQLDriverCS;

namespace wintomysql
{
    

    public partial class Form1 : Form
    {
        SQLHelper helper = new SQLHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*MySQLConnection conn = null;
            conn = new MySQLConnection(new MySQLConnectionString("svn.breadth.cn", "mez", "root", "breadth2009").AsString);
            conn.Open();

            MySQLCommand commn = new MySQLCommand("set names utf-8", conn);
            commn.ExecuteNonQuery();

            string sql = "select * from note ";
            MySQLDataAdapter mda = new MySQLDataAdapter(sql, conn);

            DataSet ds = new DataSet();
            mda.Fill(ds, "table1");
   
            
            this.dataGrid1.DataSource = ds.Tables["table1"];
            conn.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = title.Text;
            string t= dateTimePicker1.Text;
            string b = content.Text;


            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            string sql = "insert into note()";
            MySQLDataAdapter mda = new MySQLDataAdapter(sql,conn);
            

            try
            {
                conn = base.GetConn();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();

                return i;

                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void content_TextChanged(object sender, EventArgs e)
        {

        }
    }

    
}
