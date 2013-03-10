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

        public SpriteComponent(GameObject parent, SpriteType type)
            : base(parent)
        {
            this.CharacterType = type;
            this.spriteSheets = new Texture2D[4];
            this.animationFrameWork = new Dictionary<ActionComponent, AnimationDirectory>();
            this.curColumn = 0;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Sprite;
        }
    }
}
