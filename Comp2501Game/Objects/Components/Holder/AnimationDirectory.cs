using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components
{
    class AnimationDirectory
    {
        public int rowNumber;
        public int numColumns;
        public int attackTimer;

        public AnimationDirectory(int rowNum, int numCol, int attkTime)
        {
            rowNumber = rowNum;
            numColumns = numCol;
            attackTimer = attkTime;
        }
    }
}
