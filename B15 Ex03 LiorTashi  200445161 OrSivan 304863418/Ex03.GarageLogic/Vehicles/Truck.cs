using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    class Truck : Vehicle
    {
        private bool m_isCarringDangerMat;
        private float m_currBagageWeight;

        internal Truck():
            base()
        {
            m_UniqParams.Add(new ParamHolder("Is carring hazard materials?", typeof(bool))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder("Current bagage wight", typeof(float))); m_numberOfBaseParams++;
        }

        public override void ImplementUniqParams()
        {
            base.ImplementUniqParams();
            m_isCarringDangerMat = (bool)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            m_currBagageWeight = (float)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
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
