using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Objects.Components.CollisionComponents
{
    class BoundingBoxComponent : ObjectComponent
    {
        private Shape _shape;

        public BoundingBoxComponent(Shape shape)
        {
            this._shape = shape;
        }

        public Shape GetShape()
        {
            return this._shape;
        }

        public override ComponentType GetType()
        {
            return ComponentType.BoundingBox;
        }
    }
}
