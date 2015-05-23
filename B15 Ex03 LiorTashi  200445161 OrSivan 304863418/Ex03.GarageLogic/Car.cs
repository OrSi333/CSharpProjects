using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
        private eColor m_carColor;
        private eNumberOfDoors m_numOfDoors;
        private Engine m_engine;

        internal Car(eColor i_CarColor, eNumberOfDoors i_NumOfDoors, Engine i_Engine ,string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure):
            base(i_ModelName, i_LicenseNumber,i_Engine , i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_carColor = i_CarColor;
            m_numOfDoors = i_NumOfDoors;
        }
            

        internal protected enum eColor
        {
            Green,
            Black,
            White,
            Red
        };

        internal protected enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        };

        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Car color: {0}{1}The car contains {2} doors{3}", m_carColor, Environment.NewLine, m_numOfDoors, Environment.NewLine);
            return allInfo;
        }
    }
}
