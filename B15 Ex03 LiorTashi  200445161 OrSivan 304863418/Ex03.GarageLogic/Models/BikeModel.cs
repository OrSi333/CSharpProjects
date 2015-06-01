using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Models
{
    public class BikeModel : VehicleModel
    {
        internal eLisenceType m_licenseType;
        internal int m_motorVolume;

        public BikeModel(Enums.eLisenceType i_LisenceType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure) :
            base(i_ModelName, i_LicenseNumber, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_licenseType = i_LisenceType;
            m_motorVolume = i_MotorVolume;
        }

        public override string getAllParams()
        {
            return string.Format("{0}Lisence Type{1}Motor Volume{2}",base.getAllParams(),Environment.NewLine,Environment.NewLine);
        }
    }
}
