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
        public float Depth;
        public Vector2 Normal;
        public Vertex Vertex;
        public Edge Edge;

        public CollisionInfo(float depth, Vector2 normal, Vertex vertex, Edge edge)
        {
            this.Depth = depth;
            this.Normal = normal;
            this.Vertex = vertex;
            this.Edge = edge;
        }
    }
}
