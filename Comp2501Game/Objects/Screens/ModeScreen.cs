﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Types;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Systems.Renderer;
using Comp2501Game.Systems.Physics.Initializer;

namespace Comp2501Game.Objects.Screens
{
    class ModeScreen
    {
        private Game1 _game;
        private Rectangle clientBounds;
        private ScreenType _screen;

        int arrowInputSystemID;
        int controllerInputSystemID;
        int modeInputSystemID;
        int mapRendererID;
        int modeRendererID;
        int mapInitSystemID;

        public ModeScreen(Game1 game)
        {
            this._game = game;
            this._screen = ScreenType.Mode;
            this.clientBounds = game.Window.ClientBounds;
            this._game.IsMouseVisible = true;

            arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 1));
            controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 1));
            mapRendererID = game.RegisterSystem(new MapRenderer(game));
            mapInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));
            modeRendererID = game.RegisterSystem(new ModeTextRenderer(game));
            modeInputSystemID = game.RegisterSystem(new ModeInputSystem(game));

            game.SetSystemCallOrder(new List<int>
             {
                mapInitSystemID,
                arrowInputSystemID,
                controllerInputSystemID,
                mapRendererID,
                modeRendererID,
                modeInputSystemID
             });

            game.AddObject(new TextObject(game));
        }

    }
}
