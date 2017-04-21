using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// algohrithms dfs
    /// </summary>
    public class DFS : Searcher<Position, Direction>
    {
        private Stack<State<Position>> reverseStack;
        private Stack<State<Position>> stack;
        public DFS()
        {
            reverseStack = new Stack<State<Position>>();
            stack = new Stack<State<Position>>();
        }
        //return solution detail to maze
        public override SolutionDetails<Direction> search(ISearchable<Position> searchable)
        {
           
            Solution<Direction> solv = new Solution<Direction>();
            State<Position> n = searchable.getInitialState();
            //push the sirst element
            stack.Push(n);
            //if visit in this node
            Dictionary<int, State<Position>> grayList = new Dictionary<int, State<Position>>();
            //if over to check  the node and his boys
            Dictionary<int, State<Position>> BlackList = new Dictionary<int, State<Position>>();
            while (stack.Count > 0)
            {
                //get out the last element in the stack
                State<Position> s = stack.Pop();
                this.evaluatedNodes += 1;

                grayList.Add(s.state.ToString().GetHashCode(), s);
                if (s.Equals(searchable.getGoalState()))
                {
                    ConvertToDirection(n, solv);
                    break;
                }
              
                List<State<Position>> l = searchable.getAllPossibleStates(s);
                foreach (State<Position> neg in l)
                {
                    if (!grayList.ContainsKey(neg.state.ToString().GetHashCode()) && !BlackList.ContainsKey(neg.state.ToString().GetHashCode()))
                    {
                        neg.cameFrom = s;
                        neg.cost = ++s.cost;
                        stack.Push(neg);
                    }
                }
                BlackList.Add(s.state.ToString().GetHashCode(), s);
            }
            //the solution detail
            return new SolutionDetails<Direction>(solv, this.evaluatedNodes);
        }
    }
}
