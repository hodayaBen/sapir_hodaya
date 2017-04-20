using System.Net.Sockets;
using server.Model;
namespace server.Controller
{
    public class CloseCommand : ICommand
    {
        private IModel model;
        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];

            string ans = model.Close(name, client);



            return ans;
        }
    }
}