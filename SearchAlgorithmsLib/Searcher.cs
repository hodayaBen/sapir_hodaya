using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T,S> : ISearcher<T,S>
    {
        protected MyQueue<State<T>> openList;
        protected int evaluatedNodes;
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public abstract SolutionDetails<S> search(ISearchable<T> searchable);
    }
}