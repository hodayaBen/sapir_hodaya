using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class CloseCommand : ICommand
    {
        private IModel model;
        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, IClientHandler client)
        {
            string name = args[0];

            string ans = model.Close(name, client);



            return ans;
        }
    }
}