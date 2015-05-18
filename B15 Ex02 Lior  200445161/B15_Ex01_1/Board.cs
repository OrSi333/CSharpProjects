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

        public void initializeBoard()
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

        // Returns a list of positions that are empty. 
        public List<Position> getEmptyCells()
        {
            List<Position> emptyPositions = new List<Position>();

            for (int i = 0; i < getSizeOfBoard; i++)
            {
                for (int j = 0; j < getSizeOfBoard; j++)
                {
                    Position checkPosition = new Position(i, j);

                    // Checks if the cell is empty
                    if (getCellAtPos(checkPosition).Coin == null)
                    {
                        emptyPositions.Add(checkPosition);
                    }
                }
            }

            return emptyPositions;
        }

        public Cell getCellAtPos(Position i_Position)
        {
            return m_Board[i_Position.Row, i_Position.Col]; 
        }
 
        public short getSizeOfBoard
        {
            get
            {
                return m_SizeOfBoard;
            }
        }

        internal int CountCoins(eCoinColor i_Color)
        {
            int score = 0;
            Position position = new Position(0, 0);

            for (int row = 0; row < m_SizeOfBoard; row++) 
            {
                for (int col = 0; col < m_SizeOfBoard; col++)
                {
                    position.Row = row;
                    position.Col = col;

                    if (getCellAtPos(position).Coin != null && getCellAtPos(position).Coin.Color == i_Color)
                    {
                        score++;
                    }
                } 
            }

            return score;
        }
    }
}
