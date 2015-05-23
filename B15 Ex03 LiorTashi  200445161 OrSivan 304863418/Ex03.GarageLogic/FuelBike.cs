using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelBike
    {

        internal FuelBike(eLisenceType i_LisenceType, int i_MotorVolume, FuelEngine i_ElectricEngine, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_LisenceType, i_MotorVolume, i_ElectricEngine, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        { }

        public void addFuel(float i_FuelToAdd, FuelEngine.eFuelType i_FuelType)
        {
            (m_Engine as FuelEngine).addFuel(i_FuelToAdd, i_FuelType);
        }
    }
}
