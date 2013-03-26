using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class VisibleTextComponent : ObjectComponent
    {
        public string modeString;
        public int timeOrLifeVal;
        public Vector2 position1, position2;

        public VisibleTextComponent(GameObject parent, Vector2 pos1, Vector2 pos2, int tolv, string mode)
            : base(parent)
        {
            this.position1 = pos1;
            this.position2 = pos2;
            this.modeString = mode;
            this.timeOrLifeVal = tolv; 
        }

        public override ComponentType GetType()
        {
            return ComponentType.Text;
        }
    }
}
