using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
using System.IO;
using System;
namespace server.View

{
    class ClientHandler : IClientHandler
    {
        public void HandleClient(TcpClient client, Controller.Controller controller)
        {
            Console.WriteLine("handle");
            new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                {
                    
                    string commandLine = reader.ReadString();
                   
                    Console.WriteLine("Got command: {0}", commandLine);
                    string result = controller.ExecuteCommand(commandLine, client);
                    writer.Write(result);
                }
                client.Close();
            }).Start();
        }
    }
}
