using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Comp2501Game.Systems.StateMod
{
    class MusicSystem: GameSystem
    {
        bool justStarted;

        public MusicSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Song);
            this.justStarted = true;       
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                SongComponent songComponent = (SongComponent)obj.GetComponent(ComponentType.Song);


                if (this.justStarted)
                {
                   this.justStarted = false;
                   MediaPlayer.Play(songComponent.soundEffect);
                   MediaPlayer.IsRepeating = true;
                 }
            }
            base.Update(gameTime);
        }
    }
}
