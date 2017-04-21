using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;
using Newtonsoft.Json;
namespace server.Controller
{
   public class PasrseSolve
    {
        public string name;
        public int nodesEvaluated;
        public string solution;
        public PasrseSolve(string name, List<Direction> solv,int numOfNode)
        {
            this.name = name;
            this.solution = PasrseSolve.ParseSol(solv);
            this.nodesEvaluated = numOfNode;
        }
        static string ParseSol(List<Direction> solv)
        {
            string str = "";
            Direction s;
            
                for (int i = 0; i <solv.Count(); i++)
            {
                s = solv[i];
                Console.WriteLine("c1"+s.ToString());
                if (s.ToString().Equals("Right"))
                    str += "1";
                else if (s.ToString().Equals("Up"))
                    str += "2";
                else if (s.ToString().Equals("Down"))
                    str += "3";
                else
                    str += "0";
            }

            return str;
        }

    }
}
