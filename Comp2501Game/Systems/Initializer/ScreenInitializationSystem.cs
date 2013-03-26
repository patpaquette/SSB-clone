using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Types;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.Types;
using Microsoft.Xna.Framework.Media;

namespace Comp2501Game.Systems.Physics.Initializer
{
    class ScreenInitializationSystem : GameSystem
    {
        Game1 _game;

        public ScreenInitializationSystem(Game1 game)
            : base (game)
        {
            this._game = game;
            this._componentDependencies.Add(ComponentType.Map);
        }

        public override SystemType GetType()
        {
            return SystemType.Initializer;
        }

        public override void Initialize()
        {
            foreach (GameObject obj in this._objects)
            {
                MapComponent mapComponent = (MapComponent)obj.GetComponent(ComponentType.Map);
                //SongComponent songComponent = (SongComponent)obj.GetComponent(ComponentType.Song);

                if (mapComponent.screenType == ScreenType.Start)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/Screens/Start Screen"); 
                }
                else if (mapComponent.screenType == ScreenType.Character)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/Screens/CharacterSelectScreen"); 
                }
                else if (mapComponent.screenType == ScreenType.Mode)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/Screens/ModeScreen");
                }
                else if (mapComponent.screenType == ScreenType.Map)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/Screens/MapSelect");
                }
                else if (mapComponent.screenType == ScreenType.Hyrule)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/GameMap/Hyrule");
                }
                else if (mapComponent.screenType == ScreenType.Basic)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/GameMap/BasicMap");
                }
                else if (mapComponent.screenType == ScreenType.HumanAI)
                {
                    mapComponent.map = this.Game.Content.Load<Texture2D>(@"Images/Screens/HumAIScreen");
                }

                //if (songComponent != null)
                //{
                //    if (this._game.mapType == MapType.Hyrule)
                //    {
                //        songComponent.soundEffect = this._game.Content.Load<Song>(@"Songs/Delilah's Song");
                //    }
                //    else
                //    {
                //        songComponent.soundEffect = this._game.Content.Load<Song>(@"Songs/San Pedro");
                //    }
                //}
            }

            base.Initialize();
        }
    }
}
