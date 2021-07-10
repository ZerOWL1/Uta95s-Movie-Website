using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MBinary : Movie
    {
        public MBinary(int mId, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, byte[] mImgByte, byte[] mBigImgBytes) : base(mId, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            mIMGByte = mImgByte;
            this.mBigImgBytes = mBigImgBytes;
        }

        public MBinary(byte[] mImgByte, byte[] mBigImgBytes)
        {
            mIMGByte = mImgByte;
            this.mBigImgBytes = mBigImgBytes;
        }

        private byte[] mIMGByte;
        private byte[] mBigImgBytes;
       


        public MBinary(){}

        public byte[] MIMGByte { get => mIMGByte; set => mIMGByte = value; }
        public byte[] MBigImgBytes { get => mBigImgBytes; set => mBigImgBytes = value; }
    }
}
