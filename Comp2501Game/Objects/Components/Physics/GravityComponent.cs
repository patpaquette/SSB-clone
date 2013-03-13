using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Physics
{
    class GravityComponent : ObjectComponent
    {
        public float StrengthFactor;

        public GravityComponent(GameObject entity, float strengthFactor)
            : base(entity)
        {
            this.StrengthFactor = strengthFactor;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Gravity;
        }
    }
}
