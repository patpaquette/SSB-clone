using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    class LifetimeComponent : ObjectComponent
    {
        public int Lifetime;

        public LifetimeComponent(GameObject parent, int lifetime)
            : base(parent)
        {
            this.Lifetime = lifetime;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Lifetime;
        }
    }
}
