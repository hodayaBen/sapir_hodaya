using System;
using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class ListCommand : ICommand
    {
        private IModel model;
        public ListCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, ICClientHandler client)
        {
            String ans = model.list();
            return ans;
        }
    }
}