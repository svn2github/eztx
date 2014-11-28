using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _3d.Function
{
    class LinkMySql
    {
        #region 软件数据库连接

        /// <summary>
        /// 传入SQL语句，返回DataTable结果
        /// </summary>
        /// <param name="sql">String SQL</param>
        /// <returns>DataTable</returns>
        public DataTable conn(string sql)
        {
            DataTable t = new DataTable();
            MySqlConnection conn = null;
            MySqlCommand command = null;
            //conn = new MySqlConnection("Server=svn.breadth.cn;User Id=root;Password=breadth2009;Persist Security Info=True;Database=mez;Port=3307;CharSet=utf8");
            conn = new MySqlConnection("Server=mysql.sql73.cdncenter.net;User Id=sq_mezboy;Password=mez199023;Persist Security Info=True;Database=sq_mezboy;Port=3306;CharSet=utf8");
            //conn = new MySqlConnection("Server=mysql.sql47.cdncenter.net;User Id=sq_maenze;Password=mez199023;Persist Security Info=True;Database=sq_maenze;Port=3306;CharSet=utf8");
            command = conn.CreateCommand();
            command.CommandText = sql;
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            try
            {
                da.Fill(t);
            }
            catch(Exception e)
            {
                MessageBox.Show("连接数据库失败，请稍后重试或者联系管理员！", "失败！", MessageBoxButtons.OK);
                Application.Exit();
                throw e;
            }
            conn.Close();
            return t;
        }
        #endregion
    }
}
