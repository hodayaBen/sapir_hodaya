using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    class Comparator : IEqualityComparer<State<Position>>
    {
        public int GetHashCode(State<Position> p)
        {
            return p.ToString().GetHashCode();
        }
        public bool Equals(State<Position> p1, State<Position> p2)
        {
            return (p1.ToString().GetHashCode()).Equals(p2.ToString().GetHashCode());

        }
    }
}
