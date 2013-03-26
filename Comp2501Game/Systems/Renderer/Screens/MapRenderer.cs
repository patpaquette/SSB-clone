using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems.Renderer
{
    class MapRenderer : GameSystem
    {
        private SpriteBatch _spriteBatch;

        public MapRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Map);
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
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
