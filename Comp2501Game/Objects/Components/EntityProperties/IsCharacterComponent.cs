using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.EntityProperties
{
    class IsCharacterComponent : ObjectComponent
    {
        public IsCharacterComponent(GameObject parent)
            : base(parent)
        {
        }

        public override ComponentType GetType()
        {
            return ComponentType.IsCharacter;
        }
    }
}
