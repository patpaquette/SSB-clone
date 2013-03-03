using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems
{
    class AnimationSystem : GameSystem
    {
        public int playerNumber;

         public AnimationSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.Player);
            this.playerNumber = playerNum;
        }
    }
}
