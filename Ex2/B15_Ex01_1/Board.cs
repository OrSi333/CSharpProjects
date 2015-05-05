using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    class Board
    {
        //Commet to check
        private char[,] m_board;
        private int m_numOfColsInBoard = 0;
        private int m_numOfRowsInBoard = 0;
        private char m_whiteSpace = ' ';

        public Board(int i_numOfColsInBoard, int i_numOfRowsInBoard)
        {
            m_numOfColsInBoard = i_numOfColsInBoard;
            m_numOfRowsInBoard = i_numOfRowsInBoard;
            m_board = new char[i_numOfRowsInBoard, i_numOfColsInBoard];
            this.initializeBoard();
        }

        private void initializeBoard() 
        {
            
            
            char letter = 'A';
            short numOfRow = 1;

            for (int row = 0; row < m_numOfRowsInBoard; row++)
            {
                for (int col = 0; col < m_numOfColsInBoard; col++)
                {

                    // Putting letters on the colums  
                    if (row == 0 && col > 0 && col % 4 == 0)
                    {
                        m_board[row, col] = letter;

                        // Advancing to the next letter 
                        letter = (char)(((int)letter) + 1);
                        continue;
                    }
                          
                    if (row % 2 == 0 && row > 0)
                    {
                       // Putting numbers on the rows
                        if (col == 0)
                        {
                          m_board[row, col] = char.Parse(numOfRow.ToString());

                          // Advacing to the next number of row 
                          numOfRow++;
                            continue;
                        } 

                        if (col % 4 == 2)
                        {
                            // Putting dividers between each col 
                            m_board[row, col] = '|';
                            continue;
                        }       
                    }

                    // Putting dividers between each row 
                    if (row % 2 == 1 && col > 1)
                    {
                        m_board[row, col] = '=';
                        continue;
                    }
                   
                    // else filling the cell with white space
                    m_board[row, col] = m_whiteSpace;
                    }
                }
        }

        public char[,] getBoard
        {
            get
            {
                return m_board;
            }
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
