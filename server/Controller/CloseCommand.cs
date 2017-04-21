using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class CloseCommand : ICommand
    {
        private IModel model;
        /// <summary>
        /// send to both client to close the connection
        /// </summary>
        /// <param name="model"></param>
        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, ICClientHandler client)
        {
            string name = args[0];

            string ans = model.Close(name, client);



            return ans;
        }
    }
}