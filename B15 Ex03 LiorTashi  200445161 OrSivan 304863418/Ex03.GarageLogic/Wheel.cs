using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_makerName;
        private float m_currentAirPressure;
        private readonly float m_maxAirPressure;

        internal Wheel(string i_MakerName, float i_MaxAirPressure)
        {
            m_makerName = i_MakerName;
            m_maxAirPressure = i_MaxAirPressure;

            //Inflate wheel to maximum on creation
            m_currentAirPressure = m_maxAirPressure;
        }

        //TODO: Add the correct exception
        internal void InflateWheel(float i_AirToAdd)
        {
            if (m_currentAirPressure + i_AirToAdd > m_maxAirPressure)
            {
                throw new Exception();
            }
            else
            {
                m_currentAirPressure += i_AirToAdd;
            }
        }

        internal float CurrentAirPresusre
        {
            get
            {
                return m_currentAirPressure;
            }
        }

        internal float AirToFill
        {
            get
            {
                return m_maxAirPressure - m_currentAirPressure;
            }
        }
    }
}
