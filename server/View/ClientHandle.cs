using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
using System.IO;
using System;
using server.Controller;
namespace server.View

{
    
    /// <summary>
    /// funcion that hand one client and send him massage
    /// 
    /// </summary>
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
            //to accept data from client
            reader = new BinaryReader(stream);
            //to send data from client
            writer = new BinaryWriter(stream);
            //save point to this object
            cclient = new CClientHandler(this);
        }
        public void sendMssage(string s)
        {
            if (s != null)
            {
                writer.Write(s);
            }
        }
        //
        /// <summary>
        /// recive command from client and send to controller that translate the command and send to 
        /// model to perfrom
        /// </summary>
        /// <param name="client"> the client that </param>
        /// <param name="controller">the controller that communicate betwen client  and servrer</param>
        public void HandleClient(TcpClient client, Controller.Controller controller)
        {
           
            new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        //try accept message from client
                        string commandLine = reader.ReadString();
                        //if requestto close ,get out from loop
                        if (commandLine.Equals("close me"))
                        {

                            break;
                        }
                        //sent the command to controller to send to model to execute the command
                        string result = controller.ExecuteCommand(commandLine, cclient);
                        //response back to client
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