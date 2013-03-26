using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Objects.Components.Types;
using Comp2501Game.Types;
using Comp2501Game.Systems.Renderer.Screens;
using Comp2501Game.Objects.Screens;

namespace Comp2501Game.Systems.StateMod.screens
{
    class MouseInputsystem : GameSystem
    {
        private bool wasPressed;
        private bool filled;

        public Game1 _game;

        public MouseInputsystem(Game1 game)
            : base(game)
        {
            this.wasPressed = false;
            this.filled = false;
            this._game = game;
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton.Equals(ButtonState.Pressed))
            {
                this.wasPressed = true;
            }

            if (mouseState.LeftButton.Equals(ButtonState.Released) && this.wasPressed)
            {
                if (mouseState.X > 86 && mouseState.X < 532 && mouseState.Y > 68 && mouseState.Y < 364)
                {
                    this.filled = true;
                    this._game.mapType = MapType.Hyrule;
                }
                else if (mouseState.X > 640 && mouseState.X < 1089 && mouseState.Y > 423 && mouseState.Y < 716)
                {
                    this.filled = true;
                    this._game.mapType = MapType.Basic;
                }
            }


            if (this.filled)
            {
                this._game.curScreen = ScreenType.Character;
                this._game.RemoveAllSystems();
                this._game.RemoveAllObjects();
                CharacterSelectScreen selectScreen = new CharacterSelectScreen(this._game);
                //ModeScreen modeScreen = new ModeScreen(this._game);
                //MapScreen mapSelect = new MapScreen(this._game);
                //StartScreen startScreen = new StartScreen(this._game);
                this._game.LoadScene();
            }


        }
    }
}
