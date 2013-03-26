using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Comp2501Game.Objects.Components.Types;
using Microsoft.Xna.Framework.Media;

namespace Comp2501Game.Objects.Components
{
    class SongComponent : ObjectComponent
    {
        public Song soundEffect;
        public MapType map; 

        public SongComponent(GameObject parent, MapType type)
            : base(parent)
        {
            this.map = type;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Song;
        }
    }
}
