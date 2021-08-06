using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MDownload : Movie
    {
        public MDownload(int mId, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, string download, string mImg64, string mBigImg64) : base(mId, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            this.download = download;
            mIMG64 = mImg64;
            mBigIMG64 = mBigImg64;
        }

        public MDownload(string download, string mImg64, string mBigImg64)
        {
            this.download = download;
            mIMG64 = mImg64;
            mBigIMG64 = mBigImg64;
        }
        public MDownload(){}

        private string download;
        private string mIMG64;
        private string mBigIMG64;

        public string Download { get => download; set => download = value; }
        public string MIMG64 { get => mIMG64; set => mIMG64 = value; }
        public string MBigIMG64 { get => mBigIMG64; set => mBigIMG64 = value; }
    }
}
