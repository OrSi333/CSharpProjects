using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class VehicleModel
    {
        protected bool finishedInit = false;
        internal string m_modelName;
        internal string m_licenseNumber;
        internal int m_NumOfWheels;
        internal string m_WheelMakerName;
        internal float m_WheelMaxAirPressure;
        protected internal float m_EngineCapacity;
        protected internal float m_EngineCurrentEnergy;

        public VehicleModel(string i_ModelName, string i_LicenseNum, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure)
        {
            m_modelName = i_ModelName;
            m_licenseNumber = i_LicenseNum;
            m_NumOfWheels = i_NumOfWheels;
            m_WheelMakerName = i_WheelMakerName;
            m_WheelMaxAirPressure = i_WheelMaxAirPressure;
        }

        public virtual string getAllParams()
        {
            return string.Format("Model Name{0}License Number{1}Number of wheels{2}Wheel maker name{3}Wheels max air pressure{4}",
                Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);
        }
    }
}
