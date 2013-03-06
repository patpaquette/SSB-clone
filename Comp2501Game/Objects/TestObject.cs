using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects
{
    using Components;
    using Comp2501Game.Objects.Components.CollisionComponents;
    using Comp2501Game.Libs.Geometry;

    class TestObject : GameObject
    {
        public TestObject(
            Game1 game, 
            Vector2 position, 
            int width, 
            int height, 
            Color color, 
            int playerNumber, 
            bool active)
            : base(game)
        {
            Transform2DComponent transformComponent = new Transform2DComponent(
                this, 
                position, 
                0.0f, 
                new Vector2(1.0f));
            List<AABB> collisionBoxes = new List<AABB>();
            Vector2 v1 = new Vector2(-10, 10);
            Vector2 v2 = new Vector2(10, 10);
            Vector2 v3 = new Vector2(10, -10);
            Vector2 v4 = new Vector2(-10, -10);
            List<Vector2> vertices = new List<Vector2>();
            vertices.Add(v1);
            vertices.Add(v2);
            vertices.Add(v3);
            vertices.Add(v4);

            this.AddComponent(transformComponent);
            this.AddComponent(new BoundingBoxComponent(this, new Shape(vertices), active));
                
            this.AddComponent(new ColorComponent(this, color));
            this.AddComponent(new PlayerComponent(this, playerNumber));
        }
    }
}
