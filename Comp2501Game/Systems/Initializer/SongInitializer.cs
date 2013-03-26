using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components.Types;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Media;

namespace Comp2501Game.Systems.Initializer
{
    class SongInitializer : GameSystem
    {
        private Game1 _game;

        public SongInitializer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Song);
            this._game = game;
        }


        public override void Initialize()
        {
            foreach (GameObject obj in this._objects)
            {
                SongComponent songComponent = (SongComponent)obj.GetComponent(ComponentType.Song);

                if (songComponent.map == MapType.Hyrule)
                {
                    songComponent.soundEffect = this._game.Content.Load<Song>(@"Songs/Delilah's Song");
                }
                else
                {
                    songComponent.soundEffect = this._game.Content.Load<Song>(@"Songs/San Pedro");
                }
            }
        }

        public override SystemType GetType()
        {
            return SystemType.Initializer;
        }
    }
}
