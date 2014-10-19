using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
namespace Udpclient
{
    class Program
    {
        static void Main(string[] args)
        {
           try
            { 
               UdpClient udpClient = new UdpClient(11000);
               
               //���������������
               udpClient.Connect(Dns.GetHostName().ToString(), 12000);
               // Sends a message to the host to which you have connected.
               string sendStr = "�����Կͻ���:" + DateTime.Now.ToString();
               Byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
               //Byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr); �˴�����ASCII��������ȷ��������
               udpClient.Send(sendBytes, sendBytes.Length);
               Console.WriteLine("This is the message client send: " + sendStr);
                
               
               //�ȴ��������Ĵ𸴣��յ�����ʾ�𸴣��������Ի�
               IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
               // �˴�ͨ�����ô�ֵ����ÿͻ��˵�IP��ַ���˿ں�
               Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
               //�˴���÷������˵�����
               string returnData = Encoding.UTF8.GetString(receiveBytes);
               //Encoding.ASCII.GetString(receiveBytes); �˴�����ASCII��������ȷ��������
               Console.WriteLine("This is the message come from server: " + returnData.ToString());
               udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
