using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity
{
    public class Genre
    {
        private int gid;
        private string gName;

        public Genre()
        {
        }

        public Genre(int gid, string gName)
        {
            this.gid = gid;
            this.gName = gName;
        }

        public int Gid { get => gid; set => gid = value; }
        public string GName { get => gName; set => gName = value; }
    }
}
