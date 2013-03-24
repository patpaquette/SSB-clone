using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Physics;

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
                    if (!GameObject.AreRelated(obj1, obj2) && 
                        ((BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox)).Active)
                    {
                        CollisionInfo colInfo = this.checkCollision(
                            obj1, 
                            obj2, 
                            gameTime.ElapsedGameTime.Milliseconds/1000.0f
                        );

                        if (colInfo != null)
                        {
                            this.triggerCollisionEvent(colInfo, gameTime.ElapsedGameTime.Milliseconds / 1000.0f);
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

        private CollisionInfo checkCollision(GameObject obj1, GameObject obj2, float timestep)
        {
            Transform2DComponent obj1TransformComponent =
                (Transform2DComponent)obj1.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj1BoundingBoxComponent =
                (BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox);
            MotionPropertiesComponent obj1MotionComponent =
                (MotionPropertiesComponent)obj1.GetComponent(ComponentType.MotionProperties);
            Transform2DComponent obj2TransformComponent =
                (Transform2DComponent)obj2.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj2BoundingBoxComponent =
                (BoundingBoxComponent)obj2.GetComponent(ComponentType.BoundingBox);
            MotionPropertiesComponent obj2MotionComponent =
                (MotionPropertiesComponent)obj2.GetComponent(ComponentType.MotionProperties);

            List<Shape> obj1ColShapes = obj1BoundingBoxComponent.GetShapes();
            List<Shape> obj2ColShapes = obj2BoundingBoxComponent.GetShapes();
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

                        Matrix obj1Transform = obj1TransformComponent.GetCompoundTransform();
                        Matrix obj2Transform = obj2TransformComponent.GetCompoundTransform();

                        if (obj1MotionComponent != null)
                        {
                            Vector2 velocityVector = obj1MotionComponent.GetVelocity() * timestep;
                            obj1Transform = Matrix.Multiply(
                                obj1Transform,
                                Matrix.CreateTranslation(
                                    velocityVector.X,
                                    velocityVector.Y,
                                    0.0f
                                )
                            );
                        }

                        if (obj2MotionComponent != null)
                        {
                            Vector2 velocityVector = obj2MotionComponent.GetVelocity() * timestep;
                            obj2Transform = Matrix.Multiply(
                                obj2Transform,
                                Matrix.CreateTranslation(
                                    velocityVector.X,
                                    velocityVector.Y,
                                    0.0f
                                )
                            );
                        }


                        LinearFunctions.ProjectShapeToAxis(
                            axis,
                            LinearFunctions.GetTransformedShape(obj1Shape, obj1Transform),
                            ref obj1Min,
                            ref obj1Max);

                        LinearFunctions.ProjectShapeToAxis(
                            axis,
                            LinearFunctions.GetTransformedShape(obj2Shape, obj2Transform),
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
                return new CollisionInfo(obj1, obj2, depth, normal);
            }

            return null;
        }

    }
}
