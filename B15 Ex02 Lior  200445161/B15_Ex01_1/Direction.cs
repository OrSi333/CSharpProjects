using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Direction
    {
        public static readonly Direction r_Up = new Direction(-1, 0);
        public static readonly Direction r_Down = new Direction(1, 0);
        public static readonly Direction r_Left = new Direction(0, -1);
        public static readonly Direction r_Right = new Direction(0, 1);
        public static readonly Direction r_UpRight = new Direction(-1, 1);
        public static readonly Direction r_UpLeft = new Direction(-1, -1);
        public static readonly Direction r_DownRight = new Direction(1, 1);
        public static readonly Direction r_DownLeft = new Direction(1, -1);
        public static readonly List<Direction> ALLDIRECTIONS = new List<Direction> { r_Up, r_Down, r_Left, r_Right, r_UpRight, r_UpLeft, r_DownRight, r_DownLeft };

        private int rowDiff;
        private int colDiff;

        public Direction(int i_rowDiff, int i_colDiff)
        {
            rowDiff = i_rowDiff;
            colDiff = i_colDiff;
        }

        public int RowDiff
        {
            get
            {
                return rowDiff;
            }
        }

        public int ColDiff
        {
            get
            {
                return colDiff;
            }
        }
    }
}
