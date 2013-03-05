using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{


    public enum DirectionalAction
    {
        Left,
        Right
    }

    public enum SecondaryAction
    {
        Walk,
        Jump, // a large distinction here has to be made during a Jump action movement may not be made its only the aciton of jumping attack and studd
        //may be used during the falling phase, (though you may still be rising only the act (going thorugh the jumping frames) is included here) immediatly after jumping you enter 
        //a controllable 'Fall'
            //Jump can be though of as a Primary Action from Standing
        Hit,
        Second_Jump,
        Stand,
        Smash,
        Shield,
        Falling,
        Second_Falling, //falling after seocnd jump
        Flying, //jsut been hit yet to recover
        Second_Flying, // same as flying jsut with no jumps left (used both already or used a jump after being hit and has not touched gorund)
        Thrown_Object,
        Second_Hit,
        Landing
    }

    public enum PrimaryAction
    {
        None,

        Up_A,
        Down_A,
        Backward_A,
        Forward_A,
        A,

        Up_B,
        Down_B,
        B,

        Roll_Left,
        Roll_Right,

        Drift_Left,
        Drift_Right,
        Fall_Faster,

        Grab,

        Above,
        Below,
        Behind,
        Front, 

        Left,
        Right
    }

    public enum Drift
    {
        Left,
        Right,
        None
    }
}
