using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LinkUtilities
    {
        // original game is a 16x16 grid, so link moved along a 8x8 grid
        // i forget if we scaled up the background, lmk in code review if it needs changed
        public static int SnapToGrid(int position, int alignTo = 8)
        {
            int remainder = position % alignTo;
            int halfway = alignTo / 2;

            if (remainder > halfway)
                return alignTo - remainder;
            else
                return -remainder;
        }
    }
}
