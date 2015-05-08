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
            get { return m_Name; }
            set { m_Name = value; }
        }

        public short Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        
        public eCoinColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
    }
}
