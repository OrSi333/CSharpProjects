using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    class Program
    {
        static void Main()
        {
            UserInterface.GetUserInput();

            Board board = new Board(UserInterface.getSizeOfBoard);

            Console.WriteLine(BoardFormat.GetBoardStringRepresentation(board));
            Console.ReadLine();
        }
    }
}
