using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.Systems.Renderer
{
    class LinebatchMeshRenderSystem : GameSystem
    {
        private SpriteBatch _spriteBatch;

        public LinebatchMeshRenderSystem(Game1 game)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Transform2D);
            this._componentDependencies.Add(ComponentType.Mesh);
            this._componentDependencies.Add(ComponentType.Color);
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this._game.GraphicsDevice);
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            this._spriteBatch.Begin();
            foreach (GameObject obj in this._objects)
            {
                Transform2DComponent transformComponent = (Transform2DComponent)obj.GetComponent(ComponentType.Transform2D);
                MeshComponent meshComponent = (MeshComponent)obj.GetComponent(ComponentType.Mesh);
                ColorComponent colorComponent = (ColorComponent)obj.GetComponent(ComponentType.Color);
                List<Vector2> transformedVertices = LinearFunctions.GetTransformedVertices(
                    meshComponent.Vertices, 
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

            this._spriteBatch.End();
            base.Update(gameTime);
        }

        public override SystemType GetType()
        {
            return SystemType.Renderer;
        }
    }
}
