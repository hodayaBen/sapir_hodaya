using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class BestFS<T> : Searcher<T>
    {
        /// <summary>
        /// constructor of best first 
        /// search   
        /// </summary>
        public BestFS()
        {
            openList = new MyPriorityQueue<State<T>>();
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
        public override Solution<T> search(ISearchable<T> searchable)
        {
            Console.WriteLine(searchable.getInitialState().state.ToString());
            Console.WriteLine(searchable.getGoalState().state.ToString());
            Solution<T> s = new Solution<T>();
            State<T> n = new State<T>(searchable.getInitialState().state);
            n.cost = 0;
            n.cameFrom = null;
            this.openList.Add(n);
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize() > 0)
            {
                n = this.openList.Pop();
                closed.Add(n);
                if (n.state.Equals(searchable.getGoalState().state))
                {
                    while (n != null)
                    {
                        s.addNode(n);
                        Console.WriteLine(n.state.ToString());
                        n = n.cameFrom;
                    }
                    break;
                }
                List<State<T>> l = searchable.getAllPossibleStates(n);
                foreach (var x in l)
                {
                    Console.WriteLine(x.state.ToString());
                    if ((!(closed.Contains(x)))
                       && !(openList.Contains(x)))
                    {
                        x.cost = n.cost + 1 ;
                        x.cameFrom = n;
                        openList.Add(x);
                    }
                    else if ((!(closed.Contains(x))) && (x.cost > n.cost + 1))
                    {
                        Console.WriteLine(x.state.ToString() + " " + x.cost);
                        x.cost = n.cost + 1;
                        x.cameFrom = n;
                        openList.remove(x);
                        openList.Add(x);
                    }
                }
            }
            return s;
        }
    }
}
