using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Systems.AI.Pathfinding;

namespace Comp2501Game.Objects.Components.AI.Pathfinding
{
    class AStarGraphComponent : ObjectComponent
    {
        public AStarGraph Graph;

        public AStarGraphComponent(GameObject parent, AStarGraph graph)
            : base(parent)
        {
            this.Graph = graph;
        }

        public override ComponentType GetType()
        {
            return ComponentType.AStarGraph;
        }
    }
}
