using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectircCar : Car
    {

        internal ElectircCar(eColor i_CarColor, eNumberOfDoors i_NumOfDoors, ElectricEngine i_ElectricEngine, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_CarColor, i_NumOfDoors, i_ElectricEngine, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {

        }

        internal void Charge(float i_HoursToAdd)
        {
            (m_Engine as ElectricEngine).chargePower(i_HoursToAdd);
        }

        internal float PowerLeft
        {
            get
            {
                return (m_Engine as ElectricEngine).RemainingPowerTime;
            }
        }

        internal float ChargeCapacity
        {
            get
            {
                return (m_Engine as ElectricEngine).MaxPowerTime;
            }
        }
    }
}
