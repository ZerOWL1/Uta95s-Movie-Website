using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Episode
    {
        public Episode(int mid, int episode, string title, string episodeLink)
        {
            _mid = mid;
            _episode = episode;
            _title = title;
            _episode_link = episodeLink;
        }

        public Episode(){}

        private int _mid;
        private int _episode;
        private string _title;
        private string _episode_link;

        public int _Mid { get => _mid; set => _mid = value; }
        public int _Episode { get => _episode; set => _episode = value; }
        public string _Title { get => _title; set => _title = value; }
        public string _Episode_link { get => _episode_link; set => _episode_link = value; }
    }
}
