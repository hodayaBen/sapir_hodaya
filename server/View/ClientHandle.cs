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
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
               /* NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);*/
                {
                    while (true)
                      {
                    try
                    {
                          string commandLine = reader.ReadString();
                            if (commandLine.Equals("close me")) {
                                break;
                            }
                        Console.WriteLine("Got command: {0}", commandLine);
                        string result = controller.ExecuteCommand(commandLine, client);
                        writer.Write(result);
                          
                    }
                    catch
                    {
                        break;
                    }
                     }
                }
                client.Close();
            }).Start();
        }
    }
}
