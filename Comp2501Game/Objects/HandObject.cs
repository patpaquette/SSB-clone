using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Types;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects
{
    class HandObject : GameObject
    {
        public HandObject(Game1 game, int playerNum)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new MapComponent(this, ScreenType.Character));
            this.AddComponent(new PlayerComponent(this, playerNum));
            this.AddComponent(new ArrowComponent(this));
            this.AddComponent(new HandComponent(this, playerNum, game, new Vector2(100 * playerNum, 350)));
            //this.AddComponent(select);
        }
    }

    class HandObject1 : GameObject
    {
        public HandObject1(Game1 game, int playerNum)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new MapComponent(this, ScreenType.HumanAI));
            this.AddComponent(new PlayerComponent(this, playerNum));
            this.AddComponent(new ArrowComponent(this));
            this.AddComponent(new HandComponent(this, playerNum, game, new Vector2(100 * playerNum, 350)));
            //this.AddComponent(select);
        }
    }

    class HandObject2 : GameObject
    {
        public HandObject2(Game1 game, int playerNum)//, SelectComponent select)
            : base(game)
        {
            this.AddComponent(new MapComponent(this, ScreenType.Credits));
            this.AddComponent(new PlayerComponent(this, playerNum));
            this.AddComponent(new ArrowComponent(this));
            this.AddComponent(new HandComponent(this, playerNum, game, new Vector2(1150 - 150 * playerNum, 625)));
            //this.AddComponent(select);
        }
    }
}
