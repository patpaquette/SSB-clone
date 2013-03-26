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
        private Game1 _game;
        private Rectangle clientBounds;
        private ScreenType _screen;

        private int startScreenSystemID;
        private int screenInitSystemID;
        private int screenRendererID;

        public MapScreen (Game1 game)
        {
            this._game = game;
            this._screen = ScreenType.Start;
            this.clientBounds = game.Window.ClientBounds;

            startScreenSystemID = game.RegisterSystem(new ScreenInputSystem(game, this._screen));
            screenInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));
            screenRendererID = game.RegisterSystem(new MapRenderer(game));

            game.SetSystemCallOrder(new List<int>
             {
                 screenInitSystemID,
                 startScreenSystemID,
                 screenRendererID

             });

            game.AddObject(new SceneObject(game, this._screen));
        }


        }

    }

