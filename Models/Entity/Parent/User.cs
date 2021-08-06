using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class User
    {
        public User(string name, string email, string pass, int role)
        {
            this.name = name;
            this.email = email;
            this.pass = pass;
            this.role = role;
        }

        public User(){}

        private string name;
        private string email;
        private string pass;
        private int role;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Role { get => role; set => role = value; }
    }
}
