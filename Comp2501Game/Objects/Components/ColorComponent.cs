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

        public ColorComponent(Color color)
        {
            this.Color = color;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Color;
        }
    }
}
