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

        public HandComponent(GameObject parent, int num, Game game, Vector2 vec)
            : base(parent)
        {
            this.playerNum = num;
            position = vec;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Hand;
        }
    }
}
