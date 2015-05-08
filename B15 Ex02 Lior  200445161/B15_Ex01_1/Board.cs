using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Board
    {
        private Cell[,] m_Board;
        private short m_SizeOfBoard;
        public Board(short i_SizeOfBoard)
        {
            m_SizeOfBoard = i_SizeOfBoard;
            m_Board = new Cell[m_SizeOfBoard, m_SizeOfBoard];
            initializeBoard();
        }

        private void initializeBoard()
        {
            for (int row = 0; row < m_SizeOfBoard; row++) 
			{
                for (int col = 0; col < m_SizeOfBoard; col++)
			    {
                    m_Board[row, col] = new Cell();
			    }
			}

            // Set white coins in initial position
            getCellAtPos(new Position(m_SizeOfBoard / 2, m_SizeOfBoard / 2)).Coin = new Coin(eCoinColor.WHITE);
            getCellAtPos(new Position((m_SizeOfBoard / 2) - 1, (m_SizeOfBoard / 2) - 1)).Coin = new Coin(eCoinColor.WHITE);

            // Set black coins in initial position
            getCellAtPos(new Position((m_SizeOfBoard / 2) - 1, m_SizeOfBoard / 2)).Coin = new Coin(eCoinColor.BLACK);
            getCellAtPos(new Position(m_SizeOfBoard / 2, (m_SizeOfBoard / 2) - 1)).Coin = new Coin(eCoinColor.BLACK);
        }

        public Cell getCellAtPos(Position i_Position)
        {
            return this.m_Board[i_Position.Row, i_Position.Col]; 
        }
 
        public int getSizeOfBoard
        {
            get
            {
                return m_SizeOfBoard;
            }
        }
    }
}
