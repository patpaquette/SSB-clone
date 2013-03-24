using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Systems;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.Objects
{
    class PlayerObject : GameObject
    {
        public PlayerObject(Game1 game, int playerNum, SpriteType type)
            : base(game)
        {
            Transform2DComponent transformComponent = new Transform2DComponent(
             this,
             new Vector2(300,100),
             0.0f,
             new Vector2(1.0f));
                
            this.AddComponent(transformComponent);
            this.AddComponent(new PlayerComponent(this, playerNum));
            this.AddComponent(new CurrentActionComponent(
                this,
                new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None),
                new Dictionary<ActionDefinition, ActionInfo>()
            ));
            this.AddComponent(new SpriteComponent(this, type, game));
        }
            
   
    }
}
