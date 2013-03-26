using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.AI;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems.AI.BehaviourNodes
{
    class CondEntityProximityNode : BehaviourTreeNode
    {
        private float _distance;
        private GameObject _entity;

        public CondEntityProximityNode(
            Game1 game,
            GameObject parent,
            GameObject entity,
            float distance)
            : base(game, parent, BehaviourNodeType.Condition)
        {
            this._distance = distance;
            this._entity = entity;
        }

        public override bool Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Transform2DComponent parentTransformComponent =
                (Transform2DComponent)this._parent.GetComponent(ComponentType.Transform2D);
            Transform2DComponent entityTransformComponent =
                (Transform2DComponent)this._entity.GetComponent(ComponentType.Transform2D);

            float distance = 
                (parentTransformComponent.GetTranslation() - entityTransformComponent.GetTranslation()).Length();

            if (distance <= this._distance)
            {
                return true;
            }

            return false;
        }

        public override string GetName()
        {
            return "Distance condition";
        }
    }
}
