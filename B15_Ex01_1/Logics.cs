using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    public static class Logics
    {
        internal static bool isValidCoinPositioning(Board i_Board, Player player, Position i_Position)
        {
            bool isValid;

            if (i_Board.getCellAtPos(i_Position) != null) 
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

            if (i_Board.getCellAtPos(adjacentCellDown) != null && i_Board.getCellAtPos(adjacentCellDown).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellUp) != null && i_Board.getCellAtPos(adjacentCellUp).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellLeft) != null && i_Board.getCellAtPos(adjacentCellLeft).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }
            else if (i_Board.getCellAtPos(adjacentCellRight) != null && i_Board.getCellAtPos(adjacentCellRight).Coin.Color != i_Player.Color)
            {
                isValid = true;
            }

            return isValid;
        }

        internal static Position getValidConquerDestination(Position i_Position, Direction direction, Player i_player)
        {
     /*       Position checkPosition;

            do
            {
                checkPosition = new Position(i_Position.Row + direction.RowDiff, i_Position.Col + direction.ColDiff);

                i_Board.getCellAtPos(checkPosition).Coin.Color = i_player.Color;

            } while (!checkPosition.Equals(destination));
            */
            return null;
        }
    }
}

