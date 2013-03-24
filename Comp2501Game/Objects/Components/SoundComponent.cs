using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Comp2501Game.Objects.Components
{
    class SoundComponent : ObjectComponent
    {
        public SoundEffect[] actionSoundList;
        public SoundEffect[] voiceSoundList;

        public SoundComponent(GameObject parent)
            : base(parent)
        {
            this.actionSoundList = new SoundEffect[20];
            this.voiceSoundList = new SoundEffect[9];

        }


        public override ComponentType GetType()
        {
            return ComponentType.Sound;
        }
    }
}
