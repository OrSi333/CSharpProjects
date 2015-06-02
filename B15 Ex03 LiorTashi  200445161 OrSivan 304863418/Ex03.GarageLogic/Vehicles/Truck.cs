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

        internal Truck(Models.VehicleModel i_Model):
            base(i_Model)
        {
            m_UniqParams = new List<ParamHolder>();
            m_UniqParams.Add("Is carring hazard materials?", typeof(bool));
            m_UniqParams.Add("Current bagage wight", typeof(float));
        }

        public override void ImplementUniqParams()
        {
            base.m_UniqParams();
            m_isCarringDangerMat = (bool)m_UniqParams[0];
            m_currBagageWeight = (float)m_UniqParams[1];
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
