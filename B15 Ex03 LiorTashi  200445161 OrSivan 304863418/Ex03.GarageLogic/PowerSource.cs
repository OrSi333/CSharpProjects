﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //TODO: Documentation
    abstract class PowerSource
    {
        protected float m_CurrentQuantity;
        protected float m_MaxCapacity;

        protected void charge(float i_Quantity)
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
