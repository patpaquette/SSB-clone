using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Actions;

namespace Comp2501Game.Systems.Renderer
{
    class SpriteRenderer : GameSystem
    {
        private Game1 _game;
        private SpriteBatch _spriteBatch;
        private SpriteInitializationSystem _init;

        public SpriteRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.Sprite);
            this._componentDependencies.Add(ComponentType.Action);
            this._game = game;
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
                Transform2DComponent transformComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);

                Rectangle sourceFrame = new Rectangle(spriteComponent.curColumn * 200,
                    (spriteComponent.curRow % 10) * 200,
                    200, 200);
                SpriteEffects directionalFlip = SpriteEffects.None;

                //if (actionComponent.curAction.curDirection == DirectionalAction.Right)
                if (transformComponent.GetScale().X == -1)
                {
                    directionalFlip = SpriteEffects.FlipHorizontally;
                }

                int temp = spriteComponent.curRow;
                //Console.WriteLine((int) Math.Floor(temp / 10.0) + " ");
                this._spriteBatch.Draw(
                    spriteComponent.spriteSheets[(int) Math.Floor(temp / 10.0)],
                    transformComponent.GetTranslation(), 
                    sourceFrame, Color.White,
                    transformComponent.GetRotationDeg(), 
                    new Vector2(100.0f, 100.0f), 
                    new Vector2(1.0f, 1.0f), 
                    directionalFlip, 
                    1.0f); 

            }
            this._spriteBatch.End();

            //base.Update(gameTime);
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
