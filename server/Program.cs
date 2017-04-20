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
            IClientHandler handCliemt = new ClientHandler();
            TcpClient client = new TcpClient();
            //public Server(int port, IClientHandler ch, Controller.Controller con)
            Server s = new Server(8000, handCliemt,controller);
            s.Start();
            Console.Write("over");
           Console.ReadKey();
        }
    }
}
