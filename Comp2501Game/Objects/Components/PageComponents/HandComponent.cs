using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class HandComponent : ObjectComponent
    {
        public Texture2D button;
        public Vector2 position;
        public int playerNum;

        public HandComponent(GameObject parent, int num, Game game)
            : base (parent)
        {
            this.playerNum = num;
            position = new Vector2(100 * num, 350);
        }

        public override ComponentType GetType()
        {
            return ComponentType.Hand;
        }
    }
}
