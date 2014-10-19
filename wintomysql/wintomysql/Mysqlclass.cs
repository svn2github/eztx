using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySQLDriverCS;

namespace wintomysql
{
    public class DBHelper
    {
        /// <summary>
        /// 得到连接对象
        /// </summary>
        /// <returns></returns>
        public void GetConn()
        {
            MySQLConnection conn = null;
            conn = new MySQLConnection(new MySQLConnectionString("svn.breadth.cn", "mez", "root", "breadth2009").AsString);
            conn.Open();
            MySQLCommand comn = new MySQLCommand("set names utf-8", conn);
            comn.ExecuteNonQuery();
        }
    }

    public class SQLHelper : DBHelper
    {

    }
}
