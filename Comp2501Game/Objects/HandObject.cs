using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Types;

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
            this.AddComponent(new HandComponent(this, playerNum, game));
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
            this.AddComponent(new HandComponent(this, playerNum, game));
            //this.AddComponent(select);
        }
    }
}
