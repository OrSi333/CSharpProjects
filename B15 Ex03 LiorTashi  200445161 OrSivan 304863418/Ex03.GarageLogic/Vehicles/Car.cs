using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private Enums.eColor m_carColor;
        private Enums.eNumberOfDoors m_numOfDoors;

        internal Car(Models.CarModel i_Model):
            base(i_Model)
        {
            m_carColor = i_CarColor;
            m_numOfDoors = i_NumOfDoors;
        }
        
        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Car color: {0}{1}The car contains {2} doors{3}", m_carColor, Environment.NewLine, m_numOfDoors, Environment.NewLine);
            return allInfo;
        }
    }
}
