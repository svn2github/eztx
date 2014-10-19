using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDPBroadcast
{
    /// <summary>
    /// 在界面上，用户可以设置本地进程的IP地址和端口号，并将地址加入某个组播组；
    /// 可以输入发送消息的目的组的地址，并且勾选“广播”复选框将采用广播的方式发送信息
    /// 在界面上点击“接受按钮”就启动接收线程，这样程序就可以接收广播或组播的信息
    /// </summary>
    public partial class UdpBroadcasefrm : Form
    {
        private UdpClient sendUdpClient;
        private UdpClient receiveUdpClient;
        // 组播IP地址
        IPEndPoint broadcastIpEndPoint;
        public UdpBroadcasefrm()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            tbxlocalip.Text = ips[5].ToString();
            tbxlocalport.Text = "8002";
            // 默认组,组播地址是有范围
            // 具体关于组播和广播的介绍参照我上一篇博客UDP编程
            // 本地组播组
            tbxGroupIp.Text = "224.0.0.1";
            // 发送到的组播组
            tbxSendToGroupIp.Text = "224.0.0.1";
        }

        // 设置加入组
        private void chkbxJoinGtoup_Click(object sender, EventArgs e)
        {
            if (chkbxJoinGtoup.Checked == true)
            {
                tbxGroupIp.Enabled = false;
            }
            else
            {
                tbxGroupIp.Enabled = true;
                tbxGroupIp.Focus();
            }
        }

        // 选择发送模式后设置
        private void chkbxBroadcast_Click(object sender, EventArgs e)
        {
            if (chkbxBroadcast.Checked == true)
            {
                tbxSendToGroupIp.Enabled = false;
            }
            else
            {
                tbxSendToGroupIp.Enabled = true;
                tbxSendToGroupIp.Focus();
            }
        }

        // 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbxMessageSend.Text == "")
            {
                MessageBox.Show("消息内容不能为空！","提示");
                return;
            }

            // 根据选择的模式发送信息
            if (chkbxBroadcast.Checked == true)
            {
                // 广播模式(自动获得子网中的IP广播地址)
                broadcastIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 8002);
            }
            else
            {
                // 组播模式
                broadcastIpEndPoint = new IPEndPoint(IPAddress.Parse(tbxSendToGroupIp.Text), 8002);
            }

            // 启动发送线程发送消息
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(tbxMessageSend.Text);
        }

        // 发送消息
        private void SendMessage(object obj)
        {
            string message = obj.ToString();
            byte[] messagebytes = Encoding.Unicode.GetBytes(message);
            sendUdpClient = new UdpClient();
            // 发送消息到组播或广播地址
            sendUdpClient.Send(messagebytes, messagebytes.Length, broadcastIpEndPoint);
            sendUdpClient.Close();
            
            // 清空编辑消息框
            ResetMessageText(tbxMessageSend);
        }

        // 利用委托回调机制来实现界面上的消息清空操作
        delegate void ResetMessageTextCallBack(TextBox textbox);
        private void ResetMessageText(TextBox textbox)
        {
            if (textbox.InvokeRequired)
            {
                ResetMessageTextCallBack resetMessageCallback = ResetMessageText;
                textbox.Invoke(resetMessageCallback, new object[] { textbox });
            }
            else
            {
                textbox.Clear();
                textbox.Focus();
            }
        }

        // 接收消息
        private void btnReceive_Click(object sender, EventArgs e)
        {
            chkbxJoinGtoup.Enabled = false;
            // 创建接收套接字
            IPAddress localIp = IPAddress.Parse(tbxlocalip.Text);
            IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(tbxlocalport.Text));
            receiveUdpClient = new UdpClient(localIpEndPoint);
            // 加入组播组
            if (chkbxJoinGtoup.Checked == true)
            {
                receiveUdpClient.JoinMulticastGroup(IPAddress.Parse(tbxGroupIp.Text));
                receiveUdpClient.Ttl = 50;
            }

            // 启动接受线程
            Thread threadReceive = new Thread(ReceiveMessage);
            threadReceive.Start();
        }

        // 接受消息方法
        private void ReceiveMessage()
        {
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    // 关闭receiveUdpClient时此时会产生异常
                    byte[] receiveBytes = receiveUdpClient.Receive(ref remoteIpEndPoint);
                    string receivemessage = Encoding.Unicode.GetString(receiveBytes);

                    // 显示消息内容
                    ShowMessage(lstMessageBox, string.Format("{0}[{1}]", remoteIpEndPoint, receivemessage));
                }
                catch
                {
                    break;
                }
            }
        }
        // 通过委托回调机制显示消息内容
        delegate void ShowMessageCallBack(ListBox listbox,string text);
        private void ShowMessage(ListBox listbox, string text)
        {
            if (listbox.InvokeRequired)
            {
                ShowMessageCallBack showmessageCallback = ShowMessage;
                listbox.Invoke(showmessageCallback, new object[] { listbox, text });
            }
            else
            {
                listbox.Items.Add(text);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }

        // 清空消息列表
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstMessageBox.Items.Clear();
        }

        // 停止接收
        private void btnStop_Click(object sender, EventArgs e)
        {
            chkbxJoinGtoup.Enabled =true;
            receiveUdpClient.Close();
        }

       
    }
}
