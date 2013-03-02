using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects
{
    using Components;

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
            PositionComponent posComponent = new PositionComponent(position);
            List<AABB> collisionBoxes = new List<AABB>();
            collisionBoxes.Add(new AABB(posComponent, new Vector2(0.0f, -height/2.0f), (int)(width/1.5), height));
            collisionBoxes.Add(new AABB(posComponent, new Vector2(width/6.0f, height / 2.0f), width / 4, height));
            collisionBoxes.Add(new AABB(posComponent, new Vector2(width/3.0f, -height / 4.0f), width, height / 4));

            this.AddComponent(posComponent);
            if (playerNumber == 1)
            {
                this.AddComponent(new AABBCollisionComponent(active, new List<AABB>() { new AABB(posComponent, new Vector2(0.0f, -height / 2.0f), (int)(width / 1.5), height) }));
            }
            else
            {
                this.AddComponent(new AABBCollisionComponent(active, collisionBoxes));
            }
            
            this.AddComponent(new ColorComponent(color));
            this.AddComponent(new PlayerComponent(playerNumber));
        }
    }
}
