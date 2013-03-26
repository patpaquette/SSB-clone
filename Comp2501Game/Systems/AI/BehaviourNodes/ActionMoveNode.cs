using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Objects.Components.AI;
using Comp2501Game.Objects.Components.AI.Pathfinding;

namespace Comp2501Game.Systems.AI.BehaviourNodes
{
    abstract class ActionMoveNode : BehaviourTreeNode
    {
        protected AStarPathfindingSystem _pathfinding;

        public ActionMoveNode(
            Game1 game,
            GameObject parent,
            AStarPathfindingSystem pathfinding)
            : base(game, parent, BehaviourNodeType.Action)
        {
            this._pathfinding = pathfinding;
        }

        protected void moveTo(Vector2 position, GameTime gameTime)
        {
            if (this._parent.HasComponent(ComponentType.Action))
            {
                CurrentActionComponent curActionComponent =
                    (CurrentActionComponent)this._parent.GetComponent(ComponentType.Action);
                AStarComponent aStarComponent =
                    (AStarComponent)this._parent.GetComponent(ComponentType.AStar);
                Transform2DComponent transformComponent =
                    (Transform2DComponent)this._parent.GetComponent(ComponentType.Transform2D);

                aStarComponent.GoalPosition = position;

                if (this._pathfinding.GetBestPath(this._parent, gameTime, this._game.CurrentPathfindingGraph))
                {
                    Vector2 goalPosition;
                    if (aStarComponent.Path.Count > 0)
                    {
                        goalPosition = aStarComponent.Path.Peek().GetPosition();
                    }
                    else
                    {
                        goalPosition = aStarComponent.GoalPosition;
                    }
                    Vector2 curPosition = transformComponent.GetTranslation();

                    Vector2 dirVector = goalPosition - curPosition;

                    if (aStarComponent.CurrentNode.Jump)
                    {
                        curActionComponent.curAction.secondaryAction = SecondaryAction.Jump;
                    }
                    else
                    {
                        curActionComponent.curAction.secondaryAction = SecondaryAction.Walk;
                    }

                    if (dirVector.X > 0)
                    {
                        
                        curActionComponent.curAction.curDirection = DirectionalAction.Right;
                    }
                    else
                    {
  
                        curActionComponent.curAction.curDirection = DirectionalAction.Left;
                    }

                }
            }
        }
    }
}
