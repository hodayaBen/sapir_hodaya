using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Server1
{
    /// <summary>
    ///  command pattern that just execute a method by order name
    /// </summary>
    interface ICommand {
        string Execute(string[] args, TcpClient client = null);
    }
}
