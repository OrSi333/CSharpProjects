using System;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class FuelBikeModel : BikeModel
    {
        internal eFuelType m_fuelType;

        public FuelBikeModel(eFuelType i_FuelType, float i_EngineCapacity, float i_EngineCurrentEnergy, eLisenceType i_LisenceType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_LisenceType, i_MotorVolume, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_EngineCurrentEnergy = i_EngineCurrentEnergy;
            m_fuelType = i_FuelType;
        }
    }
}
