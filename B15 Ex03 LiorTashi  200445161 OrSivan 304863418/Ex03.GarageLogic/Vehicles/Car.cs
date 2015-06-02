using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    class Car : Vehicle
    {
        private eColor m_carColor;
        private eNumberOfDoors m_numOfDoors;

        internal Car(Models.VehicleModel i_Model):
            base(i_Model)
        {
            m_UniqParams = new List<ParamHolder>();
            m_UniqParams.Add(new ParamHolder("Car Color", typeof(eColor)));
            m_UniqParams.Add(new ParamHolder("Number of doors", typeof(eNumberOfDoors)));

        }

        public override void ImplementUniqParams()
        {
            base.ImplementUniqParams();
            m_carColor = (eColor)m_UniqParams[0];
            m_numOfDoors = (eNumberOfDoors)m_UniqParams[1];
        }
        
        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Car color: {0}{1}The car contains {2} doors{3}", m_carColor, Environment.NewLine, m_numOfDoors, Environment.NewLine);
            return allInfo;
        }
    }
}
