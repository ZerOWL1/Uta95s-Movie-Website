using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity
{
    public class Users
    {
        private string name;
        private string email;
        private string password;
        private int role;

        public Users()
        {
        }

        public Users(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Users(string name, string email, string password, int role)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
    }
}
