using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private eColor m_carColor;
        private eNumberOfDoors m_numOfDoors;
        private PowerSource m_powerSource;

        internal Car(eColor i_CarColor, eNumberOfDoors i_NumOfDoors, PowerSource i_PowerSource ,string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure):
            base(i_ModelName, i_LicenseNumber,i_PowerSource , i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_carColor = i_CarColor;
            m_numOfDoors = i_NumOfDoors;
        }
            

        internal enum eColor
        {
            Green,
            Black,
            White,
            Red
        };

        internal enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        };
    }
}
