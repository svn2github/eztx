using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace UdpMine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //创建一个Thread实例   
        private Thread thread1;
        //创建一个UdpClient实例
        private UdpClient udpClient;
        private UdpClient udpServer;




        private void Form1_Load(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(ReceiveMessage));
            thread1.IsBackground=true;
            thread1.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            udpServer = new UdpClient(11500);
            try
            {
                udpServer.Connect(Dns.GetHostName().ToString(), 11000);//IPAddress.Parse("192.168.1.255")
                Byte[] sendBytes = Encoding.UTF8.GetBytes(textBox1.Text);

                udpServer.Send(sendBytes, sendBytes.Length);

                udpServer.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端" + ex.ToString());
            }
        }

        private void ReceiveMessage()
        {
            udpClient = new UdpClient(11000);
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);

                this.textBox2.Text = "来自ip:" +RemoteIpEndPoint.Address.ToString() +
                                     "端口号:" +RemoteIpEndPoint.Port.ToString() + "\r\n" + returnData;

                udpClient.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("客户端" + e.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭连接
            udpClient.Close();
            udpServer.Close();
            //终止线程
            thread1.Abort();
        }


    }
}
