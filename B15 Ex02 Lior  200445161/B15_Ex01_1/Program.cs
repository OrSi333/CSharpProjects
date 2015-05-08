using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace B15_Ex02_1
{
    class Program
    {
        static void Main()
        {
            Board board;

            UserInterface.GetUserInput();

            
            board = new Board(UserInterface.getSizeOfBoard);
            Console.WriteLine(BoardFormat.GetBoardStringRepresentation(board));
            Console.ReadLine();
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
    }
}
