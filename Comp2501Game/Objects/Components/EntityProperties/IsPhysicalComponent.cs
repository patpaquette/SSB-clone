using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.CollisionComponents
{
    class IsPhysicalComponent : ObjectComponent
    {
        public bool Dynamic;

        public IsPhysicalComponent(GameObject parent, bool dynamic)
            : base(parent)
        {
            this.Dynamic = dynamic;
        }

        public override ComponentType GetType()
        {
            return ComponentType.IsPhysical;
        }
    }
}
