using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems
{
    class AnimationSystem : GameSystem
    {
        public int playerNumber;

         public AnimationSystem(Game1 game, int playerNum)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Sprite);
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Action);
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
                 CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                 SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Action);

                 spriteComponent.milisecondsSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                 if (spriteComponent.milisecondsSinceLastFrame >= 60 / (spriteComponent.animationFrameWork[actionComponent].numColumns / spriteComponent.animationFrameWork[actionComponent].attackTimer))
                 {
                     spriteComponent.curColumn = (spriteComponent.curColumn + 1) % spriteComponent.animationFrameWork[actionComponent].numColumns;
                     spriteComponent.milisecondsSinceLastFrame = 0;

                 }

                 if (spriteComponent.curColumn == 0)
                 {
                     if (actionComponent.secondaryAction == SecondaryAction.Jump)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Falling;
                         actionComponent.primaryAction = PrimaryAction.None;
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Second_Jump)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Second_Falling;
                         actionComponent.primaryAction = PrimaryAction.None;
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Landing)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Stand;
                         actionComponent.primaryAction = PrimaryAction.None;
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Hit && actionComponent.curDirection == DirectionalAction.Left)
                     {
                         if (actionComponent.primaryAction == PrimaryAction.Above || actionComponent.primaryAction == PrimaryAction.Behind || actionComponent.primaryAction == PrimaryAction.Below)
                         {
                             actionComponent.secondaryAction = SecondaryAction.Flying;
                             actionComponent.primaryAction = PrimaryAction.Left;
                         }
                         else
                         {
                             actionComponent.secondaryAction = SecondaryAction.Flying;
                             actionComponent.primaryAction = PrimaryAction.Right;
                         }
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Hit && actionComponent.curDirection == DirectionalAction.Right)
                     {
                         if (actionComponent.primaryAction == PrimaryAction.Above || actionComponent.primaryAction == PrimaryAction.Behind || actionComponent.primaryAction == PrimaryAction.Below)
                         {
                             actionComponent.secondaryAction = SecondaryAction.Flying;
                             actionComponent.primaryAction = PrimaryAction.Right;
                         }
                         else
                         {
                             actionComponent.secondaryAction = SecondaryAction.Flying;
                             actionComponent.primaryAction = PrimaryAction.Left;
                         }
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Second_Hit && actionComponent.curDirection == DirectionalAction.Left)
                     {
                         if (actionComponent.primaryAction == PrimaryAction.Above || actionComponent.primaryAction == PrimaryAction.Behind || actionComponent.primaryAction == PrimaryAction.Below)
                         {
                             actionComponent.secondaryAction = SecondaryAction.Second_Flying;
                             actionComponent.primaryAction = PrimaryAction.Left;
                         }
                         else
                         {
                             actionComponent.secondaryAction = SecondaryAction.Second_Flying;
                             actionComponent.primaryAction = PrimaryAction.Right;
                         }
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Second_Hit && actionComponent.curDirection == DirectionalAction.Right)
                     {
                         if (actionComponent.primaryAction == PrimaryAction.Above || actionComponent.primaryAction == PrimaryAction.Behind || actionComponent.primaryAction == PrimaryAction.Below)
                         {
                             actionComponent.secondaryAction = SecondaryAction.Second_Flying;
                             actionComponent.primaryAction = PrimaryAction.Right;
                         }
                         else
                         {
                             actionComponent.secondaryAction = SecondaryAction.Second_Flying;
                             actionComponent.primaryAction = PrimaryAction.Left;
                         }
                     }
                     else
                     {
                         actionComponent.primaryAction = PrimaryAction.None;
                     }

                 }
             }

             base.Update(gameTime);

         }
    }
}
