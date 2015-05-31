using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_isCarringDangerMat;
        private float m_currBagageWeight;

        internal Truck(Models.TruckModel i_Model):
            base(i_Model)
        {
            m_currBagageWeight = i_Model.m_currBagageWeight;
            m_isCarringDangerMat = i_Model.m_isCarringDangerMat; ;
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
