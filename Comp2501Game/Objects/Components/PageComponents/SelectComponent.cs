using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    class SelectComponent : ObjectComponent
    {
        public SpriteType player1;
        public SpriteType player2;

        public SelectComponent(GameObject parent)
            :   base (parent)
        {
            player1 = SpriteType.None;
            player2 = SpriteType.None;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Select;
        }


    }
}
