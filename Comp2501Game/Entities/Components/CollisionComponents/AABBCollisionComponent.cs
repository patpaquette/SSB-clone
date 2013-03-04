using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class AABBCollisionComponent : ObjectComponent
    {
        public bool Active;
        public List<AABB> CollisionBoxes;
        public bool Collided;
        public SegmentVec2 ProjectionSegment;

        public AABBCollisionComponent(GameObject parent, bool active)
            : base(parent)
        {
            this.CollisionBoxes = new List<AABB>();
            this.Active = active;
            this.Collided = false;
            this.ProjectionSegment = new SegmentVec2(Vector2.Zero, Vector2.Zero);
        }

        public AABBCollisionComponent(GameObject parent, bool active, List<AABB> collisionBoxes)
            : base(parent)
        {
            this.CollisionBoxes = collisionBoxes;
            this.Active = active;
        }

        public void AddAABB(AABB aabb)
        {
            this.CollisionBoxes.Add(aabb);
        }

        public override ComponentType GetType()
        {
            return ComponentType.AABBCollision;
        }
    }
}
