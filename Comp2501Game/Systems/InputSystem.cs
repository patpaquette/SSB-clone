using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems
{
    class InputSystem : GameSystem
    {
        public int PlayerNumber;

        public InputSystem(Game1 game, int playerNumber)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.Player);
            this.PlayerNumber = playerNumber;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (GameObject obj in this._objects)
            {
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);

                if (playerComponent.PlayerNumber == this.PlayerNumber)
                {
                    if (actionComponent.curAction == MovementType.Left_Stand)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                        }
                        else
                        {
                        }


                    }
                    else if (actionComponent.curAction == MovementType.Right_Stand)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                        }
                        else
                        {
                        }

                    }
                    else if (actionComponent.curAction == MovementType.Left_Jump || actionComponent.curAction == MovementType.Left_Fall ||
                        actionComponent.curAction == MovementType.Left_Fall_Fast)
                    {

                    }
                    else if (actionComponent.curAction == MovementType.Right_Jump || actionComponent.curAction == MovementType.Right_Fall ||
                        actionComponent.curAction == MovementType.Right_Fall_Fast)
                    {

                    }
                    else if (actionComponent.curAction == MovementType.Left_Walk)
                    {
                        if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Right_Walk)
                    {
                        if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                        }
                    }
                }

            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
