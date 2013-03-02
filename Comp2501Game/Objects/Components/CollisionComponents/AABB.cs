using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class AABB
    {
        public Vector2 Position;
        public int Width;
        public int Height;
        private PositionComponent _parentPositionComponent;
        public bool Collided;
        public SegmentVec2 ProjectionSegment;

        public AABB(PositionComponent parentPosition, Vector2 offsetPosition, int width, int height)
        {
            this.Position = offsetPosition;
            this.Width = width;
            this.Height = height;
            this._parentPositionComponent = parentPosition;
            this.Collided = false;
            this.ProjectionSegment = new SegmentVec2(Vector2.Zero, Vector2.Zero);
        }

        public List<Vector2> GetVertices()
        {
            Vector2 translation = this._parentPositionComponent.Position;
            List<Vector2> vertices = new List<Vector2>();
            Vector2 position = translation + this.Position;
            vertices.Add(position);
            vertices.Add(position + new Vector2(this.Width, 0.0f));
            vertices.Add(position + new Vector2(0.0f, this.Height));
            vertices.Add(position + new Vector2(this.Width, this.Height));

            return vertices;
        }
    }
}
