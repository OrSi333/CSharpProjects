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
        private const string k_InvalidName = "Invalid player's name, white spaces should not be used.";
        private const string k_HowManyPlayers = "Press '1' to play vs the computer or '2' to play vs a friend.";
        private const string k_InvalidNumOfPlayers = "Invalid number of players, please try again.";
        private const string k_EnterSizeOfBoard = "Please enter the desired size of board: '8' or '6'"; // should change it to  something better later.
        private const string k_InvalidSizeOfBoard = "Invalid board size, please try again.";

        private string firstPlayerName;
        private string secondPlayerName;
        private short numOfPlayers;
        private short sizeOfBoard;

        public void GetUserInput()
        {
            Console.WriteLine(k_WelcomeMessege);
            Console.WriteLine(k_EnterFirstPlayerName);
            firstPlayerName = Console.ReadLine();
            Console.WriteLine(k_HowManyPlayers);

            bool validNumOfPlayers = false;
            while (validNumOfPlayers)
            {
                // Checking if the input of the user is valid
                validNumOfPlayers = short.TryParse(Console.ReadLine(), out numOfPlayers);

                if (numOfPlayers == 2 || numOfPlayers == 1)
                {
                    validNumOfPlayers = true;

                }
                else
                {
                    Console.WriteLine(k_InvalidNumOfPlayers);
                }
            }

            if (numOfPlayers == 2)
            {
                Console.WriteLine(k_EnterSecondPlayerName);
                secondPlayerName = Console.ReadLine();
            }

            bool validSizeOfBoard = false;
            while (validSizeOfBoard) 
            {
                Console.WriteLine(k_EnterSizeOfBoard);
                validSizeOfBoard = short.TryParse(Console.ReadLine(), out sizeOfBoard);

                if (sizeOfBoard == 6 || sizeOfBoard == 8)
                {
                   validSizeOfBoard = true;
                }
                else
                {
                  Console.WriteLine(k_InvalidSizeOfBoard);
                }
            }
        }

        public short GetNumberOfPlayer
        {
            get
            {
                return numOfPlayers;
            }
        }
    }
}

