using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.View;
namespace server.Controller
{
    public class CClientHandler : ICClientHandler
    {
        private IClientHandler client;
        public CClientHandler(IClientHandler client)
        {
            this.client = client;
        }
        public void sendMssage(string s)
        {
            client.sendMssage(s);
        }

    }
}
