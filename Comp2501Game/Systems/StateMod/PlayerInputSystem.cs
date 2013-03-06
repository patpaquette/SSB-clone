using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems
{
    class PlayerInputSystem : GameSystem
    {
        public int PlayerNumber;

        public PlayerInputSystem(Game1 game, int playerNumber)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.Player);
            this.PlayerNumber = playerNumber;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (GameObject obj in this._objects)
            {
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                Transform2DComponent transform2DComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                float positionStep = 1.0f;

                if (playerComponent.PlayerNumber == this.PlayerNumber)
                {
                    if (state.IsKeyDown(Keys.Up))
                    {
                        transform2DComponent.AddTranslation(new Vector2(0.0f, -positionStep));
                    }
                    else if (state.IsKeyDown(Keys.Up) && state.IsKeyDown(Keys.Right))
                    {
                        transform2DComponent.AddTranslation(new Vector2(-positionStep, -positionStep));
                    }
                    else if (state.IsKeyDown(Keys.Down))
                    {
                        transform2DComponent.AddTranslation(new Vector2(0.0f, positionStep));
                    }
                    else if (state.IsKeyDown(Keys.Left))
                    {
                        transform2DComponent.AddTranslation(new Vector2(-positionStep, 0.0f));
                    }
                    else if (state.IsKeyDown(Keys.Right))
                    {
                        transform2DComponent.AddTranslation(new Vector2(positionStep, 0.0f));
                    }
                    if (state.IsKeyDown(Keys.Escape))
                    {
                        this.Game.Exit();
                    }
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
