using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems.StateMod
{
    class InputSystem1 : GameSystem
    {
        public int PlayerNumber;
        Dictionary<Keys, int> controls;


        public InputSystem1(Game1 game, int playerNumber)
            : base(game)
        {
            this._componentDependencies.Add(ComponentType.Action);
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Sprite);
            this.PlayerNumber = playerNumber;
            this.controls = new Dictionary<Keys,int>(); 
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A))
            {
                this.controls.Add(Keys.A, 0);
            }
            else if (state.IsKeyDown(Keys.B))
            {
                this.controls.Add(Keys.B, 0);
            }
            else if (state.IsKeyDown(Keys.R))
            {
                this.controls.Add(Keys.R, 0);
            }
            else if (state.IsKeyDown(Keys.Z))
            {
                this.controls.Add(Keys.Z, 0);
            }
            else if (state.IsKeyDown(Keys.Up))
            {
                this.controls.Add(Keys.Up, 0);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.controls.Add(Keys.Down, 0);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.controls.Add(Keys.Left, 0);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.controls.Add(Keys.Right, 0);
            }

            foreach (KeyValuePair<Keys, int> curKeys in this.controls)
            {
                curKeys.Value += gameTime.ElapsedGameTime.Milliseconds;
            }
            
            foreach (GameObject obj in this._objects)
            { 
                //Console.WriteLine("here2");
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                CurrentActionComponent actionComponent = (CurrentActionComponent)obj.GetComponent(ComponentType.Action);
                SpriteComponent spriteComponent = (SpriteComponent)obj.GetComponent(ComponentType.Sprite);

                if (playerComponent.PlayerNumber == this.PlayerNumber)
                {
                }
            }
        }
    }
}
