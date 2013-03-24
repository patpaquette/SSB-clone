using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Types;

namespace Comp2501Game.Systems.StateMod
{
    class ControllerInputSystem : GameSystem
    {
        public int playerNumber;

        public ControllerInputSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Arrow);
            this.playerNumber = playerNum;
        }


        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }


        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                ArrowComponent arrowComponent = (ArrowComponent)obj.GetComponent(ComponentType.Arrow);

                if (playerComponent.PlayerNumber == this.playerNumber)
                {
                    GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

                    Vector2 leftThumbStick = gamePadState.ThumbSticks.Left;
                    float tolerance = 0.05f;
                    if (Math.Abs(leftThumbStick.X) > tolerance || Math.Abs(leftThumbStick.Y) > tolerance)
                    {
                        if (Math.Abs(leftThumbStick.X) > Math.Abs(leftThumbStick.Y))
                        {
                            if (leftThumbStick.X > 0)
                            {
                                if (arrowComponent.arrowKey == ArrowType.Right)
                                {
                                    arrowComponent.keyTimer += gameTime.ElapsedGameTime.Milliseconds;
                                }
                                else
                                {
                                    arrowComponent.arrowKey = ArrowType.Right;
                                    arrowComponent.keyTimer = 0;
                                }
                            }
                            else
                            {
                                if (arrowComponent.arrowKey == ArrowType.Left)
                                {
                                    arrowComponent.keyTimer += gameTime.ElapsedGameTime.Milliseconds;
                                }
                                else
                                {
                                    arrowComponent.arrowKey = ArrowType.Left;
                                    arrowComponent.keyTimer = 0;
                                }
                            }
                        }
                        else if (Math.Abs(leftThumbStick.X) < Math.Abs(leftThumbStick.Y))
                        {
                            if (leftThumbStick.Y > 0)
                            {
                                if (arrowComponent.arrowKey == ArrowType.Up)
                                {
                                    arrowComponent.keyTimer += gameTime.ElapsedGameTime.Milliseconds;
                                }
                                else
                                {
                                    arrowComponent.arrowKey = ArrowType.Up;
                                    arrowComponent.keyTimer = 0;
                                }
                            }
                            else
                            {
                                if (arrowComponent.arrowKey == ArrowType.Down)
                                {
                                    arrowComponent.keyTimer += gameTime.ElapsedGameTime.Milliseconds;
                                }
                                else
                                {
                                    arrowComponent.arrowKey = ArrowType.Down;
                                    arrowComponent.keyTimer = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        arrowComponent.arrowKey = ArrowType.None;
                        arrowComponent.keyTimer = 0;
                    }

                    GamePadTriggers triggers = gamePadState.Triggers;
                    float triggerTolerance = 0.80f;
                    if (triggers.Left > triggerTolerance)
                    {
                        arrowComponent.keyPressed = KeyType.Z;
                    }
                    else if (triggers.Right > triggerTolerance)
                    {
                        arrowComponent.keyPressed = KeyType.R;
                    }
                    else
                    {
                        GamePadButtons buttons = gamePadState.Buttons;

                        if (buttons.A == ButtonState.Pressed)
                        {
                            arrowComponent.keyPressed = KeyType.A;
                        }
                        else if (buttons.B == ButtonState.Pressed)
                        {
                            arrowComponent.keyPressed = KeyType.B;
                        }
                        else
                        {
                            arrowComponent.keyPressed = KeyType.None;
                        }
                    }


                }
            }
        }
    }
}
