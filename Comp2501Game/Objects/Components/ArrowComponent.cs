using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Types;

namespace Comp2501Game.Objects.Components
{
    class ArrowComponent : ObjectComponent
    {
        public ArrowType arrowKey;
        public int keyTimer;
        public KeyType keyPressed;

        public ArrowComponent(GameObject parent)
            : base(parent)
        {
            arrowKey = ArrowType.None;
            keyTimer = 0;
            keyPressed = KeyType.None;
        }


        public override ComponentType GetType()
        {
            return ComponentType.Arrow;
        }
    }
}
