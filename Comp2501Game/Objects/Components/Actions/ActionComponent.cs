using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.Objects.Components
{
    class ActionComponent
    {
        public DirectionalAction curDirection;
        public SecondaryAction secondaryAction;
        public PrimaryAction primaryAction;
        public Drift drift;

        public ActionComponent(
            DirectionalAction direction, 
            SecondaryAction SecondaryAct, 
            PrimaryAction primaryAct, 
            Drift drifting = Drift.None)  
        {
            this.curDirection = direction;
            this.secondaryAction = SecondaryAct;
            this.primaryAction = primaryAct;
            this.drift = drifting;
        }

        public ActionDefinition GetDefinition()
        {
            return new ActionDefinition(curDirection, primaryAction, secondaryAction);
        }
    }
}
