using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Types;
using Comp2501Game.Objects.Screens;
using Comp2501Game.Systems.Renderer.Screens;

namespace Comp2501Game.Systems.StateMod
{
    class ModeInputSystem : GameSystem
    {
        public bool wasPressed;
        public bool filled;
        public Game1 _game;

        public ModeInputSystem(Game1 game)
            : base (game)
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
            foreach (GameObject obj in this._objects)
            {
                //Console.WriteLine("here2");
                VisibleTextComponent textComponent = (VisibleTextComponent)obj.GetComponent(ComponentType.Text);

                MouseState mouseState = Mouse.GetState();
                KeyboardState keyboardState = Keyboard.GetState();
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

                if (keyboardState.IsKeyDown(Keys.S) || gamePadState.IsButtonDown(Buttons.Start))
                {
                    if (textComponent.modeString != "NONE" && textComponent.timeOrLifeVal != 0)
                    {
                        if (textComponent.modeString == "TIMED")
                        {
                            this._game.gameType = GameTypes.Timed;
                        }
                        else
                        {
                            this._game.gameType = GameTypes.Stock;
                        }

                        this._game.LivesOrTime = textComponent.timeOrLifeVal;
                        this.filled = true;
                    }
                }




                if (mouseState.LeftButton.Equals(ButtonState.Pressed))
                {
                    this.wasPressed = true;
                }

                if (mouseState.LeftButton.Equals(ButtonState.Released) && this.wasPressed)
                {
                    this.wasPressed = false;
                    if (mouseState.X > 240 && mouseState.X < 370 && mouseState.Y > 291 && mouseState.Y < 360)
                    {
                        if (textComponent.modeString == "NONE")
                        {
                            textComponent.modeString = "STOCK";
                            textComponent.timeOrLifeVal = 0;
                        }
                        else if (textComponent.modeString == "TIMED")
                        {
                            textComponent.modeString = "STOCK";
                            textComponent.timeOrLifeVal = 0;
                        }
                        else
                        {
                            textComponent.modeString = "TIMED";
                            textComponent.timeOrLifeVal = 0;
                        }
                    }
                    else if (mouseState.X > 890 && mouseState.X < 1000 && mouseState.Y > 291 && mouseState.Y < 360)
                    {
                        if (textComponent.modeString == "NONE")
                        {
                            textComponent.modeString = "TIMED";
                            textComponent.timeOrLifeVal = 0;
                        }
                        else if (textComponent.modeString == "TIMED")
                        {
                            textComponent.modeString = "STOCK";
                            textComponent.timeOrLifeVal = 0;
                        }
                        else
                        {
                            textComponent.modeString = "TIMED";
                            textComponent.timeOrLifeVal = 0;
                        }
                    }
                    else if (mouseState.X > 240 && mouseState.X < 370 && mouseState.Y > 500 && mouseState.Y < 580)
                    {
                        if (textComponent.timeOrLifeVal > 0)
                        {
                            textComponent.timeOrLifeVal--;
                        }
                        else
                        {
                            textComponent.timeOrLifeVal = 60;
                        }
                    }
                    else if (mouseState.X > 890 && mouseState.X < 1000 && mouseState.Y > 500 && mouseState.Y < 580)
                    {
                        if (textComponent.timeOrLifeVal < 60)
                        {
                            textComponent.timeOrLifeVal++;
                        }
                        else
                        {
                            textComponent.timeOrLifeVal = 0;
                        }
                    }
                }
            }

            if (this.filled)
            {
                this._game.curScreen = ScreenType.Character;
                this._game.RemoveAllSystems();
                this._game.RemoveAllObjects();
                //CharacterSelectScreen selectScreen = new CharacterSelectScreen(this._game);
                //ModeScreen modeScreen = new ModeScreen(this._game);
                MapScreen mapSelect = new MapScreen(this._game);
                this._game.LoadScene();
            }
        }
    }
}
