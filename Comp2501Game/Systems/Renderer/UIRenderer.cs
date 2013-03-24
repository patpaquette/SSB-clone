using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.Health_Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.Renderer
{
    class UIRenderer : GameSystem
    {
        private SpriteFont _spriteFont;
        private SpriteBatch _spriteBatch;
        private Vector2 _healthOffset;
        private int _healthWidth;

        public UIRenderer(Game1 game)
            : base(game)
        {
            this._healthOffset = new Vector2(100.0f, 40.0f);
            this._healthWidth = 300;
            this._componentDependencies.Add(ComponentType.Health);
            this._componentDependencies.Add(ComponentType.Color);
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this._game.GraphicsDevice);
            this._spriteFont = this._game.Content.Load<SpriteFont>("SpriteFont1");
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            int counter = 0;

            this._spriteBatch.Begin();
            foreach (GameObject obj in this._objects)
            {
                HealthComponent healthComponent = (HealthComponent)obj.GetComponent(ComponentType.Health);
                ColorComponent colorComponent = (ColorComponent)obj.GetComponent(ComponentType.Color);

                this._spriteBatch.DrawString(this._spriteFont, healthComponent.getCurrDmg().ToString(), new Vector2(counter * this._healthWidth + this._healthOffset.X, this._healthOffset.Y), colorComponent.Color);

                counter++;
            }
            this._spriteBatch.End();

            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.Renderer;
        }
    }
}
