using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.Objects.Components.CollisionComponents
{
    class IsActionComponent : ObjectComponent
    {
        public ActionInfo ActionInfo;

        public IsActionComponent(GameObject parent, ActionInfo actionInfo)
            : base(parent)
        {
            this.ActionInfo = actionInfo;
        }

        public override ComponentType GetType()
        {
            return ComponentType.IsAction;
        }
    }
}
