using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.StateMod
{
    class BoundsSystem : GameSystem
    {
        public BoundsSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.IsCharacter);
            this._componentDependencies.Add(ComponentType.Transform2D);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                Transform2DComponent transformComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);

                Vector3 translation = transformComponent.GetTransform().Translation;

                if (translation.X < 0.0f ||
                    translation.X > this._game.Window.ClientBounds.Width ||
                    translation.Y < 0.0f ||
                    translation.Y > this._game.Window.ClientBounds.Height)
                {
                    transformComponent.SetTransform(
                        Matrix.CreateTranslation(
                            new Vector3(
                                this._game.Window.ClientBounds.Width / 2,
                                100.0f,
                                1.0f
                            )
                    ));
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
