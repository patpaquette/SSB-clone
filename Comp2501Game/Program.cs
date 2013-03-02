using Comp2501Game.Systems;
using System;
using Comp2501Game.Objects;
using Microsoft.Xna.Framework;

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

                //game.RegisterSystem(new TestRenderSystem(game));
                game.RegisterSystem(new AABBCollisionRenderSystem(game));
                game.RegisterSystem(new PlayerInputSystem(game, 1));
                game.RegisterSystem(new AABBCollisionSystem(game));
                game.RegisterSystem(new TimerSystem(game));
                game.RegisterSystem(new TimerRenderSystem(game));
                game.AddObject(
                    new TestObject(
                        game, 
                        new Vector2(300, 300),
                        100,
                        100,
                        new Color(1.0f, 0.0f, 0.0f, 1.0f),
                        1,
                        true));
                game.AddObject(
                    new TestObject(
                        game,
                        new Vector2(600, 300),
                        100,
                        100,
                        new Color(0.0f, 0.0f, 1.0f, 0.2f),
                        2,
                        false));
                game.AddObject(new TimeObject(game, new Vector2 (0, 0), Color.Black));

                game.Run();
            }
        }
    }
#endif
}

