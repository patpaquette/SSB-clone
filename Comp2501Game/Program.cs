using Comp2501Game.Systems;
using System;
using Comp2501Game.Objects;
using Microsoft.Xna.Framework;
using Comp2501Game.Systems.Collisions;
using Comp2501Game.Systems.Renderer;
using Comp2501Game.EntityFactory;
using Comp2501Game.Systems.StateMod;

namespace Comp2501Game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                EnvironmentFactory envFactory = new EnvironmentFactory(game);
                Rectangle clientBounds = game.Window.ClientBounds;

                //game.RegisterSystem(new TestRenderSystem(game));
                //game.RegisterSystem(new AABBCollisionRenderSystem(game));
                game.RegisterSystem(new PlayerInputSystem(game, 1));
                //game.RegisterSystem(new AABBCollisionSystem(game));
                //game.RegisterSystem(new SATCollisionSystem(game));
                //game.RegisterSystem(new CollisionRenderSystem(game));
                //game.RegisterSystem(new TimerSystem(game));
                //game.RegisterSystem(new TimerRenderSystem(game));
                //game.RegisterSystem(new LinebatchMeshRenderSystem(game));
                game.RegisterSystem(new PlayerInputSystem(game, 1));
                game.RegisterSystem(new MovementSystem(game, 1));
                game.RegisterSystem(new SpriteRenderer(game));
                game.RegisterSystem(new AnimationSystem(game, 1));
                game.AddObject(
                    new PlayerObject(game, new Vector2(800, 500), 0.0f, new Vector2(0,0), 1, Objects.Components.SpriteType.Yoshi));
                game.RegisterSystem(new SpriteInitializationSystem(game, 1));
               // game.AddObject(
               //     new TestObject(
               //         game,
               //         new Vector2(600, 300),
               //         100,
              //          100,
                //        new Color(0.0f, 0.0f, 1.0f, 0.2f),
                  //      2,
                    //    false));
               // game.AddObject(envFactory.BuildStaticRectangularObstacle(
               //     new Vector2(clientBounds.Width / 2, 450),
               //     new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width, 20),
                //    Color.Red));
                game.AddObject(new TimeObject(game, new Vector2 (0, 0), Color.Black));

                game.Run();
            }
        }
    }
#endif
}

