using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleComponents
{
    public class Wheel
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

        internal void InflateWheel(float i_AirToAdd)
        {
            if (m_currentAirPressure + i_AirToAdd > m_maxAirPressure)
            {
                throw new ValueOutOfRangeException(m_currentAirPressure, m_maxAirPressure, i_AirToAdd);
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

        public override string ToString()
        {
            return string.Format("Wheel maker : {0}, max air pressure : {1}, current air pressure : {2}",m_makerName,m_maxAirPressure,m_currentAirPressure);
        }
    }
}
