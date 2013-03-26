using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.AI
{
    class AIControllerComponent : ObjectComponent
    {
        public AIControllerComponent(GameObject parent)
            : base(parent)
        {
        }

        public override ComponentType GetType()
        {
            return ComponentType.AIController;
        }
    }
}
