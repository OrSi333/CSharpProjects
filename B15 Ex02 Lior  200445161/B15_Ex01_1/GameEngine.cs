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

               while (!performMove(playerOne, userInterface.getUserMove()))
               {
                   clearAndPrintBoard();
                   Console.WriteLine("Invalid Move");
               }
               clearAndPrintBoard();

               while (!performMove(playerTwo, userInterface.getUserMove()))
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
    
            } while (!conquerPosition.equalPos(destination));
        }
    }
}
