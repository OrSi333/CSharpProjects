using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricBike : Bike
    {

        internal ElectricBike(eLisenceType i_LisenceType, int i_MotorVolume, ElectricEngine i_ElectricEngine, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure):
            base(i_LisenceType, i_MotorVolume, i_ElectricEngine, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        { }

        public void chargePower(float i_HoursToAdd)
        {
            (m_Engine as ElectricEngine).chargePower(i_HoursToAdd);
        }
    }
}
