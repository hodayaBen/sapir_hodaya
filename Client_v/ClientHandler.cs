using System;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client_v
{
    class ClientHandler : IClientHandler {
        public void HandleClient(TcpClient client, Controller c) {
            new Task(() => {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream)) {
                    string commandLine = reader.ReadLine();
                    Console.WriteLine("Got command: {0}", commandLine);
                    string result = c.ExecuteCommand(commandLine, client);
                    writer.Write(result);
                } client.Close(); }).Start();
        }
    }
}
