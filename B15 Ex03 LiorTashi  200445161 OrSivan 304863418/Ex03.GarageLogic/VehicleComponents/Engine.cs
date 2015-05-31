using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleComponents
{
    abstract public class Engine
    {
        protected float m_CurrentQuantity;
        protected float m_MaxCapacity;

        //TODO: delete this
        internal Engine(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrentQuantity = m_MaxCapacity;
        }

        internal Engine(float i_MaxCapacity, float i_CurrentQuantity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrentQuantity = i_CurrentQuantity;
        }

        protected void addQuantity(float i_Quantity)
        {
            if (m_CurrentQuantity + i_Quantity > m_MaxCapacity)
            {
               throw new ValueOutOfRangeException(m_CurrentQuantity, m_MaxCapacity, i_Quantity);
            }
            else
            {
                m_CurrentQuantity += i_Quantity;
            }
        }

    }
}
