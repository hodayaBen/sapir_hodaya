//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Model;
//using System.Net;
//using System.Configuration;
//using System.Net.Sockets;
//using System.IO;
//using System.Web.Script.Serialization;
//namespace server
//{
//    class Program
//    {
//        private Presentor pres;
//        private MazeModel model;
//        private Dictionary<string, ICommandable> commandDic;
//        private int Height;
//        private int Width;
//        private Program()
//        {
//            model = new MazeModel();
//            pres = new Presentor(model);
//            commandDic = new Dictionary<string, ICommandable>();
//            commandDic.Add("generate", new Option1());
//            commandDic.Add("solve", new Option2());
//            commandDic.Add("start", new Option3());
//            commandDic.Add("list", new Option4());
//            commandDic.Add("join", new Option5());
//            commandDic.Add("play", new Option6());
//            commandDic.Add("close", new Option7());

//        }
//        /// <summary>
//        /// main method 
//        /// </summary>
//        /// <param name="args"></param>
//        static void Main(string[] args)
//        {
//            Program p = new Program();
//            p.run();

//        }
//        /// <summary>
//        /// run the function and wait to client to bind with
//        /// </summary>
//        public void run()
//        {
//            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Int32.Parse(ConfigurationManager.AppSettings["Port"]));
//            Socket newsock = new Socket(AddressFamily.InterNetwork,
//            SocketType.Stream, ProtocolType.Tcp);
//            newsock.Bind(ipep);
//            newsock.Listen(10);
//            while (true)
//            {
//                Socket client = newsock.Accept();
//                View handler = new View(client);
//                pres.AddView(handler);//add the view to list of views
//                // creat thread not pool
//                Task.Factory.StartNew(handler.getUserCommand); //get commed from the socket
//            }
//        }

//    }
//}
