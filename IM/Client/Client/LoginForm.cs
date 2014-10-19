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
using System.IO;

namespace Client
{
    public partial class LoginForm : Form
    {
        // 服务器端口
        int port;
        // 定义变量
        private UdpClient sendUdpClient;
        private UdpClient receiveUdpClient;
        private IPEndPoint clientIPEndPoint;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader binaryReader;
        private string userListstring;
        private List<ChatFormcs> chatFormList = new List<ChatFormcs>();

        public LoginForm()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses("");
            txtserverIP.Text = localIP[1].ToString();
            txtLocalIP.Text = localIP[1].ToString();
            // 随机指定本地端口
            Random random = new Random();
            port = random.Next(1024,65500);
            txtlocalport.Text = port.ToString();

            // 随机生成用户名
            Random random2 = new Random((int)DateTime.Now.Ticks);
            txtusername.Text = "user" + random2.Next(100, 999);
            btnLogout.Enabled = false;
        }

        // 登录服务器
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // 创建接受套接字
            IPAddress clientIP = IPAddress.Parse(txtLocalIP.Text);
            clientIPEndPoint = new IPEndPoint(clientIP, int.Parse(txtlocalport.Text));
            receiveUdpClient = new UdpClient(clientIPEndPoint);
            // 启动接收线程
            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();

            // 匿名发送
            sendUdpClient = new UdpClient(0);
            // 启动发送线程
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(string.Format("login,{0},{1}", txtusername.Text, clientIPEndPoint));

            btnlogin.Enabled = false;
            btnLogout.Enabled = true;
            this.Text = txtusername.Text;
        }

        // 客户端接受服务器回应消息 
        private void ReceiveMessage()
        {
            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any,0);
            while (true)
            {
                try
                {
                    // 关闭receiveUdpClient时会产生异常
                    byte[] receiveBytes = receiveUdpClient.Receive(ref remoteIPEndPoint);
                    string message = Encoding.Unicode.GetString(receiveBytes,0,receiveBytes.Length);

                    // 处理消息
                    string[] splitstring = message.Split(',');

                    switch (splitstring[0])
                    {
                        case "Accept":
                            try
                            {
                                tcpClient = new TcpClient();
                                tcpClient.Connect(remoteIPEndPoint.Address, int.Parse(splitstring[1]));
                                if (tcpClient != null)
                                {
                                    // 表示连接成功
                                    networkStream = tcpClient.GetStream();
                                    binaryReader = new BinaryReader(networkStream);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("连接失败", "异常");
                            }

                            Thread getUserListThread = new Thread(GetUserList);
                            getUserListThread.Start();
                            break;
                        case "login":
                            string userItem = splitstring[1] + "," + splitstring[2];
                            AddItemToListView(userItem);
                            break;
                        case "logout":
                            RemoveItemFromListView(splitstring[1]);
                            break;
                        case "talk":
                            for (int i = 0; i < chatFormList.Count; i++)
                            {
                                if (chatFormList[i].Text == splitstring[2])
                                {
                                    chatFormList[i].ShowTalkInfo(splitstring[2], splitstring[1], splitstring[3]);
                                }
                            }

                            break;
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        // 从服务器获取在线用户列表
        private void GetUserList()
        {
            while (true)
            {
                userListstring = null;
                try
                {
                    userListstring = binaryReader.ReadString();
                    if (userListstring.EndsWith("end"))
                    {
                        string[] splitstring = userListstring.Split(';');
                        for (int i = 0; i < splitstring.Length - 1; i++)
                        {
                            AddItemToListView(splitstring[i]);
                        }

                        binaryReader.Close();
                        tcpClient.Close();
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        // 用委托机制来操作界面上控件
        private delegate void AddItemToListViewDelegate(string str);

        /// <summary>
        /// 在ListView中追加用户信息
        /// </summary>
        /// <param name="userinfo">要追加的信息</param>
        private void AddItemToListView(string userinfo)
        {
            if (lstviewOnlineUser.InvokeRequired)
            {
                AddItemToListViewDelegate adddelegate = AddItemToListView;
                lstviewOnlineUser.Invoke(adddelegate, userinfo);
            }
            else
            {
                string[] splitstring = userinfo.Split(',');
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(splitstring[0]);
                item.SubItems.Add(splitstring[1]);
                lstviewOnlineUser.Items.Add(item);
            }
        }

        private delegate void RemoveItemFromListViewDelegate(string str);

        /// <summary>
        /// 从ListView中删除用户信息
        /// </summary>
        /// <param name="str">要删除的信息</param>
        private void RemoveItemFromListView(string str)
        {
            if (lstviewOnlineUser.InvokeRequired)
            {
                RemoveItemFromListViewDelegate removedelegate = RemoveItemFromListView;
                lstviewOnlineUser.Invoke(removedelegate, str);
            }
            else
            {
                for (int i = 0; i < lstviewOnlineUser.Items.Count; i++)
                {
                    if (lstviewOnlineUser.Items[i].SubItems[1].Text == str)
                    {
                        lstviewOnlineUser.Items[i].Remove();
                    }
                }
            }
        }

        // 发送登录请求
        private void SendMessage(object obj)
        {
            string message = (string)obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            IPAddress remoteIp = IPAddress.Parse(txtserverIP.Text);
            IPEndPoint remoteIPEndPoint = new IPEndPoint(remoteIp, int.Parse(txtServerport.Text));
            sendUdpClient.Send(sendbytes, sendbytes.Length, remoteIPEndPoint);
            sendUdpClient.Close();
        }

        // 退出
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 匿名发送
            sendUdpClient = new UdpClient();
            //启动发送线程
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(string.Format("lohout,{0},{1}", txtusername.Text, clientIPEndPoint));
            receiveUdpClient.Close();
            lstviewOnlineUser.Items.Clear();
            btnlogin.Enabled = true;
            btnLogout.Enabled = false;
            this.Text = "Client";
        }

        // 双击打开与某个用户聊天的子窗口 
        private void lstviewOnlineUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string peerName = lstviewOnlineUser.SelectedItems[0].SubItems[1].Text;
            if (peerName == txtusername.Text)
            {
                return;
            }

            string ipEndPoint = lstviewOnlineUser.SelectedItems[0].SubItems[2].Text;
            string[] splitString = ipEndPoint.Split(':');
            IPAddress peerIP = IPAddress.Parse(splitString[0]);
            IPEndPoint peerIPEndPoint = new IPEndPoint(peerIP,int.Parse(splitString[1]));
            ChatFormcs dialogChat = new ChatFormcs();
            dialogChat.SetUserInfo(txtusername.Text, peerName, peerIPEndPoint);
            dialogChat.Text = peerName;
            chatFormList.Add(dialogChat);
            dialogChat.Show();
        }
    }
}
