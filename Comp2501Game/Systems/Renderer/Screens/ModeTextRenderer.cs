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
    class ModeTextRenderer : GameSystem
    {
        private Game1 _game;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

         public ModeTextRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Text);
            this._game = game;
        }

         public override void Initialize()
         {
             this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
             this._spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont2");
             //base.Initialize();
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


        public override void Update(GameTime gameTime)
        {
            this.setupRenderingState();

            this._spriteBatch.Begin();

            foreach (GameObject obj in this._objects)
            {
                VisibleTextComponent textComponent = (VisibleTextComponent)obj.GetComponent(ComponentType.Text);

                _spriteBatch.DrawString(_spriteFont, textComponent.modeString, textComponent.position1, Color.White);

                if (textComponent.modeString == "TIMED")
                {
                    _spriteBatch.DrawString(_spriteFont, textComponent.timeOrLifeVal + " Mins", textComponent.position2, Color.White);
                }
                else
                {
                    _spriteBatch.DrawString(_spriteFont, textComponent.timeOrLifeVal + " Lives", textComponent.position2, Color.White);
                }

                //MouseState mouseState = Mouse.GetState();
                //_spriteBatch.DrawString(_spriteFont, mouseState.X + " + " + mouseState.Y, new Vector2(20, 20), Color.Black);
            }


            this._spriteBatch.End();
        }
    }
}
