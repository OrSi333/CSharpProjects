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

        internal Bike(eLisenceType i_LisenceType, int i_MotorVolume, PowerSource i_PowerSource, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_ModelName, i_LicenseNumber, i_PowerSource, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_licenseType = i_LisenceType;
            m_motorVolume = i_MotorVolume;
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
