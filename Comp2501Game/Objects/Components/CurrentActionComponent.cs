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

<<<<<<< HEAD
        public CurrentActionComponent(GameObject parent, DirectionalAction direction, SecondaryAction SecondaryAct, PrimaryAction primaryAct)
            : base(parent)
=======
        public CurrentActionComponent(DirectionalAction direction, SecondaryAction SecondaryAct, PrimaryAction primaryAct, Drift drifting = Drift.None)
>>>>>>> 5885c8e08afd6fb1b053c2df896a95123bd826fd
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
