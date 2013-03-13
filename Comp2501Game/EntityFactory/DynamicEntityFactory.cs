using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;
using Comp2501Game.Objects.Components.Physics;

namespace Comp2501Game.EntityFactory
{
    class DynamicEntityFactory
    {
        private Game1 _game;

        public DynamicEntityFactory(Game1 game)
        {
            this._game = game;
        }

        public GameObject BuildPlayerControlledEntity(
            int playerNumber,
            Vector2 position,
            SpriteType spriteType,
            List<Shape> boundingBoxes)
        {
            GameObject entity = new GameObject(this._game);

            PlayerComponent playerComponent = new PlayerComponent(entity, playerNumber);
            Transform2DComponent transformComponent = new Transform2DComponent(
                entity, 
                position, 
                0.0f, 
                Vector2.One);
            SpriteComponent sprite = new SpriteComponent(entity, spriteType, this._game);
            BoundingBoxComponent bbComponent = new BoundingBoxComponent(entity, boundingBoxes, true);
            CurrentActionComponent caComponent = new CurrentActionComponent(entity, new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None));
            GravityComponent gravComponent = new GravityComponent(entity, 1.0f);

            entity.AddComponent(playerComponent);
            entity.AddComponent(transformComponent);
            entity.AddComponent(sprite);
            entity.AddComponent(bbComponent);
            entity.AddComponent(caComponent);
            entity.AddComponent(gravComponent);

            return entity;
        }
    }
}
