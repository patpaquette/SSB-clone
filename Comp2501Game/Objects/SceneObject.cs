using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Types;

namespace Comp2501Game.Objects
{
    class SceneObject : GameObject
    {
        public SceneObject(Game1 game, ScreenType screenType)
            : base(game)
        {
            this.AddComponent(new MapComponent(this, screenType));

        }
    }
}
