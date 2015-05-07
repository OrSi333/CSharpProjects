using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    class GameEngine
    {
        Board m_Board;

        public void performMove(Player player, Position i_Position)
        {
            if (Logics.isValidCoinPositioning(m_Board, player, i_Position))
            {
                Position destination = Logics.getValidConquerDestination(i_Position, Direction.DOWN, player);
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.UP, player);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.LEFT, player);
                
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
                }

                destination = Logics.getValidConquerDestination(i_Position, Direction.RIGHT, player);
                if (destination != null)
                {
                    conquer(i_Position, destination, Direction.DOWN, player);
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
