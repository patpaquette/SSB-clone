using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems
{
    class AABBCollisionRenderSystem : GameSystem
    {
        private LineParametric _xAxis;
        private LineParametric _yAxis;
        private SpriteBatch _spriteBatch;
        private Texture2D _whiteTex;
        private Rectangle _destRect;
        private Vector2 _windowCenter;

        public AABBCollisionRenderSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Position);
            this._componentDependencies.Add(ComponentType.AABBCollision);
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
                PositionComponent posComponent = (PositionComponent)obj.GetComponent(ComponentType.Position);
                AABBCollisionComponent colComponent = (AABBCollisionComponent)obj.GetComponent(ComponentType.AABBCollision);
                ColorComponent colorComponent = (ColorComponent)obj.GetComponent(ComponentType.Color);
                Boolean aCollisionObj = true;

                if (colComponent == null)
                {
                    aCollisionObj = false;
                }


                if (aCollisionObj)
                {
                    List<AABB> collisionBoxes = colComponent.CollisionBoxes;

                    foreach (AABB box in collisionBoxes)
                    {
                        Vector2 position = posComponent.Position + box.Position;
                        List<Vector2> vertices = new List<Vector2>();
                        vertices.Add(position);
                        vertices.Add(position + new Vector2(box.Width, 0.0f));
                        vertices.Add(position + new Vector2(0.0f, box.Height));
                        vertices.Add(position + new Vector2(box.Width, box.Height));
                        SegmentParametric proj1 = LibFunc.GetParametricProjection(this._xAxis, vertices);
                        SegmentParametric proj2 = LibFunc.GetParametricProjection(this._yAxis, vertices);

                        Color color = colorComponent.Color;
                        if (box.Collided)
                        {
                            color = Color.Green;
                        }
                        LibFunc.DrawEmptyRect(this._spriteBatch, position, box.Width, box.Height, color);

                        LineBatch.DrawLine(
                            this._spriteBatch,
                            colorComponent.Color,
                            proj1.GetSegmentVec2().P1,
                            proj1.GetSegmentVec2().P2);

                        LineBatch.DrawLine(
                            this._spriteBatch,
                            colorComponent.Color,
                            proj2.GetSegmentVec2().P1,
                            proj2.GetSegmentVec2().P2);

                    }
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
