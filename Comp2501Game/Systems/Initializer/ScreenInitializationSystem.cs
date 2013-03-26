using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Types;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems.Physics.Initializer
{
    class ScreenInitializationSystem : GameSystem
    {

        public ScreenInitializationSystem(Game1 game)
            : base (game)
        {
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
            }

            base.Initialize();
        }
    }
}
