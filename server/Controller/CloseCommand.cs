using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Model;
namespace Controller
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

            string ans = model.Close(name);



            return ans;
        }
    }
}