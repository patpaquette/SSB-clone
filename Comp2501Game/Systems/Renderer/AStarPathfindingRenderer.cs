using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Objects.Components.AI.Pathfinding;
using Comp2501Game.Systems.AI.Pathfinding;

namespace Comp2501Game.Systems.Renderer
{
    class AStarPathfindingRenderer : GameSystem
    {
        private Rectangle _nodeRect;
        private SpriteBatch _spriteBatch;
        private Texture2D _texturePurple;
        private Texture2D _textureGreen;

        public AStarPathfindingRenderer(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.AStarGraph);
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this._game.GraphicsDevice);
            this._nodeRect = new Rectangle(-10, -10, 20, 20);
            this._texturePurple = new Texture2D(this._game.GraphicsDevice, 1, 1);
            this._texturePurple.SetData<Color>(new Color[]{Color.Purple});
            this._textureGreen = new Texture2D(this._game.GraphicsDevice, 1, 1);
            this._textureGreen.SetData<Color>(new Color[] { Color.Green });
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this._spriteBatch.Begin();
            
            foreach (GameObject obj in this._objects)
            {
                AStarGraphComponent aStarGraphComponent =
                    (AStarGraphComponent)obj.GetComponent(ComponentType.AStarGraph);

                foreach (AStarNode node in aStarGraphComponent.Graph.Nodes)
                {
                    Rectangle destRect = new Rectangle(
                        this._nodeRect.X + (int)node.GetPosition().X,
                        this._nodeRect.Y + (int)node.GetPosition().Y,
                        this._nodeRect.Width,
                        this._nodeRect.Height
                    );

                    this._spriteBatch.Draw(this._texturePurple, destRect, Color.White);
                }
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
