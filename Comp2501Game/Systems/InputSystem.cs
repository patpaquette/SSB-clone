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
                    if (actionComponent.curDirection == DirectionalAction.Left && actionComponent.secondaryAction == SecondaryAction.Stand && actionComponent.primaryAction == PrimaryAction.None)
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                            actionComponent.primaryAction = PrimaryAction.Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                            actionComponent.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curDirection = DirectionalAction.Right;
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.curDirection = DirectionalAction.Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                            actionComponent.primaryAction = PrimaryAction.None;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Jump;
                            actionComponent.primaryAction = PrimaryAction.None;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.B;
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                            actionComponent.primaryAction = PrimaryAction.Grab;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Shield; 
                        }
                    }
                    else if (actionComponent.curDirection == DirectionalAction.Right && actionComponent.secondaryAction == SecondaryAction.Stand && actionComponent.primaryAction == PrimaryAction.None)
                    {

                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                            actionComponent.primaryAction = PrimaryAction.Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                            actionComponent.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.curDirection = DirectionalAction.Left;
                            actionComponent.secondaryAction = SecondaryAction.Smash;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.curDirection = DirectionalAction.Right;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                            actionComponent.primaryAction = PrimaryAction.None;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Jump;
                            actionComponent.primaryAction = PrimaryAction.None;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.A;
                        }
                        else if (state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.B;
                        }
                        else if (state.IsKeyDown(Keys.R))
                        {
                            actionComponent.primaryAction = PrimaryAction.Grab;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Shield;
                        }
                    }
                    else if (actionComponent.curDirection == DirectionalAction.Right && actionComponent.secondaryAction == SecondaryAction.Walk && actionComponent.primaryAction == PrimaryAction.None)
                    {
                        if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Shield;
                        }
                        else
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                        }
                    }
                    else if (actionComponent.curDirection == DirectionalAction.Left && actionComponent.secondaryAction == SecondaryAction.Walk && actionComponent.primaryAction == PrimaryAction.None)
                    {
                        if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Walk;
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Shield;
                        }
                        else
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                        }
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.None)
                    {
                        if (state.IsKeyDown(Keys.Z))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Shield;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.primaryAction = PrimaryAction.Roll_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.primaryAction = PrimaryAction.Roll_Left;
                        }
                        else if (state.IsKeyDown(Keys.Up))
                        {
                            actionComponent.secondaryAction = SecondaryAction.Jump;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Grab;
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                        }
                        else
                        {
                            actionComponent.secondaryAction = SecondaryAction.Stand;
                        }
                    }
                    else if (actionComponent.curDirection == DirectionalAction.Left && (actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.None || actionComponent.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && actionComponent.secondaryAction != SecondaryAction.Second_Falling)
                        {
                            actionComponent.secondaryAction = SecondaryAction.Second_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.primaryAction = PrimaryAction.Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.primaryAction = PrimaryAction.Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.primaryAction = PrimaryAction.Fall_Faster;
                        }
                        else
                        {
                            actionComponent.primaryAction = PrimaryAction.None;
                        }
                    }
                    else if (actionComponent.curDirection == DirectionalAction.Right && (actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                       && (actionComponent.primaryAction == PrimaryAction.None || actionComponent.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Up_A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.Up_B;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Down_A;
                        }
                        else if (state.IsKeyDown(Keys.Down) && state.IsKeyDown(Keys.B))
                        {
                            actionComponent.primaryAction = PrimaryAction.Down_B;
                        }
                        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Forward_A;
                        }
                        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.Backward_A;
                        }
                        else if (state.IsKeyDown(Keys.A))
                        {
                            actionComponent.primaryAction = PrimaryAction.A;
                        }
                        else if (state.IsKeyDown(Keys.Up) && actionComponent.secondaryAction != SecondaryAction.Second_Falling)
                        {
                            actionComponent.secondaryAction = SecondaryAction.Second_Jump;
                        }
                        else if (state.IsKeyDown(Keys.Right))
                        {
                            actionComponent.primaryAction = PrimaryAction.Drift_Right;
                        }
                        else if (state.IsKeyDown(Keys.Left))
                        {
                            actionComponent.primaryAction = PrimaryAction.Drift_Left;
                        }
                        else if (state.IsKeyDown(Keys.Down))
                        {
                            actionComponent.primaryAction = PrimaryAction.Fall_Faster;
                        }
                        else
                        {
                            actionComponent.primaryAction = PrimaryAction.None;
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
