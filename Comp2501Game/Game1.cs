using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Comp2501Game.Systems;
using Comp2501Game.Systems.AI.Pathfinding;

namespace Comp2501Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public AStarGraph CurrentPathfindingGraph;
        public GameObject Character1;
        public GameObject Character2;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D[] yoshiSpriteSheets;
        List<GameSystem> _systems;
        List<GameObject> _objects;
        Dictionary<string, GameSystem> _services;
        List<int> _systemsCallOrder;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this._systems = new List<GameSystem>();
            this._objects = new List<GameObject>();
            this._services = new Dictionary<string, GameSystem>();
            this._systemsCallOrder = new List<int>();
            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 800;
            this.graphics.ApplyChanges();
            this.CurrentPathfindingGraph = new AStarGraph(this, new List<AStarNode>());
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            LineBatch.Init(this.GraphicsDevice);

            foreach (GameSystem system in this._systems)
            {
                system.Initialize();
            }

            foreach (GameObject obj in this._objects)
            {
                obj.Initialize();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            yoshiSpriteSheets = new Texture2D[4];
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            yoshiSpriteSheets[0] = Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet1");
            yoshiSpriteSheets[1] = Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet2");
            yoshiSpriteSheets[2] = Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet3");
            yoshiSpriteSheets[3] = Content.Load<Texture2D>(@"Images/Yoshi_Sprite_Sheet4");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            /*
            foreach (GameSystem system in this._systems)
            {
                if (system.GetType() == SystemType.StateModifier)
                {
                    system.Update(gameTime);
                }
            }*/

            foreach (int systemID in this._systemsCallOrder)
            {
                if (this._systems[systemID].GetType() == SystemType.StateModifier)
                {
                    this._systems[systemID].Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*foreach (GameSystem system in this._systems)
            {
                if (system.GetType() == SystemType.Renderer)
                {
                    system.Update(gameTime);
                }
            }*/

            foreach (int systemID in this._systemsCallOrder)
            {
                if (this._systems[systemID].GetType() == SystemType.Renderer)
                {
                    this._systems[systemID].Update(gameTime);
                }
            }

            base.Draw(gameTime);
        }

        //Registers a system to the game
        //Update calls will be in the registration order
        public int RegisterSystem(GameSystem system)
        {
            this._systems.Add(system);

            if (system.GetType() == SystemType.Service)
            {
                this._services.Add(system.GetName(), system);
            }

            foreach (GameObject obj in this._objects)
            {
                system.TryRegisterObject(obj);
            }

            return this._systems.Count - 1;
        }

        public GameSystem GetService(string name)
        {
            if (this._services.ContainsKey(name))
            {
                return this._services[name];
            }

            return null;
        }

        public void RemoveObject(GameObject obj)
        {
            foreach (GameSystem system in this._systems)
            {
                system.UnregisterObject(obj);
            }
        }

        public void SetSystemCallOrder(List<int> order)
        {
            this._systemsCallOrder = order;
        }

        public void AddObject(GameObject obj)
        {
            this._objects.Add(obj);

            foreach (GameSystem system in this._systems)
            {
                system.TryRegisterObject(obj);
            }
        }
    }
}
