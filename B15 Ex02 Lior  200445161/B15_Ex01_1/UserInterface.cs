using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class UserInterface
    {
        private const string k_WelcomeMessege = "Welcome to Otlo game!";
        private const string k_EnterFirstPlayerName = "Please enter first player's name.";
        private const string k_EnterSecondPlayerName = "Please enter second player's name.";
        private const string k_InvalidName = "Invalid player's name, Please enter a name with less than 15 characters";
        private const string k_HowManyPlayers = "Press '1' to play vs the computer or '2' to play vs a friend.";
        private const string k_InvalidNumOfPlayers = "Invalid number of players, please try again.";
        private const string k_EnterSizeOfBoard = "Please enter the desired size of board: '8' or '6'"; // should change it to  something better later.
        private const string k_InvalidSizeOfBoard = "Invalid board size, please try again.";

        private static string firstPlayerName;
        private static string secondPlayerName;
        private static short numOfPlayers;
        private static short sizeOfBoard;

        public static void GetUserInput()
        {
            Console.WriteLine(k_WelcomeMessege);
            Console.WriteLine(k_EnterFirstPlayerName);

            while (true)
            {

                // Getting the first player name
                firstPlayerName = Console.ReadLine();

                if (ValidateInput.isValidName(firstPlayerName, out firstPlayerName))
                {
                    break;
                }

                // Invalid input
                Console.WriteLine(k_InvalidName);
            }

            Console.WriteLine(k_HowManyPlayers);

            while (true) 
            {             
                string numOfPlayersStr = Console.ReadLine();

                if (ValidateInput.isValidNumOfPlayers(numOfPlayersStr, out numOfPlayers))
                {
                    break;
                }

                // Invalid input
                Console.WriteLine(k_InvalidNumOfPlayers);
            }

            if (numOfPlayers == 2)
            {
                Console.WriteLine(k_EnterSecondPlayerName);

                while (true)
                {
                    secondPlayerName = Console.ReadLine();

                    if (ValidateInput.isValidName(secondPlayerName, out secondPlayerName))
                    {
                        break;
                    }

                    // Invalid input
                    Console.WriteLine(k_InvalidName);
                }
            }

            Console.WriteLine(k_EnterSizeOfBoard);

            while (true)
            {
                string sizeOfBoardStr = Console.ReadLine();

                if (ValidateInput.isValidBoardSize(sizeOfBoardStr, out sizeOfBoard))
                {
                    break;
                }

                // Invalid input
                Console.WriteLine(k_InvalidSizeOfBoard);
            }
        }

        public static short GetNumberOfPlayer
        {
            get
            {
                return numOfPlayers;
            }
        }

        public static short getSizeOfBoard
        {
            get
            {
                return sizeOfBoard;
            }
        }
    }
}

