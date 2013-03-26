using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.Actions;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Holder;

namespace Comp2501Game.Objects.Components
{
    class SpriteComponent : ObjectComponent 
    {
        public Texture2D[] spriteSheets;
        public Dictionary<ActionComponent, AnimationDirectory> animationFrameWork;
        public Dictionary<ActionComponent, SoundDirectory> soundFrameWork;
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
            this.soundFrameWork = new Dictionary<ActionComponent, SoundDirectory>();
            this.curColumn = 0;
            actions = new ActionList();


            this.soundFrameWork.Add(actions.actionList[0], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[1], new SoundDirectory(16, 0, 0, 16));
            this.soundFrameWork.Add(actions.actionList[2], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[3], new SoundDirectory(16, 0, 0, 16)); // same as above
            this.soundFrameWork.Add(actions.actionList[4], new SoundDirectory(53, 42, 50, 53));
            this.soundFrameWork.Add(actions.actionList[5], new SoundDirectory(53, 42, 118, 122));
            this.soundFrameWork.Add(actions.actionList[6], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[7], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[8], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[9], new SoundDirectory(23, 34, 0, 22));
            this.soundFrameWork.Add(actions.actionList[10], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[11], new SoundDirectory(0, 43, 49, 0));
            this.soundFrameWork.Add(actions.actionList[12], new SoundDirectory(29, 0, 0, 29));
            this.soundFrameWork.Add(actions.actionList[13], new SoundDirectory(39, 0, 0, 39));
            this.soundFrameWork.Add(actions.actionList[14], new SoundDirectory(39, 0, 0, 39));
            this.soundFrameWork.Add(actions.actionList[15], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[16], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[17], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[18], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[19], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[20], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[21], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[22], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[23], new SoundDirectory(36, 43, 49, 116));
            this.soundFrameWork.Add(actions.actionList[24], new SoundDirectory(53, 42, 0, 53));
            this.soundFrameWork.Add(actions.actionList[25], new SoundDirectory(116, 0, 0, 116));
            this.soundFrameWork.Add(actions.actionList[26], new SoundDirectory(53, 42, 118, 112));
            this.soundFrameWork.Add(actions.actionList[27], new SoundDirectory(36, 43, 0, 116));
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            this.soundFrameWork.Add(actions.actionList[28], new SoundDirectory(16, 43, 49, 16));
            this.soundFrameWork.Add(actions.actionList[29], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[30], new SoundDirectory(23, 34, 0, 22));
            this.soundFrameWork.Add(actions.actionList[31], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[32], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[33], new SoundDirectory(36, 43, 49, 116));
            this.soundFrameWork.Add(actions.actionList[34], new SoundDirectory(53, 42, 0, 53));
            this.soundFrameWork.Add(actions.actionList[35], new SoundDirectory(116, 0, 0, 116));
            this.soundFrameWork.Add(actions.actionList[36], new SoundDirectory(53, 42, 118, 122));
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            this.soundFrameWork.Add(actions.actionList[37], new SoundDirectory(36, 43, 0, 116));
            this.soundFrameWork.Add(actions.actionList[38], new SoundDirectory(16, 43, 49, 16));
            this.soundFrameWork.Add(actions.actionList[39], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[40], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[41], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[42], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[43], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[44], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[45], new SoundDirectory(0, 0, 0, 0));

            this.soundFrameWork.Add(actions.actionList[46], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[47], new SoundDirectory(16, 0, 0, 16));
            this.soundFrameWork.Add(actions.actionList[48], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[49], new SoundDirectory(16, 0, 0, 16)); // same as above
            this.soundFrameWork.Add(actions.actionList[50], new SoundDirectory(53, 42, 50, 53));
            this.soundFrameWork.Add(actions.actionList[51], new SoundDirectory(53, 42, 118, 122));
            this.soundFrameWork.Add(actions.actionList[52], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[53], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[54], new SoundDirectory(14, 43, 49, 14));
            this.soundFrameWork.Add(actions.actionList[55], new SoundDirectory(23, 34, 0, 22));
            this.soundFrameWork.Add(actions.actionList[56], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[57], new SoundDirectory(0, 43, 49, 0));
            this.soundFrameWork.Add(actions.actionList[58], new SoundDirectory(29, 0, 0, 29));
            this.soundFrameWork.Add(actions.actionList[59], new SoundDirectory(39, 0, 0, 39));
            this.soundFrameWork.Add(actions.actionList[60], new SoundDirectory(39, 0, 0, 39));
            this.soundFrameWork.Add(actions.actionList[61], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[62], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[63], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[64], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[65], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[66], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[67], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[68], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[69], new SoundDirectory(36, 43, 49, 116));
            this.soundFrameWork.Add(actions.actionList[70], new SoundDirectory(53, 42, 0, 53));
            this.soundFrameWork.Add(actions.actionList[71], new SoundDirectory(116, 0, 0, 116));
            this.soundFrameWork.Add(actions.actionList[72], new SoundDirectory(53, 42, 118, 112));
            this.soundFrameWork.Add(actions.actionList[73], new SoundDirectory(36, 43, 0, 116));
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            this.soundFrameWork.Add(actions.actionList[74], new SoundDirectory(16, 43, 49, 16));
            this.soundFrameWork.Add(actions.actionList[75], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[76], new SoundDirectory(23, 34, 0, 22));
            this.soundFrameWork.Add(actions.actionList[77], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[78], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[79], new SoundDirectory(36, 43, 49, 116));
            this.soundFrameWork.Add(actions.actionList[80], new SoundDirectory(53, 42, 0, 53));
            this.soundFrameWork.Add(actions.actionList[81], new SoundDirectory(116, 0, 0, 116));
            this.soundFrameWork.Add(actions.actionList[82], new SoundDirectory(53, 42, 118, 122));
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            this.soundFrameWork.Add(actions.actionList[83], new SoundDirectory(36, 43, 0, 116));
            this.soundFrameWork.Add(actions.actionList[84], new SoundDirectory(16, 43, 49, 16));
            this.soundFrameWork.Add(actions.actionList[85], new SoundDirectory(109, 36, 0, 123));
            this.soundFrameWork.Add(actions.actionList[86], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[87], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[88], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[89], new SoundDirectory(9, 38, 51, 9));
            this.soundFrameWork.Add(actions.actionList[90], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[91], new SoundDirectory(0, 0, 0, 0));

            this.soundFrameWork.Add(actions.actionList[92], new SoundDirectory(109, 0, 0, 37));
            this.soundFrameWork.Add(actions.actionList[93], new SoundDirectory(109, 0, 0, 37));

            this.soundFrameWork.Add(actions.actionList[94], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[95], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[96], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[97], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[98], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[99], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[100], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[101], new SoundDirectory(0, 0, 0, 0));

            this.soundFrameWork.Add(actions.actionList[102], new SoundDirectory(36, 43, 49, 16));
            this.soundFrameWork.Add(actions.actionList[103], new SoundDirectory(36, 43, 49, 16));

            this.soundFrameWork.Add(actions.actionList[104], new SoundDirectory(109, 0, 0, 37));
            this.soundFrameWork.Add(actions.actionList[105], new SoundDirectory(109, 0, 0, 37));

            this.soundFrameWork.Add(actions.actionList[106], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[107], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[108], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[109], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[110], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[111], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[112], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[113], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[114], new SoundDirectory(0, 0, 0, 0));
            this.soundFrameWork.Add(actions.actionList[115], new SoundDirectory(0, 0, 0, 0));





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

                this.animationFrameWork.Add(actions.actionList[92], new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(actions.actionList[93], new AnimationDirectory(17, 8, 1500));

                this.animationFrameWork.Add(actions.actionList[94], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[95], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[96], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[97], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[98], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[99], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[100], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[101], new AnimationDirectory(10, 4, 300));

                this.animationFrameWork.Add(actions.actionList[102], new AnimationDirectory(29, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[103], new AnimationDirectory(29, 8, 1200));

                this.animationFrameWork.Add(actions.actionList[104], new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(actions.actionList[105], new AnimationDirectory(17, 8, 1500));
            }
            if (CharacterType == SpriteType.Kirby)
            {
                //spriteSheets[0] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet1");
                //spriteSheets[1] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet2");
                //spriteSheets[2] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet3");
                //spriteSheets[3] = game.Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet4");

                this.animationFrameWork.Add(actions.actionList[0], new AnimationDirectory(0, 1, 10));
                this.animationFrameWork.Add(actions.actionList[1], new AnimationDirectory(2, 9, 500));
                this.animationFrameWork.Add(actions.actionList[2], new AnimationDirectory(17, 8, 1500));
                this.animationFrameWork.Add(actions.actionList[3], new AnimationDirectory(2, 9, 500)); // same as above
                this.animationFrameWork.Add(actions.actionList[4], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[5], new AnimationDirectory(16, 8, 3000));
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
                this.animationFrameWork.Add(actions.actionList[24], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[25], new AnimationDirectory(9, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[26], new AnimationDirectory(16, 8, 3000));
                this.animationFrameWork.Add(actions.actionList[27], new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[28], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[29], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[30], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[31], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[32], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[33], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[34], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[35], new AnimationDirectory(10, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[36], new AnimationDirectory(16, 8, 3000));
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
                this.animationFrameWork.Add(actions.actionList[50], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[51], new AnimationDirectory(16, 8, 3000));
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
                this.animationFrameWork.Add(actions.actionList[63], new AnimationDirectory(22, 3, 400));
                this.animationFrameWork.Add(actions.actionList[64], new AnimationDirectory(25, 3, 400));
                this.animationFrameWork.Add(actions.actionList[65], new AnimationDirectory(23, 3, 400));
                this.animationFrameWork.Add(actions.actionList[66], new AnimationDirectory(24, 3, 400));
                this.animationFrameWork.Add(actions.actionList[67], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[68], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[69], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[70], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[71], new AnimationDirectory(9, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[72], new AnimationDirectory(16, 8, 3000));
                this.animationFrameWork.Add(actions.actionList[73], new AnimationDirectory(11, 8, 1200));
                //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[74], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[75], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[76], new AnimationDirectory(8, 8, 500));
                this.animationFrameWork.Add(actions.actionList[77], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[78], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[79], new AnimationDirectory(13, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[80], new AnimationDirectory(15, 8, 800));
                this.animationFrameWork.Add(actions.actionList[81], new AnimationDirectory(9, 7, 1000));
                this.animationFrameWork.Add(actions.actionList[82], new AnimationDirectory(16, 8, 3000));
                this.animationFrameWork.Add(actions.actionList[83], new AnimationDirectory(11, 8, 1200));
                //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
                this.animationFrameWork.Add(actions.actionList[84], new AnimationDirectory(12, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[85], new AnimationDirectory(17, 8, 1000));
                this.animationFrameWork.Add(actions.actionList[86], new AnimationDirectory(22, 3, 400));
                this.animationFrameWork.Add(actions.actionList[87], new AnimationDirectory(25, 3, 400));
                this.animationFrameWork.Add(actions.actionList[88], new AnimationDirectory(23, 3, 400));
                this.animationFrameWork.Add(actions.actionList[89], new AnimationDirectory(24, 3, 400));
                this.animationFrameWork.Add(actions.actionList[90], new AnimationDirectory(26, 8, 500));
                this.animationFrameWork.Add(actions.actionList[91], new AnimationDirectory(27, 8, 500));

                this.animationFrameWork.Add(actions.actionList[92], new AnimationDirectory(30, 4, 500));
                this.animationFrameWork.Add(actions.actionList[93], new AnimationDirectory(30, 4, 500));

                this.animationFrameWork.Add(actions.actionList[94], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[95], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[96], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[97], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[98], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[99], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[100], new AnimationDirectory(10, 4, 300));
                this.animationFrameWork.Add(actions.actionList[101], new AnimationDirectory(10, 4, 300));

                this.animationFrameWork.Add(actions.actionList[102], new AnimationDirectory(29, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[103], new AnimationDirectory(29, 8, 1200));

                this.animationFrameWork.Add(actions.actionList[104], new AnimationDirectory(30, 4, 500));
                this.animationFrameWork.Add(actions.actionList[105], new AnimationDirectory(30, 4, 500));

                this.animationFrameWork.Add(actions.actionList[106], new AnimationDirectory(31, 6, 500));
                this.animationFrameWork.Add(actions.actionList[107], new AnimationDirectory(32, 10, 800));
                this.animationFrameWork.Add(actions.actionList[108], new AnimationDirectory(32, 10, 800));
                this.animationFrameWork.Add(actions.actionList[109], new AnimationDirectory(31, 6, 500));

                this.animationFrameWork.Add(actions.actionList[110], new AnimationDirectory(29, 8, 1200));
                this.animationFrameWork.Add(actions.actionList[111], new AnimationDirectory(29, 8, 1200));

                this.animationFrameWork.Add(actions.actionList[112], new AnimationDirectory(31, 1, 10));
                this.animationFrameWork.Add(actions.actionList[113], new AnimationDirectory(31, 1, 10));
                this.animationFrameWork.Add(actions.actionList[114], new AnimationDirectory(31, 1, 10));
                this.animationFrameWork.Add(actions.actionList[115], new AnimationDirectory(31, 1, 10));
            }
                //Console.WriteLine(this.animationFrameWork[new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None)].attackTimer);
        }

        public override ComponentType GetType()
        {
            return ComponentType.Sprite;
        }
    }
}
