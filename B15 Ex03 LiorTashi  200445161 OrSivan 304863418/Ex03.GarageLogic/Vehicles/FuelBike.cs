using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelBike : Bike
    {

        internal FuelBike(eLisenceType i_LisenceType, int i_MotorVolume, FuelEngine i_ElectricEngine, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_LisenceType, i_MotorVolume, i_ElectricEngine, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        { }

        internal void addFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            (m_Engine as FuelEngine).addFuel(i_FuelToAdd, i_FuelType);
        }

        internal eFuelType FuelType
        {
            get
            {
                return (m_Engine as FuelEngine).FuelType;
            }
        }

        internal float FuelLeft
        {
            get
            {
                return (m_Engine as FuelEngine).CurrentAmmountOfFuel;
            }
        }

        internal float FuelCapacity
        {
            get
            {
                return (m_Engine as FuelEngine).MaxFuelCapacity;
            }
        }
    }
}
