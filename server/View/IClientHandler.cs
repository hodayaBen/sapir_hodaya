﻿//tcplistener
using System.Net.Sockets;

namespace server.View
{
    /// <summary>
    /// handle one client, get and send message to him
    /// </summary>
    public interface IClientHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client">Tcp client</param>
        /// <param name="controller">controller - to communicate with the model</param>
        void HandleClient(TcpClient client, Controller.Controller controller);
        /// <summary>
        /// send message to the client
        /// </summary>
        /// <param name="s"></param>
        void sendMssage(string s);
    }
}
