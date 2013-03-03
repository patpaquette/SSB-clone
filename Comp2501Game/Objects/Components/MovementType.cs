using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    /// Syntax used
    /// XXX_YYY_ZZZZ_Z
    /// XXX- side character is facing 
    /// YYYY-possible secondary action i.e. Jumping (Optional)
    /// ZZZ_Z- final action/the action actualy being preformed
    /// </summary>

    public enum MovementType
    {
        Left_Stand,
            Left_Smash_Up_A,
            Left_Smash_Down_A,
            Left_Smash_Forward_A,
            Left_A,
            Left_B,
            Left_Up_B,
            Left_Down_B,
            Left_Grab,

        Left_Sheild,
            Left_Sheild_Roll_Right,
            Left_Sheild_Roll_Left,

        Left_Walk,
            Left_Walk_A,
            
        Left_Jump, // has one jump left
            Left_Jump_Up_A,
            Left_Jump_Down_A,
            Left_Jump_Forward_A,
            Left_Jump_Backward_A,
            Left_Jump_Up_B,
            Left_Jump_Down_B,
            Left_Jump_B,
            Left_Jump_A,
            Left_Fall,
            Left_Fall_Fast,
            Left_Drift_Right,
            Left_Drift_Left,


            Left_Second_Jump, //cannot jump anymore
                Left_Second_Jump_Up_A,
                Left_Second_Jump_Down_A,
                Left_Second_Jump_Forward_A,
                Left_Second_Jump_A,
                Left_Second_Jump_Backward_A,
                Left_Second_Jump_B,
                Left_Second_Jump_Down_B,
                Left_Second_Jump_Up_B,
                Left_Second_Jump_Fall,
                Left_Second_Jump_Fall_Fast,
                Left_Second_Jump_Drift_Right,
                Left_Second_Jump_Drift_Left,
        Left_Flying, // flying and has a jump left
        Left_second_Jump_Flying, // flying and has no jumps left

        Right_Stand,
            Right_Smash_Up_A,
            Right_Smash_Down_A,
            Right_Smash_Forward_A,
            Right_A,
            Right_B,
            Right_Up_B,
            Right_Down_B,
            Right_Grab,

        Right_Sheild,
            Right_Sheild_Roll_Right,
            Right_Sheild_Roll_Left,

        Right_Walk,
            Right_Walk_A,

        Right_Jump, // has one jump left
            Right_Jump_Up_A,
            Right_Jump_Down_A,
            Right_Jump_Forward_A,
            Right_Jump_Backward_A,
            Right_Jump_Up_B,
            Right_Jump_Down_B,
            Right_Jump_B,
            Right_Jump_A,
            Right_Fall,
            Right_Fall_Fast,
            Right_Drift_Right,
            Right_Drift_Left,


            Right_Second_Jump, //cannot jump anymore
                Right_Second_Jump_Up_A,
                Right_Second_Jump_Down_A,
                Right_Second_Jump_Forward_A,
                Right_Second_Jump_A,
                Right_Second_Jump_Backward_A,
                Right_Second_Jump_B,
                Right_Second_Jump_Down_B,
                Right_Second_Jump_Up_B,
                Right_Second_Jump_Fall,
                Right_Second_Jump_Fall_Fast,
                Right_Second_Jump_Drift_Right,
                Right_Second_Jump_Drift_Left,

        Right_Flying, // flying and has a jump left
        Right_second_Jump_Flying, // flying and has no jumps left

    }
}
