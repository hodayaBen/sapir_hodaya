using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;
//using System.Web.Script.Serialization;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using server.Model;
using server.View;
namespace server.Controller
{
    public class PlayCommand : ICommand
    {
        private IModel model;
        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        //public string Execute(string[] args, TcpClient client)
        public string Execute(string[] args, ICClientHandler client)
        {

            string move = args[0];
            String s = model.Play(move, client);



            return s;
        }
    }
}