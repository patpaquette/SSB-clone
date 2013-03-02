using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    class Vertex
    {
        public float X;
        public float Y;

        public Vertex(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(this.X, this.Y);
        }
    }
}
