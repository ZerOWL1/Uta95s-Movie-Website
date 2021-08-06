using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class UProfileBase64 : User
    {
        public UProfileBase64(string name, string email, string pass, int role, string uId, string uImg) : base(name, email, pass, role)
        {
            uID = uId;
            uIMG = uImg;
        }

        public UProfileBase64(string uId, string uImg)
        {
            uID = uId;
            uIMG = uImg;
        }

        public UProfileBase64(){}

        private string uID;
        private string uIMG;

        public string UID { get => uID; set => uID = value; }
        public string UIMG { get => uIMG; set => uIMG = value; }
    }
}
