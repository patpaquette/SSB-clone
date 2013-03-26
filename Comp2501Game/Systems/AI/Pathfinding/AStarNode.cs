using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Systems.AI.Pathfinding
{
    public class AStarNode : IPosition2D
    {
        private class sortFScoreAscendingHelper : IComparer<AStarNode>
        {
            int IComparer<AStarNode>.Compare(AStarNode node1, AStarNode node2)
            {
                if (node1.FScore > node2.FScore)
                    return 1;
                else if (node1.FScore == node2.FScore)
                    return 0;
                else
                    return -1;
            }
        }

        public float GScore;
        public float FScore;
        public bool Visited;
        public bool Processed;
        private Vector2 _position;
        private List<AStarNode> _neighbors;
        private AStarNode _optimalPathParent;
        
        public AStarNode(Vector2 position)
            : this(position, new List<AStarNode>())
        {
        }

        public AStarNode(Vector2 position, List<AStarNode> neighbors)
        {
            this._position = position;
            this._neighbors = neighbors;
        }

        public void Initialize()
        {
            this.FScore = 0;
            this.GScore = 0;
            this.Visited = false;
            this.Processed = false;
            this._optimalPathParent = null;
        }

        public Vector2 GetPosition()
        {
            return this._position;
        }

        public List<AStarNode> GetNeighbors()
        {
            return this._neighbors;
        }

        public AStarNode GetOptimalPathParent()
        {
            return this._optimalPathParent;
        }

        public void SetOptimalPathParent(AStarNode node)
        {
            this._optimalPathParent = node;
        }

        public void AddNeighbor(AStarNode node)
        {
            this._neighbors.Add(node);
        }

        public static IComparer<AStarNode> sortFScoreAscending()
        {
            return (IComparer<AStarNode>)new sortFScoreAscendingHelper();
        }
    }
}
