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
            this._componentDependencies.Add(ComponentType.Transform2D);
            this.playerNumber = playerNum;
        }

        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine("here3");
            foreach (GameObject obj in this._objects)
            {
                //Console.WriteLine("here4");
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                Transform2DComponent positionComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);



                if (actionComponent.curAction.curDirection == DirectionalAction.Left)
                {
                    if (actionComponent.curAction.secondaryAction == SecondaryAction.Walk)
                    {
                        positionComponent.position += new Vector2(-2.0f, 0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                    {
                        positionComponent.position += new Vector2(0.0f, -4.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction != PrimaryAction.Fall_Faster
                        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Left
                        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Right))
                    {
                        positionComponent.position += new Vector2(0.0f, 1.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        positionComponent.position += new Vector2(0.0f, 2.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.position += new Vector2(-1.0f, 0.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.position += new Vector2(-1.0f, 0.0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Right)
                    {
                        positionComponent.position += new Vector2(3.0f, 0.0f);
                    }

                }
                else
                {
                    if (actionComponent.curAction.secondaryAction == SecondaryAction.Walk)
                    {
                        positionComponent.position += new Vector2(2.0f, 0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                    {
                        positionComponent.position += new Vector2(0.0f, -4.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling 
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction != PrimaryAction.Fall_Faster || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Left
                        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Right))
                    {
                        positionComponent.position += new Vector2(0.0f, 1.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling 
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                    {
                        positionComponent.position += new Vector2(0.0f, 2.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                    {
                        positionComponent.position += new Vector2(-1.0f, 0.0f);
                    }
                    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Right))
                    {
                        positionComponent.position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield 
                        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.position += new Vector2(1.0f, 0.0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                    {
                        positionComponent.position += new Vector2(-3.0f, 0.0f);
                    }
                    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Right)
                    {
                        positionComponent.position += new Vector2(3.0f, 0.0f);
                    }
                }


                if (actionComponent.curAction.drift == Drift.Left)
                {
                    positionComponent.position += new Vector2(-1.0f, 0.0f);
                }
                else if (actionComponent.curAction.drift == Drift.Right)
                {
                    positionComponent.position += new Vector2(1.0f, 0.0f);
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
