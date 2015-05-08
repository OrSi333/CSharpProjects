using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    public static class BoardFormat
    {
        public static string GetBoardStringRepresentation(Board i_Board)
        {
            StringBuilder boardToString = new StringBuilder();

            boardToString.Append("  ");
            boardToString.Append(getColumnLetters(i_Board.getNumofColsInBoard));
            boardToString.Append(Environment.NewLine);

            boardToString.Append(getEqualLine(i_Board.getNumofColsInBoard));
            boardToString.Append(Environment.NewLine);
            boardToString.Append(boardLines(i_Board));

            return boardToString.ToString();
        }

        private static string boardLines(Board i_Board)
        {
            StringBuilder lines = new StringBuilder();

            for (int row = 0; row < i_Board.getNumOfRowsInBoard; row++)
            {
                lines.Append(string.Format("{0} ", (row + 1).ToString()));

                for (int col = 0; col < i_Board.getNumofColsInBoard; col++)
                {
                    lines.Append(string.Format("|{0}", CellToPrint(i_Board.getCellAtPos(new Position(row, col)))));
                }

                lines.Append(string.Format("|{0}", Environment.NewLine));
                lines.Append(getEqualLine(i_Board.getNumofColsInBoard) + Environment.NewLine);
            }

            return lines.ToString();
        }

        private static string getEqualLine(int i_numberOfColums)
        {
            StringBuilder equalLine = new StringBuilder();
            equalLine.Append("  ");

            for (int i = 0; i < i_numberOfColums; i++)
            {
                equalLine.Append("====");
            }

            equalLine.Append("=");
            return equalLine.ToString();
        }

        private static string getColumnLetters(int i_numberOfColumns)
        {
            StringBuilder columnLetters = new StringBuilder();
            char letter = 'A';

            for (int i = 0; i < i_numberOfColumns; i++)
            {
                columnLetters.Append(string.Format("  {0} ", letter));

                // Advancing to the next letter 
                letter = (char)(((int)letter) + 1);
            }

            return columnLetters.ToString();
        }

        private static string CellToPrint(Cell cell)
        {
            string cellStr = null;
            if (cell.Coin != null)
            {
                switch (cell.Coin.Color)
                {
                    case eCoinColor.BLACK:
                        cellStr = " X ";
                        break;
                    case eCoinColor.WHITE:
                        cellStr = " O ";
                        break;
                }
            }
            else
            {
                cellStr = "   ";
            }
        
            return cellStr;
        }
    }
}
