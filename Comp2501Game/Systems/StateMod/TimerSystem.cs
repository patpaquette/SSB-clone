using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comp2501Game.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Comp2501Game.Systems
{
    class TimerSystem : GameSystem
    {
        private Vector2 _topRightCorner; //spot to draw timer
        private TimerComponent _myTime;  //timer
 //       private SpriteFont _spriteFont;
//        SpriteBatch _spriteBatch;

        //initializes all the components this System needs
       public TimerSystem(Game1 game)
            : base(game)
        {
//            this.Game.Content.RootDirectory = "Comp2501GameContent";
            this._componentDependencies.Add(ComponentType.Timers);
            this._componentDependencies.Add(ComponentType.Position);
        }

        //returns this system is a state modifier
        public override SystemType GetType()
        {
            return SystemType.StateModifier;
        }

        //setTime: GameTime int TimerComponent -> void
        //Purpose: Sets the timer at the start of a game
        public void setTime(GameTime gameTime, int secs, TimerComponent myTime)
        {
            myTime.startCount = gameTime.TotalGameTime.Seconds;
            myTime.endCount = myTime.startCount + secs;
            myTime.isComplete = false;
            myTime.isActive = true;
            myTime.displayValue = "Start";
        }

        //timerView: int -> string
        //purpose: take in the number of seconds left, and returns a string of a proper countown timer
        public string timerView(int timeLeft)
        {
            int mins = 0;

            while (timeLeft >= 60)
            {
                timeLeft -= 60;
                mins++;
            }
            if (timeLeft > 10)
            {
                return (mins.ToString() + ":" + timeLeft.ToString());
            }
            else
            {
                return (mins.ToString() + ":0" + timeLeft.ToString());
            }
        }

        //checkTime: GameTime TimerComponent -> Boolean
        //purpose: checks if the timer has ended
        public Boolean checkTime(GameTime gameTime, TimerComponent myTime)
        {
            //myTime.displayValue = "fuck you";
            if (myTime.isComplete == false)
            {
                //myTime.displayValue = "fuck you";
                //ensuring a second has past
                if (gameTime.TotalGameTime.Seconds > myTime.startCount)
                {
                    myTime.startCount = gameTime.TotalGameTime.Seconds;
                    myTime.endCount = myTime.endCount - 1;
                    myTime.displayValue = timerView(myTime.endCount);
                    //myTime.displayValue = "fuck you";
                    //timer done
                    if (myTime.endCount <= 0)
                    {
                        myTime.endCount = 0;
                        myTime.isComplete = true;
                        myTime.displayValue = "0";
                    }
                }
            }

            return myTime.isComplete;
        }

        //resetTimer: TimerComponent  -> void
        //purpose: resets the timer for future games (possibly opperations)
        public void resetTimer (TimerComponent myTime)
        {
            myTime.startCount = 0;
            myTime.endCount = 0;
            myTime.displayValue = "None";
            myTime.isActive = false;
            myTime.isComplete = false;
        }

        //initialise the view
        //finds top right corner of screen in which to display text
        //initialises timer values
        public override void Initialize()
        {
           // this._topRightCorner = new Vector2(this.Game.Window.ClientBounds.Width - 50, this.Game.Window.ClientBounds.Height - 50);
            this._topRightCorner = new Vector2(20, 20);
            //this._myTime = new TimerComponent();

            base.Initialize();
        }

        //updating the timer
        //this class will have to be updated a bit for actual game implementation, setTime() will have to be called
           //to set the exact amount of time you want in seconds, at the moment it begins a timer set to 4:03 minutes
        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj1 in this._objects)
            {
                //go through all the objects registered to the system
                TimerComponent curTime = (TimerComponent)obj1.GetComponent(ComponentType.Timers);
                Boolean aTimeObj = true;

                if (curTime == null)
                {
                    aTimeObj = false;
                }


                if (aTimeObj)
                {
                    //if the timer is new (yet to be set) set it to 1 min, else check time
                    if (curTime.isActive == false)
                    {
                        setTime(gameTime, this._game.LivesOrTime, curTime);
                    }
                    else
                    {
                        checkTime(gameTime, curTime);
                    }
                }
                //update the 'time'
                //update text
            }
            base.Update(gameTime);
            //render system will update display (create a general one to update sprites/text)
        }
    }
}
