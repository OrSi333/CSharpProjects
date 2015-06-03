using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    class Car : Vehicle
    {
        private eColor m_carColor;
        private eNumberOfDoors m_numOfDoors;

        internal Car():
            base()
        {
            m_UniqParams.Add(new ParamHolder("Car Color", typeof(eColor))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder("Number of doors", typeof(eNumberOfDoors))); m_numberOfBaseParams++;

        }

        public override void ImplementUniqParams()
        {
            base.ImplementUniqParams();
            m_carColor = (eColor)(m_UniqParams[m_numberOfBaseParams].Value); m_numberOfBaseParams++;
            m_numOfDoors = (eNumberOfDoors)(m_UniqParams[m_numberOfBaseParams].Value); m_numberOfBaseParams++;
        }
        
        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Car color: {0}{1}The car contains {2} doors{3}", m_carColor, Environment.NewLine, m_numOfDoors, Environment.NewLine);
            return allInfo;
        }
    }
}
