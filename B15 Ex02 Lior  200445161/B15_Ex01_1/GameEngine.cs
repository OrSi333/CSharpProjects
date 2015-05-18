using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
   public class GameEngine
    {
       private Board m_Board;
       private Player m_PlayerTwo;
       private Player m_PlayerOne;
       private UserInterface userInterface;
       private AI m_Ai;

       public void RunGame()
       {
           gameSetup();

           while (true)
           {
               m_Board.initializeBoard();

               while (!Logics.gameOver(m_Board, m_PlayerOne, m_PlayerTwo))
               {
                   clearAndPrintBoard();

                   if (Logics.getAllPossibleMoves(m_Board, m_PlayerOne).Count != 0)
                   {
                       while (!performMove(m_PlayerOne, getPlayerSelectedPosition(m_PlayerOne, m_Ai)))
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

                   if (Logics.getAllPossibleMoves(m_Board, m_PlayerTwo).Count != 0)
                   {
                       while (!performMove(m_PlayerTwo, getPlayerSelectedPosition(m_PlayerTwo, m_Ai)))
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

               clearAndPrintBoard();
               calculatePlayersScore();

                Player winner = winnerOfTheGame();
              
                if (winner == null)
                {
                    userInterface.printDrawMsg();
                }

                userInterface.printScore(m_PlayerOne);
                userInterface.printScore(m_PlayerTwo);

                if (userInterface.gameOverAndPlayAnotherGame(winner.Name) == false)
                {
                    break;
                }
           }
       }

       private void gameSetup()
       {
           userInterface = new UserInterface();
           userInterface.WelcomeMessage();

           m_PlayerOne = new Player(userInterface.GetFirstPlayerName(), 2, eCoinColor.WHITE);

           if (userInterface.getNumberOfPlayers() == 2)
           {
               m_PlayerTwo = new Player(userInterface.getSecondPlayerName(), 2, eCoinColor.BLACK);
           }
           else
           {
               m_PlayerTwo = new Player(AI.Name, 2, eCoinColor.BLACK);
           }

           m_Board = new Board(userInterface.getSizeOfBoard());
           m_Ai = new AI(m_Board, m_PlayerTwo);
           clearAndPrintBoard();
       }

       private void clearAndPrintBoard()
       {
           Ex02.ConsoleUtils.Screen.Clear();
           Console.WriteLine(BoardFormat.GetBoardStringRepresentation(m_Board));
       }

       private Position getPlayerSelectedPosition(Player i_Player, AI i_AIPlayer)
       {
           Position positionToReturn = null;
 
           if (i_Player.Name == AI.Name)
           {
               userInterface.printPlayerTurnPrompt(i_Player);
               System.Threading.Thread.Sleep(AI.ThinkingTime); 
               positionToReturn = i_AIPlayer.getPosition();
           }
           else
           {
               positionToReturn = userInterface.getUserMove(i_Player);
           }

           return positionToReturn;
       }

       public bool performMove(Player player, Position i_Position)
       {
           bool movePerformed = false;
           if (Logics.isValidCoinPositioning(m_Board, player, i_Position))
           {
               foreach (Direction direction in Direction.ALLDIRECTIONS)
               {
                   Position destination = Logics.getValidConquerDestination(i_Position, direction, player, m_Board);
                   if (destination != null)
                   {
                       conquer(i_Position, destination, direction, player);
                       movePerformed = true;
                   }
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

        private void calculatePlayersScore()
        {
            m_PlayerOne.Score = m_Board.CountCoins(m_PlayerOne.Color);
            m_PlayerTwo.Score = m_Board.CountCoins(m_PlayerTwo.Color);
        }

        private Player winnerOfTheGame()
        {
            Player playerToRetrun = m_PlayerOne;

            // Checks who has the highest score
            if (m_PlayerOne.Score < m_PlayerTwo.Score)
            {
                playerToRetrun = m_PlayerTwo;
            }

            // Tie, is it possible in this game ? 
            if (m_PlayerOne.Score == m_PlayerTwo.Score)
            {
                playerToRetrun = null;
            }

            return playerToRetrun;
        }
    }
}
