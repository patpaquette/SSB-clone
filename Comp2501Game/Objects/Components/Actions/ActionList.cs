using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Actions
{
    class ActionList
    {
        public ActionComponent [] actionList;

        public ActionList()
        {
            actionList = new ActionComponent [102];

            actionList [0] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.None);
            actionList [1] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.A);
            actionList [2] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.B);
            actionList [3] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Forward_A); // same as above
            actionList [4] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Up_B);
            actionList [5] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Stand, PrimaryAction.Down_B);
            actionList [6] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Forward_A);
            actionList [7] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Up_A);
            actionList [8] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Smash, PrimaryAction.Down_A);
            actionList [9] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Jump, PrimaryAction.None);
            actionList [10] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.None);
            actionList [11] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Walk, PrimaryAction.Forward_A);
            actionList [12] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.None);
            actionList [13] =  new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Left);
            actionList [14] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Roll_Right);
            actionList [15] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Right);
            actionList [16] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Flying, PrimaryAction.Left);
            actionList [17] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Above);
            actionList [18] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Below);
            actionList [19] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Front);
            actionList [20] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Hit, PrimaryAction.Behind);
            actionList [21] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Fall_Faster);
            actionList [22] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.None);
            actionList [23] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_A);
            actionList [24] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Up_B);
            actionList [25] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_A);
            actionList [26] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Down_B);
            actionList [27] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Forward_A);
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            actionList [28] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.A);
            actionList [29] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.B);
            actionList [30] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Jump, PrimaryAction.None);
            actionList [31] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster);
            actionList [32] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.None);
            actionList [33] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_A);
            actionList [34] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Up_B);
            actionList [35] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_A);
            actionList [36] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Down_B);
            actionList [37] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Forward_A);
            //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            actionList [38] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.A);
            actionList [39] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.B);
            actionList [40] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Above);
            actionList [41] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Below);
            actionList [42] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Front);
            actionList [43] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Hit, PrimaryAction.Behind);
            actionList [44] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Right);
            actionList [45] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Flying, PrimaryAction.Left);

            actionList [46] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.None);
            actionList [47] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.A);
            actionList [48] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.B);
            actionList [49] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Forward_A); // same as above
            actionList [50] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Up_B);
            actionList [51] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Stand, PrimaryAction.Down_B);
            actionList[52] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Forward_A);
            actionList [53] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Up_A);
            actionList [54] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Smash, PrimaryAction.Down_A);
            actionList [55] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Jump, PrimaryAction.None);
            actionList [56] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.None);
            actionList [57] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Walk, PrimaryAction.Forward_A);
            actionList [58] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.None);
            actionList [59] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Left);
            actionList [60] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Roll_Right);
            actionList [61] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Right);
            actionList [62] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Flying, PrimaryAction.Left);
            actionList [63] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Above);
            actionList [64] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Below);
            actionList [65] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Front);
            actionList [66] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Hit, PrimaryAction.Behind);
            actionList [67] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Fall_Faster);
            actionList [68] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.None);
            actionList [69] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_A);
            actionList [70] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Up_B);
            actionList [71] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_A);
            actionList [72] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Down_B);
            actionList [73] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Forward_A);
            //TODO  spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            actionList [74] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.A);
            actionList [75] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.B);
            actionList [76] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Jump, PrimaryAction.None);
            actionList [77] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Fall_Faster);
            actionList [78] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.None);
            actionList [79] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_A);
            actionList [80] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Up_B);
            actionList [81] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_A);
            actionList [82] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Down_B);
            actionList [83] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Forward_A);
            //spriteComponent.animationFrameWork.Add(new CurrentActionComponent (obj, DirectionalAction.Left, SecondaryAction.Second_Falling , PrimaryAction.Backward_A), new AnimationDirectory( , , ));
            actionList [84] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.A);
            actionList [85] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.B);
            actionList [86] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Above);
            actionList [87] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Below);
            actionList [88] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Front);
            actionList [89] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Hit, PrimaryAction.Behind);
            actionList [90] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Right);
            actionList [91] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Flying, PrimaryAction.Left);
            
            
            actionList[92] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Shield, PrimaryAction.Grab);
            actionList[93] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Shield, PrimaryAction.Grab);

            actionList[94] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Drift_Left);
            actionList[95] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Falling, PrimaryAction.Drift_Right);
            actionList[96] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Drift_Left);
            actionList[97] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Falling, PrimaryAction.Drift_Right);

            actionList[98] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Drift_Left);
            actionList[99] = new ActionComponent(DirectionalAction.Left, SecondaryAction.Second_Falling, PrimaryAction.Drift_Right);
            actionList[100] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Drift_Left);
            actionList[101] = new ActionComponent(DirectionalAction.Right, SecondaryAction.Second_Falling, PrimaryAction.Drift_Right);
        }

        public int findAction(ActionComponent action)
        {
            int index = 0;
            for (int i = 0; i < actionList.Length; i++)
            {
                if (action.curDirection == actionList[i].curDirection
                    && action.secondaryAction == actionList[i].secondaryAction
                    && action.primaryAction == actionList[i].primaryAction)
                {
                    break;
                }
                index++;
            }

            return index;
        }
    }
}
