using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.Collisions
{
    public delegate void CollisionHandler(CollisionInfo colInfo, float timestep);

    abstract class CollisionSystem : GameSystem
    {
        public static event CollisionHandler PhysicalCollision;
        public static event CollisionHandler ActionCollision;
        private CollisionType _collisionTypeToCheck;

        protected List<CollisionInfo> _collisions;

        public CollisionSystem(Game1 game)
            : this(game, "")
        {
        }

        public CollisionSystem(Game1 game, string name)
            : base(game, name)
        {
            this._collisions = new List<CollisionInfo>();
            this._collisionTypeToCheck = CollisionType.All;
        }

        public List<CollisionInfo> GetCollisions()
        {
            return this._collisions;
        }

        public override SystemType GetType()
        {
            return SystemType.Service;
        }

        public void CheckCollisions(CollisionType collisionType, GameTime gameTime)
        {
            this._collisionTypeToCheck = collisionType;

            this.Update(gameTime);
            
        }

        protected bool MustCheckCollision(GameObject obj1, GameObject obj2)
        {
            if (this._collisionTypeToCheck == CollisionType.All)
            {
                return true;
            }
            else if (this._collisionTypeToCheck == CollisionType.Action)
            {
                if (obj1.HasComponent(ComponentType.IsAction) && obj2.HasComponent(ComponentType.IsCharacter))
                {
                    return true;
                }
            }
            else if (this._collisionTypeToCheck == CollisionType.Physical)
            {
                if (obj1.HasComponent(ComponentType.IsPhysical) && obj2.HasComponent(ComponentType.IsPhysical))
                {
                    return true;
                }
            }

            return false;
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
