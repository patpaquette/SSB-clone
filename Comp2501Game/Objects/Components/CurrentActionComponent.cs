using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Comp2501Game.Objects.Components
{
    class CurrentActionComponent : ObjectComponent
    {
        public DirectionalAction curDirection;
        public SecondaryAction secondaryAction;
        public PrimaryAction primaryAction;
        public Drift drift;

        public CurrentActionComponent(DirectionalAction direction, SecondaryAction SecondaryAct, PrimaryAction primaryAct, Drift drifting = Drift.None)
        {
            this.curDirection = direction;
            this.secondaryAction = SecondaryAct;
            this.primaryAction = primaryAct;
            this.drift = drifting;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Action;
        }
    }
}
