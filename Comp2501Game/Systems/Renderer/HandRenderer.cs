using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Comp2501Game.Types;
using Comp2501Game.Objects.Screens;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems.Renderer
{
    class HandRenderer : GameSystem
    {
        private Game1 _game;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        public HandRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Hand);
            this._componentDependencies.Add(ComponentType.Player);
            this._game = game;
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this._spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont1");
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
                HandComponent handcomponent = (HandComponent)obj.GetComponent(ComponentType.Hand);
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);

                int yOffSet;

                if (playerComponent.PlayerNumber == 1)
                {
                    yOffSet = 0;
                }
                else
                {
                    yOffSet = 200;
                }

                Rectangle sourceFrame = new Rectangle(0,
                        yOffSet,
                        200, 200);

                this._spriteBatch.Draw(handcomponent.button, handcomponent.position, sourceFrame, Color.White, 0.0f, new Vector2(100.0f, 100.0f),
                        new Vector2(1.0f, 1.0f), SpriteEffects.None, 1.0f);
                if (playerComponent.PlayerNumber == 1)
                {
                    if (handcomponent.position.Y > 50 && handcomponent.position.X > 25 && handcomponent.position.Y < 340 && handcomponent.position.X < 535)
                    {
                        this._game.play1 = SpriteType.Kirby;
                    }
                    else if (handcomponent.position.Y > 400 && handcomponent.position.X > 600 && handcomponent.position.Y < 725 && handcomponent.position.X < 1135)
                    {
                        this._game.play1 = SpriteType.Yoshi;
                    }
                    else
                    {
                        this._game.play1 = SpriteType.None;
                    }
                    //_spriteBatch.DrawString(_spriteFont, handcomponent.position.Y + " + " + handcomponent.position.X, new Vector2(20, 20), Color.Black);
                }
                else if (playerComponent.PlayerNumber == 2)
                {
                    if (handcomponent.position.Y > 50 && handcomponent.position.X > 25 && handcomponent.position.Y < 340 && handcomponent.position.X < 535)
                    {
                        this._game.play2 = SpriteType.Kirby;
                    }
                    else if (handcomponent.position.Y > 400 && handcomponent.position.X > 600 && handcomponent.position.Y < 725 && handcomponent.position.X < 1135)
                    {
                        this._game.play2 = SpriteType.Yoshi;
                    }
                    else
                    {
                        this._game.play2 = SpriteType.None;
                    }
                }

                if (this._game.play1 != SpriteType.None && this._game.play2 != SpriteType.None) 
                {
                    KeyboardState state = Keyboard.GetState();
                    GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

                    if (state.IsKeyDown(Keys.S) || gamePadState.IsButtonDown(Buttons.Start)) 
                    {
                        this._game.curScreen = ScreenType.Game;
                        this._game.RemoveAllSystems();
                        this._game.RemoveAllObjects();
                        GameScreen gameScreen = new GameScreen(this._game, this._game.play1, this._game.play2);
                        //CharacterSelectScreen selectScreen = new CharacterSelectScreen(this._game);
                        this._game.LoadScene();
                    }
                }

            }

            this._spriteBatch.End();

        }
    }
}
