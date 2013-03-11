using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.Systems
{
    class AnimationSystem : GameSystem
    {
        public int playerNumber;

         public AnimationSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Action);
            this._componentDependencies.Add(ComponentType.Sprite);
            this.playerNumber = playerNum;
        }

         public override SystemType GetType()
         {
             return SystemType.Initializer;
         }

  


         public override void Update(GameTime gameTime)
         {
             foreach (GameObject obj in this._objects)
             {
                 PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                 CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                 SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);
                 //Console.WriteLine(actionComponent.curAction.curDirection + " " + actionComponent.curAction.secondaryAction + " " + actionComponent.curAction.primaryAction);
                 ActionComponent curAct = actionComponent.curAction;
                 Dictionary<ActionComponent, AnimationDirectory> framework = spriteComponent.animationFrameWork;
                 ActionList actList = spriteComponent.actions;

                 if (playerComponent.PlayerNumber == this.playerNumber)
                 {
                     if (spriteComponent.curColumn == 0)
                     {
                         spriteComponent.curRow = framework[actList.actionList[actList.findAction(curAct)]].rowNumber;
                     }

                     spriteComponent.milisecondsSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                     if (spriteComponent.milisecondsSinceLastFrame >= (1000 / 
                         framework[actList.actionList[actList.findAction(curAct)]].attackTimer) /
                         framework[actList.actionList[actList.findAction(curAct)]].numColumns)
                     {
                         spriteComponent.curColumn = (spriteComponent.curColumn + 1)
                             % (framework[actList.actionList[actList.findAction(curAct)]].numColumns);
                         spriteComponent.milisecondsSinceLastFrame = 0;

                     }

                     if (spriteComponent.curColumn == 0)
                     {
                         if (actionComponent.curAction.secondaryAction == SecondaryAction.Jump)
                         {
                             actionComponent.curAction.secondaryAction = SecondaryAction.Falling;
                             actionComponent.curAction.primaryAction = PrimaryAction.None;
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Second_Jump)
                         {
                             actionComponent.curAction.secondaryAction = SecondaryAction.Second_Falling;
                             actionComponent.curAction.primaryAction = PrimaryAction.None;
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Landing)
                         {
                             actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                             actionComponent.curAction.primaryAction = PrimaryAction.None;
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Hit
                             && actionComponent.curAction.curDirection == DirectionalAction.Left)
                         {
                             if (actionComponent.curAction.primaryAction == PrimaryAction.Above
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Behind
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Below)
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Left;
                             }
                             else
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Right;
                             }
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Hit
                             && actionComponent.curAction.curDirection == DirectionalAction.Right)
                         {
                             if (actionComponent.curAction.primaryAction == PrimaryAction.Above
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Behind
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Below)
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Right;
                             }
                             else
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Left;
                             }
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Second_Hit
                             && actionComponent.curAction.curDirection == DirectionalAction.Left)
                         {
                             if (actionComponent.curAction.primaryAction == PrimaryAction.Above
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Behind
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Below)
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Second_Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Left;
                             }
                             else
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Second_Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Right;
                             }
                         }
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Second_Hit
                             && actionComponent.curAction.curDirection == DirectionalAction.Right)
                         {
                             if (actionComponent.curAction.primaryAction == PrimaryAction.Above
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Behind
                                 || actionComponent.curAction.primaryAction == PrimaryAction.Below)
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Second_Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Right;
                             }
                             else
                             {
                                 actionComponent.curAction.secondaryAction = SecondaryAction.Second_Flying;
                                 actionComponent.curAction.primaryAction = PrimaryAction.Left;
                             }
                         }
                         else
                         {
                             actionComponent.curAction.primaryAction = PrimaryAction.None;
                             actionComponent.curAction.drift = Drift.None;
                         }

                     }
                 }

                 base.Update(gameTime);
             }
         }
    }
}
