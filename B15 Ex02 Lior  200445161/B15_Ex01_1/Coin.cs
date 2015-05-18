using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public enum eCoinColor
    {
        BLACK,
        WHITE
    }

    public class Coin
    {
        private eCoinColor m_Color;

        public Coin(eCoinColor i_Color)
        {
            m_Color = i_Color;
        }

        public eCoinColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }
    }
}
