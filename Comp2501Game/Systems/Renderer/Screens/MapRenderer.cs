using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems.Renderer
{
    class MapRenderer : GameSystem
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        Game1 _game;

        public MapRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Map);
            this._game = game;
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this._spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont2");
            //base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            this.setupRenderingState();

            this._spriteBatch.Begin();

            foreach (GameObject obj in this._objects)
            {
                MapComponent mapComponent = (MapComponent)obj.GetComponent(ComponentType.Map);

                Rectangle destRect = new Rectangle(0, 0, this._game.Window.ClientBounds.Width, this._game.Window.ClientBounds.Height);
                this._spriteBatch.Draw(mapComponent.map, destRect, Color.White);

                //this._game.IsMouseVisible = true;
                //MouseState mouseState = Mouse.GetState();
                //_spriteBatch.DrawString(_spriteFont, mouseState.X + " + " + mouseState.Y, new Vector2(20, 20), Color.White);
            }

            this._spriteBatch.End();
        }

        public override SystemType GetType()
        {
            return SystemType.Renderer;
        }

        private void setupRenderingState()
        {
            this._game.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            this._game.GraphicsDevice.DepthStencilState = DepthStencilState.None;
        }

    }
}
