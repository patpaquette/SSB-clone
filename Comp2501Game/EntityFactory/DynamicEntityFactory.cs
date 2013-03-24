using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;
using Comp2501Game.Objects.Components.Physics;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Objects.Components.EntityProperties;
using Comp2501Game.Objects.Components.Health_Components;

namespace Comp2501Game.EntityFactory
{
    static class DynamicEntityFactory
    {
        public static GameObject BuildPlayerControlledEntity(
            Game1 game,
            int playerNumber,
            Color playerColor,
            Vector2 position,
            float rotation,
            Vector2 scale,
            float maxSpeed,
            SpriteType spriteType,
            List<Shape> boundingBoxes,
            Dictionary<ActionDefinition, ActionInfo> actionsInformationList)
        {
            GameObject entity = DynamicEntityFactory.BuildDynamicEntity(game, position, rotation, scale, maxSpeed, spriteType, boundingBoxes);

            PlayerComponent playerComponent = new PlayerComponent(entity, playerNumber);
            HealthComponent healthComponent = new HealthComponent(entity);
            ColorComponent colorComponent = new ColorComponent(entity, playerColor);

            CurrentActionComponent curActionComponent = (CurrentActionComponent)entity.GetComponent(ComponentType.Action);
            curActionComponent.SetActionInfoList(actionsInformationList);

            entity.AddComponent(playerComponent);
            entity.AddComponent(healthComponent);
            entity.AddComponent(colorComponent);

            return entity;
        }

        public static GameObject BuildDynamicEntity(
            Game1 game,
            Vector2 position,
            float rotation,
            Vector2 scale,
            float maxSpeed,
            SpriteType spriteType,
            List<Shape> boundingBoxes)
        {
            GameObject entity = new GameObject(game);

            
            Transform2DComponent transformComponent = new Transform2DComponent(
                entity,
                position,
                rotation,
                scale);
            SpriteComponent sprite = new SpriteComponent(entity, spriteType, game);
            BoundingBoxComponent bbComponent = new BoundingBoxComponent(entity, boundingBoxes, true);
            CurrentActionComponent caComponent = new CurrentActionComponent(
                entity, 
                new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None),
                new Dictionary<ActionDefinition, ActionInfo>());
            GravityComponent gravComponent = new GravityComponent(entity, 1.0f);
            MotionPropertiesComponent motionComponent = new MotionPropertiesComponent(entity, 1.0f, maxSpeed);
            IsPhysicalComponent isPhysicalComponent = new IsPhysicalComponent(entity, true);
            IsCharacterComponent isCharComponent = new IsCharacterComponent(entity);
            SoundComponent soundComponent = new SoundComponent(entity);
            ArrowComponent arrowComponent = new ArrowComponent(entity);

            
            entity.AddComponent(transformComponent);
            entity.AddComponent(sprite);
            entity.AddComponent(bbComponent);
            entity.AddComponent(caComponent);
            entity.AddComponent(gravComponent);
            entity.AddComponent(motionComponent);
            entity.AddComponent(isPhysicalComponent);
            entity.AddComponent(isCharComponent);
            entity.AddComponent(soundComponent);
            entity.AddComponent(arrowComponent);
            return entity;
        }

        public static GameObject BuildActionProjectile(
            Game1 game,
            GameObject parent,
            ActionInfo actInfo,
            Vector2 position,
            Vector2 velocity,
            int lifetime,
            List<Shape> boundingBoxes)
        {
            GameObject entity = new GameObject(game);
            entity.SetParent(parent);

            Transform2DComponent transformComponent = new Transform2DComponent(
                entity,
                position,
                0.0f,
                Vector2.One);

            BoundingBoxComponent bbComponent = new BoundingBoxComponent(entity, boundingBoxes, true);
            CurrentActionComponent caComponent = new CurrentActionComponent(
                entity,
                new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None),
                new Dictionary<ActionDefinition, ActionInfo>());
            LifetimeComponent lifetimeComponent = new LifetimeComponent(entity, lifetime);
            IsActionComponent isActionComponent = new IsActionComponent(entity, actInfo);
            MotionPropertiesComponent motionComponent = new MotionPropertiesComponent(entity, 1.0f);
            motionComponent.SetVelocity(velocity);

            entity.AddComponent(transformComponent);
            entity.AddComponent(bbComponent);
            entity.AddComponent(caComponent);
            entity.AddComponent(motionComponent);
            entity.AddComponent(lifetimeComponent);
            entity.AddComponent(isActionComponent);

            return entity;
        }
    }
}
