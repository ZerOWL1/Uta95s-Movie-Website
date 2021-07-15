using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Mail
    {
        public Mail(string name, string pass, string toMail, string reCode)
        {
            this.name = name;
            this.pass = pass;
            this.toMail = toMail;
            this.reCode = reCode;
        }

        public  Mail(){}

        private string name;
        private string pass;
        private string toMail;
        private string reCode;

        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
        public string ToMail { get => toMail; set => toMail = value; }
        public string ReCode { get => reCode; set => reCode = value; }
    }
}
