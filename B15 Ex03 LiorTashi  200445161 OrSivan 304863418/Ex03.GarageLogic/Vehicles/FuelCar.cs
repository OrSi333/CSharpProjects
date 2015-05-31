using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic
{
    class FuelCar : Car
    {

        internal FuelCar(Models.CarModel i_Model) :
            base(i_Model)
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
