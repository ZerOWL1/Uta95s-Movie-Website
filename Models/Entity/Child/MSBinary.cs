using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child
{
    public class MSBinary : Movie
    {
        public MSBinary(int mId, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, int sId, byte[] img, byte[] bigImg, string download) : base(mId, title, desc, totalEsp, nation, language, release, trailer, length, view, date)
        {
            sID = sId;
            _IMG = img;
            _BigIMG = bigImg;
            this.download = download;
        }

        public MSBinary(int mid, string title, int sId, byte[] img, byte[] bigImg, string download) : base(mid, title)
        {
            sID = sId;
            _IMG = img;
            _BigIMG = bigImg;
            this.download = download;
        }

        public MSBinary(int sId, byte[] img, byte[] bigImg, string download)
        {
            sID = sId;
            _IMG = img;
            _BigIMG = bigImg;
            this.download = download;
        }


        public MSBinary(){}

        private int sID;
        private byte[] _IMG;
        private byte[] _BigIMG;
        private string download;

        public int SID { get => sID; set => sID = value; }
        public byte[] IMG { get => _IMG; set => _IMG = value; }
        public byte[] BigIMG { get => _BigIMG; set => _BigIMG = value; }
        public string Download { get => download; set => download = value; }
    }
}
