using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class ColorComponent : ObjectComponent
    {
        public Color Color;

        public ColorComponent(GameObject parent, Color color)
            : base(parent)
        {
            this.Color = color;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Color;
        }
    }
}
