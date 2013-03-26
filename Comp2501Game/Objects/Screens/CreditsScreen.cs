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
    class CreditsScreen
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
        private int switchSystemID;

        public CreditsScreen(Game1 game)
        {
            this._game = game;
            this._screen = ScreenType.Character;
            this.clientBounds = game.Window.ClientBounds;
            this._game.IsMouseVisible = false;


            handInitSystemID = game.RegisterSystem(new HandInitSystem(game));

            if (game.winner == 1)
            {
                arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 1));
                selectsInputID1 = game.RegisterSystem(new SelectInputSystem(game, 1));
            }
            else if (game.winner == 2)
            {
                controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 2));
                selectsInputID2 = game.RegisterSystem(new SelectInputSystem(game, 2));
            }
            else
            {
                selectsInputID1 = game.RegisterSystem(new SelectInputSystem(game, 1));
                selectsInputID2 = game.RegisterSystem(new SelectInputSystem(game, 2));
            }
            mapRendererID = game.RegisterSystem(new MapRenderer(game));
            handRenderID = game.RegisterSystem(new HandRenderer1(game));
            screenInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));
            switchSystemID = game.RegisterSystem(new SwitchScreenSystem(game));

            if (game.winner == 1)
            {
                game.SetSystemCallOrder(new List<int>
                 {
                    screenInitSystemID,
                    handInitSystemID,
                    arrowInputSystemID,
                    selectsInputID1,
                    mapRendererID,
                    handRenderID,
                    switchSystemID
                 });
            }
            else if (game.winner == 2)
            {
                game.SetSystemCallOrder(new List<int>
                 {
                    screenInitSystemID,
                    handInitSystemID,
                    controllerInputSystemID,
                    selectsInputID2,
                    mapRendererID,
                    handRenderID,
                    switchSystemID
                 });
            }
            else
            {
                game.SetSystemCallOrder(new List<int>
                 {
                    screenInitSystemID,
                    handInitSystemID,
                    arrowInputSystemID,
                    controllerInputSystemID,
                    selectsInputID1,
                    selectsInputID2,
                    mapRendererID,
                    handRenderID,
                    switchSystemID
                 });
            }

            game.AddObject(new HandObject2(game, 1));
            game.AddObject(new HandObject2(game, 2));
        }
    }
}
