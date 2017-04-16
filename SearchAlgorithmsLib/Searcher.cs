using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public abstract class Searcher : ISearcher
    {
        protected MyQueue<State<Position>> openList;
        protected int evaluatedNodes;
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        
        public abstract Solution search(ISearchable searchable);
    }
}
