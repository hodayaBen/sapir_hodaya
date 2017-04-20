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
        public int numOfNode;
        public string solv;
        public PasrseSolve(string name, List<Direction> solv,int numOfNode)
        {
            this.name = name;
            this.solv = PasrseSolve.ParseSol(solv);
            this.numOfNode = numOfNode;
        }
        static string ParseSol(List<Direction> solv)
        {
            string str = "";
            for(int i = 0; i <solv.Count(); i++)
            {
                str += solv[i];
            }
            return str;
        }

    }
}
