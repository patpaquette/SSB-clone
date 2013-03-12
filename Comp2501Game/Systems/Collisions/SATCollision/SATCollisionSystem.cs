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
            this._componentDependencies.Add(Objects.Components.ComponentType.Transform2D);
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
            Transform2DComponent obj1Transform = (Transform2DComponent)obj1.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj1BoundingBox = (BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox);
            Transform2DComponent obj2Transform = (Transform2DComponent)obj2.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj2BoundingBox = (BoundingBoxComponent)obj2.GetComponent(ComponentType.BoundingBox);
            List<Shape> obj1ColShapes = obj1BoundingBox.GetTransformedShapes();
            List<Shape> obj2ColShapes = obj2BoundingBox.GetTransformedShapes();
            bool collision = false;
            Vector2 normal = new Vector2(0.0f, 0.0f);
            Edge edge;
            float depth = 0.0f;

            foreach (Shape obj1Shape in obj1ColShapes)
            {
                if (collision) break;
                
                List<Edge> edges = obj1Shape.GetEdges();

                foreach (Shape obj2Shape in obj2ColShapes)
                {
                    List<Edge> allEdges = new List<Edge>();
                    allEdges.AddRange(edges);
                    allEdges.AddRange(obj2Shape.GetEdges());
                    float minDistance = 9999.9f;
                    int edgeCounter = 0;
                    
                    Vector2 Vector2;
                    
                    foreach (Edge e in allEdges)
                    {
                        float obj1Min = 0.0f;
                        float obj1Max = 0.0f;
                        float obj2Min = 0.0f;
                        float obj2Max = 0.0f;

                        Vector2 v = e.GetNormalizedVector();
                        Vector2 axis = new Vector2(-v.Y, v.X);

                        LinearFunctions.ProjectShapeToAxis(
                            axis,
                            obj1Shape,
                            ref obj1Min,
                            ref obj1Max);

                        LinearFunctions.ProjectShapeToAxis(
                            axis,
                            obj2Shape,
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

                            if (edgeCounter == allEdges.Count())
                            {
                                collision = true;
                                break;
                            }
                        }
                        else
                        {
                            //no collision
                            break;
                        }
                    }
                }
                
            }

            //collision
            if (collision)
            {
                Vector2 obj2obj1_vector = obj2Transform.GetTranslation() - obj1Transform.GetTranslation();
                obj2obj1_vector.Normalize();
                normal.Normalize();

                if (Vector2.Dot(normal, obj2obj1_vector) > 0)
                {
                    normal = normal * -1;
                }

                obj1Transform.SetTranslation(obj1Transform.GetTranslation() + normal * depth);

                obj1BoundingBox.Collided = true;
                obj2BoundingBox.Collided = true;
                return new CollisionInfo(obj1, obj2, depth, normal);
            }
            else
            {
                return null;
            }
        }

    }
}
