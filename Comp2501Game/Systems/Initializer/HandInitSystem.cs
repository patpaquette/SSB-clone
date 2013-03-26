using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems.Physics.Initializer
{
    class HandInitSystem : GameSystem
    {
         public HandInitSystem(Game1 game)
            : base (game)
        {
            this._componentDependencies.Add(ComponentType.Hand);
        }

         public override SystemType GetType()
         {
             return SystemType.Initializer;
         }

         public override void Initialize()
         {
             foreach (GameObject obj in this._objects)
             {
                 HandComponent hand = (HandComponent)obj.GetComponent(ComponentType.Hand);

                 hand.button = this.Game.Content.Load<Texture2D>(@"Images/SelectionBalls"); 
             }
         }
    }
}
