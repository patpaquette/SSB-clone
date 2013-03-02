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
            foreach (GameObject obj1 in this._objects)
            {
                PositionComponent obj1Position = (PositionComponent)obj1.GetComponent(ComponentType.Position);
                BoundingBoxComponent obj1BoundingBox = (BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox);

                foreach (GameObject obj2 in this._objects)
                {
                    if (obj1 != obj2)
                    {
                        PositionComponent obj2Position = (PositionComponent)obj2.GetComponent(ComponentType.Position);
                        BoundingBoxComponent obj2BoundingBox = (BoundingBoxComponent)obj2.GetComponent(ComponentType.BoundingBox);
                        List<Edge> edges = obj1BoundingBox.GetShape().GetEdges();
                        edges.AddRange(obj2BoundingBox.GetShape().GetEdges());
                        float minDistance = 0.0f;
                        int edgeCounter = 0;
                        float depth = 0.0f;
                        Vector2 normal = new Vector2(0.0f, 0.0f);
                        Vertex vertex;
                        Edge edge;


                        foreach (Edge e in edges)
                        {
                            float obj1Min = 0.0f;
                            float obj1Max = 0.0f;
                            float obj2Min = 0.0f;
                            float obj2Max = 0.0f;

                            Vector2 axis = e.GetNormalizedVector();
                            

                            obj1BoundingBox.GetShape().ProjectToAxis(axis, ref obj1Min, ref obj1Max);
                            obj2BoundingBox.GetShape().ProjectToAxis(axis, ref obj2Min, ref obj2Max);

                            float distance = LinearFunctions.IntervalDistance(obj1Min, obj1Max, obj2Min, obj2Max);

                            if (distance < 0) //collision
                            {
                                if (distance < minDistance) //keep smallest collision vector
                                {
                                    minDistance = distance;
                                    depth = minDistance;


                                }
                                edgeCounter++;
                            }
                            else
                            {
                                //no collision
                                break;
                            }

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

    }
}
