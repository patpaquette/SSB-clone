using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Comp2501Game.Systems
{
    class SpriteInitializationSystem : GameSystem
    {
        public int playerNumber;

        public SpriteInitializationSystem(Game1 game, int num)
            :base(game)
        {
            //this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Sprite);
            this._componentDependencies.Add(ComponentType.Sound);
            this.playerNumber = num;
        }

        public override SystemType GetType()
        {
            return SystemType.Initializer;
        }

        public override void Initialize()
        {
            foreach (GameObject obj in this._objects)
            {
                //PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);
                SoundComponent soundComponent = (SoundComponent)obj.GetComponent(ComponentType.Sound);

                //if (playerComponent.PlayerNumber == this.playerNumber)
                //{
                    if (spriteComponent.CharacterType == SpriteType.Yoshi)
                    {
                        spriteComponent.spriteSheets[0] = this.Game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet1");
                        spriteComponent.spriteSheets[1] = this.Game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet2");
                        spriteComponent.spriteSheets[2] = this.Game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet3");
                        spriteComponent.spriteSheets[3] = this.Game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet4");

                    }
                    else if (spriteComponent.CharacterType == SpriteType.Kirby)
                    {
                        spriteComponent.spriteSheets[0] = this.Game.Content.Load<Texture2D>(@"Images/Kirby_Sprite_Sheet1");
                        spriteComponent.spriteSheets[1] = this.Game.Content.Load<Texture2D>(@"Images/Kirby_Sprite_Sheet2");
                        spriteComponent.spriteSheets[2] = this.Game.Content.Load<Texture2D>(@"Images/Kirby_Sprite_Sheet3");
                        spriteComponent.spriteSheets[3] = this.Game.Content.Load<Texture2D>(@"Images/Kirby_Sprite_Sheet4");
                    }


                    soundComponent.actionSoundList[0] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/8");
                    soundComponent.actionSoundList[1] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/9");
                    soundComponent.actionSoundList[2] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/14");
                    soundComponent.actionSoundList[3] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/16");
                    soundComponent.actionSoundList[4] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/22");
                    soundComponent.actionSoundList[5] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/28");
                    soundComponent.actionSoundList[6] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/29");
                    soundComponent.actionSoundList[7] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/31");
                    soundComponent.actionSoundList[8] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/32");
                    soundComponent.actionSoundList[9] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/33");
                    soundComponent.actionSoundList[10] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/36");
                    soundComponent.actionSoundList[11] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/37");
                    soundComponent.actionSoundList[12] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/39");
                    soundComponent.actionSoundList[13] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/53");
                    soundComponent.actionSoundList[14] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/109");
                    soundComponent.actionSoundList[15] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/111");
                    soundComponent.actionSoundList[16] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/112");
                    soundComponent.actionSoundList[17] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/116");
                    soundComponent.actionSoundList[18] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/122");
                    soundComponent.actionSoundList[19] = this.Game.Content.Load<SoundEffect>(@"Sounds/ActionSounds/123");

                    soundComponent.voiceSoundList[0] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/34");
                    soundComponent.voiceSoundList[1] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/36");
                    soundComponent.voiceSoundList[2] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/38");
                    soundComponent.voiceSoundList[3] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/42");
                    soundComponent.voiceSoundList[4] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/43");
                    soundComponent.voiceSoundList[5] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/49");
                    soundComponent.voiceSoundList[6] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/50");
                    soundComponent.voiceSoundList[7] = this.Game.Content.Load<SoundEffect>(@"Sounds/CharacterSounds/51");
                      
                //}
                base.Initialize();
            }
        }

    }
}
