using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace B15_Ex02_1
{
    public static class ValidateInput
    {
        public static bool isValidName(string i_name, out string o_name)
        {
            bool validName = true;

            // Trimming white space in the given string
            string nameWithoutMultiplySpaces = Regex.Replace(i_name, @"\s+", " ");

            if (nameWithoutMultiplySpaces.Length > 15)
            {
                validName = false;
            }

            o_name = nameWithoutMultiplySpaces;

            return validName;
        }

        public static bool isValidBoardSize(string i_BoardSize, out short o_BoardSize)
        {
            bool isValidBoardSize = short.TryParse(i_BoardSize, out o_BoardSize);

            // Checking if the user gave the right size of board that we support
            if (o_BoardSize != 6 && o_BoardSize != 8)
            {
                isValidBoardSize = false;
            }

            return isValidBoardSize; 
        }

        public static bool isValidNumOfPlayers(string i_NumOfPlayers, out short o_NumOfPlayers)
        {
            bool isValidNumOfPlayers = short.TryParse(i_NumOfPlayers, out o_NumOfPlayers);

            // Checking if the user gave the number of players
            if (o_NumOfPlayers != 2 && o_NumOfPlayers != 1)
            {
                isValidNumOfPlayers = false;
            }

            return isValidNumOfPlayers;
        }

        public static bool isValidMoveInput(string i_Move)
        {
            // TODO 
            return false;
        }
    }
}
