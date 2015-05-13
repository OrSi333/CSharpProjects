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
            this.m_SizeOfBoard = i_SizeOfBoard;
            this.m_Board = new Cell[this.m_SizeOfBoard, this.m_SizeOfBoard];
            this.initializeBoard();
        }

        public void initializeBoard()
        {
            for (int row = 0; row < this.m_SizeOfBoard; row++) 
			{
                for (int col = 0; col < this.m_SizeOfBoard; col++)
			    {
                    this.m_Board[row, col] = new Cell();
			    }
			}

            // Set white coins in initial position
            this.getCellAtPos(new Position(this.m_SizeOfBoard / 2, this.m_SizeOfBoard / 2)).Coin = new Coin(eCoinColor.WHITE);
            this.getCellAtPos(new Position((this.m_SizeOfBoard / 2) - 1, (this.m_SizeOfBoard / 2) - 1)).Coin = new Coin(eCoinColor.WHITE);

            // Set black coins in initial position
            this.getCellAtPos(new Position((this.m_SizeOfBoard / 2) - 1, this.m_SizeOfBoard / 2)).Coin = new Coin(eCoinColor.BLACK);
            this.getCellAtPos(new Position(this.m_SizeOfBoard / 2, (this.m_SizeOfBoard / 2) - 1)).Coin = new Coin(eCoinColor.BLACK);
        }

        public Cell getCellAtPos(Position i_Position)
        {
            return this.m_Board[i_Position.Row, i_Position.Col]; 
        }
 
        public short getSizeOfBoard
        {
            get
            {
                return this.m_SizeOfBoard;
            }
        }
    }
}
