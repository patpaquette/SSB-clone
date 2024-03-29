﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class PositionComponent : ObjectComponent
    {
        public Vector2 Position;

        public PositionComponent(GameObject parent, Vector2 pos)
            : base (parent)
        {
            this.Position = pos;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Position;
        }
    }
}
