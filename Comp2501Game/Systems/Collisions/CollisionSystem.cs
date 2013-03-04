﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.CollisionComponents;

namespace Comp2501Game.Systems.Collisions
{
    abstract class CollisionSystem : GameSystem
    {
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
    }
}
