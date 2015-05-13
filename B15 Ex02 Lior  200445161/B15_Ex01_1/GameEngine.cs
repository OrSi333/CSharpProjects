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

           while (true)
           {
               while (!Logics.gameOver(m_Board))
               {
                   clearAndPrintBoard();

                   if (Logics.allPossibleMoves(m_Board, playerOne) != null)
                   {
                       while (!performMove(playerOne, userInterface.getUserMove(playerOne)))
                       {
                           clearAndPrintBoard();
                           userInterface.printErrorMsg();
                       }
                   }
                   else
                   {
                       userInterface.printNoPossibleMsg();
                   }

                   clearAndPrintBoard();

                   if (Logics.allPossibleMoves(m_Board, playerTwo) != null)
                   {
                       while (!performMove(playerTwo, userInterface.getUserMove(playerTwo)))
                       {
                           clearAndPrintBoard();
                           userInterface.printErrorMsg();
                       }
                   }
                   else
                   {
                       clearAndPrintBoard();
                       userInterface.printErrorMsg();
                   }
               }

               Player winner = Logics.winnerOfTheGame(m_Board, playerOne, playerTwo);
               if (userInterface.gameOverAndPlayAnotherGame(winner.Name) == false) // SHOULD BE CHAGNED!
               {
                   break;
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
    }
}
