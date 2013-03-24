using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Actions
{
    class ActionInfoMovement : ActionInfo
    {
        public ActionInfoMovement()
            : base()
        {
        }

        public override ActionType GetType()
        {
            return ActionType.Movement;
        }
    }
}
