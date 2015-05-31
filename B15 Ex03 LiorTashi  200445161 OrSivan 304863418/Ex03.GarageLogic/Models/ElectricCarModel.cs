using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class ElectricCarModel : CarModel
    {
        

        public ElectricCarModel(float i_EngineCapacity, float i_EngineCurrentEnergy, string i_ModelName, string i_LicenseNum, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure,eColor i_Color, eNumberOfDoors i_NumOfDoors):
            base(i_ModelName, i_LicenseNum, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure, i_Color, i_NumOfDoors)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_EngineCurrentEnergy = i_EngineCurrentEnergy;
        }
    }
}
