using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Objects.Components.CollisionComponents
{
    class CollisionInfo
    {
        public GameObject Entity1;
        public GameObject Entity2;
        public float Depth;
        public Vector2 Normal;
        //public Vector2 Vector2;
        //public Edge Edge;

        public CollisionInfo(GameObject entity1, GameObject entity2, float depth, Vector2 normal)//, Vector2 Vector2, Edge edge)
        {
            this.Entity1 = entity1;
            this.Entity2 = entity2;
            this.Depth = depth;
            this.Normal = normal;
        }
    }
}
