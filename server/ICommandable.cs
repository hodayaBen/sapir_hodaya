using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server1
{
    /// <summary>
    ///  command pattern that just execute a method by order name
    /// </summary>
    public interface ICommandable
    {
        Package1 execute(string com, MazeModel game, int id);
    }
}
