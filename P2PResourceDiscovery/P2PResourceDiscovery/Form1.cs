using System;
// 添加需要的命名空间
using System.Net;
using System.Net.PeerToPeer;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace P2PResourceDiscovery
{
    /// <summary>
    /// 在本地地址输入本机的IP地址和进程的端口号，再输入资源名后点击注册按钮
    /// 这时在分享下拉列表中就可以看到刚刚注册的资源，用户也可以随时通过在下拉列表
    /// 选中资源点撤销来撤销自己发布的资源
    /// 同时程序也提供了在网上搜索其他用户已发布好的资源
    /// 只要在种子输入框中输入要搜索的资源名后点击搜索按钮，程序会自动
    /// 搜索资源所在的主机地址和资源发布时间
    /// </summary>
    public partial class frmP2PresourceDis : Form
    {
        // PeerNameRegistration 表示在云中注册的节点名
        PeerNameRegistration[] resourceNameReg =new PeerNameRegistration[100];
        
        // 本地发布的种子数
        int seedCount = 0;

        public frmP2PresourceDis()
        {
            InitializeComponent();
            
            // 窗口初始化数据 
            IPAddress[] ips = Dns.GetHostAddresses("");
            tbxlocalip.Text =ips[3].ToString();
            int port = new Random().Next(48000, 50000);
            tbxlocalport.Text = port.ToString();
            tbxResourceName.Text = "Res01";
        }

        // 注册资源
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbxResourceName.Text == "")
            {
                MessageBox.Show("请输入发布的资源名！", "提示");
                return;
            }

            // 将资源名注册到云中
            // 具体资源名的结构在博客有介绍
            PeerName resourceName = new PeerName(tbxResourceName.Text, PeerNameType.Unsecured);
            // 用指定的名称和端口号初始化PeerNameRegistration类的实例
            resourceNameReg[seedCount] = new PeerNameRegistration(resourceName, int.Parse(tbxlocalport.Text));
            // 设置在云中注册的对等名对象的其他信息的注释
            resourceNameReg[seedCount].Comment =resourceName.ToString();
            // 设置PeerNameRegistration对象的应用程序定义的二进制数据
            resourceNameReg[seedCount].Data = Encoding.UTF8.GetBytes(string.Format("{0}", DateTime.Now.ToString()));
            // 在云中注册PeerName(对等名)
            resourceNameReg[seedCount].Start();
            seedCount++;
            comboxSharelist.Items.Add(resourceName.ToString());
            tbxResourceName.Text = "";
        }

        // 从云中撤销资源
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = comboxSharelist.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("请先选择撤销的资源！", "提示");
                return;
            }
            else
            {
                for (int i = 0; i < seedCount; i++)
                {
                    if (resourceNameReg[i].Comment == comboxSharelist.SelectedItem.ToString())
                    {
                        // 撤销资源
                        resourceNameReg[i].Stop();
                        // 下列列表移除资源
                        // Remove方法是移除指定项，RemoveAt是移除指定索引，这两种方式都可以
                        comboxSharelist.Items.Remove(comboxSharelist.SelectedItem);
                        ////comboxSharelist.Items.RemoveAt(index);
                        comboxSharelist.Text = "";
                        break;
                    }
                }
            }
        }

        // 搜索资源
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSeed.Text == "")
            {
                MessageBox.Show("请先输入要寻找的种子资源名", "提示");
                return;
            }

            lstViewOnlinePeer.Items.Clear();
            // 初始化要搜索的资源名
            PeerName searchSeed = new PeerName("0." + tbxSeed.Text);
            // PeerNameResolver类是将节点名解析为PeerNameRecord的值（即将通过资源名来查找资源名所在的地址,包括IP地址和端口号）
            // PeerNameRecord用来定于云中的各个节点
            PeerNameResolver myresolver = new PeerNameResolver();

            // PeerNameRecordCollection表示PeerNameRecord元素的容器
            // Resolve方法是同步的完成解析
            // 使用同步方法可能会出现界面“假死”现象
            // 解决界面假死现象可以采用多线程或异步的方式
            // 关于多线程的知识可以参考本人博客中多线程系列我前面UDP编程中有所使用
            // 在这里就不列出多线程的使用了，朋友可以自己实现，如果有问题可以留言给我一起讨论
            PeerNameRecordCollection recordCollection = myresolver.Resolve(searchSeed);
            foreach (PeerNameRecord record in recordCollection)
            {
                foreach(IPEndPoint endpoint in record.EndPointCollection)
                {
                    if (endpoint.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        ListViewItem item = new ListViewItem();   
                        item.SubItems.Add(endpoint.ToString());
                        item.SubItems.Add(Encoding.UTF8.GetString(record.Data));
                        lstViewOnlinePeer.Items.Add(item);
                    }
                }
            }
        }
    }
}
