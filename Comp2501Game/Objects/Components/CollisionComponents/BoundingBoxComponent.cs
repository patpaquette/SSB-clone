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
        private Shape _shape;


        public BoundingBoxComponent(GameObject parent, Shape shape, Boolean active)
            : base(parent)
        {
            this._shape = shape;
            this.Active = active;
        }

        public Shape GetShape()
        {
            return this._shape;
        }

        public Shape GetTransformedShape()
        {
            Transform2DComponent transformComponent = (Transform2DComponent)ParentEntity.GetComponent(ComponentType.Transform2D);

            if (transformComponent != null)
            {
                List<Vector2> transformedVertices = new List<Vector2>();

                foreach (Vector2 v in this._shape.GetVertices())
                {
                    transformedVertices.Add(new Vector2(v.X + transformComponent.GetTranslation().X, v.Y + transformComponent.GetTranslation().Y));
                }

                return new Shape(transformedVertices);
            }

            return this._shape;
        }

        public override ComponentType GetType()
        {
            return ComponentType.BoundingBox;
        }
    }
}
