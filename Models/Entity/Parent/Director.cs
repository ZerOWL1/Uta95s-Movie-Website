using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Director
    {
        public Director(int did, string dName, string dNational)
        {
            this.did = did;
            this.dName = dName;
            this.dNational = dNational;
        }

        public Director(){}

        private int did;
        private string dName;
        private string dNational;

        public int Did { get => did; set => did = value; }
        public string DName { get => dName; set => dName = value; }
        public string DNational { get => dNational; set => dNational = value; }
    }
}
