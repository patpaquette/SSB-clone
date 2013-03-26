using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Libs.Geometry;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.AI.Pathfinding
{
    public class AStarGraph
    {
        private Game1 _game;
        private QuadTree<AStarNode> _quadTree;
        public List<AStarNode> Nodes;

        public AStarGraph(
            Game1 game,
            List<AStarNode> nodes)
        {
            this._game = game;
            this._quadTree = new QuadTree<AStarNode>(
                new Rectangle(
                    0,
                    0,
                    this._game.Window.ClientBounds.Width,
                    this._game.Window.ClientBounds.Height
                ), 
                1
            );

            this.Nodes = nodes;

            foreach (AStarNode node in nodes)
            {
                this._quadTree.Insert(node);
            }
        }

        public AStarNode GetClosestNode(Vector2 position)
        {
            return this._quadTree.GetClosest(position);
        }


    }
}
