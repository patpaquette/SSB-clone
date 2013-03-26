using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Comp2501Game.Objects.Components.Actions;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class CurrentActionComponent : ObjectComponent
    {
        public ActionComponent curAction;
        public ActionDefinition LastActionDef;
        public bool InProgress;
        public int Timing;
        private Dictionary<ActionDefinition, ActionInfo> _actionsInformation;

        public CurrentActionComponent(
            GameObject parent, 
            ActionComponent action,
            Dictionary<ActionDefinition, ActionInfo> actionsInformation)
            : base(parent)
        {
            curAction = action;
            this.LastActionDef = curAction.GetDefinition();
            this._actionsInformation = actionsInformation;
            this.InProgress = false;
            this.Timing = 0;
        }

        public ActionInfo GetActionInfo()
        {
            ActionDefinition actionDef = new ActionDefinition(
                curAction.curDirection,
                curAction.primaryAction,
                curAction.secondaryAction
            );

            if (this._actionsInformation.ContainsKey(actionDef))
            {
                return this._actionsInformation[actionDef];
            }
            else
            {
                return new ActionInfoMovement();
            }
        }

        public void SetActionInfoList(Dictionary<ActionDefinition, ActionInfo> actionInformationList)
        {
            this._actionsInformation = actionInformationList;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Action;
        }
    }
}
