using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components;
using Comp2501Game.Objects.Components.CollisionComponents;
using Comp2501Game.Libs.Geometry;

namespace Comp2501Game.EntityFactory
{
    public class EnvironmentFactory
    {
        private Game1 _game;

        public EnvironmentFactory(Game1 game)
        {
            this._game = game;
        }

        public GameObject BuildStaticRectangularObstacle(Vector2 translation, Rectangle rect, Color color)
        {
            GameObject obstacle = new GameObject(this._game);

            List<Vector2> vertices = new List<Vector2>();

            vertices.Add(new Vector2(rect.Left, rect.Top));
            vertices.Add(new Vector2(rect.Right, rect.Top));
            vertices.Add(new Vector2(rect.Right, rect.Bottom));
            vertices.Add(new Vector2(rect.Left, rect.Bottom));

            Transform2DComponent transformComponent = new Transform2DComponent(
                obstacle, 
                translation, 
                0.0f, 
                new Vector2(1.0f, 1.0f));
            MeshComponent meshComponent = new MeshComponent(obstacle, vertices);
            ColorComponent colorComponent = new ColorComponent(obstacle, color);
            BoundingBoxComponent boundingBoxComponent = new BoundingBoxComponent(
                obstacle, 
                new List<Shape>{
                    new Shape(vertices)
                }, 
                false); 

            obstacle.AddComponent(transformComponent);
            obstacle.AddComponent(meshComponent);
            obstacle.AddComponent(colorComponent);
            obstacle.AddComponent(boundingBoxComponent);

            return obstacle;
        }
    }
}
