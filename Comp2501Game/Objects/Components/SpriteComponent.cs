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
        public Dictionary<MovementType, AnimationDirectory> animationFrameWork;
        public SpriteType CharacterType;

        public SpriteComponent(Texture2D[] sheets, Dictionary<MovementType, AnimationDirectory> info, SpriteType type)
        {
            spriteSheets = sheets;
            animationFrameWork = info;
            CharacterType = type;
        }

        public override ComponentType GetType()
        {
            return ComponentType.Sprite;
        }
    }
}
