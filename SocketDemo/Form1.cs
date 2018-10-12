using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SocketDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("localhost", 8080);
            int bytecount = Encoding.ASCII.GetByteCount(textBox1.Text);
            byte[] sendData = new byte[bytecount];
            sendData = Encoding.ASCII.GetBytes(textBox1.Text);
            NetworkStream stream = client.GetStream();
            stream.Write(sendData, 0, sendData.Length);
            stream.Close();
            client.Close();

        }
    }
}
