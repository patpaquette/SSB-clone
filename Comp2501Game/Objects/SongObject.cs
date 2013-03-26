using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Types;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Objects
{
    class SongObject : GameObject
    {
        public SongObject(Game1 game, MapType screenType)
            : base(game)
        {
            this.AddComponent(new SongComponent(this, screenType));

        }
    }
}
