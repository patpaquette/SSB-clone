using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Comp2501Game.Objects.Components.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems.StateMod
{
    class SelectInputSystem : GameSystem
    {
        public int playerNum;

        public SelectInputSystem(Game1 game, int num)
            : base (game)
        {
            this._componentDependencies.Add(ComponentType.Player);
            this._componentDependencies.Add(ComponentType.Hand);
            this._componentDependencies.Add(ComponentType.Arrow);
            this.playerNum = num;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in this._objects)
            {
                //Console.WriteLine("here2");
                PlayerComponent playerComponent = (PlayerComponent)obj.GetComponent(ComponentType.Player);
                HandComponent handComponent = (HandComponent)obj.GetComponent(ComponentType.Hand);
                ArrowComponent arrowComponent = (ArrowComponent)obj.GetComponent(ComponentType.Arrow);

                if (this.playerNum == playerComponent.PlayerNumber)
                {
                    if (arrowComponent.arrowKey == ArrowType.Up)
                    {
                        handComponent.position.Y -= 5;
                    }
                    else if (arrowComponent.arrowKey == ArrowType.Down)
                    {
                        handComponent.position.Y += 5;
                    }
                    else if (arrowComponent.arrowKey == ArrowType.Left)
                    {
                        handComponent.position.X -= 5;
                    }
                    else if (arrowComponent.arrowKey == ArrowType.Right)
                    {
                        handComponent.position.X += 5;
                    }
                    
                }
            }
        }



        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }
    }
}
