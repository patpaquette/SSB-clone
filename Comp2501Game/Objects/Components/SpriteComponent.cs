using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Objects.Components
{
    class SpriteComponent : ObjectComponent 
    {
        public Texture2D[] spriteSheets;
        public Dictionary<ActionComponent, AnimationDirectory> animationFrameWork;
        public SpriteType CharacterType;
        public int curColumn;
        public int milisecondsSinceLastFrame;

        public SpriteComponent(GameObject parent, SpriteType type, Game1 game)
            : base(parent)
        {
            this.CharacterType = type;
            this.spriteSheets = new Texture2D[4];
            this.animationFrameWork = new Dictionary<ActionComponent, AnimationDirectory>();
            this.curColumn = 0;

            //if (CharacterType == SpriteType.Yoshi)
            //{
                //spriteSheets[0] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet1");
                //spriteSheets[1] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet2");
                //spriteSheets[2] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet3");
                //spriteSheets[3] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet4");

                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None), new AnimationDirectory(0, 1, 10));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.A), new AnimationDirectory(2, 9, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.B), new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Forward_A), new AnimationDirectory(2, 9, 500)); // same as above
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Forward_A), new AnimationDirectory(6, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Up_A), new AnimationDirectory(5, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Down_A), new AnimationDirectory(7, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.None), new AnimationDirectory(0, 5, 600));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.Forward_A), new AnimationDirectory(1, 9, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.None), new AnimationDirectory(18, 1, 10));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Left), new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Right), new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));

                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.None), new AnimationDirectory(0, 1, 10));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.A), new AnimationDirectory(2, 9, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.B), new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Forward_A), new AnimationDirectory(2, 9, 500)); // same as above
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Forward_A), new AnimationDirectory(6, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Up_A), new AnimationDirectory(5, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Down_A), new AnimationDirectory(7, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.None), new AnimationDirectory(0, 5, 600));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.Forward_A), new AnimationDirectory(1, 9, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.None), new AnimationDirectory(18, 1, 10));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Left), new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Right), new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Jump, PrimaryAction.None), new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.None), new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_A), new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_B), new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_A), new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_B), new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Forward_A), new AnimationDirectory(11, 8, 1200));
                //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.A), new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.B), new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Above), new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Below), new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Front), new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Behind), new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Right), new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Left), new AnimationDirectory(27, 8, 500));
           // }
                Console.WriteLine(this.animationFrameWork[new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None)].attackTimer);
        }

        public override ComponentType GetType()
        {
            return ComponentType.Sprite;
        }
    }
}
