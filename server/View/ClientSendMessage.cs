using System.IO;
using System.Net.Sockets;

namespace server.View
{
    class ClientSendMessage
    {
        public void SendToClient(TcpClient client, string msg)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(msg);
            }
        }
    }
}