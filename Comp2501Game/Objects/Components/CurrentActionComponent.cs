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

        public CurrentActionComponent(GameObject parent, DirectionalAction direction, SecondaryAction SecondaryAct, PrimaryAction primaryAct)
            : base(parent)
        {
            this.curDirection = direction;
            this.secondaryAction = SecondaryAct;
            this.primaryAction = primaryAct;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Action;
        }
    }
}
