using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    /// <summary>
    /// Movie Actor Director
    /// </summary>
    public class MovieAD
    {
        public MovieAD(int mId, string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date, string download, int actorId, string actorName, string actorWiki, int did, string dName, string dNational)
        {
            mID = mId;
            this.title = title;
            this.desc = desc;
            this.totalEsp = totalEsp;
            this.nation = nation;
            this.language = language;
            this.release = release;
            this.trailer = trailer;
            this.length = length;
            this.view = view;
            this.date = date;
            this.download = download;
            actorID = actorId;
            this.actorName = actorName;
            this.actorWiki = actorWiki;
            this.did = did;
            this.dName = dName;
            this.dNational = dNational;
        }

        public MovieAD(){}

        private int mID;
        private string title;
        private string desc;
        private int totalEsp;
        private string nation;
        private string language;
        private string release;
        private string trailer;
        private int length;
        private int view;
        private DateTime date;
        private string download;
        private int actorID;
        private string actorName;
        private string actorWiki;
        private int did;
        private string dName;
        private string dNational;

        public int MID { get => mID; set => mID = value; }
        public string Title { get => title; set => title = value; }
        public string Desc { get => desc; set => desc = value; }
        public int TotalEsp { get => totalEsp; set => totalEsp = value; }
        public string Nation { get => nation; set => nation = value; }
        public string Language { get => language; set => language = value; }
        public string Release { get => release; set => release = value; }
        public string Trailer { get => trailer; set => trailer = value; }
        public int Length { get => length; set => length = value; }
        public int View { get => view; set => view = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Download { get => download; set => download = value; }
        public int ActorID { get => actorID; set => actorID = value; }
        public string ActorName { get => actorName; set => actorName = value; }
        public string ActorWiki { get => actorWiki; set => actorWiki = value; }
        public int Did { get => did; set => did = value; }
        public string DName { get => dName; set => dName = value; }
        public string DNational { get => dNational; set => dNational = value; }
    }
}
