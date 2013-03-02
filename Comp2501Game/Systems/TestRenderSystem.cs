using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems
{
    class TestRenderSystem : GameSystem
    {
        private Texture2D _rectTex;
        private Game1 _game;
        private SpriteBatch _spriteBatch;

        public TestRenderSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._game = game;
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this._rectTex = new Texture2D(this.Game.GraphicsDevice, 1, 1);
            this._rectTex.SetData(new Color[] { Color.White });
        }

        public override void Update(GameTime gameTime)
        {
            this._spriteBatch.Begin();

            foreach (GameObject obj in this._objects)
            {
                PositionComponent posComponent = (PositionComponent)obj.GetComponent(ComponentType.Position);

                if (posComponent != null)
                {
                    this._spriteBatch.Draw(
                        this._rectTex, 
                        new Rectangle((int)posComponent.Position.X, (int)posComponent.Position.Y, 100, 100), 
                        Color.White);
                }
            }

            this._spriteBatch.End();
        }

        public override SystemType GetType()
        {
            return SystemType.Renderer;
        }
    }
}
