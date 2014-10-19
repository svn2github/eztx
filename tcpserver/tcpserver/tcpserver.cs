using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace tcpclient
{
    class Program
    {
        private const int portNum = 80;
        static void Main(string[] args)
        {
            bool done = false;
            //TcpListener listener = new TcpListener(portNum); //����VS2005 MSDN �˷����Ѿ���ʱ������ʹ�� 
            // IPEndPoint�� �������ʶΪIP��ַ�Ͷ˿ں�
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, portNum));
            listener.Start();
            while (!done)
            {
                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();
                byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
                try
                {
                    ns.Write(byteTime, 0, byteTime.Length);
                    ns.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            listener.Stop();
        }
    }
}
