using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Comp2501Game.Objects.Components.Types;

namespace Comp2501Game.Systems.StateMod
{
    class ArrowInputSystem : GameSystem
    {
        public int playerNumber;

        public ArrowInputSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Arrow);
            this.playerNumber = playerNum;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                ArrowComponent arrowComponent = (ArrowComponent)obj.GetComponent(ComponentType.Arrow);

                if (playerComponent.PlayerNumber == this.playerNumber)
                {
                    KeyboardState state = Keyboard.GetState();

                    if (state.IsKeyDown(Keys.Up))
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
                    else if (state.IsKeyDown(Keys.Down))
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
                    else if (state.IsKeyDown(Keys.Right))
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
                    else if (state.IsKeyDown(Keys.Left))
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
                    else
                    {
                        arrowComponent.arrowKey = ArrowType.None;
                        arrowComponent.keyTimer = 0;
                    }


                    if (state.IsKeyDown(Keys.A))
                    {
                        arrowComponent.keyPressed = KeyType.A;
                    }
                    else if (state.IsKeyDown(Keys.B))
                    {
                        arrowComponent.keyPressed = KeyType.B;
                    }
                    else if (state.IsKeyDown(Keys.Z))
                    {
                        arrowComponent.keyPressed = KeyType.Z;
                    }
                    else if (state.IsKeyDown(Keys.R))
                    {
                        arrowComponent.keyPressed = KeyType.R;
                    }
                    else
                    {
                        arrowComponent.keyPressed = KeyType.None;
                    }
                }
            }
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
