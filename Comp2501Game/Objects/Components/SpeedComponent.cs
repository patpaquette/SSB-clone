using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class SpeedComponent : ObjectComponent 
    {
        public Vector2 characterSpeed;

        public SpeedComponent(Vector2 speed)
        {
            this.characterSpeed = speed;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Speed;
        }
    }
}
