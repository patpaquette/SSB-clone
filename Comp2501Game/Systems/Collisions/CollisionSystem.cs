using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.CollisionComponents;

namespace Comp2501Game.Systems.Collisions
{
    public delegate void CollisionHandler(CollisionInfo colInfo, float timestep);

    abstract class CollisionSystem : GameSystem
    {
        public static event CollisionHandler PhysicalCollision;

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
    }
}
