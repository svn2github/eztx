using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace _3d
{
    class LinkMyMDB
    {
        private static string mdbPath = Application.StartupPath + "\\numGroups.mdb";

        /// <summary>
        /// 读取mdb数据单张表所有数据 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="mdbPath">MDB地址</param>
        /// <param name="success"></param>
        /// <returns></returns>
        public static DataTable ReadAllData(string tableName, ref bool success)
        {
            DataTable dt = new DataTable();
            try
            {
                DataRow dr;
                //1、建立连接 
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=bbq;";
                OleDbConnection odcConnection = new OleDbConnection(strConn);
                //2、打开连接 
                odcConnection.Open();
                //建立SQL查询 
                OleDbCommand odCommand = odcConnection.CreateCommand();
                //3、输入查询语句 
                string sql = "select " + tableName + ".[id]," + tableName + ".[issue]," + tableName + ".[num_group] from " + tableName + ",(select TOP 15 " + tableName + ".[id] from " + tableName + " order by " + tableName + ".[id] desc)a where " + tableName + ".[id]=a.[id] order by " + tableName + ".[id] asc";
                odCommand.CommandText = sql;
                //建立读取 
                OleDbDataReader odrReader = odCommand.ExecuteReader();
                //查询并显示数据 
                int size = odrReader.FieldCount;
                for (int i = 0; i < size; i++)
                {
                    DataColumn dc;
                    dc = new DataColumn(odrReader.GetName(i));
                    dt.Columns.Add(dc);
                }
                while (odrReader.Read())
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < size; i++)
                    {
                        dr[odrReader.GetName(i)] = odrReader[odrReader.GetName(i)].ToString();
                    }
                    dt.Rows.Add(dr);
                }
                //关闭连接 
                odrReader.Close();
                odcConnection.Close();
                success = true;
                return dt;
            }
            catch
            {
                success = false;
                return dt;
            }
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="success">返回成功与失败</param>
        /// <returns>返回DataTable</returns>
        public static DataTable operatingQuery(string sql, ref bool success)
        {
            DataTable dt = new DataTable();
            try
            {
                DataRow dr;
                //1、建立连接 
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=bbq;";
                OleDbConnection odcConnection = new OleDbConnection(strConn);
                //2、打开连接 
                odcConnection.Open();
                //建立SQL查询 
                OleDbCommand odCommand = odcConnection.CreateCommand();
                //3、输入查询语句 
                odCommand.CommandText = sql;
                //建立读取 
                OleDbDataReader odrReader = odCommand.ExecuteReader();
                //查询并显示数据 
                int size = odrReader.FieldCount;
                for (int i = 0; i < size; i++)
                {
                    DataColumn dc;
                    dc = new DataColumn(odrReader.GetName(i));
                    dt.Columns.Add(dc);
                }
                while (odrReader.Read())
                {
                    dr = dt.NewRow();
                    for (int i = 0; i < size; i++)
                    {
                        dr[odrReader.GetName(i)] = odrReader[odrReader.GetName(i)].ToString();
                    }
                    dt.Rows.Add(dr);
                }
                //关闭连接 
                odrReader.Close();
                odcConnection.Close();
                success = true;
                return dt;
            }
            catch
            {
                success = false;
                return dt;
            }
        }

        /// <summary>
        /// 插入期号与开奖号码
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="issue">期号</param>
        /// <param name="numGroup">开奖号码</param>
        /// <returns></returns>
        public static bool insertData(string tableName,string issue,string numGroup)
        {
            try
            {
                //1、建立连接 
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=bbq;";
                OleDbConnection odcConnection = new OleDbConnection(strConn);
                OleDbDataAdapter xAdapter = new OleDbDataAdapter();
                //2、打开连接 
                odcConnection.Open();
                //建立SQL查询 
                OleDbCommand odCommand = odcConnection.CreateCommand();
                //3、输入查询语句 
                string sql = "insert into " + tableName + "(issue,num_group) values('" + issue + "','" + numGroup + "')";
                OleDbCommand sqlCmd = new OleDbCommand(sql, odcConnection);//要有一个command去执行你的sql
                sqlCmd.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 清空表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="issue">期号</param>
        /// <param name="numGroup">开奖号码</param>
        /// <returns></returns>
        public static bool clearData(string tableName)
        {
            try
            {
                //1、建立连接 
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbPath + ";Jet OLEDB:Database Password=bbq;";
                OleDbConnection odcConnection = new OleDbConnection(strConn);
                OleDbDataAdapter xAdapter = new OleDbDataAdapter();
                //2、打开连接 
                odcConnection.Open();
                //建立SQL查询 
                OleDbCommand odCommand = odcConnection.CreateCommand();
                //3、输入查询语句 
                string sql = "delete from " + tableName + "";
                OleDbCommand sqlCmd = new OleDbCommand(sql, odcConnection);//要有一个command去执行你的sql
                sqlCmd.ExecuteNonQuery();
                odcConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
