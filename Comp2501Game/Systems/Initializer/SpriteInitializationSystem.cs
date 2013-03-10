using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;

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

                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None), new AnimationDirectory(0, 1, 10));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.A), new AnimationDirectory(2, 9, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.B), new AnimationDirectory(17, 8, 1500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Forward_A), new AnimationDirectory(2, 9, 500)); // same as above
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Forward_A), new AnimationDirectory(6, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Up_A), new AnimationDirectory(5, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Down_A), new AnimationDirectory(7, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.None), new AnimationDirectory(0, 5, 600));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.Forward_A), new AnimationDirectory(1, 9, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.None), new AnimationDirectory(18, 1, 10));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Left), new AnimationDirectory(18, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Right), new AnimationDirectory(18, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                        //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                        //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));

                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.None), new AnimationDirectory(0, 1, 10));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.A), new AnimationDirectory(2, 9, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.B), new AnimationDirectory(17, 8, 1500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Forward_A), new AnimationDirectory(2, 9, 500)); // same as above
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Forward_A), new AnimationDirectory(6, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Up_A), new AnimationDirectory(5, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Down_A), new AnimationDirectory(7, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.None), new AnimationDirectory(0, 5, 600));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.Forward_A), new AnimationDirectory(1, 9, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.None), new AnimationDirectory(18, 1, 10));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Left), new AnimationDirectory(18, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Right), new AnimationDirectory(18, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                        //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                        //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                        spriteComponent.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500)); 
                    }

                }
                base.Initialize();
            }
        }

    }
}
