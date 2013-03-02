using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;

namespace Comp2501Game.Objects.Components
{
    class TimerComponent : ObjectComponent
    {
        public int startCount;
        public int endCount;
        public String displayValue;
        public Boolean isActive;
        public Boolean isComplete;

        //constructor
        public TimerComponent()
        {
            this.startCount = -97;
            this.endCount = -97;
            this.displayValue = "None";
            this.isActive = false;
            this.isComplete = false;
        }
           
        public override ComponentType GetType()
        {
            return ComponentType.Timers;
        }

    }
}
