using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Holder
{
    class SoundDirectory
    {
        public int yoshiActionSound;
        public int yoshiVoiceSound;
        public int kirbyVoiceSound;
        public int kirbyActionSound;

        public SoundDirectory(int yAS, int yVS, int kVS, int kAS)
        {
            this.yoshiActionSound = yAS;
            this.yoshiVoiceSound = yVS;
            this.kirbyVoiceSound = kVS;
            this.kirbyActionSound = kAS;
        }
    }
}
