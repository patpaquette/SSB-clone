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
            PositionComponent posComponent = new PositionComponent(this, position);
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

            this.AddComponent(posComponent);
            this.AddComponent(new BoundingBoxComponent(this, new Shape(vertices), active));
                
            this.AddComponent(new ColorComponent(this, color));
            this.AddComponent(new PlayerComponent(this, playerNumber));
        }
    }
}
