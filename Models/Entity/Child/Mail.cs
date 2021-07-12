using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class Mail
    {
        public Mail()
        {
        }

        public Mail(string name, string toMail, string pass, string repass, string code)
        {
            _name = name;
            _toMail = toMail;
            _pass = pass;
            _repass = repass;
            _code = code;
        }

        private string _name;
        private string _toMail;
        private string _pass;
        private string _repass;
        private string _code;

        public string Name { get => _name; set => _name = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Repass { get => _repass; set => _repass = value; }
        public string Code { get => _code; set => _code = value; }
        public string ToMail { get => _toMail; set => _toMail = value; }
    }
}
