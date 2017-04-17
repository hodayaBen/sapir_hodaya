using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server1;

namespace Server1
{ 
    class Option6 : ICommandable
    {/// <summary>
    /// to send an check if player can go in d direction 
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="game"></param>
    /// <param name="id"></param>
    /// <returns></returns>
       public Package1 execute(string msg, MazeModel game, int id)
        {
           
            string[] commend = msg.Split(' ');
            string move = commend[1];
            direction d;
          
            switch (move)
            {
                case "up":
                    d = direction.up;
                    break;
                case "right":
                    d = direction.right;
                    break;
                case "left":
                    d = direction.left;
                    break;
                default:
                    d = direction.down;
                    break;
            }  
            Game g = game.GetGameAcId(id);
            return g.Move(id, d);
        }
    }
}
