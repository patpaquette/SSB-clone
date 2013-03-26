using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Types;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Objects
{
    class MapObject : GameObject
    {
        public MapObject(Game1 game, ScreenType type)
            : base (game)
        {
            this.AddComponent(new MapComponent(this, type));
        }
    }
}
