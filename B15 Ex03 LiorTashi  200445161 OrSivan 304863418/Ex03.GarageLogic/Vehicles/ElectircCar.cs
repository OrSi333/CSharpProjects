using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic
{
    internal class ElectircCar : Car
    {

        internal ElectircCar(Models.CarModel i_Model) :
            base(i_Model)
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
