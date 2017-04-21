using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.View;
namespace server.Controller
{
    public interface ICClientHandler
    {
        void sendMssage(string s);
    }
}
