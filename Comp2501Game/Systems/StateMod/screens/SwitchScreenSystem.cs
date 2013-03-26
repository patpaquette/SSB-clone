using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Objects.Components;
using Comp2501Game.Types;
using Comp2501Game.Objects.Components.Types;
using Comp2501Game.Screens;

namespace Comp2501Game.Systems.StateMod
{
    class SwitchScreenSystem : GameSystem
    {
        public bool wasPressed;
        public bool filled;
        public Game1 _game;

        public SwitchScreenSystem(Game1 game)
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
            KeyboardState state = Keyboard.GetState();
            GamePadState gamePadState1 = GamePad.GetState(PlayerIndex.One);

            if (state.IsKeyDown(Keys.B) || gamePadState1.IsButtonDown(Buttons.Back))
            {
                this.Game.Exit();
            }
            else if (state.GetPressedKeys().Length > 0 || gamePadState1.IsButtonDown(Buttons.Start))
            {
                this._game.curScreen = ScreenType.Start;
                this._game.RemoveAllSystems();
                this._game.RemoveAllObjects();
                //GameScreen gameScreen = new GameScreen(this._game, SpriteType.Yoshi, SpriteType.Yoshi);
                //CharacterSelectScreen selectScreen = new CharacterSelectScreen(this._game);
                StartScreen startScreen = new StartScreen(this._game);
                this._game.LoadScene();


                this._game.play1 = SpriteType.None;
                this._game.play2 = SpriteType.None;

                this._game.playe1 = PlayerType.None;
                this._game.playe2 = PlayerType.None;

                this._game.gameType = GameTypes.None;
                this._game.LivesOrTime = 0;
                this._game.winner = 0;
                this._game.mapType = MapType.None;
            }
        }

    }
}
