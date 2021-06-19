using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Entity
{
    public class Actor
    {
        private int actorID;
        private string actorName;
        private string actorWiki;

        public Actor()
        {
        }

        public Actor(int actorId, string actorName, string actorWiki)
        {
            actorID = actorId;
            this.actorName = actorName;
            this.actorWiki = actorWiki;
        }

        public int ActorID { get => actorID; set => actorID = value; }
        public string ActorName { get => actorName; set => actorName = value; }
        public string ActorWiki { get => actorWiki; set => actorWiki = value; }


    }
}
