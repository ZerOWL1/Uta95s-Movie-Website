using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class UProfile : User
    {
        private byte[] uIMG;

        public UProfile(string name, string email, string pass, int role, byte[] uImg) : base(name, email, pass, role)
        {
            uIMG = uImg;
        }

        public UProfile(byte[] uImg)
        {
            uIMG = uImg;
        }

        public UProfile()
        {
        }

        public byte[] UIMG { get => uIMG; set => uIMG = value; }
    }
}
