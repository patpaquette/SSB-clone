using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components.Actions
{
    class ActionInfoProjectile : ActionInfo
    {
        public Vector2 Velocity;
        public int Lifetime; //in milliseconds
        public Vector2 OnHitForce;
        public int OnHitDamage;
        public int Timing;
        public Rectangle BoundingBoxRect;

        public ActionInfoProjectile(
            Vector2 velocity,
            int lifetime,
            Vector2 OnHitForce,
            int OnHitDamage,
            Rectangle boundingBoxRect,
            int timing)
            : base()
        {
            this.Velocity = velocity;
            this.Lifetime = lifetime;
            this.OnHitForce = OnHitForce;
            this.OnHitDamage = OnHitDamage;
            this.BoundingBoxRect = boundingBoxRect;
            this.Timing = timing;
        }

        public override ActionType GetType()
        {
            return ActionType.AttackProjectile;
        }
    }
}
