using System;
using System.Net.Sockets;
using server.Model;
namespace server.Controller
{
    public class ListCommand : ICommand
    {
        private IModel model;
        public ListCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            String ans = model.list();
            return ans;
        }
    }
}