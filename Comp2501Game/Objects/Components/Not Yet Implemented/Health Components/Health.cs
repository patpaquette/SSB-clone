using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Comp2501Game.Objects.Components.Health_Components
{
    class HealthComponent : ObjectComponent
    {
        public float currentDmg;  

        //constructor sets damage taken to 0
        public HealthComponent(GameObject parent)
            : base(parent)
        {
            this.currentDmg = 0.0f;
        }

        //returns float value of characters currentDmg
        public float getCurrDmg()
        {
            return this.currentDmg;
        }

//        public void addDamage(float inDmg)
//        {
//            this.currentDmg += inDmg;
//       }

        public override ComponentType GetType()
        {
            return ComponentType.Health;
        }

    }
}
