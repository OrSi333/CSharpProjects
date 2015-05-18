using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Move
    {
        private Position m_Source;
        private Position m_Destination;
        private Direction m_Direction;
        private int m_NumberOfEatenCoins;

        public Move(Position i_Source, Position i_Destination, Direction i_Direction) 
        {
            m_Source = i_Source;
            m_Destination = i_Destination;
            m_Direction = i_Direction;
            m_NumberOfEatenCoins = numberOfCoinsConqured();
        }

        public Direction Direction
        {
            get { return m_Direction; }
        }

        public Position Source
        {
            get { return m_Source; }
        }

        public Position Destination
        {
            get { return m_Destination; }
        }

        private int numberOfCoinsConqured()
        {
            int sumOfConquredCoins = 0;
            Position runPosition = new Position(m_Source.Row + m_Direction.RowDiff, m_Source.Col + m_Direction.ColDiff);

            while (!runPosition.equalPos(m_Destination))
            {
                runPosition.Row += m_Direction.RowDiff;
                runPosition.Col += m_Direction.ColDiff;

                sumOfConquredCoins++;
            }

            return sumOfConquredCoins;
        }

        public int NumOfEatenCoins
        {
            get { return m_NumberOfEatenCoins; }
        }
    }
}
