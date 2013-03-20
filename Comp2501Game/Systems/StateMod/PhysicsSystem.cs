using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Physics;

namespace Comp2501Game.Systems.StateMod
{
    class PhysicsSystem : GameSystem
    {
        public float GravityForce;

        public PhysicsSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.MotionProperties);
            this.GravityForce = 300.0f;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                MotionPropertiesComponent motionComponent = (MotionPropertiesComponent)obj.GetComponent(ComponentType.MotionProperties);

                if (obj.HasComponent(ComponentType.Gravity))
                {
                    GravityComponent gravComponent = (GravityComponent)obj.GetComponent(ComponentType.Gravity);

                    motionComponent.AddForce(
                        new Vector2(
                            0.0f, 
                            this.GravityForce * gravComponent.StrengthFactor
                    ));
                }

                this.resolveForces(motionComponent, gameTime.ElapsedGameTime.Milliseconds);
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        private void resolveForces(MotionPropertiesComponent motionComponent, int timestep)
        {
            motionComponent.AccelerationVector = 
                motionComponent.AggregateForcesVector / motionComponent.Mass;
            motionComponent.VelocityVector += 
                motionComponent.AccelerationVector * timestep / 1000.0f;
        }
    }
}
