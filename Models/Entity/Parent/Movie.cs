using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Movie
    {
        public Movie(string title, string desc, int totalEsp, string nation, string language, string release, string trailer, int length, int view, DateTime date)
        {
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
        }

        public Movie()
        {
        }

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
    }
}
