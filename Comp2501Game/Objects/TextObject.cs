using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Comp2501Game.Types;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Types;

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


    class TextObject1 : GameObject
    {
        public TextObject1(Game1 game)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new VisibleTextComponent(this, new Vector2(490, 260), new Vector2(470, 480), 0, "NONE"));
            this.AddComponent(new MapComponent(this, ScreenType.Map));
        }

    }


    class TextObject2 : GameObject
    {
        public TextObject2(Game1 game, MapType map)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new VisibleTextComponent(this, new Vector2(490, 260), new Vector2(470, 480), 0, "NONE"));

            if (map == MapType.Hyrule)
            {
                this.AddComponent(new MapComponent(this, ScreenType.Hyrule));
            }
            else
            {
                this.AddComponent(new MapComponent(this, ScreenType.Basic));
            }
        }

    }
}
