using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Player
    {
        private string m_Name;
        private short m_Score;
        private eCoinColor m_Color;

        public Player(string i_Name, short i_Score, eCoinColor i_Color)
        {
            this.m_Name = i_Name;
            this.m_Color = i_Color;
            this.m_Score = i_Score;
        }

        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public short Score
        {
            get { return this.m_Score; }
            set { this.m_Score = value; }
        }
        
        public eCoinColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }
    }
}
