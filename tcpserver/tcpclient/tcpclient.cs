using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace tcpclient
{
    class tcpclient
    {
        private static int portNum = 80;
        private static string hostName = Dns.GetHostName().ToString();
        public static void Main(String[] args)
        {
            try
            {
                Console.WriteLine("�������֣�"+ Dns.GetHostName());
                Console.WriteLine("����IP��ַ��"+ Dns.GetHostAddresses(Dns.GetHostName())[0]);
               
                TcpClient client = new TcpClient(hostName, portNum);
                NetworkStream ns = client.GetStream();
                byte[] bytes = new byte[1024];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);
                //���ֽ�������Ϊ�ַ���
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                client.Close();
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
         }
    }

}
