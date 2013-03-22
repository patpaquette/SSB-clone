using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.Physics;

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

                transformComponent.AddTranslation(
                    motionComponent.GetVelocity() * gameTime.ElapsedGameTime.Milliseconds / 1000.0f
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
