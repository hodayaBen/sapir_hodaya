using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.View;
using System.Net.Sockets;
using server.Controller;
namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.Controller controller = new Controller.Controller();
            //TcpClient client = new TcpClient();
            //IClientHandler handCliemt = new ClientHandler(client);
           
            //public Server(int port, IClientHandler ch, Controller.Controller con)
            Server s = new Server(8000,controller);
            s.Start();
            //Console.Write("over");
           Console.ReadKey();
        }
    }
}
