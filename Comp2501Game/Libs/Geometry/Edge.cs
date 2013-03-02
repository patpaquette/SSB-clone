using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    class Edge
    {
        public Vertex V1;
        public Vertex V2;

        public Edge(Vertex v1, Vertex v2)
        {
            this.V1 = v1;
            this.V2 = v2;
        }

        public Vector2 GetVector()
        {
            return new Vector2(this.V2.X - this.V1.X, this.V2.Y - this.V2.Y);   
        }

        public Vector2 GetNormalizedVector()
        {
            Vector2 v = new Vector2(this.V2.X - this.V1.X, this.V2.Y - this.V2.Y);
            v.Normalize();

            return v;
        }
    }
}
