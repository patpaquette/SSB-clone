using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    class Shape
    {
        private List<Vertex> _vertices;
        private List<Edge> _edges;

        public Shape(List<Vertex> vertices, List<Edge> edges)
        {
            this._vertices = vertices;
            this._edges = edges;
        }

        public List<Vertex> GetVertices()
        {
            return this._vertices;
        }

        public List<Edge> GetEdges()
        {
            return this._edges;
        }

        public void ProjectToAxis(Vector2 axis, ref float min, ref float max)
        {
            float proj = LinearFunctions.GetProjection(axis, this._vertices[0]);

            min = max = proj;

            for (int i = 1; i < this._vertices.Count; i++)
            {
                proj = LinearFunctions.GetProjection(axis, this._vertices[i]);

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
    }
}
