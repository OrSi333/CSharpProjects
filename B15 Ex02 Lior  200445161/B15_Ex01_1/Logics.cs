using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public static class Logics
    {
        internal static bool isValidCoinPositioning(Board i_Board, Player i_Player, Position i_Position)
        {
            bool isValid;

            if (isNotPositionInsideBoard(i_Position, i_Board))
            {
                isValid = false;
            }
            else if (i_Board.getCellAtPos(i_Position).Coin != null)
            {
                isValid = false;
            }
            else
            {
                isValid = getAllPossibleMoves(i_Board, i_Player, i_Position).Count != 0;
            }

            return isValid;
        }

        private static bool checkIfAdjacentCellIsEnemy(Board i_Board, Player i_Player, Position i_Position, Direction direction)
        {
            Position toCheck = new Position(i_Position.Row + direction.RowDiff, i_Position.Col + direction.ColDiff);
            bool isValid = false;
            
            if (!isNotPositionInsideBoard(toCheck, i_Board))
            {
                if (i_Board.getCellAtPos(toCheck).Coin != null && i_Board.getCellAtPos(toCheck).Coin.Color != i_Player.Color)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private static bool checkIfAdjacentCellIsEnemy(Board i_Board, Player i_Player, Position i_Position)
        {
            bool isValid = false;

            foreach (Direction direction in Direction.ALLDIRECTIONS)
            {
                if (checkIfAdjacentCellIsEnemy(i_Board, i_Player, i_Position, direction))
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        internal static bool isNotPositionInsideBoard(Position i_Position, Board i_Board)
        {
            bool isOutofBound = false;
            short sizeOfBoard = i_Board.getSizeOfBoard;

            // Checks if the given position is not within the board dimentions
            if (i_Position.Row < 0 || i_Position.Row >= sizeOfBoard || i_Position.Col < 0 || i_Position.Col >= sizeOfBoard)
            {
                isOutofBound = true;    
            }

            return isOutofBound;
        }

        internal static Position getValidConquerDestination(Position i_Position, Direction direction, Player i_Player, Board i_Board)
        {
            Position checkPosition = new Position(i_Position.Row, i_Position.Col);

            if (checkIfAdjacentCellIsEnemy(i_Board, i_Player, i_Position, direction))
            {
                do
                {
                    checkPosition = new Position(checkPosition.Row + direction.RowDiff, checkPosition.Col + direction.ColDiff);
             
                    // If the cell is empty or out of board bounds - return invalid
                    if (isNotPositionInsideBoard(checkPosition, i_Board) || i_Board.getCellAtPos(checkPosition).Coin == null)
                    {
                        checkPosition = null;
                        break;
                    }

                    if (i_Board.getCellAtPos(checkPosition).Coin.Color == i_Player.Color)
                    {
                        break;
                    }
                } 
                while (i_Board.getCellAtPos(checkPosition).Coin.Color != i_Player.Color);
            }
            else
            {
                checkPosition = null;
            }
          
            return checkPosition;
        }

        internal static bool gameOver(Board i_Board, Player i_PlayerOne, Player i_PlayerTwo)
        {
            bool gameOver = false;
            List<Move> possibleMovesForPlayerOne = getAllPossibleMoves(i_Board, i_PlayerOne);
            List<Move> possibleMovesForPlayerTwo = getAllPossibleMoves(i_Board, i_PlayerTwo);

            // Check if both players got no more possible moves.
            if (possibleMovesForPlayerOne.Count == 0 && possibleMovesForPlayerTwo.Count == 0)
            {
                gameOver = true;
            }

            return gameOver;
        }

        internal static List<Move> getAllPossibleMoves(Board i_Board, Player i_Player)
        {
            List<Move> allPossibleMoves = new List<Move>();

            foreach (Position position in allPossiblePositions(i_Board, i_Player))
            {
                allPossibleMoves.AddRange(getAllPossibleMoves(i_Board, i_Player, position));
            }

            return allPossibleMoves;
        }

        internal static List<Move> getAllPossibleMoves(Board i_Board, Player i_Player, Position i_Position) 
        {
           List<Move> allPossibleMoves = new List<Move>();
           Position potentialDest = null;

           foreach (Direction direction in Direction.ALLDIRECTIONS)
           {
               potentialDest = Logics.getValidConquerDestination(i_Position, direction, i_Player, i_Board);

               if (potentialDest != null)
               {
                    allPossibleMoves.Add(new Move(i_Position, potentialDest, direction));
               }
          }

        return allPossibleMoves;
        }  

        // Returns a list of possible moves that the current player can make.
        internal static List<Position> allPossiblePositions(Board i_Board, Player i_Player)
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
    }
}
