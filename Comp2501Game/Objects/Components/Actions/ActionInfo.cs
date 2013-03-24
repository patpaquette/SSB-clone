using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Actions
{
    abstract class ActionInfo
    {
        public ActionInfo()
        {
        }

        public abstract ActionType GetType();
    }
}
