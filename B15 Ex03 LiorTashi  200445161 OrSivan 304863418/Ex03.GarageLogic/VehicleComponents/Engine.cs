﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleComponents
{
    abstract public class Engine
    {
        protected float m_CurrentQuantity;
        protected float m_MaxCapacity;

        public Engine()
        {
            
        }

        public float EnergyLeft
        {
            get
            {
                return 100f*m_CurrentQuantity / m_MaxCapacity;
            }
        }

        public float MaxCapacity
        {
            get { return m_MaxCapacity; }
            set { m_MaxCapacity = value; }
        }

        public float CurrentQuantity
        {
            get { return m_CurrentQuantity;}
            set { m_CurrentQuantity = value; }
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
