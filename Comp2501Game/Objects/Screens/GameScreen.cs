using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Comp2501Game.EntityFactory;
using Comp2501Game.Systems;
using Comp2501Game.Systems.StateMod;
using Comp2501Game.Systems.Collisions;
using Comp2501Game.Systems.Renderer;
using Comp2501Game.Objects.Components;
using Comp2501Game.Libs.Geometry;
using Comp2501Game.Systems.AI;
using Comp2501Game.Systems.AI.Pathfinding;
using Comp2501Game.Objects.Components.AI.Pathfinding;
using Comp2501Game.Systems.Physics.Initializer;
using Comp2501Game.Objects.Components.Types;
using Comp2501Game.Systems.Initializer;

namespace Comp2501Game.Objects.Screens
{
    class GameScreen
    {
        private Game1 _game;

        EnvironmentFactory envFactory;
        Rectangle clientBounds;


        GameObject p1, p2;

        //game.RegisterSystem(new PlayerInputSystem(game, 1));
        //game.RegisterSystem(new TimerSystem(game));
        //game.RegisterSystem(new TimerRenderSystem(game));

        int spriteInitSystemID1;
        int spriteInitSystemID2;
        int arrowInputSystemID;
        int controllerInputSystemID;
        int inputSystemID1;
        int inputSystemID2;
        int animationSystemID1;
        int animationSystemID2;
        int movementSystemID1;
        int movementSystemID2;
        int actionSystemID;
        int physicsSystemID;
        int boundsSystemID;
        int collisionSystemID;
        int meshRendererID;
        int collisionRendererID;
        int spriteRendererID;
        int uiRendererID;
        int transformResolverID;
        int lifetimeSystemID;
        int mapRendererID;
        int mapInitSystemID;
        int songInitSystemID;
        int songSystemID;


        public GameScreen(Game1 game, SpriteType player1, SpriteType player2)
        {
            game.IsMouseVisible = true;

            this.envFactory = new EnvironmentFactory(game);
            this.clientBounds = game.Window.ClientBounds;
            mapInitSystemID = game.RegisterSystem(new ScreenInitializationSystem(game));
            spriteInitSystemID1 = game.RegisterSystem(new SpriteInitializationSystem(game, 1));
            spriteInitSystemID2 = game.RegisterSystem(new SpriteInitializationSystem(game, 2));
            songInitSystemID = game.RegisterSystem(new SongInitializer(game));
            arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 2));
            controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 1));
            inputSystemID1 = game.RegisterSystem(new InputSystem(game, 1));
            inputSystemID2 = game.RegisterSystem(new InputSystem(game, 2));
            animationSystemID1 = game.RegisterSystem(new AnimationSystem(game, 1));
            animationSystemID2 = game.RegisterSystem(new AnimationSystem(game, 2));
            movementSystemID1 = game.RegisterSystem(new MovementSystem(game, 1));
            movementSystemID2 = game.RegisterSystem(new MovementSystem(game, 2));
            actionSystemID = game.RegisterSystem(new ActionSystem(game));
            physicsSystemID = game.RegisterSystem(new PhysicsSystem(game));
            boundsSystemID = game.RegisterSystem(new BoundsSystem(game));
            meshRendererID = game.RegisterSystem(new LinebatchMeshRenderSystem(game));
            collisionRendererID = game.RegisterSystem(new CollisionRenderSystem(game));
            mapRendererID = game.RegisterSystem(new MapRenderer(game));
            spriteRendererID = game.RegisterSystem(new SpriteRenderer(game));
            uiRendererID = game.RegisterSystem(new UIRenderer(game));
            transformResolverID = game.RegisterSystem(new PhysicsTransformResolverSystem(game));
            lifetimeSystemID = game.RegisterSystem(new LifetimeSystem(game));
            int aStarPathRendererID = game.RegisterSystem(new AStarPathRenderer(game));
            int aStarRendererID = game.RegisterSystem(new AStarPathfindingRenderer(game));
            int aiSystemID = game.RegisterSystem(new AISystem(game));
            songSystemID = game.RegisterSystem(new MusicSystem(game));

            //services
            int collisionSystemID = game.RegisterSystem(new SATCollisionSystem(game, "Collision"));
            int aStarServiceID = game.RegisterSystem(new AStarPathfindingSystem(game, "Pathfinding", 50));

            game.SetSystemCallOrder(new List<int>
                {
                    this.mapInitSystemID,
                    this.spriteInitSystemID1,
                    this.spriteInitSystemID2,
                    this.songInitSystemID,
                    this.arrowInputSystemID,
                    this.controllerInputSystemID,
                    aiSystemID,
                    this.inputSystemID1,
                    this.inputSystemID2,
                    this.animationSystemID1,
                    this.animationSystemID2,
                    this.movementSystemID1,
                    this.movementSystemID2,
                    this.actionSystemID,
                    this.physicsSystemID,
                    this.transformResolverID,
                    this.boundsSystemID,
                    this.lifetimeSystemID,
                    //this.physicsSystemID,
                    this.meshRendererID,
                    this.mapRendererID,
                    this.collisionRendererID,
                    this.spriteRendererID,
                    this.uiRendererID,
                    aStarRendererID,
                    aStarPathRendererID,
                    songSystemID
                });
            if (player1 == SpriteType.Yoshi)
            {
                this.p1 = DynamicEntityFactory.BuildPlayerControlledEntity(
                     game,
                     1,
                     Color.Green,
                     new Vector2(100, 0),
                     0.0f,
                     new Vector2(1.0f, 1.0f),
                     400,
                     1000,
                     SpriteType.Yoshi,
                     new List<Shape>
                            {
                                //Shape.BuildRectangle(new Rectangle(-55, -60, 90, 60)),
                                Shape.BuildRectangle(new Rectangle(-40, 0, 120, 60)),
                                Shape.BuildRectangle(new Rectangle(25, 60, 40, 30))
                            },
                     MoveDefinitions.GetYoshiMoves()
                 );
            }
            else
            {
                this.p1 = DynamicEntityFactory.BuildPlayerControlledEntity(
                    game,
                    1,
                    Color.Green,
                    new Vector2(100, 0),
                    0.0f,
                    new Vector2(1.0f, 1.0f),
                    300,
                    1000,
                    SpriteType.Kirby,
                    new List<Shape>
                        {
                            Shape.BuildRectangle(new Rectangle(-60, -60, 110, 110))
                        },
                    MoveDefinitions.GetKirbyMoves()
                );

                //kirby.AddComponent(new LifetimeComponent(kirby, 5000));
                //kirby.SetParent(yoshi);
            }

            game.AddObject(p1);



            if (player2 == SpriteType.Yoshi)
            {
                this.p2 = DynamicEntityFactory.BuildPlayerControlledEntity(
                     game,
                     2,
                     Color.Pink,
                     new Vector2(800, 0),
                     0.0f,
                     new Vector2(1.0f, 1.0f),
                     400,
                     500,
                     SpriteType.Yoshi,
                     new List<Shape>
                            {
                                //Shape.BuildRectangle(new Rectangle(-55, -60, 90, 60)),
                                Shape.BuildRectangle(new Rectangle(-40, 0, 120, 60)),
                                Shape.BuildRectangle(new Rectangle(25, 60, 40, 30))
                            },
                     MoveDefinitions.GetYoshiMoves()
                 );
            }
            else
            {
                
                this.p2 = DynamicEntityFactory.BuildPlayerControlledEntity(
                    game,
                    2,
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
                    MoveDefinitions.GetKirbyMoves()
                );

                //this.p2 = DynamicEntityFactory.BuildComputerControlledEntity(
                //    game,
                //    2,
                //    Color.Pink,
                //    new Vector2(800, 0),
                //    0.0f,
                //    new Vector2(1.0f, 1.0f),
                //    250,
                //    500,
                //    SpriteType.Kirby,
                //    new List<Shape>
                //        {
                //            Shape.BuildRectangle(new Rectangle(-60, -60, 110, 110))
                //        },
                //    MoveDefinitions.GetYoshiMoves(),
                //    this.p1
                //);
            }

            game.AddObject(p2);


            if (game.mapType == MapType.Basic)
            {
                game.AddObject(new TextObject2(game, MapType.Basic));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(403, 347),
                    new Rectangle(0, -10, -378, -36),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(1173, 498),
                    new Rectangle(0, -10, -380, -37),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(1165, 119),
                    new Rectangle(0, -10, -530, -39),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(1050, 662),
                    new Rectangle(0, -10, -927, -1),
                    2000.0f,
                    Color.Red));

                game.AddObject(new SongObject(game, MapType.Basic));
            }
            else
            {
                game.AddObject(new TextObject2(game, MapType.Hyrule));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(303, 500),
                    new Rectangle(0, -10, -10, -120),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(302, 515),
                    new Rectangle(0, -10, -140, -10),
                    2000.0f,
                    Color.Red));


                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(815, 400),
                    new Rectangle(0, -10, -516, -10),
                    2000.0f,
                    Color.Red));

                //game.AddObject(envFactory.BuildStaticRectangularObstacle(
                //    new Vector2(704, 330),
                //    new Rectangle(0, -10, -109, -10),
                //    2000.0f,
                //    Color.Red));

                //game.AddObject(envFactory.BuildStaticRectangularObstacle(
                //    new Vector2(757, 223),
                //    new Rectangle(0, -10, -107, -10),
                //    2000.0f,
                //    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(1064, 521),
                    new Rectangle(0, -10, -250, -10),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(818, 510),
                    new Rectangle(0, -10, -10, -130),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(174, 800),
                    new Rectangle(0, -10, -10, -300),
                    2000.0f,
                    Color.Red));

                game.AddObject(envFactory.BuildStaticRectangularObstacle(
                    new Vector2(1066, 810),
                    new Rectangle(0, -10, -10, -306),
                    2000.0f,
                    Color.Red));

                game.AddObject(new SongObject(game, MapType.Hyrule));
            }


            //game.AddObject(envFactory.BuildStaticRectangularObstacle(
            //    new Vector2(clientBounds.Width / 2, clientBounds.Height),
            //    new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width, 20),
            //    2000.0f,
            //    Color.Red));

            //game.AddObject(envFactory.BuildStaticRectangularObstacle(
            //    new Vector2(clientBounds.Width / 2, clientBounds.Height / 3 * 2),
            //    new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width / 2, 20),
            //    2000.0f,
            //    Color.Red));


            game.AddObject(new TimeObject(game, new Vector2(0, 0), Color.Black));

            AStarPathfindingSystem pathfinding = (AStarPathfindingSystem)game.GetService("Pathfinding");
            AStarNode node1 = new AStarNode(new Vector2(clientBounds.Width / 2, clientBounds.Height - 50));
            AStarNode node2 = new AStarNode(new Vector2(clientBounds.Width / 2 + 200, clientBounds.Height - 50), true);
            AStarNode node3 = new AStarNode(new Vector2(clientBounds.Width / 2, clientBounds.Height - 300));
            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
            node2.AddNeighbor(node3);
            node3.AddNeighbor(node2);
            AStarGraph graph = new AStarGraph(game, new List<AStarNode> { node1, node2, node3 });
            GameObject graphEntity = new GameObject(game);
            graphEntity.AddComponent(new AStarGraphComponent(graphEntity, graph));
            game.AddObject(graphEntity);
            game.CurrentPathfindingGraph = graph;

            game.Character1 = this.p1;
            game.Character2 = this.p2;
        }
    }
}
