using System;
using System.Threading.Tasks;
//tcplistener
using System.Net.Sockets;
//ipendpoint
using System.Net;
using System.IO;
namespace server.View
{
    class Server
    {
        //port the server listen
        private int port;
        //server
        private TcpListener listener;
        private IClientHandler ch;
        private Controller.Controller controller;
//        public Server(int port, IClientHandler ch, Controller.Controller con)
//        {
//            this.controller = con;
 //           this.port = port;
 //           this.ch = ch;
 //       }
        public Server(int port, Controller.Controller con)
        {
            this.controller = con;
            this.port = port;
            
        }

        public void Start()
        {
            //create socket to server
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start();
            /*
             * wait to clients
             */
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        //perform the task
                        this.ch = new ClientHandler(client);
                       ch.HandleClient(client, this.controller);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
                Console.ReadKey();
            }); task.Start();
        }
        /*
         * the propuse to stop waiting to clients
         */
        public void Stop()
        {
            listener.Stop();
        }
    }
}
