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

            if (isPositionInsideBoard(i_Position, i_Board))
            {
                isValid = false;
            }
            else if (i_Board.getCellAtPos(i_Position).Coin != null)
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
            Position adjacentCellUpRight = new Position(i_Position.Row + Direction.UPRIGHT.RowDiff, i_Position.Col + Direction.UPRIGHT.ColDiff);
            Position adjacentCellUpLeft = new Position(i_Position.Row + Direction.UPLEFT.RowDiff, i_Position.Col + Direction.UPLEFT.ColDiff);
            Position adjacentCellDownRight = new Position(i_Position.Row + Direction.DOWNRIGHT.RowDiff, i_Position.Col + Direction.DOWNRIGHT.ColDiff);
            Position adjacentCellDownLeft = new Position(i_Position.Row + Direction.DOWNLEFT.RowDiff, i_Position.Col + Direction.DOWNLEFT.ColDiff);

            // Checks if the adjacent cells are controled by the enemy
            if (!isPositionInsideBoard(adjacentCellUpRight, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellUpRight).Coin != null && i_Board.getCellAtPos(adjacentCellUpRight).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellUpLeft, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellUpLeft).Coin != null && i_Board.getCellAtPos(adjacentCellUpLeft).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellDownRight, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellDownRight).Coin != null && i_Board.getCellAtPos(adjacentCellDownRight).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellDownLeft, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellDownLeft).Coin != null && i_Board.getCellAtPos(adjacentCellDownLeft).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellDown, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellDown).Coin != null && i_Board.getCellAtPos(adjacentCellDown).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellUp, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellUp).Coin != null && i_Board.getCellAtPos(adjacentCellUp).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellLeft, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellLeft).Coin != null && i_Board.getCellAtPos(adjacentCellLeft).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            if (!isPositionInsideBoard(adjacentCellRight, i_Board))
            {
                if (i_Board.getCellAtPos(adjacentCellRight).Coin != null && i_Board.getCellAtPos(adjacentCellRight).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        internal static bool isPositionInsideBoard(Position i_Position, Board i_Board)
        {
            bool isBoarder = false;
            short sizeOfBoard = i_Board.getSizeOfBoard;

            // Checks if the given position is within the board dimentions
            if (i_Position.Row < 0 || i_Position.Row >= sizeOfBoard || i_Position.Col < 0 || i_Position.Col >= sizeOfBoard)
            {
                isBoarder = true;    
            }

            return isBoarder;
        }

        internal static Position getValidConquerDestination(Position i_Position, Direction direction, Player i_player, Board i_Board)
        {
            Position checkPosition = new Position(i_Position.Row, i_Position.Col);

            do
            {
                checkPosition = new Position(checkPosition.Row + direction.RowDiff, checkPosition.Col + direction.ColDiff);
             
                if (isPositionInsideBoard(checkPosition, i_Board))
                {
                    checkPosition = null;
                    break;
                }
                    
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
            } 
            while (i_Board.getCellAtPos(checkPosition).Coin.Color != i_player.Color);
          
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

        // Returns a list of possible moves that the current player can make.
        internal static List<Position> allPossibleMoves(Board i_Board, Player i_Player)
        {
            List<Position> possibleMoves = new List<Position>();

            foreach (Position pos in i_Board.getEmptyCells())
            {
                
                // Checks if the position is valid
                if (Logics.isValidCoinPositioning(i_Board, i_Player, pos))
                {
                    possibleMoves.Add(pos);
                }
            }

            return possibleMoves;
        }

        internal static Player winnerOfTheGame(Board i_Board, Player playerOne, Player playerTwo)
        {
            Player playerToRetrun = playerOne;

            for (int i = 0; i < i_Board.getSizeOfBoard; i++)
            {
                for (int j = 0; j < i_Board.getSizeOfBoard; j++)
                {
                    if (i_Board.getCellAtPos(new Position(i, j)).Coin.Color == eCoinColor.WHITE)
                    {
                        playerOne.Score++;
                    }
                    else
                    {
                        playerTwo.Score++;
                    }
                }
            }

            // Checks who has the highest score
            if (playerOne.Score < playerTwo.Score)
            {
                playerToRetrun = playerTwo;
            }

            // Tie, is it possible in this game ? 
            if (playerOne.Score == playerTwo.Score)
            {
                playerToRetrun = null;
            }

            return playerToRetrun;
        }
    }
}
