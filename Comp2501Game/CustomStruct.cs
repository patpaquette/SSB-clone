using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Comp2501Game
{
    public struct SegmentVec2
    {
        Vector2 P1;
        Vector2 P2;

        public SegmentVec2(Vector2 p1, Vector2 p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }
    }

    public class LineVecForm
    {

        Vector2 NormalizedVector;
    }

}
