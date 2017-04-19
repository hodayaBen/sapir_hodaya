using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace Server1
{
    public class ListCommand : ICommand
    {
        private MazeModle model;
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