using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    //TODO: Make the class
    internal class Bike : Vehicle
    {

        private eLisenceType m_licenseType;
        private int m_motorVolume;
        private PowerSource m_powerSource;

        internal Bike(eLisenceType i_LisenceType, int i_MotorVolume, PowerSource i_PowerSource) : 
            base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_licenseType = i_LisenceType;
            m_motorVolume = i_MotorVolume;
            m_powerSource = i_PowerSource;
        }

        internal enum eLisenceType
        {
            A,
            A2,
            AB,
            B1
        };
    }
}
