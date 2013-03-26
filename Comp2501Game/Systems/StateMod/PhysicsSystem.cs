using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Physics;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Systems.Collisions;

namespace Comp2501Game.Systems.StateMod
{
    class PhysicsSystem : GameSystem
    {
        public float GravityForce;

        public PhysicsSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.MotionProperties);
            this._componentDependencies.Add(ComponentType.Transform2D);
            this.GravityForce = 300.0f;
        }

        public override void Initialize()
        {
            CollisionSystem.PhysicalCollision += new CollisionHandler(this.handleCollision);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                MotionPropertiesComponent motionComponent = 
                    (MotionPropertiesComponent)obj.GetComponent(ComponentType.MotionProperties);
                Transform2DComponent transformComponent =
                        (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);

                if (obj.HasComponent(ComponentType.Gravity))
                {
                    GravityComponent gravComponent = 
                        (GravityComponent)obj.GetComponent(ComponentType.Gravity);
                    

                    motionComponent.AddForce(
                        new Vector2(
                            0.0f, 
                            this.GravityForce * gravComponent.StrengthFactor
                    ));
                }

                this.resolveVelocity(
                    motionComponent, 
                    gameTime.ElapsedGameTime.Milliseconds
                );

                motionComponent.ResetForces();
            }

            ((CollisionSystem)this._game.GetService("Collision")).CheckCollisions(CollisionType.Physical, gameTime);
            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private void resolveVelocity(MotionPropertiesComponent motionComponent, int timestep)
        {
            motionComponent.AccelerationVector = 
                motionComponent.AggregateForcesVector / motionComponent.Mass;
            motionComponent.AddVelocity(
                motionComponent.AccelerationVector * timestep / 1000.0f
            );
        }

        private void handleCollision(CollisionInfo colInfo, float timestep)
        {
            GameObject obj1 = colInfo.Entity1;
            GameObject obj2 = colInfo.Entity2;
            Vector2 normal = colInfo.Normal;
            float depth = colInfo.Depth;

            if (!obj1.HasComponent(ComponentType.MotionProperties)) return;
            if (!obj1.HasComponent(ComponentType.Transform2D)) return;
            if (!obj1.HasComponent(ComponentType.BoundingBox)) return;
            if (!obj2.HasComponent(ComponentType.Transform2D)) return;
            if (!obj2.HasComponent(ComponentType.BoundingBox)) return;

            MotionPropertiesComponent obj1MotionComponent =
                (MotionPropertiesComponent)obj1.GetComponent(ComponentType.MotionProperties);
            Transform2DComponent obj1TransformComponent =
                (Transform2DComponent)obj1.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj1BoundingBoxComponent =
                (BoundingBoxComponent)obj1.GetComponent(ComponentType.BoundingBox);
            CurrentActionComponent obj1CurActionComponent =
                (CurrentActionComponent)obj1.GetComponent(ComponentType.Action);
            Transform2DComponent obj2TransformComponent =
                (Transform2DComponent)obj2.GetComponent(ComponentType.Transform2D);
            BoundingBoxComponent obj2BoundingBoxComponent =
                (BoundingBoxComponent)obj2.GetComponent(ComponentType.BoundingBox);

            //velocity correction
            Vector2 obj2obj1_vector = obj2TransformComponent.GetTranslation() - obj1TransformComponent.GetTranslation();
            obj2obj1_vector.Normalize();

            if (Vector2.Dot(normal, obj2obj1_vector) > 0)
            {
                normal = normal * -1;
            }

            Vector2 velocityCorrection = normal * depth * (float)(1.0f / timestep);

            if (obj2.HasComponent(ComponentType.MotionProperties))
            {
                MotionPropertiesComponent obj2MotionComponent =
                    (MotionPropertiesComponent)obj2.GetComponent(ComponentType.MotionProperties);
                obj1MotionComponent.AddVelocity(velocityCorrection);

            }
            else
            {
                obj1MotionComponent.AddVelocity(velocityCorrection);
            }

            if (velocityCorrection.Y != 0.0f)
            {
                obj1MotionComponent.State = MotionState.Ground;
                if (obj1CurActionComponent != null &&
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Smash && 
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Shield &&
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Walk &&
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Throw &&
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Grabbed &&
                    obj1CurActionComponent.curAction.secondaryAction != SecondaryAction.Grab)
                {
                    obj1CurActionComponent.curAction.primaryAction = PrimaryAction.None;
                    obj1CurActionComponent.curAction.secondaryAction = SecondaryAction.Stand;
                }
            }
            else
            {
                obj1MotionComponent.State = MotionState.Air;
            }

            //friction
            if(obj2.HasComponent(ComponentType.PhysicalProperties))
            {
                PhysicalPropertiesComponent obj2PhysicalPropertiesComponent = 
                    (PhysicalPropertiesComponent)obj2.GetComponent(ComponentType.PhysicalProperties);
                
                Vector2 velocity = obj1MotionComponent.GetVelocity();
                float velocityX = velocity.X / Math.Abs(velocity.X);
                if (float.IsNaN(velocityX)) velocityX = 0;
                float frictionCoefficient = obj2PhysicalPropertiesComponent.Friction * velocityX * -1.0f;

                if (velocityX != 0)
                {
                    float velocityXBuffer = obj1MotionComponent.GetVelocity().X;
                    obj1MotionComponent.AddVelocity(new Vector2(frictionCoefficient * timestep, 0.0f));

                    if (velocityXBuffer * obj1MotionComponent.GetVelocity().X < 0)
                    {
                        obj1MotionComponent.SetVelocity(
                            new Vector2(0.0f, obj1MotionComponent.GetVelocity().Y));
                    }
                }
            }



        }
    }
}
