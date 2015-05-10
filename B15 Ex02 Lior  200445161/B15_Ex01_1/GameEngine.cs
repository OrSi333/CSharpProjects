using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
   public class GameEngine
    {
       Board m_Board;

       public void RunGame()
       {
           UserInterface userInterface = new UserInterface();
           Player playerOne = new Player(userInterface.GetFirstPlayerName(), 0, eCoinColor.WHITE);

           if (userInterface.getNumberOfPlayers() == 2)
           {
               Player playerTwo = new Player(userInterface.getSecondPlayerName(), 0, eCoinColor.BLACK);
           }

           m_Board = new Board(userInterface.getSizeOfBoard());
           m_Board.initializeBoard();

           Ex02.ConsoleUtils.Screen.Clear();

           Console.WriteLine(BoardFormat.GetBoardStringRepresentation(m_Board));


           while (!Logics.gameOver(m_Board))
           {
               while 
               {
                    
               }
           }
       }



       public void performMove(Player player, Position i_Position)
        {
            if (Logics.isValidCoinPositioning(m_Board, player, i_Position))
            {
                Position destination = Logics.getValidConquerDestination(i_Position, Direction.DOWN, player, m_Board);
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.UP, player, m_Board);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.UP, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.LEFT, player, m_Board);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.LEFT, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.RIGHT, player, m_Board);
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.RIGHT, player);
                }
            }
        }

        private void conquer(Position source, Position destination, Direction direction, Player i_player)
        {
            Position conquerPosition;

            do
            {
                conquerPosition = new Position(source.Row + direction.RowDiff, source.Col + direction.ColDiff);

                m_Board.getCellAtPos(conquerPosition).Coin.Color = i_player.Color;
    
            } while (!conquerPosition.Equals(destination));
        }
    }
}
