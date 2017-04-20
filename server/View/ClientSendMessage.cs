using System.IO;
using System.Net.Sockets;

using System;
namespace server.View
{
    class ClientSendMessage
    {
        public void SendToClient(TcpClient client, string msg)
        {
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                Console.WriteLine("cilent check:"+msg);
                writer.Write(msg);
                //writer.Flush();
            }
        }
    }
}


/*
using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
               /* NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);*/
               /* {
                    while (true)
                      {
                    try
                    {
                          string commandLine = reader.ReadString();
// string commandLine = reader.Read();
Console.WriteLine("Got command: {0}", commandLine);
                        string result = controller.ExecuteCommand(commandLine, client);
writer.Write(result);
                    }
                    catch
                    {

    */