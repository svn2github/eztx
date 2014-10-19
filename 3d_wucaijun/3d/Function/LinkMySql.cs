using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace _3d.Function
{
    class LinkMySql
    {
        #region 软件数据库连接

        /// <summary>
        /// 连接数据库，传入sql语句就行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet conn(string sql)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            //MySqlDataReader reader = null;
            //conn = new MySqlConnection("Server=svn.breadth.cn;User Id=root;Password=breadth2009;Persist Security Info=True;Database=mez;Port=3307;CharSet=utf8");
            conn = new MySqlConnection("Server=mysql.sql73.cdncenter.net;User Id=sq_mezboy;Password=mez199023;Persist Security Info=True;Database=sq_mezboy;Port=3306;CharSet=utf8");
            //conn = new MySqlConnection("Server=mysql.sql47.cdncenter.net;User Id=sq_maenze;Password=mez199023;Persist Security Info=True;Database=sq_maenze;Port=3306;CharSet=utf8");
            command = conn.CreateCommand();
            command.CommandText = sql;
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            conn.Close();
            return ds;
        }
        #endregion
    }
}
