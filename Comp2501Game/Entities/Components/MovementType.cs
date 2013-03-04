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
        Left_Walk, 
        Left_Flying, // the character has been hit
        Left_Landing,
        Left_Fall,
        Left_Fall_Fast,
        Left_Grab,

        Right_Stand,
        Right_Walk,
        Right_Flying,
        Right_Landing,
        Right_Fall,
        Right_Fall_Fast,
        Right_Grab,

        Left_Jump,
        Left_Jump_Back_A,
        Left_Jump_Forward_A,
        Left_Jump_Up_A,
        Left_Jump_Down_A,

        Right_Jump,
        Right_Jump_Back_A,
        Right_Jump_Forward_A,
        Right_Jump_Up_A,
        Right_Jump_Down_A,

        Left_A,
        Left_Forward_A,
        Left_Up_A,
        Left_Down_A,

        Right_A,
        Right_Forward_A,
        Right_Up_A,
        Right_Down_A,

        Left_Smash_Forward_A,
        Left_Smash_Up_A,
        Left_Smash_Down_A,
        
        Right_Smash_Forward_A,
        Right_Smash_Down_A,
        Right_Smash_Up_A,

        Right_B,
        Right_Up_B,
        Right_Down_B,
            
        Left_B,
        Left_Up_B,
        Left_Down_B,
    }
}
