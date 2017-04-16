using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
namespace ex1_20
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMazeGenerator img = new DFSMazeGenerator();
            Maze maze = img.Generate(100, 100);
            SearchableMaze sm = new SearchableMaze(maze);
            Console.WriteLine(maze.ToString());
            Console.WriteLine(maze.InitialPos);
            Console.WriteLine(maze.GoalPos);
            ISearcher searcher = new SearchAlgorithmsLib.BestFS();
            Console.WriteLine(searcher.search(sm).getSolve().Count);
            //ISearcher searcherDFS = new DFS();
            //searcherDFS.search(sm);
            Console.ReadKey();
        }
    }
}