using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
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
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }

    }
}
