using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems
{
    class AABBCollisionSystem : GameSystem
    {
        private LineParametric _xAxis;
        private LineParametric _yAxis;
        private List<LineParametric> _axes;
        private Vector2 _windowCenter;

        public AABBCollisionSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.AABBCollision);
            this._axes = new List<LineParametric>();
        }

        public override void Initialize()
        {
            this._windowCenter = new Vector2(this.Game.Window.ClientBounds.Width / 2, this.Game.Window.ClientBounds.Height / 2);
            this._xAxis = new LineParametric(this._windowCenter, this._windowCenter + new Vector2(1.0f, 0.0f));
            this._yAxis = new LineParametric(this._windowCenter, this._windowCenter + new Vector2(0.0f, 1.0f));
            this._axes.Add(this._xAxis);
            this._axes.Add(this._yAxis);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj1 in this._objects)
            {
                AABBCollisionComponent colComponent = (AABBCollisionComponent)obj1.GetComponent(ComponentType.AABBCollision);
                colComponent.Collided = false;
                colComponent.ProjectionSegment = new SegmentVec2(Vector2.Zero, Vector2.Zero);

                if (colComponent.Active)
                {
                    foreach (GameObject obj2 in this._objects)
                    {
                        if (obj1 != obj2)
                        {
                            this.findCollisions(obj1, obj2);
                        }
                    }
                }
                
            }
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private void findCollisions(GameObject obj1, GameObject obj2)
        {
            PositionComponent obj1PosComponent = (PositionComponent)obj1.GetComponent(ComponentType.Position);
            PositionComponent obj2PosComponent = (PositionComponent)obj2.GetComponent(ComponentType.Position);
            AABBCollisionComponent obj1ColComponent = (AABBCollisionComponent)obj1.GetComponent(ComponentType.AABBCollision);
            AABBCollisionComponent obj2ColComponent = (AABBCollisionComponent)obj2.GetComponent(ComponentType.AABBCollision);
            SegmentVec2 projectionSegment = new SegmentVec2(Vector2.Zero, Vector2.Zero);
            SegmentVec2 overlapSegment;
            SegmentVec2 smallestOverlapSegment = new SegmentVec2(Vector2.Zero, new Vector2(999, 999));
            bool collision = true;

            foreach (AABB box in obj2ColComponent.CollisionBoxes)
            {
                box.Collided = false;
            }

            foreach (AABB box1 in obj1ColComponent.CollisionBoxes)
            {
                box1.Collided = false;
                

                foreach (AABB box2 in obj2ColComponent.CollisionBoxes)
                {
                    collision = true;

                    foreach (LineParametric axis in this._axes)
                    {
                        SegmentParametric box1Proj = LibFunc.GetParametricProjection(axis, box1.GetVertices());
                        SegmentParametric box2Proj = LibFunc.GetParametricProjection(axis, box2.GetVertices());
                        overlapSegment = LibFunc.GetOverlapSegmentVec2(box1Proj, box2Proj);

                        if (overlapSegment.GetVector2().LengthSquared() == 0)
                        {
                            collision = false;
                            break;
                        }
                        else
                        {
                            if (overlapSegment.GetVector2().LengthSquared() < smallestOverlapSegment.GetVector2().LengthSquared())
                            {
                                smallestOverlapSegment = overlapSegment;
                            }
                        }
                    }

                    if (collision)
                    {
                        box1.Collided = true;
                        box2.Collided = true;
                        if (smallestOverlapSegment.GetVector2().LengthSquared() > projectionSegment.GetVector2().LengthSquared())
                        {
                            projectionSegment = smallestOverlapSegment;
                        }
                    }
                }
            }

            if (projectionSegment.GetVector2().LengthSquared() != 0)
            {
                obj1ColComponent.Collided = true;
                obj1ColComponent.ProjectionSegment = projectionSegment;
            }
            
        }

    }
}
