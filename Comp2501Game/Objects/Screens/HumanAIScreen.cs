using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Types;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Systems.Physics.Initializer;
using Comp2501Game.Systems.Renderer;
using Comp2501Game.Systems.Renderer.Screens;

namespace Comp2501Game.Objects.Screens
{
    class HumanAIScreen
    {
        private Game1 _game;
        private Rectangle clientBounds;
        private ScreenType _screen;

        private int arrowInputSystemID;
        private int controllerInputSystemID;
        private int selectsInputID1;
        private int selectsInputID2;
        private int mapRendererID;
        private int handRenderID;
        private int handInitSystemID;
        private int screenInitSystemID;

        public HumanAIScreen(Game1 game)
        {
            this._game = game;
            this._screen = ScreenType.Character;
            this.clientBounds = game.Window.ClientBounds;
            this._game.IsMouseVisible = false;

            arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 1));
            handInitSystemID = game.RegisterSystem(new HandInitSystem(game));
            controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 2));
            selectsInputID1 = game.RegisterSystem(new SelectInputSystem(game, 1));
            selectsInputID2 = game.RegisterSystem(new SelectInputSystem(game, 2));
            mapRendererID = game.RegisterSystem(new MapRenderer(game));
            handRenderID = game.RegisterSystem(new HandRenderer1(game));
            screenInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));

            game.SetSystemCallOrder(new List<int>
             {
                screenInitSystemID,
                handInitSystemID,
                arrowInputSystemID,
                controllerInputSystemID,
                selectsInputID1,
                selectsInputID2,
                mapRendererID,
                handRenderID
             });

            game.AddObject(new HandObject1(game, 1));
            game.AddObject(new HandObject1(game, 2));
        }

    
    }
}
