using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Systems.AI
{
    enum BehaviourNodeType
    {
        PrioritySelector,
        ConcurrentSelector,
        SequenceSelector,
        Condition,
        Action
    }
}
