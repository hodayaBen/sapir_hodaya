using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class BestFS : Searcher
    {
        /// <summary>
        /// constructor of best first 
        /// search   
        /// </summary>
        public BestFS()
        {
            openList = new MyPriorityQueue<State<Position>>();
            evaluatedNodes = 0;
        }
        // a property of openList
        public int OpenListSize()
        {
            return openList.Count();
        }
        /// <summary>
        /// search the shortest way to end of the maze
        /// </summary>
        /// <param name="searchable">searchable maze we can check for wanted way</param>
        /// <returns>shorted way fron start to end of maze</returns>
        public override Solution search(ISearchable searchable)
        {
            Solution s = new Solution();

            State<Position> n = StatePool.getState(searchable.getInitialState().state, null, 0);
            this.openList.Add(n);
            HashSet<State<Position>> closed = new HashSet<State<Position>>();
            while (OpenListSize() > 0)
            {       
                closed.Add(n);
                if (n.state.Equals(searchable.getGoalState().state))
                {       
                    while (n != null)
                    {       
                        s.addNode(n);
                        n = n.cameFrom;
                    }
                    break;
                }
                List<State<Position>> l = searchable.getAllPossibleStates(n);
                
                foreach (var x in l)
                {
                    if ((!(closed.Contains(x)))
                       && !(openList.Contains(x)))
                    {
                        x.cost = n.cost + GetCost(x.state, searchable.getGoalState().state); ;
                        x.cameFrom = n;
                        openList.Add(x);
                    }
                    else if ((!(closed.Contains(x))) && (x.cost > n.cost + GetCost(x.state, searchable.getGoalState().state)))
                    {
                        openList.remove(x);
                        x.cost = n.cost + GetCost(x.state, searchable.getGoalState().state);
                        x.cameFrom = n;
                        openList.Add(x);
                    }
                }

                n = this.openList.Pop();
            }
            return s;
        }
        /// <summary>
        /// getter of cost of the distance of node
        /// x from goal node
        /// </summary>
        /// <param name="x">the node we will seek his cost</param>
        /// <param name="goal">goal node in the maze </param>
        /// <returns>cost of x in  relation to goal</returns>
        public virtual double GetCost(Position x, Position goal)
        {
            return Math.Abs(x.Row - goal.Row) + Math.Abs(x.Col - goal.Col);
        }
    }

}