using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Libs.Geometry
{
    public class Shape
    {
        private List<Vector2> _vertices;
        private List<Edge> _edges;

        public Shape(List<Vector2> vertices)
        {
            this._vertices = vertices;
            this._edges = this.resolveEdges(this._vertices);
        }

        public List<Vector2> GetVertices()
        {
            return this._vertices;
        }

        public List<Edge> GetEdges()
        {
            return this._edges;
        }

        private List<Edge> resolveEdges(List<Vector2> vertices)
        {
            List<Edge> edges = new List<Edge>();
            Vector2 vBuffer = vertices[0];

            foreach (Vector2 v in vertices.GetRange(1, vertices.Count-1))
            {
                edges.Add(new Edge(vBuffer, v));
                vBuffer = v;
            }

            edges.Add(new Edge(vertices[vertices.Count-1], vertices[0]));

            return edges;
        }
    }
}
