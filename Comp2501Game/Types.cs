using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    public struct SegmentVec2
    {
        public Vector2 P1;
        public Vector2 P2;

        public SegmentVec2(Vector2 p1, Vector2 p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public Vector2 GetVector2()
        {
            return this.P2 - this.P1;
        }
    }

    public struct SegmentParametric
    {
        public LineParametric Line;
        public float T1;
        public float T2;

        public SegmentParametric(LineParametric line, float t1, float t2)
        {
            this.Line = line;
            this.T1 = t1;
            this.T2 = t2;
        }

        public float GetLength()
        {
            return Math.Abs(this.T2 - this.T1);
        }

        public SegmentVec2 GetSegmentVec2()
        {
            return new SegmentVec2(
                this.Line.GetPoint(this.T1),
                this.Line.GetPoint(this.T2));
        }
    }

    public struct PointParametric
    {
        public LineParametric Line;
        public float T;

        public PointParametric(LineParametric line, float t)
        {
            this.Line = line;
            this.T = t;
        }

        public Vector2 GetPointVec2()
        {
            return this.Line.GetPoint(this.T);
        }
    }

    public class LineParametric
    {
        public Vector2 a;
        public Vector2 b;
        public Vector2 AB;

        public LineParametric(Vector2 P1, Vector2 P2)
        {
            this.a = P1;
            this.b = P2;
            this.AB = this.b - this.a;
        }

        public Vector2 GetPoint(float t)
        {
            return this.a + this.AB * t;
        }

        public PointParametric GetProjectionPoint(Vector2 point)
        {
            Vector2 AP = point - a;
            float ABLengthSquared = this.AB.LengthSquared();
            float AP_AB_dot = AP.X * AB.X + AP.Y * AB.Y;

            return new PointParametric(this, AP_AB_dot / ABLengthSquared);
        }
    }
}
