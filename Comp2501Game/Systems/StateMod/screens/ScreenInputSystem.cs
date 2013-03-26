using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Objects.Screens;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems.StateMod
{
    class ScreenInputSystem : GameSystem
    {
        ScreenType curScreen;
        Game1 _game;

        public ScreenInputSystem(Game1 game, ScreenType type)
            : base(game)
        {
            curScreen = type;
            _game = game;
        }


        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            GamePadState gamePadState1 = GamePad.GetState(PlayerIndex.One);
            GamePadState gamePadState2 = GamePad.GetState(PlayerIndex.Two);
            if (curScreen == ScreenType.Start)
            {
                if (state.GetPressedKeys().Length > 0 || gamePadState1.IsButtonDown(Buttons.Start) || gamePadState2.IsButtonDown(Buttons.Start))
                {
                        this._game.curScreen = ScreenType.Mode;
                        this._game.RemoveAllSystems();
                        this._game.RemoveAllObjects();
                        //GameScreen gameScreen = new GameScreen(this._game, SpriteType.Yoshi, SpriteType.Yoshi);
                        //CharacterSelectScreen selectScreen = new CharacterSelectScreen(this._game);
                        ModeScreen modeScreen = new ModeScreen(this._game);
                        this._game.LoadScene();
                }
            }

        }
    }
}
