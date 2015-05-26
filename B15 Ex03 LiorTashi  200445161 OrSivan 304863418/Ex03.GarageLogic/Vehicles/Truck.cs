using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_isCarringDangerMat;
        private float m_currBagageWeight;

        internal Truck(bool i_IsCarringDangerMat, float i_CurrBagageWeight, Engine i_Engine ,string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure):
            base(i_ModelName, i_LicenseNumber, i_Engine, i_NumOfWheels, i_WheelMakerName, i_WheelMaxAirPressure)
        {
            m_currBagageWeight = i_CurrBagageWeight;
            m_isCarringDangerMat = i_IsCarringDangerMat;
        }

        public override string ToString()
        {
            string allInfo = base.ToString();
            string containsHazard = "";
            if (!m_isCarringDangerMat)
            {
                containsHazard = "doesn't ";
            }
            allInfo += string.Format("Truck's current bagage weight {0}{1}The truck {2}contains dangerous materials",
                m_currBagageWeight, Environment.NewLine, containsHazard, Environment.NewLine);
            return allInfo;
        }
    }
}
