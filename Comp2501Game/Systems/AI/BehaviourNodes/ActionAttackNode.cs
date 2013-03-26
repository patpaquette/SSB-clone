using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Physics;

namespace Comp2501Game.Systems.AI.BehaviourNodes
{
    class ActionAttackNode : BehaviourTreeNode
    {
        private ActionDefinition _actDef;

        public ActionAttackNode(
            Game1 game,
            GameObject parent,
            ActionDefinition actDef
            )
            : base(game, parent, BehaviourNodeType.Action)
        {
            this._actDef = actDef;
        }

        public override bool Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            CurrentActionComponent parentCurActionComponent =
                (CurrentActionComponent)this._parent.GetComponent(ComponentType.Action);
            MotionPropertiesComponent parentMotionComponent =
                (MotionPropertiesComponent)this._parent.GetComponent(ComponentType.MotionProperties);

            if (parentMotionComponent.State == MotionState.Ground && 
                parentCurActionComponent.Timing <= 0 &&
                (parentCurActionComponent.curAction.secondaryAction == SecondaryAction.Stand ||
                parentCurActionComponent.curAction.secondaryAction == SecondaryAction.Walk))
            {
                parentCurActionComponent.curAction.primaryAction = this._actDef.PrimaryAction;
                parentCurActionComponent.curAction.secondaryAction = this._actDef.SecondaryAction;
            }

            return true;
        }

        public override string GetName()
        {
            return "ActionAttack";
        }
    }
}
