//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Client_v
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string msn = "";
//            TCPClient Tcp = new TCPClient();
//            Thread t = new Thread(Tcp.SendMsg);
//            t.Start();
//            while (!(msn.Equals("close")))
//            {
//                msn = Tcp.ReceviveMsg();
//                if (msn != "wait")
//                    Console.Write(msn);
//            }
//            Tcp.run = false;//closing the tread for sendMsg

//        }
//    }
//}
