using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    class TruckModel : VehicleModel
    {
        internal bool m_isCarringDangerMat;
        internal float m_currBagageWeight;
        internal eFuelType m_fuelType;

        public TruckModel(eFuelType i_FuelType, bool i_IsCarringHazard, float i_CurrBagageWeight, string i_ModelName, string i_LicenseNum, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_ModelName, i_LicenseNum, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_isCarringDangerMat = i_IsCarringHazard;
            m_currBagageWeight = i_CurrBagageWeight;
            m_fuelType = i_FuelType;
        }
    }
}
