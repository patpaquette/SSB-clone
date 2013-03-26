using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Comp2501Game.Systems.StateMod.screens
{
    class MouseInputsystem : GameSystem
    {
        private bool wasPressed;

        public MouseInputsystem(Game1 game)
            : base(game)
        {
            this.wasPressed = false;
        }

        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

                if (mouseState.LeftButton.Equals(ButtonState.Pressed))
                {
                    this.wasPressed = true;
                }

                if (mouseState.LeftButton.Equals(ButtonState.Released) && this.wasPressed)
                {

                }
        
        }
    }
}
