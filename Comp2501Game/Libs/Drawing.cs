using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Libs.Geometry;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs
{
    static class Drawing
    {
        public static void DrawShape(Shape shape, Matrix transform, Color color, SpriteBatch spriteBatch)
        {
            List<Edge> edges = shape.GetEdges();

            foreach (Edge e in edges)
            {
                Vector2 transformedV1 = Vector2.Transform(e.V1, transform);
                Vector2 transformedV2 = Vector2.Transform(e.V2, transform);

                LineBatch.DrawLine(
                    spriteBatch,
                    color,
                    transformedV1,
                    transformedV2);
            }
        }

        public static void DrawLine(Vector2 p1, Vector2 p2, Color color, SpriteBatch spriteBatch)
        {
            LineBatch.DrawLine(spriteBatch, color, p1, p2);
        }
    }
}
