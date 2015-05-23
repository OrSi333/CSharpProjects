using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class VehicleModel
    {
        internal string m_modelName;
        internal string m_licenseNumber;
        internal int m_NumOfWheels;
        internal string m_WheelMakerName;
        internal float m_WheelMaxAirPressure;

        public VehicleModel(string i_ModelName, string i_LicenseNum, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure)
        {
            m_modelName = i_ModelName;
            m_licenseNumber = i_LicenseNum;
            m_NumOfWheels = i_NumOfWheels;
            m_WheelMakerName = i_WheelMakerName;
            m_WheelMaxAirPressure = i_WheelMaxAirPressure;
        }
    }
}
