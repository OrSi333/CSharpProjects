using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class UserInterface
    {
        private const string k_WelcomeMessege = "Welcome to Otthelo game!";
        private const string k_EnterFirstPlayerName = "Please enter first player's name.";
        private const string k_EnterSecondPlayerName = "Please enter second player's name.";
        private const string k_InvalidName = "Invalid player's name, Please enter a name with less than 15 characters";
        private const string k_HowManyPlayers = "Press '1' to play vs the computer or '2' to play vs a friend.";
        private const string k_InvalidNumOfPlayers = "Invalid number of players, please try again.";
        private const string k_EnterSizeOfBoard = "Please enter the desired size of board: '8' or '6'"; // should change it to  something better later.
        private const string k_InvalidSizeOfBoard = "Invalid board size, please try again.";
        private const string k_EnterMove = "whats your move? (Enter cell location)";
        private const string k_InvalidMove = "Invalid move, see example (A,2)";
        private const string k_NoPossibleMoves = "You don't have any possible moves, press 'Enter' to continue";
        private const string k_GameOver = "Game Over! the winner is {0}";
        private const string k_playAgain = "Would you like to play again ? press '1' to play again or any other key to quit";

        // Delete? 
        public void WelcomeMessage()
        {
            Console.WriteLine(k_WelcomeMessege);
        }

        public Position getUserMove(Player i_player)
        {
            Console.WriteLine(string.Format("{0}, {1}", i_player.Name, k_EnterMove));

            while (true)
            {
                short column;

                string userMove = Console.ReadLine();
                
                if (InputValidator.isValidMoveInput(userMove))
                {
                    short row = short.Parse(userMove.Substring(3, 1));
                    string col = userMove.Substring(1, 1);

                    // replace the letter of the column to the number of the column. // Maybe there's a better way ? 
                    switch (col.ToUpper()) 
                    {
                        case "A":
                            column = 0;
                            break;
                        case "B":
                            column = 1;
                            break;
                        case "C":
                            column = 2;
                            break;
                        case "D":
                            column = 3;
                            break;
                        case "E":
                            column = 4;
                            break;
                        case "F":
                            column = 5;
                            break;
                        case "G":
                            column = 6;
                            break;
                        case "H":
                            column = 7;
                            break;
                        default:
                            Console.WriteLine(k_InvalidMove);
                            continue;
                    }

                     return new Position(row - 1, column);
                }

                Console.WriteLine(k_InvalidMove);
            }
        }

        public short getSizeOfBoard()
        {
            Console.WriteLine(k_EnterSizeOfBoard);

            short sizeOfBoard = 0;

            while (true)
            {
                string sizeOfBoardStr = Console.ReadLine();

                if (InputValidator.isValidBoardSize(sizeOfBoardStr, out sizeOfBoard))
                {
                    return sizeOfBoard;
                }

                // Invalid input
                Console.WriteLine(k_InvalidSizeOfBoard);
            }
        }

        public string getSecondPlayerName()
        {
            Console.WriteLine(k_EnterSecondPlayerName);

            while (true)
            {
                string secondPlayerName = Console.ReadLine();

                if (InputValidator.isValidName(secondPlayerName, out secondPlayerName))
                {
                    return secondPlayerName;
                }

                // Invalid input
                Console.WriteLine(k_InvalidName);
            }
        }

        public short getNumberOfPlayers()
        {
            short numOfPlayers = 0;
            Console.WriteLine(k_HowManyPlayers);

            while (true)
            {
                string numOfPlayersStr = Console.ReadLine();

                if (InputValidator.isValidNumOfPlayers(numOfPlayersStr, out numOfPlayers))
                {
                    return numOfPlayers;
                }

                // Invalid input
                Console.WriteLine(k_InvalidNumOfPlayers);
            }
        }

        public string GetFirstPlayerName()
        {
            Console.WriteLine(k_EnterFirstPlayerName);

            while (true)
            {

                // Getting the first player name from the user
                string firstPlayerName = Console.ReadLine();

                if (InputValidator.isValidName(firstPlayerName, out firstPlayerName))
                {
                    return firstPlayerName;
                }

                // Invalid input
                Console.WriteLine(k_InvalidName);
            }
        }

        internal void printErrorMsg()
        {
            Console.WriteLine(k_InvalidMove);
            Console.ReadLine();
        }

        internal void printNoPossibleMsg()
        {
            Console.WriteLine(k_NoPossibleMoves);
            Console.ReadLine();
        }

        internal bool gameOverAndPlayAnotherGame(string i_PlayerName)
        {
            bool anotherGame = false;

            Console.WriteLine(string.Format(k_GameOver, i_PlayerName));
            Console.WriteLine(k_playAgain);
            string playAgainInput = Console.ReadLine();

            if (playAgainInput.Equals("1"))
            {
                anotherGame = true;
            }

            return anotherGame;
        }
    }
}

