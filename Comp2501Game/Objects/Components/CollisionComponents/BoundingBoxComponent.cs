using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Libs.Geometry;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components.CollisionComponents
{
    class BoundingBoxComponent : ObjectComponent
    {
        public Boolean Active;
        public Boolean Collided;
        public String Group;

        private List<Shape> _shapes;


        public BoundingBoxComponent(GameObject parent, List<Shape> shapes, Boolean active)
            : base(parent)
        {
            this._shapes = shapes;
            this.Active = active;
        }

        public List<Shape> GetShapes()
        {
            return this._shapes;
        }
 
        public override ComponentType GetType()
        {
            return ComponentType.BoundingBox;
        }
    }
}
