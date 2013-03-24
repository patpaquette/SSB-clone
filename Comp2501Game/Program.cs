using Comp2501Game.Systems;
using System;
using Comp2501Game.Objects;
using Microsoft.Xna.Framework;
using Comp2501Game.Systems.Collisions;
using Comp2501Game.Systems.Renderer;
using Comp2501Game.EntityFactory;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Objects.Components;
using Comp2501Game.Libs.Geometry;
using System.Collections.Generic;
using Comp2501Game.Objects.Components.Actions;

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

                
                
                //game.RegisterSystem(new PlayerInputSystem(game, 1));
                //game.RegisterSystem(new TimerSystem(game));
                //game.RegisterSystem(new TimerRenderSystem(game));

                int spriteInitSystemID = game.RegisterSystem(new SpriteInitializationSystem(game, 1));
                int inputSystemID = game.RegisterSystem(new InputSystem(game, 1));
                int animationSystemID = game.RegisterSystem(new AnimationSystem(game, 1));
                int movementSystemID = game.RegisterSystem(new MovementSystem(game, 1));
                int actionSystemID = game.RegisterSystem(new ActionSystem(game));
                int physicsSystemID = game.RegisterSystem(new PhysicsSystem(game));
                int collisionSystemID = game.RegisterSystem(new SATCollisionSystem(game));
                int meshRendererID = game.RegisterSystem(new LinebatchMeshRenderSystem(game));
                int collisionRendererID = game.RegisterSystem(new CollisionRenderSystem(game));
                int spriteRendererID = game.RegisterSystem(new SpriteRenderer(game));
                int transformResolverID = game.RegisterSystem(new PhysicsTransformResolverSystem(game));
                int lifetimeSystemID = game.RegisterSystem(new LifetimeSystem(game));

                game.SetSystemCallOrder(new List<int>
                {
                    spriteInitSystemID,
                    inputSystemID,
                    animationSystemID,
                    movementSystemID,
                    actionSystemID,
                    physicsSystemID,
                    collisionSystemID,
                    transformResolverID,
                    lifetimeSystemID,
                    //physicsSystemID,
                    meshRendererID,
                    collisionRendererID,
                    spriteRendererID,
                });
                //game.AddObject(
                //  new PlayerObject(game, 1, Objects.Components.SpriteType.Yoshi));
                GameObject yoshi = DynamicEntityFactory.BuildPlayerControlledEntity(
                    game,
                    1,
                    new Vector2(100, 0),
                    0.0f,
                    new Vector2(1.0f, 1.0f),
                    300,
                    SpriteType.Yoshi,
                    new List<Shape>
                        {
                            Shape.BuildRectangle(new Rectangle(-55, -60, 90, 60)),
                            Shape.BuildRectangle(new Rectangle(-40, 0, 120, 60)),
                            Shape.BuildRectangle(new Rectangle(25, 60, 40, 30))
                        },
                    new Dictionary<ActionDefinition, ActionInfo>()
                    {
                        {
                            new ActionDefinition(
                                DirectionalAction.Left,
                                PrimaryAction.A,
                                SecondaryAction.Stand
                            ),
                            new ActionInfoProjectile(
                                new Vector2(-2000.0f, -2000.0f),
                                100,
                                new Vector2(-500.0f, -500.0f),
                                20,
                                new Rectangle(-25, 80, 50, 50)
                            )
                        },
                         {
                            new ActionDefinition(
                                DirectionalAction.Right,
                                PrimaryAction.A,
                                SecondaryAction.Stand
                            ),
                            new ActionInfoProjectile(
                                new Vector2(2000.0f, -2000.0f),
                                100,
                                new Vector2(500.0f, 500.0f),
                                20,
                                new Rectangle(-25, 80, 50, 50)
                            )
                        }
                    }
                );
                game.AddObject(yoshi);

                GameObject kirby = DynamicEntityFactory.BuildDynamicEntity(
                    game,
                    new Vector2(500, 0),
                    0.0f,
                    new Vector2(1.0f, 1.0f),
                    300,
                    SpriteType.Kirby,
                    new List<Shape>
                        {
                            Shape.BuildRectangle(new Rectangle(-60, -60, 110, 110))
                });

                //kirby.AddComponent(new LifetimeComponent(kirby, 5000));
                //kirby.SetParent(yoshi);
                game.AddObject(kirby);
                
                

                //game.AddObject(new TestObject(game, new Vector2(300, 300), 100, 100, Color.Red, 1, true));
                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(clientBounds.Width / 2, 450),
                    new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width, 20),
                    1000.0f,
                    Color.Red));
                game.AddObject(new TimeObject(game, new Vector2 (0, 0), Color.Black));

                game.Run();
            }
        }
    }
#endif
}

