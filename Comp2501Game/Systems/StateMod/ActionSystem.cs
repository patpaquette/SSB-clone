﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Objects.Components.Actions;
using Comp2501Game.Systems.Collisions;
using Comp2501Game.EntityFactory;
using Microsoft.Xna.Framework;
using Comp2501Game.Libs.Geometry;
using Comp2501Game.Objects.Components.Health_Components;
using Comp2501Game.Objects.Components.Physics;

namespace Comp2501Game.Systems.StateMod
{
    class ActionSystem : GameSystem
    {
        public ActionSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Action);
        }

        public override void Initialize()
        {
            CollisionSystem.ActionCollision += new CollisionHandler(this.actionHitHandler);
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            List<GameObject> objsToAdd = new List<GameObject>();

            foreach (GameObject obj in this._objects)
            {
                CurrentActionComponent curActionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                curActionComponent.Timing -= gameTime.ElapsedGameTime.Milliseconds;

                if (!curActionComponent.curAction.GetDefinition().Equals(curActionComponent.LastActionDef))
                {
                    curActionComponent.InProgress = false;
                }

                if (curActionComponent.InProgress == false && curActionComponent.Timing <= 0)
                {   
                    curActionComponent.InProgress = true;

                    if (curActionComponent.GetActionInfo().GetType() == ActionType.AttackProjectile)
                    {
                        ActionInfoProjectile actInfo = (ActionInfoProjectile)curActionComponent.GetActionInfo();
                        curActionComponent.Timing = actInfo.Timing;

                        objsToAdd.Add(
                            DynamicEntityFactory.BuildActionProjectile(
                                this._game,
                                obj,
                                actInfo,
                                Vector2.Zero,
                                actInfo.Velocity,
                                actInfo.Lifetime,
                                new List<Shape>{
                                    Shape.BuildRectangle(actInfo.BoundingBoxRect)
                                }
                            )
                        );
                    }
                }
            }

            foreach (GameObject obj in objsToAdd)
            {
                this._game.AddObject(obj);
            }

            ((CollisionSystem)this._game.GetService("Collision")).CheckCollisions(CollisionType.Action, gameTime);

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private void actionHitHandler(CollisionInfo colInfo, float timestep)
        {
            GameObject obj1 = colInfo.Entity1;
            GameObject obj2 = colInfo.Entity2;
            GameObject obj1Parent = obj1.GetParent();

            if (!obj1.HasComponent(ComponentType.IsAction)) return;
            if (!obj2.HasComponent(ComponentType.IsCharacter)) return;
            if (!obj2.HasComponent(ComponentType.Health)) return;
            if (!obj2.HasComponent(ComponentType.MotionProperties)) return;

            IsActionComponent obj1ActionComponent = (IsActionComponent)obj1.GetComponent(ComponentType.IsAction);
            LifetimeComponent obj1LifetimeComponent = (LifetimeComponent)obj1.GetComponent(ComponentType.Lifetime);
            HealthComponent obj2HealthComponent = (HealthComponent)obj2.GetComponent(ComponentType.Health);
            MotionPropertiesComponent obj2MotionComponent = (MotionPropertiesComponent)obj2.GetComponent(ComponentType.MotionProperties);
            ActionInfoProjectile actionInfo = (ActionInfoProjectile)obj1ActionComponent.ActionInfo;

            obj2HealthComponent.AddDmg(actionInfo.OnHitDamage);
            Vector2 forceFinal = actionInfo.OnHitForce * obj2HealthComponent.getCurrDmg() / obj2MotionComponent.Mass;
            obj2MotionComponent.AddVelocity(forceFinal);
            obj1LifetimeComponent.Lifetime = 0;

            if (obj1Parent != null)
            {
                CurrentActionComponent obj1ParentCurAction =
                    (CurrentActionComponent)obj1Parent.GetComponent(ComponentType.Action);
            }
            
        }
    }
}
