using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Systems
{
    public class CollisionRenderSystem : GameSystem
    {
        private LineParametric _xAxis;
        private LineParametric _yAxis;
        private SpriteBatch _spriteBatch;
        private Texture2D _whiteTex;
        private Rectangle _destRect;
        private Vector2 _windowCenter;

        public CollisionRenderSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.BoundingBox);
            this._componentDependencies.Add(ComponentType.Color);
        }

        public override void Initialize()
        {
            this._windowCenter = new Vector2(this.Game.Window.ClientBounds.Width / 2, this.Game.Window.ClientBounds.Height / 2);
            this._xAxis = new LineParametric(this._windowCenter, this._windowCenter + new Vector2(1.0f, 0.0f));
            this._yAxis = new LineParametric(this._windowCenter, this._windowCenter + new Vector2(0.0f, 1.0f));
            this._spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this._whiteTex = new Texture2D(this.Game.GraphicsDevice, 1, 1);
            this._whiteTex.SetData(new Color[] { Color.White });
            this._destRect = new Rectangle();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            this._spriteBatch.Begin();
            this._destRect.X = 0;
            this._destRect.Y = (int)this._windowCenter.Y;
            this._destRect.Width = this.Game.Window.ClientBounds.Width;
            this._destRect.Height = 1;
            this._spriteBatch.Draw(this._whiteTex, this._destRect, Color.White);

            this._destRect.X = (int)this._windowCenter.X;
            this._destRect.Y = 0;
            this._destRect.Width = 1;
            this._destRect.Height = this.Game.Window.ClientBounds.Height;
            this._spriteBatch.Draw(this._whiteTex, this._destRect, Color.White);

            foreach (GameObject obj in this._objects)
            {
                Transform2DComponent transformComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                BoundingBoxComponent colComponent = (BoundingBoxComponent)obj.GetComponent(ComponentType.BoundingBox);
                ColorComponent colorComponent = (ColorComponent)obj.GetComponent(ComponentType.Color);
                Boolean aCollisionObj = true;

                if (colComponent == null)
                {
                    aCollisionObj = false;
                }


                if (aCollisionObj)
                {
                    Color col = colorComponent.Color;

                    if (colComponent.Collided)
                    {
                        col = Color.Green;
                    }

                    List<Vector2> transformedVertices = LinearFunctions.GetTransformedVertices(
                        colComponent.GetShape().GetVertices(),
                        transformComponent.GetTranslation());
                    Vector2 vertexBuffer = transformedVertices[0];

                    for (int i = 1; i < transformedVertices.Count; i++)
                    {
                        Libs.Drawing.DrawLine(
                            vertexBuffer, transformedVertices[i], colorComponent.Color, this._spriteBatch);

                        vertexBuffer = transformedVertices[i];
                    }

                    Libs.Drawing.DrawLine(
                        transformedVertices[0],
                        transformedVertices[transformedVertices.Count - 1],
                        colorComponent.Color,
                        this._spriteBatch);
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
