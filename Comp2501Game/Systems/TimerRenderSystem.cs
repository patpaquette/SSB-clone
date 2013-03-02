using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Systems
{
    class TimerRenderSystem : GameSystem 
    {
        private SpriteFont _spriteFont;
        private SpriteBatch _spriteBatch;
        private Vector2 _windowCenter;

        //construcotr, addign components
        public TimerRenderSystem(Game1 game)
            : base(game)
        {
            this.Game.Content.RootDirectory = "Comp2501GameContent";
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.Timers);
            this._componentDependencies.Add(ComponentType.Color);
        }

        //creaitng the time renderer system
        //initializing variables
        public override void Initialize()
        {
            //this._windowCenter = new Vector2(this.Game.Window.ClientBounds.Width, this.Game.Window.ClientBounds.Height);
            this._windowCenter = new Vector2(10, 10);
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);

            _spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont1");

            base.Initialize();
        }
        
        //updating the screen i hope to god
        public override void Update(GameTime gameTime)
        {
            this._spriteBatch.Begin();

            foreach (GameObject obj in this._objects)
            {
                PositionComponent posComponent = (PositionComponent)obj.GetComponent(ComponentType.Position);
                TimerComponent timeComponent = (TimerComponent)obj.GetComponent(ComponentType.Timers);
                ColorComponent colorComponent = (ColorComponent)obj.GetComponent(ComponentType.Color);
                Boolean aTimeObj = true;

                if (timeComponent == null)
                {
                    aTimeObj = false;
                }


                if (aTimeObj)
                {
                    _spriteBatch.DrawString(_spriteFont, timeComponent.displayValue, _windowCenter, colorComponent.Color);
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
