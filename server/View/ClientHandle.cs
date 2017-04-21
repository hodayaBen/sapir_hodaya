using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
using System.IO;
using System;
using server.Controller;
namespace server.View

{
    public class ClientHandler : IClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private ICClientHandler cclient;

        public ClientHandler(TcpClient client1)
        {
            this.client = client1;
            stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            cclient = new CClientHandler(this);
        }
        public void sendMssage(string s)
        {
            if (s != null)
            {
                writer.Write(s);
            }
        }
        public void HandleClient(TcpClient client, Controller.Controller controller)
        {
            Console.WriteLine("handle");
            new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        string commandLine = reader.ReadString();
                        if (commandLine.Equals("close me"))
                        {

                            break;
                        }
                        // Console.WriteLine("Got command: {0}", commandLine);
                        string result = controller.ExecuteCommand(commandLine, cclient);
                        writer.Write(result);

                    }
                    catch
                    {
                        break;
                    }
                }

                client.Close();
            }).Start();
        }
    }
}