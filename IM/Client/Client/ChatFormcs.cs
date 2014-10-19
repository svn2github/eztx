using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 添加额外命名空间
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class ChatFormcs : Form
    {
        private string selfUserName;
        private string peerUserName;
        private IPEndPoint peerUserIPEndPoint;
        private UdpClient sendUdpClient;

        public ChatFormcs()
        {
            InitializeComponent();
        }

        public void SetUserInfo(string selfName, string peerName, IPEndPoint peerIPEndPoint)
        {
            selfUserName = selfName;
            peerUserName = peerName;
            peerUserIPEndPoint = peerIPEndPoint;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 匿名发送
            sendUdpClient = new UdpClient();
            // 启动发送线程
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(string.Format("talk,{0},{1},{2}", DateTime.Now.ToLongTimeString(), selfUserName, txbSend.Text));
            richtxbTalkinfo.AppendText(selfUserName + "    " + DateTime.Now.ToLongTimeString() + Environment.NewLine + txbSend.Text);
            richtxbTalkinfo.AppendText(Environment.NewLine);
            // 将控件内容滚动到当前插入符的位置
            richtxbTalkinfo.ScrollToCaret();
            txbSend.Text = "";
            txbSend.Focus();

        }
        private void SendMessage(object obj)
        {
            string message = (string)obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            sendUdpClient.Send(sendbytes,sendbytes.Length,peerUserIPEndPoint);
            sendUdpClient.Close();
        }

        public void ShowTalkInfo(string peerName, string time, string content)
        {
            richtxbTalkinfo.AppendText(peerName + "    " + time + Environment.NewLine + content);
            richtxbTalkinfo.AppendText(Environment.NewLine);
            richtxbTalkinfo.ScrollToCaret();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
