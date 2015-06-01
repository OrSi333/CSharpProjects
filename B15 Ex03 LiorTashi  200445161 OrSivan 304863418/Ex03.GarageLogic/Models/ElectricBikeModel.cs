using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    class ElectricBikeModel : BikeModel
    {
        
        public ElectricBikeModel(float i_EngineCapacity, float i_EngineCurrentEnergy ,Enums.eLisenceType i_LisenceType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_LisenceType, i_MotorVolume, i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_EngineCurrentEnergy = i_EngineCurrentEnergy;
        }

        public override string getAllParams()
        {
            return string.Format("{0}Charge capacity{1}Current charge{2}", base.getAllParams(), Environment.NewLine, Environment.NewLine);
        }
    }
}
