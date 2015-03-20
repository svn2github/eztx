using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;

using MySql.Data.MySqlClient;

namespace _3d.Function
{
    class LinkMySql
    {
        
        #region 数据库配置

        /// <summary>
        /// 数据库配置
        /// </summary>
        public void getSQLcfg(string serverAddress)
        {
            string serverXmlFile = serverAddress;

            WebConnect wc = new WebConnect();
            string pageXML = wc.getOnlineXML(serverXmlFile);

            //读取数据库信息
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(pageXML);
            XmlNode rootNode = xml.SelectSingleNode("MySQLConfig");//得到根节点
            XmlNode addressNode = rootNode.SelectSingleNode("Address");//地址
            XmlNode portNode = rootNode.SelectSingleNode("Port");//端口
            XmlNode usernameNode = rootNode.SelectSingleNode("Username");//用户名
            XmlNode passwordNode = rootNode.SelectSingleNode("Password");//密码
            XmlNode databaseNode = rootNode.SelectSingleNode("Database");//数据库
            XmlNode charsetNode = rootNode.SelectSingleNode("Charset");//编码
            XmlNode use_tableNode = rootNode.SelectSingleNode("use_table");//所用表

            Global.sqlAddress = addressNode.InnerText;
            Global.sqlPort = portNode.InnerText;
            Global.sqlUsername = usernameNode.InnerText;
            Global.sqlPwd = passwordNode.InnerText;
            Global.sqlDB = databaseNode.InnerText;
            Global.sqlCharset = charsetNode.InnerText;
            Global.sqlUserTable = use_tableNode.InnerText;

            //读取当前软件版本
            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            xml = new XmlDocument();
            xml.Load(localXmlFile);
            XmlNode xn = xml.SelectSingleNode("//Files/File");
            Global.version = xn.Attributes["Ver"].InnerText;
        }
        #endregion


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
            //conn = new MySqlConnection("Server=mysql.sql73.cdncenter.net;User Id=sq_mezboy;Password=mez199023;Persist Security Info=True;Database=sq_mezboy;Port=3306;CharSet=utf8");
            //conn = new MySqlConnection("Server=mysql.sql47.cdncenter.net;User Id=sq_maenze;Password=mez199023;Persist Security Info=True;Database=sq_maenze;Port=3306;CharSet=utf8");
            conn = new MySqlConnection(
                "Server=" + Global.sqlAddress 
                + ";User Id=" + Global.sqlUsername 
                + ";Password=" + Global.sqlPwd 
                + ";Persist Security Info=True;Database=" + Global.sqlDB 
                + ";Port=" + Global.sqlPort 
                + ";CharSet=" + Global.sqlCharset + "");
            command = conn.CreateCommand();
            command.CommandText = sql;
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            try
            {
                da.Fill(t);
            }
            catch (Exception e)
            {
                MessageBox.Show("连接数据库失败，请稍后重试！", "失败！", MessageBoxButtons.OK);
                Application.Exit();
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return t;
        }
        #endregion
    }
}
