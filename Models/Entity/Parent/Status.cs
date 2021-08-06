using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Status
    {
        private int sid;
        private string sname;

        public Status()
        {
        }

        public Status(int sid, string sname)
        {
            this.sid = sid;
            this.sname = sname;
        }

        public int Sid { get => sid; set => sid = value; }
        public string Sname { get => sname; set => sname = value; }
    }
}
