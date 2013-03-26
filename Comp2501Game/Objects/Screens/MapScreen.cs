using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Types;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects;
using Comp2501Game.Systems.Physics.Initializer;
using Comp2501Game.Systems.StateMod;

namespace Comp2501Game.Systems.Renderer.Screens
{
    class MapScreen
    {
        private Rectangle clientBounds;
        private ScreenType _screen;

        private int screenInitSystemID;
        private int screenRendererID;

        public MapScreen (Game1 game)
        {
            this._screen = ScreenType.Map;
            this.clientBounds = game.Window.ClientBounds;

            screenInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));
            screenRendererID = game.RegisterSystem(new MapRenderer(game));

            game.SetSystemCallOrder(new List<int>
             {
                 screenInitSystemID,
                 screenRendererID,

             });

           game.AddObject(new MapObject(game, this._screen));
        }


        }

    }

