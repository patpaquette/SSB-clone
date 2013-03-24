using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Physics;

namespace Comp2501Game.Systems.StateMod
{
    class MovementSystem : GameSystem 
    {
        public int playerNumber;

        public MovementSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Action);
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.MotionProperties);
            this.playerNumber = playerNum;
        }

        public override void Update(GameTime gameTime)
        {
            float timestep = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            //Console.WriteLine("here3");
            foreach (GameObject obj in this._objects)
            {
                //Console.WriteLine("here4")
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                Transform2DComponent positionComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                MotionPropertiesComponent motionComponent = (MotionPropertiesComponent)obj.GetComponent(ComponentType.MotionProperties);

                Vector2 tbAdded = new Vector2(0, 0);

                if (actionComponent.curAction.secondaryAction == SecondaryAction.Walk)
                {
                    tbAdded += new Vector2(-1500, 0);
                    positionComponent.SetScale(new Vector2(1.0f, 1.0f));
                }
                
                if (actionComponent.curAction.primaryAction == PrimaryAction.Roll_Right)
                {
                    tbAdded += new Vector2(-3000, 0);
                }
                else if (actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                {
                    tbAdded += new Vector2(-3000, 0);
                }

                if (actionComponent.curAction.secondaryAction == SecondaryAction.Falling ||
                   actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                {
                   // tbAdded += new Vector2(0, 1);
                }
                else if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump ||
                    actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                {
                    //Added += new Vector2(0, -10);
                    motionComponent.AddVelocity(new Vector2(0.0f, -20.0f));
                }

                if (actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster)
                {
                    tbAdded += new Vector2(0, 2);
                }

                if (actionComponent.curAction.primaryAction == PrimaryAction.Down_B &&
                    actionComponent.curAction.secondaryAction == SecondaryAction.Falling ||
                    actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                {
                    tbAdded = new Vector2(0, 8);
                }


                if (actionComponent.curAction.curDirection == DirectionalAction.Right)
                {
                    tbAdded.X = -tbAdded.X;
                    positionComponent.SetScale(new Vector2(-1.0f, 1.0f));
                }
                else
                {
                    positionComponent.SetScale(new Vector2(1.0f, 1.0f));
                }

                if (actionComponent.curAction.drift == Drift.Left)
                {
                    tbAdded += new Vector2(-500, 0);
                }
                else if (actionComponent.curAction.drift == Drift.Right)
                {
                    tbAdded += new Vector2(500, 0);
                }

                motionComponent.AddForce(tbAdded);
                
                
                //if (actionComponent.curAction.curDirection == DirectionalAction.Left)
                //{
                //    positionComponent.SetScale(new Vector2(1.0f, 1.0f));

                //    if (actionComponent.curAction.secondaryAction == SecondaryAction.Walk)
                //    {
                //        positionComponent.AddTranslation(new Vector2(-2.0f, 0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, -4.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction != PrimaryAction.Fall_Faster
                //        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Left
                //        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Right))
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, 1.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, 2.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                //    {
                //        positionComponent.AddTranslation(new Vector2(-1.0f, 0.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                //    {
                //        positionComponent.AddTranslation(new Vector2(-1.0f, 0.0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                //        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                //    {
                //        positionComponent.AddTranslation(new Vector2(-3.0f, 0.0f));
                //        //positionComponent.position += new Vector2(-3.0f, 0.0f);
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                //        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Right)
                //    {
                //        positionComponent.AddTranslation(new Vector2(3.0f, 0.0f));
                //    }

                //}
                //else
                //{
                //    positionComponent.SetScale(new Vector2(-1.0f, 1.0f));

                //    if (actionComponent.curAction.secondaryAction == SecondaryAction.Walk)
                //    {
                //        positionComponent.AddTranslation(new Vector2(2.0f, 0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, -4.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling 
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction != PrimaryAction.Fall_Faster || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Left
                //        || actionComponent.curAction.primaryAction != PrimaryAction.Drift_Right))
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, 1.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling 
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Fall_Faster))
                //    {
                //        positionComponent.AddTranslation(new Vector2(0.0f, 2.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Left))
                //    {
                //        positionComponent.AddTranslation(new Vector2(-1.0f, 0.0f));
                //    }
                //    else if ((actionComponent.curAction.secondaryAction == SecondaryAction.Falling
                //        || actionComponent.curAction.secondaryAction == SecondaryAction.Second_Falling)
                //        && (actionComponent.curAction.primaryAction == PrimaryAction.Drift_Right))
                //    {
                //        positionComponent.AddTranslation(new Vector2(1.0f, 0.0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield 
                //        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                //    {
                //        positionComponent.AddTranslation(new Vector2(1.0f, 0.0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                //        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Left)
                //    {
                //        positionComponent.AddTranslation(new Vector2(-3.0f, 0.0f));
                //    }
                //    else if (actionComponent.curAction.secondaryAction == SecondaryAction.Shield
                //        && actionComponent.curAction.primaryAction == PrimaryAction.Roll_Right)
                //    {
                //        positionComponent.AddTranslation(new Vector2(3.0f, 0.0f));
                //    }
                //}


            }

            base.Update(gameTime);
        }



        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }


    }
}
