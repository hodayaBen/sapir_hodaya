using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// save the path of the maze
    /// </summary>
    public class Solution
    {
        private List<State<Position>> solve;
        /// <summary>
        /// constructor 
        /// </summary>
        public Solution()
        {
            this.solve = new List<State<Position>>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="list"></param>
        public Solution(List<State<Position>> list)
        {
            this.solve = list;
        }
        /// <summary>
        /// get the solition
        /// </summary>
        /// <returns></returns>
        public List<State<Position>> getSolve()
        {
            return this.solve;
        }
        /// <summary>
        /// add node to solition 
        /// </summary>
        /// <param name="node"></param>
        public void addNode(State<Position> node)
        {
            this.solve.Add(node);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            solve.ForEach(item =>sb.Append(item.state.ToString() + ","));
            return sb.ToString();
        }
    }
}
