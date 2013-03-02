using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game
{
    public static class LibFunc
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

            foreach (Vector2 vertex in vertices)
            {
                tempPoint = line.GetProjectionPoint(vertex);
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

        public static SegmentVec2 GetOverlapSegmentVec2(SegmentParametric seg1, SegmentParametric seg2)
        {
            if (seg1.Line != seg2.Line)
            {
                return new SegmentVec2(Vector2.Zero, Vector2.Zero); ;
            }

            float lengthSeg1 = Math.Abs(seg1.T2-seg1.T1);
            float lengthSeg2 = Math.Abs(seg2.T2-seg2.T1);
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

        public static void DrawEmptyRect(
            SpriteBatch batch, 
            Vector2 position, 
            int width, 
            int height, 
            Color color)
        {
            LineBatch.DrawLine(
                batch,
                color,
                position,
                position + new Vector2(width, 0.0f));
            LineBatch.DrawLine(
                batch,
                color,
                position + new Vector2(width, 0.0f),
                position + new Vector2(width, height));
            LineBatch.DrawLine(
                batch,
                color,
                position + new Vector2(width, height),
                position + new Vector2(0.0f, height));
            LineBatch.DrawLine(
                batch,
                color,
                position,
                position + new Vector2(0.0f, height));
        }

    }

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

    /// <summary>
    /// Line Batch
    /// For drawing lines in a spritebatch
    /// http://www.david-amador.com/2010/01/drawing-lines-in-xna/
    /// </summary>
    public static class LineBatch
    {
        static private Texture2D _empty_texture;
        static private bool _set_data = false;

        static public void Init(GraphicsDevice device)
        {
            _empty_texture = new Texture2D(device, 1, 2, false, SurfaceFormat.Color);
        }

        static public void DrawLine(SpriteBatch batch, Color color,
                                    Vector2 point1, Vector2 point2)
        {

            DrawLine(batch, color, point1, point2, 0);
        }

        /// <summary>
        /// Draw a line into a SpriteBatch
        /// </summary>
        /// <param name="batch">SpriteBatch to draw line</param>
        /// <param name="color">The line color</param>
        /// <param name="point1">Start Point</param>
        /// <param name="point2">End Point</param>
        /// <param name="Layer">Layer or Z position</param>
        static public void DrawLine(SpriteBatch batch, Color color, Vector2 point1,
                                    Vector2 point2, float Layer)
        {
            //Check if data has been set for texture
            //Do this only once otherwise
            if (!_set_data)
            {
                _empty_texture.SetData(new[] { Color.White, Color.White });
                _set_data = true;
            }


            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = (point2 - point1).Length();

            batch.Draw(_empty_texture, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, 1),
                       SpriteEffects.None, Layer);
        }
    }
}
