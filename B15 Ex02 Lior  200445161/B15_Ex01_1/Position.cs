using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Position
    {
        private int m_Row;
        private int m_Col;

        public Position(int i_Row, int i_Col)
        {
            m_Col = i_Col;
            m_Row = i_Row;
        }

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }

        public bool equalPos(Position i_Position)
        {
            bool isEqual = false;

            // Checks if the two positions share the same row and col
            if (Col == i_Position.Col && Row == i_Position.Row) 
            {
                isEqual = true;
            }

            return isEqual;
        }
    }
}
