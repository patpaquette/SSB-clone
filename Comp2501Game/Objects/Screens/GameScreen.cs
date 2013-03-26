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


        public GameScreen(Game1 game, SpriteType player1, SpriteType player2)
        {
            this.envFactory = new EnvironmentFactory(game);
            this.clientBounds = game.Window.ClientBounds;

            spriteInitSystemID1 = game.RegisterSystem(new SpriteInitializationSystem(game, 1));
            spriteInitSystemID2 = game.RegisterSystem(new SpriteInitializationSystem(game, 2));
            arrowInputSystemID = game.RegisterSystem(new ArrowInputSystem(game, 1));
            controllerInputSystemID = game.RegisterSystem(new ControllerInputSystem(game, 2));
            inputSystemID1 = game.RegisterSystem(new InputSystem(game, 1));
            inputSystemID2 = game.RegisterSystem(new InputSystem(game, 2));
            animationSystemID1 = game.RegisterSystem(new AnimationSystem(game, 1));
            animationSystemID2 = game.RegisterSystem(new AnimationSystem(game, 2));
            movementSystemID1 = game.RegisterSystem(new MovementSystem(game, 1));
            movementSystemID2 = game.RegisterSystem(new MovementSystem(game, 2));
            actionSystemID = game.RegisterSystem(new ActionSystem(game));
            physicsSystemID = game.RegisterSystem(new PhysicsSystem(game));
            boundsSystemID = game.RegisterSystem(new BoundsSystem(game));
            collisionSystemID = game.RegisterSystem(new SATCollisionSystem(game, "Collision"));
            meshRendererID = game.RegisterSystem(new LinebatchMeshRenderSystem(game));
            collisionRendererID = game.RegisterSystem(new CollisionRenderSystem(game));
            spriteRendererID = game.RegisterSystem(new SpriteRenderer(game));
            uiRendererID = game.RegisterSystem(new UIRenderer(game));
            transformResolverID = game.RegisterSystem(new PhysicsTransformResolverSystem(game));
            lifetimeSystemID = game.RegisterSystem(new LifetimeSystem(game));

            game.SetSystemCallOrder(new List<int>
                {
                    this.spriteInitSystemID1,
                    this.spriteInitSystemID2,
                    this.arrowInputSystemID,
                    this.controllerInputSystemID,
                    this.inputSystemID1,
                    this.inputSystemID2,
                    this.animationSystemID1,
                    this.animationSystemID2,
                    this.movementSystemID1,
                    this.movementSystemID2,
                    this.actionSystemID,
                    this.physicsSystemID,
                    this.collisionSystemID,
                    this.transformResolverID,
                    this.boundsSystemID,
                    this.lifetimeSystemID,
                    //physicsSystemID,
                    this.meshRendererID,
                    this.collisionRendererID,
                    this.spriteRendererID,
                    this.uiRendererID
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
                    10000,
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
                     new Vector2(500, 0),
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

                //kirby.AddComponent(new LifetimeComponent(kirby, 5000));
                //kirby.SetParent(yoshi);
            }

            game.AddObject(p2);





            game.AddObject(envFactory.BuildStaticRectangularObstacle(
                new Vector2(clientBounds.Width / 2, clientBounds.Height),
                new Rectangle(-clientBounds.Width / 2, -10, clientBounds.Width, 20),
                1000.0f,
                Color.Red));

            game.AddObject(new TimeObject(game, new Vector2(0, 0), Color.Black));

            
        }
    }
}
