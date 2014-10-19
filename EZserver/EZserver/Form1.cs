using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Resources;
using System.Diagnostics;
using System.Runtime;
using System.ServiceProcess;

namespace EZserver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AskYou ay = new AskYou();

        protected string GetIP()   //获取本地IP 
        {
            System.Net.NetworkInformation.TcpConnectionInformation connection = Array.FindAll(
    System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections(),
    o => !System.Net.IPAddress.IsLoopback(o.LocalEndPoint.Address)
).FirstOrDefault();
            string ip = "";
            if (connection != null)
            {
                ip = connection.LocalEndPoint.Address.ToString();
            }
            return ip;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runBat("RayzenWebserverCFG.exe");

            openLabel();
            try
            {
                if (ServiceIsExisted("RayzenWebserver") == false && ServiceIsExisted("RayzenWebserverDB") == false)
                {
                    DialogResult dr = ay.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        runBat("install.bat");
                    }
                    if (dr == DialogResult.Cancel)
                    {
                        this.Show();
                    }
                }
            }
            catch {
                MessageBox.Show("发现错误，请先删除服务再安装即可。","提示");
            }

            this.linkLabel1.Text = GetIP() + ":8100";
            this.timer1.Interval = 1000;
            this.timer1.Start();
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        private void runBat(string batName)
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + "\\" + batName;
                if (File.Exists(path))
                {
                    Process MyProcess = new Process();
                    MyProcess.StartInfo.FileName = path;
                    MyProcess.StartInfo.Verb = "Open";
                    MyProcess.StartInfo.CreateNoWindow = true;//不创建窗口
                    MyProcess.StartInfo.UseShellExecute = false;//不使用外壳执行
                    MyProcess.Start();
                }
                else
                {
                    MessageBox.Show("未找到安装文件 " + batName + " ，请重新安装以后再试。","提示");
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            runBat("start_srv.bat");
        }

        /// <summary>
        /// 重启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            runBat("restart_srv.bat");
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            runBat("stop_srv.bat");
        }

        /// <summary>
        /// 判断服务是否存在
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        private bool ServiceIsExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == serviceName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 服务是否正在运行
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        private string ServiceIsAlive(string serviceName)
        {
            ServiceController cs = new ServiceController();
            cs.MachineName = GetIP(); //主机名
            cs.ServiceName = serviceName; //服务名
            cs.Refresh();
            string srvRun = "";
            if (cs.Status == ServiceControllerStatus.Running)
            {
                //服务在运行
                srvRun = serviceName + "正在运行";
            }
            if (cs.Status == ServiceControllerStatus.Stopped)
            {
                //服务在运行
                srvRun = serviceName + "已停止";
            }
            return srvRun;
        }

        /// <summary>
        /// 启用两个label控件
        /// </summary>
        private void openLabel()
        {
            this.label2.Visible = true;
            this.label3.Visible = true;
        }

        private void 安装服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runBat("install.bat");
        }

        private void 删除服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runBat("unregist.bat");
        }

        private void 卸载程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            runBat("uninstall.bat");
        }

        /// <summary>
        /// 打开主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string targetURL = "http://" + this.linkLabel1.Text + "/index.xhtml";
            //targetURL = "http://" + this.linkLabel1.Text + "/ok/index.jsp";
            System.Diagnostics.Process.Start(targetURL);
        }

        /// <summary>
        /// picturebox1绿色启动
        /// </summary>
        private void picBox1GreenEnable()
        {
            this.pictureBox1.Location = new Point(this.label2.Location.X + this.label2.Width + 5, this.label2.Location.Y + 1);
            Image img = EZserver.Properties.Resources.green;
            this.pictureBox1.Image = img;
            this.pictureBox1.Visible = true;
        }

        /// <summary>
        /// picturebox1红色启动
        /// </summary>
        private void picBox1RedEnable()
        {
            this.pictureBox1.Location = new Point(this.label2.Location.X + this.label2.Width + 5, this.label2.Location.Y + 1);
            Image img = EZserver.Properties.Resources.red;
            this.pictureBox1.Image = img;
            this.pictureBox1.Visible = true;
        }

        /// <summary>
        /// picturebox2绿色启动
        /// </summary>
        private void picBox2GreenEnable()
        {
            this.pictureBox2.Location = new Point(this.label3.Location.X + this.label3.Width + 5, this.label3.Location.Y + 1);
            Image img = EZserver.Properties.Resources.green;
            this.pictureBox2.Image = img;
            this.pictureBox2.Visible = true;
        }

        /// <summary>
        /// picturebox2红色启动
        /// </summary>
        private void picBox2RedEnable()
        {
            this.pictureBox2.Location = new Point(this.label3.Location.X + this.label3.Width + 5, this.label3.Location.Y + 1);
            Image img = EZserver.Properties.Resources.red;
            this.pictureBox2.Image = img;
            this.pictureBox2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ServiceIsExisted("RayzenWebserver") == true)
                {
                    if (ServiceIsAlive("RayzenWebserver").Contains("运行"))
                    {
                        this.label2.Text = ServiceIsAlive("RayzenWebserver");
                        picBox1GreenEnable();
                    }
                    else
                    {
                        this.label2.Text = ServiceIsAlive("RayzenWebserver");
                        picBox1RedEnable();
                    }
                }
                else
                {
                    this.label2.Text = "RayzenWebserver未安装";
                    picBox1RedEnable();
                }

                if (ServiceIsExisted("RayzenWebserverDB") == true)
                {
                    if (ServiceIsAlive("RayzenWebserverDB").Contains("运行"))
                    {
                        this.label3.Text = ServiceIsAlive("RayzenWebserverDB");
                        picBox2GreenEnable();
                    }
                    else
                    {
                        this.label3.Text = ServiceIsAlive("RayzenWebserverDB");
                        picBox2RedEnable();
                    }
                }
                else
                {
                    this.label3.Text = "RayzenWebserverDB未安装";
                    picBox2RedEnable();
                }
            }
            catch { }
        }

        //关闭的时候会自动把服务删除
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //runBat("unregist.bat");
        }
    }
}
