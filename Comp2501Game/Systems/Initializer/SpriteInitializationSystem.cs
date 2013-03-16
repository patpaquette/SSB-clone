using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems
{
    class SpriteInitializationSystem : GameSystem
    {
        public int playerNumber;

        public SpriteInitializationSystem(Game1 game, int num)
            :base(game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Sprite);
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
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);

                if (playerComponent.PlayerNumber == this.playerNumber)
                {
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
                      
                }
                base.Initialize();
            }
        }

    }
}
