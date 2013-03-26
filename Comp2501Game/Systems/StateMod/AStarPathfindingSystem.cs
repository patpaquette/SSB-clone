using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems.AI.Pathfinding;
using Comp2501Game.Objects.Components.AI.Pathfinding;
using Microsoft.Xna.Framework;
using Libs.DataStructure;

namespace Comp2501Game.Systems.StateMod
{
    class AStarPathfindingSystem : GameSystem
    {
        private int _cooldown;

        public AStarPathfindingSystem(Game1 game, string name, int cooldown)
            : base(game, name)
        {
            this._componentDependencies.Add(ComponentType.AStar);
            this._cooldown = cooldown;
        }

        public override void Initialize()
        {

            base.Initialize();
        }


        public bool GetBestPath(GameObject obj, GameTime gameTime, AStarGraph graph)
        {
            Stack<AStarNode> path = new Stack<AStarNode>();

            Transform2DComponent transformComponent = 
                (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
            AStarComponent aStarComponent =
                (AStarComponent)obj.GetComponent(ComponentType.AStar);

            if (transformComponent == null || aStarComponent == null)
            {
                return false;
            }

            AStarNode entityNode = graph.GetClosestNode(transformComponent.GetTranslation());
            AStarNode goalNode;

            if (aStarComponent.Follow)
            {
                GameObject entity = aStarComponent.EntityToFollow;
                Transform2DComponent entityTransformComponent =
                    (Transform2DComponent)entity.GetComponent(ComponentType.Transform2D);
                aStarComponent.EntityToFollowPosBuffer = entityTransformComponent.GetTranslation();

                goalNode = graph.GetClosestNode(aStarComponent.EntityToFollowPosBuffer);
            }
            else
            {
                goalNode = graph.GetClosestNode(aStarComponent.GoalPosition);
            }

            this.resolvePath(aStarComponent, entityNode, goalNode, graph);

            return true;
        }

        private void resolvePath(AStarComponent aStarComponent, AStarNode currentNode_in, AStarNode goalNode_in, AStarGraph graph_in)
        {
            BinaryPriorityQueue<AStarNode> openset = 
                new BinaryPriorityQueue<AStarNode>(AStarNode.sortFScoreAscending());
            AStarNode currentNode = currentNode_in;
            AStarNode goalNode = goalNode_in;
            AStarGraph graph = graph_in;

            if (currentNode != null)
            {
                aStarComponent.ClearPath();

                for (int i = 0; i < graph.Nodes.Count; i++)
                {
                    graph.Nodes[i].Initialize();
                }

                openset.Push(currentNode);
                currentNode.FScore = this.getFScore(currentNode, goalNode);

                while (openset.Count > 0)
                {
                    AStarNode current;

                    current = openset.Pop();

                    List<AStarNode> neighbors = current.GetNeighbors();

                    if (current.GetPosition() == goalNode.GetPosition())
                    {
                        AStarNode node = current;

                        while (node.GetOptimalPathParent() != null)
                        {
                            aStarComponent.Path.Push(node);
                            node = node.GetOptimalPathParent();
                        }

                        //aStarComponent.Path.Push(node);

                        break;
                    }

                    current.Processed = true;

                    for (int i = 0; i < neighbors.Count; i++)
                    {
                        AStarNode neighbor = neighbors[i];

                        if (!neighbor.Processed)
                        {
                            float tentative_g_score =
                                current.GScore + (current.GetPosition() - neighbor.GetPosition()).Length();

                            if (!neighbor.Visited || tentative_g_score <= neighbor.GScore)
                            {
                                neighbor.SetOptimalPathParent(current);
                                neighbor.GScore = tentative_g_score;
                                neighbor.FScore = neighbor.GScore + this.getFScore(neighbor, goalNode);

                                if (!neighbor.Visited)
                                {
                                    neighbor.Visited = true;
                                }
                                openset.Push(neighbor);
                            }
                        }
                    }
                }
            }
        }

        private float getFScore(AStarNode node1, AStarNode node2)
        {
            float distance = (node1.GetPosition() - node2.GetPosition()).Length();
            return distance;
        }

        private bool ensureGoalIntegrity(AStarComponent aStarComponent)
        {
            if (aStarComponent.Follow)
            {
                GameObject entity = aStarComponent.EntityToFollow;
                Transform2DComponent entityTransformComponent =
                    (Transform2DComponent)entity.GetComponent(ComponentType.Transform2D);

                if (!aStarComponent.DoSearch)
                {
                    if (aStarComponent.EntityToFollowPosBuffer != entityTransformComponent.GetTranslation() ||
                        aStarComponent.SwitchedEntity)
                    {
                        return false;
                    }

                    return true;
                }

                aStarComponent.DoSearch = false;
                return true;
            }

            return !aStarComponent.DoSearch;
        }

        public override SystemType GetType()
        {
            return SystemType.Service;
        }
    }
}
