using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Systems.AI.Pathfinding;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components.AI.Pathfinding
{
    class AStarComponent : ObjectComponent
    {
        public Stack<AStarNode> Path;
        public bool Follow;
        public GameObject EntityToFollow;
        public Vector2 EntityToFollowPosBuffer;
        public Vector2 GoalPosition;
        public bool SwitchedEntity;
        public bool DoSearch;

        public AStarComponent(GameObject parent)
            :base(parent)
        {
            this.Path = new Stack<AStarNode>();
            this.Follow = false;
            this.EntityToFollow = null;
            this.EntityToFollowPosBuffer = Vector2.Zero;
            this.GoalPosition = Vector2.Zero;
            this.SwitchedEntity = false;
            this.DoSearch = false;
        }

        public void SetFollowEntity(GameObject entity)
        {
            this.EntityToFollow = entity;
            this.Follow = true;
        }

        public void StopFollow()
        {
            this.EntityToFollow = null;
            this.Follow = false;
        }

        public void ClearPath()
        {
            this.Path.Clear();
        }

        public override ComponentType GetType()
        {
            return ComponentType.AStar;
        }
    }
}
