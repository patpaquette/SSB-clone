using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    class PlayerComponent : ObjectComponent
    {
        public int PlayerNumber;

        public PlayerComponent(GameObject parent, int playerNumber)
            : base(parent)
        {
            this.PlayerNumber = playerNumber;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Player;
        }
    }
}
