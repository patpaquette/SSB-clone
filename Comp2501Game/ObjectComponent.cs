using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;

namespace Comp2501Game
{
    public abstract class ObjectComponent
    {
        public GameObject ParentEntity;

        public ObjectComponent(GameObject parent)
        {
            this.ParentEntity = parent;
        }

        public abstract ComponentType GetType();
    }
}
