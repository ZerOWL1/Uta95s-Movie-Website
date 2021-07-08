using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MBase64 : Movie
    {
        private string mIMG64;
        private string mIMG_BGbyte;

        public MBase64(int mid, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, string mImg64, string mImg_BGByte) : base(mid, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            mIMG64 = mImg64;
            mIMG_BGbyte = mImg_BGByte;
        }

        public MBase64(string mImg64, string mImg_BGByte)
        {
            mIMG64 = mImg64;
            mIMG_BGbyte = mImg_BGByte;
        }

        public MBase64(){}

        

        public string MIMG64 { get => mIMG64; set => mIMG64 = value; }
        public string MIMG_BGbyte { get => mIMG_BGbyte; set => mIMG_BGbyte = value; }
    }
}
