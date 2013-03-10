using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems;

namespace Comp2501Game.Objects
{
    class PlayerObject : GameObject
    {
        public PlayerObject(Game1 game, Vector2 pos, float rot, Vector2 scale, int playerNum, SpriteType type)
            : base(game)
        {
            Transform2DComponent transformComponent = new Transform2DComponent(
             this,
             pos,
             rot,
             scale);
            this.AddComponent(transformComponent);
            this.AddComponent(new PlayerComponent(this, playerNum));
            this.AddComponent(new CurrentActionComponent(this,new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None)));
            this.AddComponent(new SpriteComponent(this, type, game));
        }
            
   
    }
}
