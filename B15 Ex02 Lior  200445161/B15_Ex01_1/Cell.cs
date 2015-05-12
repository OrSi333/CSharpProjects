using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02_1
{
    public class Cell
    {
        private Coin m_Coin;

        public Coin Coin
        {
            get
            {
                return this.m_Coin;
            }

            set
            {
                this.m_Coin = value;
            }
        }
    }
}
