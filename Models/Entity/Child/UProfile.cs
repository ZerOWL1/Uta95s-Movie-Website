using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class UProfile : User
    {
        public UProfile(string name, string email, string pass, int role, string uId, byte[] uImg) : base(name, email, pass, role)
        {
            uID = uId;
            uIMG = uImg;
        }

        public UProfile(string uId, byte[] uImg)
        {
            uID = uId;
            uIMG = uImg;
        }

        private string uID;
        private byte[] uIMG;

       

        public UProfile()
        {
        }

        public string UID { get => uID; set => uID = value; }
        public byte[] UIMG { get => uIMG; set => uIMG = value; }
    }
}
