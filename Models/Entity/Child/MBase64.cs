using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MBase64 : Movie
    {
        public MBase64(int mId, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, string mImg64, string mBigImg64) : base(mId, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            mIMG64 = mImg64;
            mBigIMG64 = mBigImg64;
        }

        public MBase64(string mImg64, string mBigImg64)
        {
            mIMG64 = mImg64;
            mBigIMG64 = mBigImg64;
        }

        private string mIMG64;
        private string mBigIMG64;
       

        public MBase64(){}

        public string MIMG64 { get => mIMG64; set => mIMG64 = value; }
        public string MBigIMG64 { get => mBigIMG64; set => mBigIMG64 = value; }
    }
}
