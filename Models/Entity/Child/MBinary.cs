using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MBinary : Movie
    {
        private byte[] mIMGByte;

        public MBinary(string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, byte[] mImgByte) : base(title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            mIMGByte = mImgByte;
        }

        public MBinary(byte[] mImgByte)
        {
            mIMGByte = mImgByte;
        }

        public MBinary(){}

        public byte[] MIMGByte { get => mIMGByte; set => mIMGByte = value; }
    }
}
