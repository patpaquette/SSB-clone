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
                     actionComponent.primaryAction = PrimaryAction.None;

                     if (actionComponent.secondaryAction == SecondaryAction.Jump)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Falling;
                     }
                     if (actionComponent.secondaryAction == SecondaryAction.Second_Jump)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Second_Falling;
                     }
                     else if (actionComponent.secondaryAction == SecondaryAction.Landing)
                     {
                         actionComponent.secondaryAction = SecondaryAction.Stand;
                     }

                 }
             }

             base.Update(gameTime);

         }
    }
}
