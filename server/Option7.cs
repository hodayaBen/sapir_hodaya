
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Server1;

//namespace Server1
//{
//    class Option7 : ICommandable
//    {
//        /// <summary>
//        /// close game to this id
//        /// </summary>
//        /// <param name="msg"></param>
//        /// <param name="game"></param>
//        /// <param name="idc"></param>
//        /// <returns></returns>
//        public Package1 execute(string msg, MazeModel game,int idc)
//        {
//            string[] commend = msg.Split(' ');
//            string name = commend[1];
//            int id =idc;
//            Game g = game.GetGame(name);
//            if (g != null)
//            {
//                game.close(g.getName());
//                return g.close(id);
//            }
//            return new Package1("close", idc);
//        }
//    }
//}
