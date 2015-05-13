using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Position
    {
        int m_Row;
        int m_Col;

        public Position(int i_Row, int i_Col)
        {
            this.m_Col = i_Col;
            this.m_Row = i_Row;
        }

        public int Row
        {
            get { return this.m_Row; }
            set { this.m_Row = value; }
        }

        public int Col
        {
            get { return this.m_Col; }
            set { this.m_Col = value; }
        }

        public bool equalPos(Position i_Position)
        {
            bool isEqual = false;

            // Checks if the two positions share the same row and col
            if (this.Col == i_Position.Col && this.Row == i_Position.Row) 
            {
                isEqual = true;
            }

            return isEqual;
        }

    }
}
