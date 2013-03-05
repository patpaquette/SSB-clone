using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.StateMod
{
    class MovementSystem : GameSystem 
    {
        public int playerNumber;

        public MovementSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Action);
            this._componentDependencies.Add(ComponentType.Position);
            this.playerNumber = playerNum;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                PositionComponent positionComponent = (PositionComponent)obj.GetComponent(ComponentType.Position);

                if (actionComponent.curDirection == DirectionalAction.Left)
                {
                    if (actionComponent.secondaryAction == SecondaryAction.Walk)
                    {
                        positionComponent.Position += new Vector2(-2.0f, 0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Jump || actionComponent.secondaryAction == SecondaryAction.Second_Jump)
                    {
                        positionComponent.Position += new Vector2(0.0f, -4.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction != PrimaryAction.Fall_Faster || actionComponent.primaryAction != PrimaryAction.Drift_Left || actionComponent.primaryAction != PrimaryAction.Drift_Right))
                    {
                        positionComponent.Position += new Vector2(0.0f, 1.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        positionComponent.Position += new Vector2(0.0f, 2.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.Position += new Vector2(-1.0f, 0.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.Position += new Vector2(-1.0f, 0.0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.Position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.Roll_Right)
                    {
                        positionComponent.Position += new Vector2(3.0f, 0.0f);
                    }

                }
                else
                {
                    if (actionComponent.secondaryAction == SecondaryAction.Walk)
                    {
                        positionComponent.Position += new Vector2(2.0f, 0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Jump || actionComponent.secondaryAction == SecondaryAction.Second_Jump)
                    {
                        positionComponent.Position += new Vector2(0.0f, -4.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction != PrimaryAction.Fall_Faster || actionComponent.primaryAction != PrimaryAction.Drift_Left || actionComponent.primaryAction != PrimaryAction.Drift_Right))
                    {
                        positionComponent.Position += new Vector2(0.0f, 1.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        positionComponent.Position += new Vector2(0.0f, 2.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.Position += new Vector2(-1.0f, 0.0f);
                    }
                    else if ((actionComponent.secondaryAction == SecondaryAction.Falling || actionComponent.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.primaryAction == PrimaryAction.Drift_Right))
                    {
                        positionComponent.Position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.Position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.Position += new Vector2(-3.0f, 0.0f);
                    }
                    else if (actionComponent.secondaryAction == SecondaryAction.Shield && actionComponent.primaryAction == PrimaryAction.Roll_Right)
                    {
                        positionComponent.Position += new Vector2(3.0f, 0.0f);
                    }
                }


                if (actionComponent.drift == Drift.Left)
                {
                    positionComponent.Position += new Vector2(-1.0f, 0.0f);
                }
                else if (actionComponent.drift == Drift.Right)
                {
                    positionComponent.Position += new Vector2(1.0f, 0.0f);
                }
            }
        }



        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }


    }
}
