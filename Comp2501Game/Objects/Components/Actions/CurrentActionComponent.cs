using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Comp2501Game.Objects.Components
{
    class CurrentActionComponent : ObjectComponent
    {
        public ActionComponent curAction;

        public CurrentActionComponent(GameObject parent, DirectionalAction direction, SecondaryAction SecondaryAct, PrimaryAction primaryAct, Drift drifting = Drift.None)
            : base(parent)
        {
            this.curAction.curDirection = direction;
            this.curAction.secondaryAction = SecondaryAct;
            this.curAction.primaryAction = primaryAct;
            this.curAction.drift = drifting;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Action;
        }
    }
}
