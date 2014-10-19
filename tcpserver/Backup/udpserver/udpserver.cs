using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;
namespace Udpclient2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UdpClient udpClient = new UdpClient(12000);
                string returnData = "client_end";
                do
                {
                    Console.WriteLine("�������˽������ݣ�.............................");
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    // �˴�ͨ�����ô�ֵ����ÿͻ��˵�IP��ַ���˿ں�
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    //�˴���ÿͻ��˵�����
                    returnData = Encoding.UTF8.GetString(receiveBytes);
                    //Encoding.ASCII.GetString(receiveBytes); �˴�����ASCII��������ȷ��������
                    Console.WriteLine("This is the message server received: " + returnData.ToString());

                    Thread.Sleep(3000);
                 
                    Console.WriteLine("��ͻ��˷������ݣ�.............................");
                    udpClient.Connect(Dns.GetHostName().ToString(), 11000);
                    // Sends a message to the host to which you have connected.
                    string sendStr = "�����Է�������:" + DateTime.Now.ToString();
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
                    //Byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr); �˴�����ASCII��������ȷ��������
                    udpClient.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine("This is the message server send: " + sendStr);

                 } while (returnData != "client_end");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
