using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public static class Logics
    {
        internal static bool isValidCoinPositioning(Board i_Board, Player player, Position i_Position)
        {
            bool isValid;

            if (i_Board.getCellAtPos(i_Position).Coin != null) 
            {
                isValid = false;
            }
            else
            {
                isValid = checkIfAdjacentCellIsEnemy(i_Board, player, i_Position);
            }

            return isValid;
        }

        private static bool checkIfAdjacentCellIsEnemy(Board i_Board, Player i_Player, Position i_Position)
        {
            bool isValid = false;

            Position adjacentCellUp = new Position(i_Position.Row + Direction.UP.RowDiff, i_Position.Col + Direction.UP.ColDiff);
            Position adjacentCellDown = new Position(i_Position.Row + Direction.DOWN.RowDiff, i_Position.Col + Direction.DOWN.ColDiff);
            Position adjacentCellLeft = new Position(i_Position.Row + Direction.LEFT.RowDiff, i_Position.Col + Direction.LEFT.ColDiff);
            Position adjacentCellRight = new Position(i_Position.Row + Direction.RIGHT.RowDiff, i_Position.Col + Direction.RIGHT.ColDiff);

            // Checks if the adjacent cells are controled by the enemy
            if (i_Board.getCellAtPos(adjacentCellDown).Coin != null && i_Board.getCellAtPos(adjacentCellDown).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellUp).Coin != null && i_Board.getCellAtPos(adjacentCellUp).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellLeft).Coin != null && i_Board.getCellAtPos(adjacentCellLeft).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellRight).Coin != null && i_Board.getCellAtPos(adjacentCellRight).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }

            return isValid;
        }

        internal static Position getValidConquerDestination(Position i_Position, Direction direction, Player i_player, Board i_Board)
        {
            Position checkPosition = new Position(i_Position.Row, i_Position.Col);

            do
            {
                checkPosition = new Position(checkPosition.Row + direction.RowDiff, checkPosition.Col + direction.ColDiff);

                // If the cell is empty
                if (i_Board.getCellAtPos(checkPosition).Coin == null)
                {
                    checkPosition = null;
                    break;
                }

                if (i_Board.getCellAtPos(checkPosition).Coin.Color == i_player.Color)
                {
                    break;
                }

            } while (i_Board.getCellAtPos(checkPosition).Coin.Color != i_player.Color);
          
            return checkPosition;
        }

        internal static bool gameOver(Board i_Board)
        {
            bool gameOver = true;

            // Going over the entire board and checks if all cells are filled, if not the game is not over.
            for (int row = 0; row < i_Board.getSizeOfBoard; row++)
            {
                for (int col = 0; col < i_Board.getSizeOfBoard; col++)
                {
                    if (i_Board.getCellAtPos(new Position(row, col)).Coin == null)
                    {
                        gameOver = false;
                    }
                }
            }

            return gameOver;
        }
    }
}

