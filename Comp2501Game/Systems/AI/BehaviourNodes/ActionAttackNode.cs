using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Objects.Components;

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

            if (parentCurActionComponent.curAction.primaryAction == this._actDef.PrimaryAction)
            {
                parentCurActionComponent.curAction.primaryAction = PrimaryAction.None;
            }
            else
            {
                parentCurActionComponent.curAction.primaryAction = this._actDef.PrimaryAction;
            }
            
            return true;
        }

        public override string GetName()
        {
            return "ActionAttack";
        }
    }
}
