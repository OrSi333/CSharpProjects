using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Direction
    {
        public static readonly Direction UP = new Direction(-1, 0);
        public static readonly Direction DOWN = new Direction(1, 0);
        public static readonly Direction LEFT = new Direction(0, -1);
        public static readonly Direction RIGHT = new Direction(0, 1);

        private int rowDiff;
        private int colDiff;

        public Direction(int i_rowDiff, int i_colDiff)
        {
            this.rowDiff = i_rowDiff;
            this.colDiff = i_colDiff;
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
