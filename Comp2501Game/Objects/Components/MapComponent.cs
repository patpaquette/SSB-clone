using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Comp2501Game.Types;

namespace Comp2501Game.Objects.Components
{
    class MapComponent : ObjectComponent
    {
        public Texture2D map;
        public List<Rectangle> platforms;
        public ScreenType screenType;

        public MapComponent(GameObject parent, ScreenType screen)
            : base (parent)
        {
            this.screenType = screen;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Map;
        }


    }
}
