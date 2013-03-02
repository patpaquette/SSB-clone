using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects
{
    using Components;
using Microsoft.Xna.Framework;

    class TimeObject : GameObject
    {
        //cunstructor
        public TimeObject(Game1 game, Vector2 posit, Color col) : base (game)
        {
            this.AddComponent(new PositionComponent(posit));

            this.AddComponent(new ColorComponent(col));

            this.AddComponent(new TimerComponent());
        }
    }
}
