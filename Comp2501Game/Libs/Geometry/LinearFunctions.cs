using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    public static class LinearFunctions
    {
        public static Vector2 ClosestPointOnLine1P(
            Vector2 linePoint1,
            Vector2 linePoint2,
            Vector2 point,
            bool segmentClamp)
        {
            Vector2 p1p2 = linePoint2 - linePoint1;
            Vector2 p1p = point - linePoint1;
            float p1p2LengthSquared = p1p2.LengthSquared();
            float p1p_p1p2_dot = p1p.X * p1p2.X + p1p.Y * p1p2.Y;
            float t = p1p_p1p2_dot / p1p2LengthSquared;
            if (segmentClamp)
            {
                if (t < 0.0f) t = 0.0f;
                else if (t > 1.0f) t = 1.0f;
            }
            return linePoint1 + p1p2 * t;
        }

        public static Vector2 ClosestPointOnLine1P(
            LineParametric line,
            Vector2 point,
            bool segmentClamp)
        {
            return ClosestPointOnLine1P(line.a, line.b, point, segmentClamp);
        }

        public static SegmentParametric GetParametricProjection(
            LineParametric line,
            List<Vector2> vertices)
        {
            PointParametric max = new PointParametric(line, -999999);
            PointParametric min = new PointParametric(line, 999999);
            PointParametric tempPoint;

            foreach (Vector2 Vector2 in vertices)
            {
                tempPoint = line.GetProjectionPoint(Vector2);
                if (tempPoint.T > max.T)
                {
                    max = tempPoint;
                }
                else if (tempPoint.T < min.T)
                {
                    min = tempPoint;
                }
            }

            return new SegmentParametric(line, min.T, max.T);
        }

        public static float GetProjection(
            Vector2 axis,
            Vector2 vertex
            )
        {
            float dotProduct = Vector2.Dot(axis, vertex);
            return dotProduct;
        }

        public static float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            if (minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }

        public static SegmentVec2 GetOverlapSegmentVec2(SegmentParametric seg1, SegmentParametric seg2)
        {
            if (seg1.Line != seg2.Line)
            {
                return new SegmentVec2(Vector2.Zero, Vector2.Zero); ;
            }

            float lengthSeg1 = Math.Abs(seg1.T2 - seg1.T1);
            float lengthSeg2 = Math.Abs(seg2.T2 - seg2.T1);
            float minT = (seg1.T1 < seg2.T1) ? seg1.T1 : seg2.T1;
            float maxT = (seg1.T2 > seg2.T2) ? seg1.T2 : seg2.T2;
            float totalTLength = lengthSeg1 + lengthSeg2;
            float combinedTLength = Math.Abs(maxT - minT);

            if (combinedTLength < totalTLength)
            {
                SegmentParametric proj1 = new SegmentParametric(seg1.Line, seg1.T2, seg2.T1);
                SegmentParametric proj2 = new SegmentParametric(seg1.Line, seg1.T1, seg2.T2);

                if (proj1.GetLength() < proj2.GetLength())
                {
                    return proj1.GetSegmentVec2();
                }
                else
                {
                    return proj2.GetSegmentVec2();
                }
            }
            else
            {
                return new SegmentVec2(Vector2.Zero, Vector2.Zero);
            }
        }

        public static void ProjectShapeToAxis(Vector2 axis, Shape shape, ref float min, ref float max)
        {
            List<Vector2> vertices = shape.GetVertices();
            float proj = LinearFunctions.GetProjection(axis, vertices[0]);

            min = max = proj;

            for (int i = 1; i < vertices.Count; i++)
            {
                proj = LinearFunctions.GetProjection(axis, vertices[i]);

                if (proj < min)
                {
                    min = proj;
                }
                else if (proj > max)
                {
                    max = proj;
                }
            }
        }

        public static List<Vector2> GetTransformedVertices(List<Vector2> vertices, Vector2 translation)
        {
            List<Vector2> transformedVertices = new List<Vector2>();

            foreach (Vector2 v in vertices)
            {
                transformedVertices.Add(v + translation);
            }

            return transformedVertices;
        }
    }
}
