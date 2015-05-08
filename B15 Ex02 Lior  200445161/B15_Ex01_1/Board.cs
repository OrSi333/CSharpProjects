using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    public class Board
    {
        private Cell[,] m_board;
        private int m_numOfColsInBoard = 0;
        private int m_numOfRowsInBoard = 0;

        public Board(int i_numOfColsInBoard, int i_numOfRowsInBoard)
        {
            m_numOfColsInBoard = i_numOfColsInBoard;
            m_numOfRowsInBoard = i_numOfRowsInBoard;
            m_board = new Cell[i_numOfRowsInBoard, i_numOfColsInBoard];
            initializeBoard();
        }

        private void initializeBoard()
        {
            for (int row = 0; row < m_numOfRowsInBoard; row++) 
			{
			    for (int col = 0; col < m_numOfColsInBoard; col++)
			    {
                    m_board[row, col] = new Cell();
			    }
			}

            // Set white coins in initial position
            getCellAtPos(new Position(m_numOfRowsInBoard / 2, m_numOfColsInBoard / 2)).Coin = new Coin(eCoinColor.WHITE);
            getCellAtPos(new Position((m_numOfRowsInBoard / 2) - 1, (m_numOfColsInBoard / 2) - 1)).Coin = new Coin(eCoinColor.WHITE);

            // Set black coins in initial position
            getCellAtPos(new Position((m_numOfRowsInBoard / 2) - 1, m_numOfColsInBoard / 2)).Coin = new Coin(eCoinColor.BLACK);
            getCellAtPos(new Position(m_numOfRowsInBoard / 2, (m_numOfColsInBoard / 2) - 1)).Coin = new Coin(eCoinColor.BLACK);
        }

        public Cell getCellAtPos(Position i_Position)
        {
            return this.m_board[i_Position.Row, i_Position.Col]; ;
        }
 
        public int getNumOfRowsInBoard
        {
            get
            {
                return m_numOfRowsInBoard;
            }
        }

        public int getNumofColsInBoard
        {
            get
            {
                return m_numOfColsInBoard;
            }
        }
    }
}
