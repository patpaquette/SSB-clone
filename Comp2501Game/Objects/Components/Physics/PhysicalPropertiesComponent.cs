using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components.Physics
{
    class PhysicalPropertiesComponent : ObjectComponent
    {
        public float Friction;

        public PhysicalPropertiesComponent(GameObject parent)
            : this(parent, 0.0f)
        {
        }

        public PhysicalPropertiesComponent(GameObject parent, float friction)
            : base(parent)
        {
            this.Friction = friction;
        }

        public override ComponentType GetType()
        {
            return ComponentType.PhysicalProperties;
        }
    }
}
