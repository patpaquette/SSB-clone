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
            this._componentDependencies.Add(ComponentType.Sound);
            this.playerNumber = playerNum;
        }

         public override SystemType GetType()
         {
             return SystemType.StateModifier;
         }



         private void playSounds(int act, int voice, SoundComponent sound)
         {
             if (act != 0)
             {
                 if (act == 8) { sound.actionSoundList[0].Play(); }
                 else if (act == 9) { sound.actionSoundList[1].Play(); }
                 else if (act == 14) { sound.actionSoundList[2].Play(); }
                 else if (act == 16) { sound.actionSoundList[3].Play(); }
                 else if (act == 22) { sound.actionSoundList[4].Play(); }
                 else if (act == 28) { sound.actionSoundList[5].Play(); }
                 else if (act == 31) { sound.actionSoundList[7].Play(); }
                 else if (act == 32)
                 {
                     sound.actionSoundList[8].Play();
                 }
                 else if (act == 33)
                 {
                     sound.actionSoundList[9].Play();
                 }
                 else if (act == 36)
                 {
                     sound.actionSoundList[10].Play();
                 }
                 else if (act == 37)
                 {
                     sound.actionSoundList[11].Play();
                 }
                 else if (act == 39)
                 {
                     sound.actionSoundList[12].Play();
                 }
                 else if (act == 53)
                 {
                     sound.actionSoundList[13].Play();
                 }
                 else if (act == 109)
                 {
                     sound.actionSoundList[14].Play();
                 }
                 else if (act == 111)
                 {
                     sound.actionSoundList[15].Play();
                 }
                 else if (act == 112)
                 {
                     sound.actionSoundList[16].Play();
                 }
                 else if (act == 116)
                 {
                     sound.actionSoundList[17].Play();
                 }
                 else if (act == 122)
                 {
                     sound.actionSoundList[18].Play();
                 }
                 else if (act == 123)
                 {
                     sound.actionSoundList[19].Play();
                 }
             }

             if (voice != 0)
             {
                 if (voice == 34)
                 {
                     sound.voiceSoundList[0].Play();
                 }
                 else if (voice == 36)
                 {
                     sound.voiceSoundList[1].Play();
                 }
                 else if (voice == 38)
                 {
                     sound.voiceSoundList[2].Play();
                 }
                 else if (voice == 42)
                 {
                     sound.voiceSoundList[3].Play();
                 }
                 else if (voice == 43)
                 {
                     sound.voiceSoundList[4].Play();
                 }
                 else if (voice == 49)
                 {
                     sound.voiceSoundList[5].Play();
                 }
                 else if (voice == 50)
                 {
                     sound.voiceSoundList[6].Play();
                 }
                 else if (voice == 51)
                 {
                     sound.voiceSoundList[7].Play();
                 }
                 else if (voice == 118)
                 {
                     sound.voiceSoundList[8].Play();
                 }
             }
         }


         public override void Update(GameTime gameTime)
         {
             foreach (GameObject obj in this._objects)
             {
                 PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                 CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                 SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);
                 SoundComponent soundComponent = (SoundComponent)obj.GetComponent(ComponentType.Sound);


                 //Console.WriteLine(actionComponent.curAction.curDirection + " " + actionComponent.curAction.secondaryAction + " " + actionComponent.curAction.primaryAction);
                 
                 
                 ActionComponent curAct = actionComponent.curAction;
                 Dictionary<ActionComponent, AnimationDirectory> framework = spriteComponent.animationFrameWork;
                 ActionList actList = spriteComponent.actions;
                 if (playerComponent.PlayerNumber == this.playerNumber)
                 {
                     Console.WriteLine(actionComponent.curAction.curDirection + " " + actionComponent.curAction.secondaryAction + " " + actionComponent.curAction.primaryAction);
                     if (spriteComponent.curColumn == 0)
                     {
                         spriteComponent.curRow = framework[actList.actionList[actList.findAction(curAct)]].rowNumber;
                         spriteComponent.curColumn = 1;

                         if (spriteComponent.CharacterType == SpriteType.Kirby)
                         {
                             playSounds(spriteComponent.soundFrameWork[actList.actionList[actList.findAction(curAct)]].kirbyActionSound,
                                 spriteComponent.soundFrameWork[actList.actionList[actList.findAction(curAct)]].kirbyVoiceSound, soundComponent);
                         }
                         else
                         {
                             playSounds(spriteComponent.soundFrameWork[actList.actionList[actList.findAction(curAct)]].yoshiActionSound,
                                spriteComponent.soundFrameWork[actList.actionList[actList.findAction(curAct)]].yoshiVoiceSound, soundComponent);
                         }
                     }

                     spriteComponent.milisecondsSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                     if (spriteComponent.milisecondsSinceLastFrame >= (
                         ((framework[actList.actionList[actList.findAction(curAct)]].attackTimer) /
                         framework[actList.actionList[actList.findAction(curAct)]].numColumns)))
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
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Smash)
                         {
                             actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
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
                         else if (actionComponent.curAction.secondaryAction == SecondaryAction.Throw)
                         {
                             actionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                             actionComponent.curAction.primaryAction = PrimaryAction.None;

                         }
                         else
                         {
                             actionComponent.curAction.primaryAction = PrimaryAction.None;
                             actionComponent.curAction.drift = Drift.None;
                         }

                     }
                 }

             }
             base.Update(gameTime);
         }
    }
}
