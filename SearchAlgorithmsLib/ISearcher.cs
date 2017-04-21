using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// interface that shared to all algorithms
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    public interface ISearcher<T, S>
    {
        int evaluatedNodes { get; set; }
        // the search method
        SolutionDetails<S> search(ISearchable<T> searchable);
    }

}
