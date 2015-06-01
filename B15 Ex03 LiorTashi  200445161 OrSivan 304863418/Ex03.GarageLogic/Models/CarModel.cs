using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Models
{
    public class CarModel : VehicleModel
    {
        internal Enums.eColor m_carColor;
        internal Enums.eNumberOfDoors m_numOfDoors;

        public CarModel(string i_ModelName, string i_LicenseNum, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure,Enums.eColor i_Color, Enums.eNumberOfDoors i_NumOfDoors):
            base(i_ModelName, i_LicenseNum, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_carColor = i_Color;
            m_numOfDoors = i_NumOfDoors;
        }

        public override string getAllParams()
        {
            return string.Format("{0}Car color{1}Number of doors{2}", base.getAllParams(), Environment.NewLine, Environment.NewLine);
        }
    }
}
