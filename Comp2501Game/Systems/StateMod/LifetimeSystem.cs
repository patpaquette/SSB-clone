using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;

namespace Comp2501Game.Systems.StateMod
{
    class LifetimeSystem : GameSystem
    {
        public LifetimeSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Lifetime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            List<GameObject> objsToRemove = new List<GameObject>();
            int milliseconds = gameTime.ElapsedGameTime.Milliseconds;

            foreach (GameObject obj in this._objects)
            {
                LifetimeComponent lifetimeComponent =
                    (LifetimeComponent)obj.GetComponent(ComponentType.Lifetime);

                lifetimeComponent.Lifetime -= milliseconds;

                if (lifetimeComponent.Lifetime <= 0)
                {
                    objsToRemove.Add(obj);
                }
            }

            foreach (GameObject obj in objsToRemove)
            {
                this._game.RemoveObject(obj);
            }

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
