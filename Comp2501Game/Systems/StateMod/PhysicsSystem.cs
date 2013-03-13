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
            this._componentDependencies.Add(ComponentType.Transform2D);
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
                Transform2DComponent transformComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                if (obj.HasComponent(ComponentType.Gravity))
                {
                    GravityComponent gravComponent = (GravityComponent)obj.GetComponent(ComponentType.Gravity);
                    transformComponent.AddTranslation(
                        new Vector2(
                            0.0f, 
                            gameTime.ElapsedGameTime.Milliseconds * this.GravityForce * gravComponent.StrengthFactor / 1000.0f));
                    
                }
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
