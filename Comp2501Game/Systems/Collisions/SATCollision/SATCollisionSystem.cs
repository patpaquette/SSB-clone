using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.Collisions
{
    class SATCollisionSystem : CollisionSystem
    {
        public SATCollisionSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(Objects.Components.ComponentType.Position);
            this._componentDependencies.Add(Objects.Components.ComponentType.BoundingBox);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this._collisions.Clear();
            foreach (GameObject obj in this._objects)
            {
                ((BoundingBoxComponent)obj.GetComponent(ComponentType.BoundingBox)).Collided = false;
            }

            foreach (GameObject obj1 in this._objects)
            {
                foreach (GameObject obj2 in this._objects)
                {
                    if (obj1 != obj2 && 
                        ((BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox)).Active)
                    {
                        CollisionInfo collision = this.checkCollision(obj1, obj2);

                        if (collision != null)
                        {
                            this._collisions.Add(collision);
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private CollisionInfo checkCollision(GameObject obj1, GameObject obj2)
        {
            PositionComponent obj1Position = (PositionComponent)obj1.GetComponent(ComponentType.Position);
            BoundingBoxComponent obj1BoundingBox = (BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox);
            PositionComponent obj2Position = (PositionComponent)obj2.GetComponent(ComponentType.Position);
            BoundingBoxComponent obj2BoundingBox = (BoundingBoxComponent)obj2.GetComponent(ComponentType.BoundingBox);
            List<Edge> edges = obj1BoundingBox.GetShape().GetEdges();
            edges.AddRange(obj2BoundingBox.GetShape().GetEdges());
            float minDistance = 9999.9f;
            int edgeCounter = 0;
            float depth = 0.0f;
            Vector2 normal = new Vector2(0.0f, 0.0f);
            Vector2 Vector2;
            Edge edge;


            foreach (Edge e in edges)
            {
                float obj1Min = 0.0f;
                float obj1Max = 0.0f;
                float obj2Min = 0.0f;
                float obj2Max = 0.0f;

                Vector2 v = e.GetNormalizedVector();
                Vector2 axis = new Vector2(-v.Y, v.X);

                LinearFunctions.ProjectShapeToAxis(
                    axis, 
                    obj1BoundingBox.GetTransformedShape(), 
                    ref obj1Min, 
                    ref obj1Max);

                LinearFunctions.ProjectShapeToAxis(
                    axis, 
                    obj2BoundingBox.GetTransformedShape(), 
                    ref obj2Min, 
                    ref obj2Max);

                float distance = LinearFunctions.IntervalDistance(obj1Min, obj1Max, obj2Min, obj2Max);

                if (distance < 0) //projection overlap
                {
                    distance = Math.Abs(distance);
                    if (Math.Abs(distance) < Math.Abs(minDistance)) //keep smallest collision vector
                    {
                        minDistance = distance;
                        depth = minDistance;
                        normal = axis;
                    }
                    edgeCounter++;
                }
                else
                {
                    //no collision
                    return null;
                }
            }

            //collision
            Vector2 obj2obj1_vector = obj2Position.Position - obj1Position.Position;
            obj2obj1_vector.Normalize();
            normal.Normalize();

            if (Vector2.Dot(normal, obj2obj1_vector) > 0)
            {
                normal = normal * -1;
            }

            obj1Position.Position = obj1Position.Position + normal * depth;

            obj1BoundingBox.Collided = true;
            obj2BoundingBox.Collided = true;
            return new CollisionInfo(obj1, obj2, depth, normal);
        }

    }
}
