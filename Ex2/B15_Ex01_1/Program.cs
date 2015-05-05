using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace B15_Ex01_1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                int numOfplayers;
                string firstPlayerName;
                string secondPlayerName;
                int sizeOfBoard;
                Board board;

                Console.WriteLine(
 @"Welcome to Otlo Game!
please enter your name and press 'enter': ");

                firstPlayerName = Console.ReadLine();
             
                if (!validateName(firstPlayerName))
                {
                    Console.WriteLine("Invalid name, please try again.");
                    continue;
                }

                Console.WriteLine("how many players play? (1 or 2) ");
                string playersStr = Console.ReadLine();
                
                if (!int.TryParse(playersStr, out numOfplayers))
                {
                    Console.WriteLine("Invalid number of players, please try again.");
                    continue;
                }

                if (numOfplayers != 2 && numOfplayers != 1)
                {
                    Console.WriteLine("Invalid number of players, please try again.");
                    continue;
                }

                if (numOfplayers == 2)
                {
                    Console.WriteLine("Please enter the second player name: ");
                    secondPlayerName = Console.ReadLine();
                    if (!validateName(secondPlayerName))
                    {
                        Console.WriteLine("Invalid name, please try again.");
                        continue;
                    }
                }

                Console.WriteLine("What is the size of the board you like to with? 8 or 6?");

                if (!int.TryParse(Console.ReadLine(), out sizeOfBoard))
                {
                    Console.WriteLine("Invalid size of board, please try again");
                }

                if (sizeOfBoard == 8)
                {
                    board = new Board(35, 18);
                }
                else
                {
                    board = new Board(27, 14);
                }

                PrintBoard(board);
                Console.ReadLine();
            }        
        }

        private static bool validateName(string i_playerName)
        {
            bool isValid = true;

            // Making sure the name is not too long or has white spaces
            if (i_playerName.Length > 15)
            {
                isValid = false;
            }

            // names with white spaces are not valid
            if (Regex.IsMatch(i_playerName, @"\s", RegexOptions.IgnoreCase))
            {
                isValid = false;
            }

            return isValid;
        }

        private static void PrintBoard(Board board)
        {
            char[,] boardToPrint = board.getBoard;

            for (int i = 0; i < board.getNumOfRowsInBoard; i++)
            {
                for (int j = 0; j < board.getNumofColsInBoard; j++)
                {
                    Console.Write(string.Format("{0}", boardToPrint[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
