using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Actor
    {
        private string actorName;
        private string actorWiki;

        public Actor()
        {
        }

        public Actor(string actorName, string actorWiki)
        {
            this.actorName = actorName;
            this.actorWiki = actorWiki;
        }

        public string ActorName { get => actorName; set => actorName = value; }
        public string ActorWiki { get => actorWiki; set => actorWiki = value; }
    }
}
