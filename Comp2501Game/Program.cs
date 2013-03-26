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
using Comp2501Game.Systems.AI.Pathfinding;
using Comp2501Game.Objects.Components.AI.Pathfinding;
using Comp2501Game.Systems.AI;
using Comp2501Game.Objects.Components.AI;
using Comp2501Game.Objects.Screens;
using Comp2501Game.Screens;

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


                //GameScreen gameScreen = new GameScreen(game, SpriteType.Yoshi, SpriteType.Yoshi);
                StartScreen startScreen = new StartScreen(game);
                //CharacterSelectScreen selectScreen = new CharacterSelectScreen(game);

                //EnvironmentFactory envFactory = new EnvironmentFactory(game);
                //Rectangle clientBounds = game.Window.ClientBounds;

                
                
                ////game.RegisterSystem(new PlayerInputSystem(game, 1));
                ////game.RegisterSystem(new TimerSystem(game));
                ////game.RegisterSystem(new TimerRenderSystem(game));
                
    /*
                int spriteInitSystemID = game.RegisterSystem(new SpriteInitializationSystem(game, 1));
                //int arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 1));
                int controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 1));
                int inputSystemID = game.RegisterSystem(new InputSystem(game, 1));
                int AISystemID = game.RegisterSystem(new AISystem(game));
                int animationSystemID = game.RegisterSystem(new AnimationSystem(game, 1));
                int movementSystemID = game.RegisterSystem(new MovementSystem(game, 1));
                int actionSystemID = game.RegisterSystem(new ActionSystem(game));
                int physicsSystemID = game.RegisterSystem(new PhysicsSystem(game));
                int boundsSystemID = game.RegisterSystem(new BoundsSystem(game));
                int meshRendererID = game.RegisterSystem(new LinebatchMeshRenderSystem(game));
                int collisionRendererID = game.RegisterSystem(new CollisionRenderSystem(game));
                int spriteRendererID = game.RegisterSystem(new SpriteRenderer(game));
                int uiRendererID = game.RegisterSystem(new UIRenderer(game));
                int aStarRendererID = game.RegisterSystem(new AStarPathfindingRenderer(game));
                int transformResolverID = game.RegisterSystem(new PhysicsTransformResolverSystem(game));
                int lifetimeSystemID = game.RegisterSystem(new LifetimeSystem(game));
                int aStarPathRendererID = game.RegisterSystem(new AStarPathRenderer(game));

                //services
                int collisionSystemID = game.RegisterSystem(new SATCollisionSystem(game, "Collision"));
                int aStarServiceID = game.RegisterSystem(new AStarPathfindingSystem(game, "Pathfinding", 50));

                game.SetSystemCallOrder(new List<int>
                {
                    spriteInitSystemID,
                    //arrowInputSystemID,
                    controllerInputSystemID,
                    AISystemID,
                    inputSystemID,
                    animationSystemID,
                    movementSystemID,
                    actionSystemID,
                    physicsSystemID,
                    collisionSystemID,
                    transformResolverID,
                    boundsSystemID,
                    lifetimeSystemID,
                    //physicsSystemID,
                    meshRendererID,
                    collisionRendererID,
                    spriteRendererID,
                    uiRendererID,
                    aStarRendererID,
                    aStarPathRendererID
                });
                //game.AddObject(
                //  new PlayerObject(game, 1, Objects.Components.SpriteType.Yoshi));
                GameObject yoshi = DynamicEntityFactory.BuildPlayerControlledEntity(
                    game,
                    1,
                    Color.Green,
                    new Vector2(100, 0),
                    0.0f,
                    new Vector2(1.0f, 1.0f),
                    300,
                    10000,
                    SpriteType.Yoshi,
                    new List<Shape>
                        {
                            Shape.BuildRectangle(new Rectangle(-55, -60, 90, 60)),
                            Shape.BuildRectangle(new Rectangle(-40, 0, 120, 60)),
                            Shape.BuildRectangle(new Rectangle(25, 60, 40, 30))
                        },
                    MoveDefinitions.GetYoshiMoves()
                );
                game.AddObject(yoshi);

                GameObject kirby = DynamicEntityFactory.BuildComputerControlledEntity(
                    game,
                    Color.Pink,
                    new Vector2(500, 0),
                    0.0f,
                    new Vector2(1.0f, 1.0f),
                    300,
                    10000,
                    SpriteType.Kirby,
                    new List<Shape>
                        {
                            Shape.BuildRectangle(new Rectangle(-60, -60, 110, 110))
                        },
                    MoveDefinitions.GetYoshiMoves(),
                    yoshi
                );
                //kirby.AddComponent(new AStarComponent(kirby));
                //kirby.AddComponent(new AIControllerComponent(kirby));
                //kirby.AddComponent(new LifetimeComponent(kirby, 5000));
                //kirby.SetParent(yoshi);
                game.AddObject(kirby);
                
                
                //game.AddObject(new TestObject(game, new Vector2(300, 300), 100, 100, Color.Red, 1, true));
                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(clientBounds.Width / 2, clientBounds.Height),
                    new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width, 20),
                    1000.0f,
                    Color.Red));
                game.AddObject(new TimeObject(game, new Vector2 (0, 0), Color.Black));

                AStarPathfindingSystem pathfinding = (AStarPathfindingSystem)game.GetService("Pathfinding");
                AStarNode node1 = new AStarNode(new Vector2(clientBounds.Width / 2, clientBounds.Height - 50));
                AStarNode node2 = new AStarNode(new Vector2(clientBounds.Width / 2 + 200, clientBounds.Height - 50));
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
                AStarGraph graph = new AStarGraph(game, new List<AStarNode> { node1, node2 });
                GameObject graphEntity = new GameObject(game);
                graphEntity.AddComponent(new AStarGraphComponent(graphEntity, graph));
                game.AddObject(graphEntity);
                game.CurrentPathfindingGraph = graph;

                game.Character1 = yoshi;
                game.Character2 = kirby;
    (/
                game.Run();
            }
        }
    }
#endif
}

