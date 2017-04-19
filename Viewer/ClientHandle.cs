using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
//ipendpoint
using System.Net;
using System.IO;
using Controller;
namespace Viewer
    
{
    class ClientHandler : IClientHandler
    {
        public void HandleClient(TcpClient client,Controller.Controller controller)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string commandLine = reader.ReadLine();
                    Console.WriteLine("Got command: {0}", commandLine);
                    string result = controller.ExecuteCommand(commandLine, client);
                    writer.Write(result);
                }
                client.Close();
            }).Start();
        }
    }
}
