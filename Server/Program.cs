using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress iPAddress = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener tcpListener = new TcpListener(iPAddress, 8080);
            TcpClient tcpClient = default(TcpClient);
            try
            {
                tcpListener.Start();
                Console.WriteLine("Server started...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.Read();
            }
            while (true)
            {
                tcpClient = tcpListener.AcceptTcpClient();
                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                string message = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);
                StringBuilder msg = new StringBuilder();
                foreach (byte item in receivedBuffer)
                {
                    if (item.Equals(59))
                    {
                        break;
                    }
                    else
                        msg.Append(Convert.ToChar(item).ToString()); 
                }
                Console.WriteLine(msg);
            }
        }
    }
}
