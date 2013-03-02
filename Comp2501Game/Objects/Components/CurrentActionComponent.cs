using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Comp2501Game.Objects.Components
{
    class CurrentActionComponent : ObjectComponent
    {
        public ArrayList pendingActions;
        public MovementType curAction;

        public CurrentActionComponent(MovementType action)
        {
            this.curAction = action;
            this.pendingActions = new ArrayList();
        }

        public override ComponentType GetType()
        {
            return ComponentType.Action;
        }
    }
}
