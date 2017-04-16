using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public static class StatePool
    {
        static Dictionary<int, State<Position>> dictionary = new Dictionary<int, State<Position>>();
        public static State<Position> getState(Position t, State<Position> comeFrom, double cost) {
            State<Position> s;
            //save state acoording posion
            if (dictionary.ContainsKey(t.ToString().GetHashCode())) {
                dictionary.TryGetValue(t.ToString().GetHashCode(), out s);
                s.cameFrom = comeFrom;
                s.cost = cost;

            }
            else
            {
                s = new State<Position>(t);
                s.cameFrom = comeFrom;
                s.cost = cost;
                dictionary.Add(s.GetHashCode(),s);
            }
            return s;
        }
    }
}
