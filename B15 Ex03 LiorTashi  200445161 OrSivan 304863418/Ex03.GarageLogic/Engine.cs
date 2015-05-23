using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract internal class Engine
    {
        protected float m_CurrentQuantity;
        protected float m_MaxCapacity;

        internal Engine(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;

            //On creation, charge to full
            m_CurrentQuantity = m_MaxCapacity;
        }

        protected void addQuantity(float i_Quantity)
        {
            if (m_CurrentQuantity + i_Quantity > m_MaxCapacity)
            {
               throw new ValueOutOfRangeException(m_CurrentQuantity, m_MaxCapacity, i_Quantity);
            }
        }

    }
}
