using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    public class Cell
    {
        private Coin m_Coin;

        public Coin Coin
        {
            get
            {
                return m_Coin;
            }
            set
            {
                m_Coin = value;
            }
        }
    }
}
 