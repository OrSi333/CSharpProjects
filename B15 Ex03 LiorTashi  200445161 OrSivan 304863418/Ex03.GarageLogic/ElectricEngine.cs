using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {

        internal ElectricEngine(float i_MaxPowerTime) :
            base(i_MaxPowerTime)
        {
            
        }
        
        float RemainingPowerTime
        {
            get
            {
                return m_CurrentQuantity;
            }
        }

        float MaxPowerTime
        {
            get
            {
                return m_MaxCapacity;
            }
        }

        internal void chargePower(float i_HoursToAdd)
        {
            if (m_CurrentQuantity + i_HoursToAdd > m_MaxCapacity)
            {
                throw ValueOutOfRangeException(m_CurrentQuantity, m_MaxCapacity, i_HoursToAdd);
            }
            base.addQuantity(i_HoursToAdd);
        }

        public override string ToString()
        {
            return string.Format("Energy left: {0} hours{1} Energy Capacity: {2} hours{3}", m_CurrentQuantity, Environment.NewLine, m_MaxCapacity, Environment.NewLine);
        }
    }
}
