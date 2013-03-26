using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Systems.AI.Pathfinding;

namespace Comp2501Game.Libs.Geometry
{
    class QuadTree<T> where T:class, IPosition2D
    {
        public Rectangle Boundary;
        public QuadTree<T> NorthWest;
        public QuadTree<T> NorthEast;
        public QuadTree<T> SouthWest;
        public QuadTree<T> SouthEast;
        private List<QuadTree<T>> _children;
        public List<T> SpatialData;
        public int MaxNodeCapacity;

        public QuadTree(Rectangle boundary, int nodeCapacity)
        {
            this.MaxNodeCapacity = nodeCapacity;
            this.Boundary = boundary;
            this.SpatialData = new List<T>();
            this.NorthWest = null;
            this.NorthEast = null;
            this.SouthWest = null;
            this.SouthEast = null;
            this._children = new List<QuadTree<T>>();
        }

        public T GetClosest(Vector2 position)
        {
            if (!this.Boundary.Contains((int)position.X, (int)position.Y) || this.SpatialData.Count == 0)
            {
                return null;
            }

            T toReturn = SpatialData[0];
            float minLength = (SpatialData[0].GetPosition()-position).Length();

            foreach (T obj in this.SpatialData)
            {
                float length = (obj.GetPosition() - position).Length();

                if (length < minLength)
                {
                    minLength = length;
                    toReturn = obj;
                }
            }

            T childRet = null;

            foreach (QuadTree<T> child in this._children)
            {
                childRet = child.GetClosest(position);
                if (childRet != null)
                {
                    return childRet;
                }
            }

            return toReturn;
        }

        public List<T> QueryRange(Rectangle range)
        {
            List<T> dataInRange = new List<T>();

            if (!this.Boundary.Intersects(range)) return dataInRange;

            for (int i = 0; i <= this.SpatialData.Count; i++)
            {
                Vector2 point = this.SpatialData[i].GetPosition();

                if (range.Contains((int)point.X, (int)point.Y))
                {
                    dataInRange.Add(this.SpatialData[i]);
                }
            }

            if (this.NorthWest == null)
            {
                return dataInRange;
            }

            dataInRange.AddRange(this.NorthWest.QueryRange(range));
            dataInRange.AddRange(this.NorthEast.QueryRange(range));
            dataInRange.AddRange(this.SouthWest.QueryRange(range));
            dataInRange.AddRange(this.SouthEast.QueryRange(range));

            return dataInRange;
        }

        public bool Insert(T spatialDataPoint)
        {
            Vector2 point = spatialDataPoint.GetPosition();

            if (!this.Boundary.Contains((int)point.X, (int)point.Y))
            {
                return false;
            }

            if (this.SpatialData.Count < MaxNodeCapacity)
            {
                this.SpatialData.Add(spatialDataPoint);
                return true;
            }

            if (this.NorthWest == null)
            {
                this.Subdivide();
            }

            if (this.NorthWest.Insert(spatialDataPoint)) return true;
            if (this.NorthEast.Insert(spatialDataPoint)) return true;
            if (this.SouthWest.Insert(spatialDataPoint)) return true;
            if (this.SouthEast.Insert(spatialDataPoint)) return true;

            return false;
        }

        public void Subdivide()
        {
            Rectangle subRect = new Rectangle(
                this.Boundary.X,
                this.Boundary.Y,
                this.Boundary.Width/2,
                this.Boundary.Height/2
            );

            this.NorthWest = new QuadTree<T>(
                new Rectangle(
                    subRect.X,
                    subRect.Y,
                    subRect.Width,
                    subRect.Height
                ),
                this.MaxNodeCapacity
            );
            this.NorthEast = new QuadTree<T>(
                new Rectangle(
                    subRect.X + subRect.Width,
                    subRect.Y,
                    subRect.Width,
                    subRect.Height
                ),
                this.MaxNodeCapacity
            );
            this.SouthWest = new QuadTree<T>(
                new Rectangle(
                    subRect.X,
                    subRect.Y + subRect.Height,
                    subRect.Width,
                    subRect.Height
                ),
                this.MaxNodeCapacity
            );
            this.SouthEast = new QuadTree<T>(
                new Rectangle(
                    subRect.X + subRect.Width,
                    subRect.Y + subRect.Height,
                    subRect.Width,
                    subRect.Height
                ),
                this.MaxNodeCapacity
            );

            this._children = new List<QuadTree<T>>{
                this.NorthWest,
                this.NorthEast,
                this.SouthWest,
                this.SouthEast
            };
        }
    }
}
