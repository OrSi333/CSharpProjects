using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
   public class AI
    {
        private static readonly string r_Name = "Computer";
        private static readonly int r_ThinkingTime = 1500;

        private Board m_Board;
        private Player m_AIPlayer;

        public AI(Board i_Board, Player i_Player)
        {
            m_Board = i_Board;
            m_AIPlayer = i_Player;
        }

        public Position getPosition()
        {
            Dictionary<Position, int> soruceToNumberOfConqured = new Dictionary<Position, int>();
            List<Move> allPossibleMoves = Logics.getAllPossibleMoves(m_Board, m_AIPlayer);
            Position bestPosition = null;

            foreach (Move move in allPossibleMoves)
            {
                if (soruceToNumberOfConqured.ContainsKey(move.Source))
                {
                    soruceToNumberOfConqured[move.Source] += move.NumOfEatenCoins;
                }
                else
                {
                    soruceToNumberOfConqured.Add(move.Source, move.NumOfEatenCoins);
                }
            }

            foreach (Position position in soruceToNumberOfConqured.Keys)
            {
                if (bestPosition == null || soruceToNumberOfConqured[bestPosition] < soruceToNumberOfConqured[position])
                {
                    bestPosition = position;
                }
            }

            return bestPosition;
        }

        public static string Name
        {
            get { return AI.r_Name; }
        }

        public static int ThinkingTime
        {
            get { return AI.r_ThinkingTime; }
        } 
    }
}
