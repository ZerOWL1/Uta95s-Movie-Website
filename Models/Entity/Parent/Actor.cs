using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent
{
    public class Actor
    {
        private string actorID;
        private string actorName;
        private string actorWiki;

        public Actor()
        {
        }

        public Actor(string actorId, string actorName, string actorWiki)
        {
            actorID = actorId;
            this.actorName = actorName;
            this.actorWiki = actorWiki;
        }

        public string ActorID { get => actorID; set => actorID = value; }
        public string ActorName { get => actorName; set => actorName = value; }
        public string ActorWiki { get => actorWiki; set => actorWiki = value; }
    }
}
