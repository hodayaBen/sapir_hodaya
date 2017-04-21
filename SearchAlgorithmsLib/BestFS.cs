using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public class BestFS : Searcher<Position, Direction>
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
        public override SolutionDetails<Direction> search(ISearchable<Position> searchable)
        {
            Console.WriteLine(searchable.getInitialState().state.ToString());
            Console.WriteLine(searchable.getGoalState().state.ToString());
            SolutionDetails<Direction> s = new SolutionDetails<Direction>();
            State<Position> n = new State<Position>(searchable.getInitialState().state);
            n.cost = 0;
            n.cameFrom = null;
            this.openList.Add(n);
            HashSet<State<Position>> closed = new HashSet<State<Position>>();
            while (OpenListSize() > 0)
            {
                n = this.openList.Pop();
                closed.Add(n);
                if (n.state.Equals(searchable.getGoalState().state))
                {
                    State<Position> pre;
                    Stack<State<Position>> stack = new Stack<State<Position>>();
                    while (n != null)
                    {
                        stack.Push(n);
                        s.NodesEvaluated += 1;

                        //s.addNode(n);
                        //Console.WriteLine(n.state.ToString());
                        n = n.cameFrom;
                    }
                    n = stack.Pop();
                    while (stack.Count != 0)
                    {
                        pre = n;
                        n = stack.Pop();
                        int dif = pre.state.Row - n.state.Row;
                        if (dif == -1)
                        {
                            s.addNode(Direction.Down);
                        }
                        else if (dif == 1)
                        {
                            s.addNode(Direction.Up);
                        }
                        else
                        {
                            dif = pre.state.Col - n.state.Col;
                            if (dif == -1)
                            {
                                s.addNode(Direction.Right);
                            }
                            else if (dif == 1)
                            {
                                s.addNode(Direction.Left);
                            }
                        }
                    }
                    break;
                }
                List<State<Position>> l = searchable.getAllPossibleStates(n);
                foreach (var x in l)
                {
                    Console.WriteLine(x.state.ToString());
                    if ((!(closed.Contains(x)))
                       && !(openList.Contains(x)))
                    {
                        this.evaluatedNodes++;
                        x.cost = n.cost + 1;
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