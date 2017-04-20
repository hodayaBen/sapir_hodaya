﻿using System.Net.Sockets;
using server.Model;
namespace server.Controller
{
    public class StartCommand : ICommand
    {
        private IModel model;
        public StartCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            string ans = model.StartGame(name, rows, cols, client);



            return ans;
        }
    }
}