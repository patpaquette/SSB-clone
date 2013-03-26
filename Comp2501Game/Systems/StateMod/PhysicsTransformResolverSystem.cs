using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Physics;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.StateMod
{
    class PhysicsTransformResolverSystem : GameSystem
    {
        public PhysicsTransformResolverSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.MotionProperties);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                Transform2DComponent transformComponent =
                    (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                MotionPropertiesComponent motionComponent =
                    (MotionPropertiesComponent)obj.GetComponent(ComponentType.MotionProperties);

                Vector2 objVelocity = motionComponent.GetVelocity();
                if (objVelocity.Y < 0)
                {
                    motionComponent.State = MotionState.Air;
                }

                if (motionComponent.State == MotionState.Ground)
                {
                    if (objVelocity.Length() > motionComponent.MaxGroundSpeed)
                    {
                        objVelocity = objVelocity * motionComponent.MaxGroundSpeed / objVelocity.Length();
                    }
                }
                else if (motionComponent.State == MotionState.Air)
                {
                    if (objVelocity.Length() > motionComponent.MaxAirSpeed)
                    {
                        objVelocity = objVelocity * motionComponent.MaxAirSpeed / objVelocity.Length();
                    }
                }

                transformComponent.AddTranslation(
                    objVelocity * gameTime.ElapsedGameTime.Milliseconds / 1000.0f
                );
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
