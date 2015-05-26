using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : Car
    {

        internal FuelCar(eColor i_CarColor, eNumberOfDoors i_NumOfDoors, FuelEngine i_ElectricEngine, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_CarColor, i_NumOfDoors, i_ElectricEngine, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
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
