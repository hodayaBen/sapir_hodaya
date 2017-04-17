using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server1
{
    /// <summary>
    /// id and message
    /// </summary>
    public class Package1
    {
        public Dictionary<int, string> idMsg {get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public Package1()
        {
            this.idMsg = new Dictionary<int, string>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="msn">the msn we want tp send</param>
        /// <param name="id">who we want to send to</param>
        public Package1(string msn, int id)
        {
            this.idMsg = new Dictionary<int, string>();
            this.idMsg.Add(id, msn);
        }
        /// <summary>
        /// add id to send to msn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msn"></param>
        public void AddID(int id, string msn)
        {
            if (idMsg.Keys.Contains(id))
            {
                idMsg[id] = msn;
                return;
            }
            this.idMsg.Add(id, msn);
        }
    }
}
