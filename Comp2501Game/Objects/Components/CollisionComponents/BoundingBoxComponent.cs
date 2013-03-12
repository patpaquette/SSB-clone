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

        public List<Shape> GetTransformedShapes()
        {
            Transform2DComponent transformComponent = (Transform2DComponent)ParentEntity.GetComponent(ComponentType.Transform2D);

            if (transformComponent != null)
            {
                List<Shape> transformedShapes = new List<Shape>();

                foreach (Shape shape in this._shapes)
                {
                    List<Vector2> transformedVertices = new List<Vector2>();

                    foreach (Vector2 v in shape.GetVertices())
                    {
                        transformedVertices.Add(new Vector2(v.X + transformComponent.GetTranslation().X, v.Y + transformComponent.GetTranslation().Y));
                    }

                    transformedShapes.Add(new Shape(transformedVertices));
                }

                return transformedShapes;
            }

            return this._shapes;
        }

        public override ComponentType GetType()
        {
            return ComponentType.BoundingBox;
        }
    }
}
