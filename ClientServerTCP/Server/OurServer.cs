using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Server
{
    class OurServer
    {
        TcpListener server;

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();
        }

        void LoopClients() //слуаем каждого клиента
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                
                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient client) //обрабатываем каждого клиента
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);

            string sData = null;

            while (true)
            {
                string message = sReader.ReadLine();
                Console.WriteLine($"Клиент написал - {message}");

                sWriter.WriteLine("Сервер получил Ваше сообщение!");
                sWriter.Flush();
            }

        }
    }
}