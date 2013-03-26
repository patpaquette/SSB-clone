using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Systems.AI;

namespace Comp2501Game.Objects.Components.AI
{
    class BehaviourComponent : ObjectComponent
    {
        public BehaviourState State;
        public BehaviourTreeNode Root;

        public BehaviourComponent(GameObject parent, BehaviourTreeNode root)
            : base(parent)
        {
            this.State = BehaviourState.Idle;
            this.Root = root;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Behaviour;
        }
    }
}
