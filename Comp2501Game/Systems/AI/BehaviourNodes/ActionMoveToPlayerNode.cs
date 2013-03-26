using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Objects.Components.AI;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.AI.BehaviourNodes
{
    class ActionMoveToPlayerNode : ActionMoveNode
    {
        private GameObject _player;

        public ActionMoveToPlayerNode(
            Game1 game,
            GameObject parent,
            GameObject player, 
            AStarPathfindingSystem pathfinding)
            : base(game, parent, pathfinding)
        {
            this._pathfinding = pathfinding;
            this._player = player;
        }

        public override bool Update(GameTime gameTime)
        {
            Transform2DComponent playerTransformComponent =
                (Transform2DComponent)this._player.GetComponent(ComponentType.Transform2D);

            this.moveTo(playerTransformComponent.GetTranslation(), gameTime);
            return true;
        }

        public override string GetName()
        {
            return "ActionMoveToPlayer";
        }
    }
}
