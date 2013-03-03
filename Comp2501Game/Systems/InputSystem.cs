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
                            actionComponent.curAction = MovementType.Left_Smash_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.curAction = MovementType.Left_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Smash_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Smash_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Left_Walk;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Smash_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Right_Walk;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_B;
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                            actionComponent.curAction = MovementType.Left_Grab;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Left_Sheild;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Left_Stand; 
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Right_Stand)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Smash_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.curAction = MovementType.Right_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Smash_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Smash_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Left_Walk;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Smash_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Right_Walk;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_B;
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                            actionComponent.curAction = MovementType.Right_Grab;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Right_Sheild;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Right_Stand; 
                        }
                    }
                    //first Jump left side
                    else if (actionComponent.curAction == MovementType.Left_Fall ||
                        actionComponent.curAction == MovementType.Left_Fall_Fast)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Left_Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Left_Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.curAction = MovementType.Left_Fall_Fast;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Jump_B;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Left_Fall;
                        }
                    }
                    //
                    else if (actionComponent.curAction == MovementType.Right_Fall ||
                        actionComponent.curAction == MovementType.Right_Fall_Fast)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Right_Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Right_Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.curAction = MovementType.Right_Fall_Fast;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Jump_B;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Right_Fall;
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Left_Walk)
                    {
                        if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Walk_A;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Left_Walk;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Left_Stand;
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Right_Walk)
                    {
                        if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Walk_A;
                        }
                        else if  (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Right_Walk;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Right_Stand;
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Left_Sheild)
                    {
                        if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Left_Sheild_Roll_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Left_Sheild_Roll_Left;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Left_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Left_Sheild;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Left_Stand;
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Right_Sheild)
                    {
                        if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Right_Sheild_Roll_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Right_Sheild_Roll_Left;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Right_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.curAction = MovementType.Right_Sheild;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Right_Stand;
                        }
                    }
                    else if (actionComponent.curAction == MovementType.Left_Second_Jump_Fall || 
                        actionComponent.curAction == MovementType.Left_Second_Jump_Fall_Fast)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Fall_Fast;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_B;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Left_Second_Jump_Fall;
                        }
                    }
                    //
                    else if (actionComponent.curAction == MovementType.Right_Second_Jump_Fall ||
                        actionComponent.curAction == MovementType.Right_Second_Jump_Fall_Fast)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Fall_Fast;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_B;
                        }
                        else
                        {
                            actionComponent.curAction = MovementType.Right_Second_Jump_Fall;
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
