using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.Actions;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class SpriteComponent : ObjectComponent 
    {
        public Texture2D[] spriteSheets;
        public Dictionary<ActionComponent, AnimationDirectory> animationFrameWork;
        public SpriteType CharacterType;
        public int curColumn;
        public int curRow;
        public int milisecondsSinceLastFrame;
        public ActionList actions;

        public SpriteComponent(GameObject parent, SpriteType type, Game1 game)
            : base(parent)
        {
            this.CharacterType = type;
            this.spriteSheets = new Texture2D[4];
            this.animationFrameWork = new Dictionary<ActionComponent, AnimationDirectory>();
            this.curColumn = 0;
            actions = new ActionList();

            if (CharacterType == SpriteType.Yoshi)
            {
                //spriteSheets[0] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet1");
                //spriteSheets[1] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet2");
                //spriteSheets[2] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet3");
                //spriteSheets[3] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet4");

                this.animationFrameWork.Add(actions.actionList[0], new AnimationDirectory(0, 1, 10));
                this.animationFrameWork.Add(actions.actionList[1], new AnimationDirectory(2, 9, 500));
                this.animationFrameWork.Add(actions.actionList[2], new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(actions.actionList[3], new AnimationDirectory(2, 9, 500)); // same as above
                this.animationFrameWork.Add(actions.actionList[4], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[5], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[6], new AnimationDirectory(6, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[7], new AnimationDirectory(5, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[8], new AnimationDirectory(7, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[9], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[10], new AnimationDirectory(0, 5, 600));
                this.animationFrameWork.Add(actions.actionList[11], new AnimationDirectory(1, 9, 1000));
                this.animationFrameWork.Add(actions.actionList[12], new AnimationDirectory(18, 1, 10));
                this.animationFrameWork.Add(actions.actionList[13], new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(actions.actionList[14], new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(actions.actionList[15], new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(actions.actionList[16], new AnimationDirectory(27, 8, 500));
                this.animationFrameWork.Add(actions.actionList[17], new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(actions.actionList[18], new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(actions.actionList[19], new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(actions.actionList[20], new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(actions.actionList[21], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[22], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[23], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[24], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[25], new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[26], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[27], new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[28], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[29], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[30], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[31], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[32], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[33], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[34], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[35], new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[36], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[37], new AnimationDirectory(11, 8, 1200));
                //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[38], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[39], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[40], new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(actions.actionList[41], new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(actions.actionList[42], new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(actions.actionList[43], new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(actions.actionList[44], new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(actions.actionList[45], new AnimationDirectory(27, 8, 500));

                this.animationFrameWork.Add(actions.actionList[46], new AnimationDirectory(0, 1, 10));
                this.animationFrameWork.Add(actions.actionList[47], new AnimationDirectory(2, 9, 500));
                this.animationFrameWork.Add(actions.actionList[48], new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(actions.actionList[49], new AnimationDirectory(2, 9, 500)); // same as above
                this.animationFrameWork.Add(actions.actionList[50], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[51], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[52], new AnimationDirectory(6, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[53], new AnimationDirectory(5, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[54], new AnimationDirectory(7, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[55], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[56], new AnimationDirectory(0, 5, 600));
                this.animationFrameWork.Add(actions.actionList[57], new AnimationDirectory(1, 9, 1000));
                this.animationFrameWork.Add(actions.actionList[58], new AnimationDirectory(18, 1, 10));
                this.animationFrameWork.Add(actions.actionList[59], new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(actions.actionList[60], new AnimationDirectory(18, 8, 400));
                this.animationFrameWork.Add(actions.actionList[61], new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(actions.actionList[62], new AnimationDirectory(27, 8, 500));
                this.animationFrameWork.Add(actions.actionList[63], new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(actions.actionList[64], new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(actions.actionList[65], new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(actions.actionList[66], new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(actions.actionList[67], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[68], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[69], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[70], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[71], new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[72], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[73], new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[74], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[75], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[76], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[77], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[78], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[79], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[80], new AnimationDirectory(16, 8, 800));
                this.animationFrameWork.Add(actions.actionList[81], new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[82], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[83], new AnimationDirectory(11, 8, 1200));
                //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[84], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[85], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[86], new AnimationDirectory(22, 8, 400));
                this.animationFrameWork.Add(actions.actionList[87], new AnimationDirectory(25, 8, 400));
                this.animationFrameWork.Add(actions.actionList[88], new AnimationDirectory(23, 8, 400));
                this.animationFrameWork.Add(actions.actionList[89], new AnimationDirectory(24, 8, 400));
                this.animationFrameWork.Add(actions.actionList[90], new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(actions.actionList[91], new AnimationDirectory(27, 8, 500));
            }
                //Console.WriteLine(this.animationFrameWork[new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None)].attackTimer);
        }

        public override ComponentType GetType()
        {
            return ComponentType.Sprite;
        }
    }
}
