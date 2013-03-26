using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Comp2501Game.Types;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects
{
    class TextObject : GameObject
    {
        public TextObject(Game1 game)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new VisibleTextComponent(this, new Vector2(490, 260), new Vector2(470, 480), 0 , "NONE"));
            this.AddComponent(new MapComponent(this, ScreenType.Mode));
        }
    }
}
