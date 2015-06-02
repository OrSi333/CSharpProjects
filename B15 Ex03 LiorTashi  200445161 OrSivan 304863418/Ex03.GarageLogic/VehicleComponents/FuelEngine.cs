using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class FuelEngine : Engine
    {
        private eFuelType m_fuelType;

        internal FuelEngine(float i_MaxFuelCapacity, eFuelType i_FuelType) :
            base(i_MaxFuelCapacity)
        {
            m_fuelType = i_FuelType;
        }


        public void addFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (!(i_FuelType == m_fuelType))
            {
                string errorMsg = string.Format("This engine takes {0} fuel, but you tried to insert {1}!", m_fuelType.ToString(), i_FuelType.ToString());
                throw new ArgumentException(errorMsg);
            }
            if (m_CurrentQuantity + i_FuelToAdd > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(m_CurrentQuantity, m_MaxCapacity, i_FuelToAdd);
            }
            base.addQuantity(i_FuelToAdd);
        }

        internal eFuelType FuelType
        {
            get
            {
                return m_fuelType;
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel left: {0} liters{1}Fuel Capacity: {2} liters{3}Fuel type {4}{5}", 
                m_CurrentQuantity, Environment.NewLine, m_MaxCapacity, Environment.NewLine,m_fuelType,Environment.NewLine);
        }
    }
}
