using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        private TcpClient client;
        private StreamWriter sWriter;
        private StreamReader sReader;

        public OurClient()
        {
            client = new TcpClient("127.0.0.1", 5555);
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            
            HandleCommunication();
        }

        void HandleCommunication()
        {
            while (true) //постоянно держим TCP соединение
            {
                Console.Write("> ");
                string message = Console.ReadLine();
                sWriter.WriteLine(message); //подготовить к отправке сообщение
                sWriter.Flush(); //отправить сообщение немедленно
                string answer = sReader.ReadLine();
                Console.WriteLine(answer);
            }
        }
    }
}