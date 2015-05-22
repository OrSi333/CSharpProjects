using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_modelName;
        private string m_licenseNumber;
        protected float m_EnergyLeft;
        protected Wheel[] m_WheelSet;
        protected PowerSource m_powerSource;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, PowerSource i_PowerSource, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure)
        {
            m_licenseNumber = i_LicenseNumber;
            m_modelName = i_ModelName;
            m_powerSource = i_PowerSource;
            m_WheelSet = new Wheel[i_NumOfWheels];
            foreach (Wheel wheel in m_WheelSet)
            {
                wheel = new Wheel(i_WheelMakerName, i_WheelMaxAirPressure);
            }

        }

        internal void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelSet)
            {
                if (wheel.AirToFill > 0)
                {
                    wheel.InflateWheel(wheel.AirToFill);
                }
            }
        }

    }
}
