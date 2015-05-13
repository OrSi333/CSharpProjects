using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
   public class GameEngine
    {
       Board m_Board;
       Player playerTwo;

       public void RunGame()
       {
           UserInterface userInterface = new UserInterface();
           userInterface.WelcomeMessage();

           Player playerOne = new Player(userInterface.GetFirstPlayerName(), 0, eCoinColor.WHITE);

           if (userInterface.getNumberOfPlayers() == 2)
           {
               playerTwo = new Player(userInterface.getSecondPlayerName(), 0, eCoinColor.BLACK);
           }

           m_Board = new Board(userInterface.getSizeOfBoard());

           clearAndPrintBoard();

           while (!Logics.gameOver(m_Board))
           {
               clearAndPrintBoard();

               while (!performMove(playerOne, userInterface.getUserMove(playerOne)))
               {
                   clearAndPrintBoard();
                   Console.WriteLine("Invalid Move");
               }

               clearAndPrintBoard();

               while (!performMove(playerTwo, userInterface.getUserMove(playerTwo)))
               {
                   clearAndPrintBoard();
                   Console.WriteLine("Invalid Move");
               }
           }
       }

       private void clearAndPrintBoard()
       {
           Ex02.ConsoleUtils.Screen.Clear();
           Console.WriteLine(BoardFormat.GetBoardStringRepresentation(m_Board));
       }

       public bool performMove(Player player, Position i_Position)
        {
            bool movePerformed = false;

            if (Logics.isValidCoinPositioning(m_Board, player, i_Position))
            {
                Position destination = Logics.getValidConquerDestination(i_Position, Direction.DOWN, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.UP, player, m_Board);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.UP, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.LEFT, player, m_Board);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.LEFT, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.RIGHT, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.RIGHT, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.UPRIGHT, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.UPRIGHT, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.UPLEFT, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.UPLEFT, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.DOWNRIGHT, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWNRIGHT, player);
                    movePerformed = true;
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.DOWNLEFT, player, m_Board);

                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWNLEFT, player);
                    movePerformed = true;
                }
            }

            return movePerformed;
        }

        private void conquer(Position source, Position destination, Direction direction, Player i_player)
        {
            m_Board.getCellAtPos(source).Coin = new Coin(i_player.Color); 

            Position conquerPosition = source;

            do
            {
                conquerPosition = new Position(conquerPosition.Row + direction.RowDiff, conquerPosition.Col + direction.ColDiff);

                m_Board.getCellAtPos(conquerPosition).Coin.Color = i_player.Color;
            } 
            while (!conquerPosition.equalPos(destination));
        }

       // Returns a list of positions that are empty. 
       public List<Position> emptyCells(Board i_Board)
        {
           List<Position> emptyPositions = new List<Position>();

           for (int i = 0; i < i_Board.getSizeOfBoard; i++) 
           {
               for (int j = 0; j <i_Board.getSizeOfBoard; j++) 
               {
                   Position checkPosition = new Position(i, j);

                   // Checks if the cell is empty
                   if (i_Board.getCellAtPos(checkPosition).Coin == null) 
                   {
                       emptyPositions.Add(checkPosition);
                   }
               }
           }

           return emptyPositions;
        }
    }
}
