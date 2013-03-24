using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems.Collisions
{
    public delegate void CollisionHandler(CollisionInfo colInfo, float timestep);

    abstract class CollisionSystem : GameSystem
    {
        public static event CollisionHandler PhysicalCollision;
        public static event CollisionHandler ActionCollision;

        protected List<CollisionInfo> _collisions;

        public CollisionSystem(Game1 game)
            : base(game)
        {
            this._collisions = new List<CollisionInfo>();
        }

        public List<CollisionInfo> GetCollisions()
        {
            return this._collisions;
        }

        protected void triggerPhysicalCollision(CollisionInfo colInfo, float timestep)
        {
            PhysicalCollision(colInfo, timestep);
        }

        protected void triggerActionCollision(CollisionInfo colInfo, float timestep)
        {
            ActionCollision(colInfo, timestep);
        }

        protected void triggerCollisionEvent(CollisionInfo colInfo, float timestep)
        {
            GameObject obj1 = colInfo.Entity1;
            GameObject obj2 = colInfo.Entity2;

            if (obj1.HasComponent(ComponentType.IsPhysical) && obj2.HasComponent(ComponentType.IsPhysical))
            {
                this.triggerPhysicalCollision(colInfo, timestep);
            }

            if (obj1.HasComponent(ComponentType.IsAction) && obj2.HasComponent(ComponentType.IsCharacter))
            {
                this.triggerActionCollision(colInfo, timestep);
            }
        }
    }
}
