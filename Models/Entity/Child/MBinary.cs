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
        private byte[] mIMG_BGbyte;

        public MBinary(int mid, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, byte[] mImgByte, byte[] mImg_BGByte) : base(mid, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            mIMGByte = mImgByte;
            mIMG_BGbyte = mImg_BGByte;
        }

        public MBinary(byte[] mImgByte, byte[] mImg_BGByte)
        {
            mIMGByte = mImgByte;
            mIMG_BGbyte = mImg_BGByte;
        }

        public MBinary(){}

        

        public byte[] MIMGByte { get => mIMGByte; set => mIMGByte = value; }
        public byte[] MIMG_BGbyte { get => mIMG_BGbyte; set => mIMG_BGbyte = value; }
    }
}
