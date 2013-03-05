using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    class Score : ObjectComponent 
    {
        public int deaths;
        public int kills;

        public Score(GameObject parent)
            : base(parent)
        {
            this.deaths = 0;
            this.kills = 0;
        }

        public int getDeaths()
        {
            return this.deaths;
        }

        public int getKills()
        {
            return this.kills;
        }

        public int getScore()
        {
            return this.kills - this.deaths;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Score;
        }
    }
}
