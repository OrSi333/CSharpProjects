using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    //TODO: Make the class
    internal class Bike : Vehicle
    {
        private eLisenceType m_licenseType;
        private int m_motorVolume;

        internal Bike(Models.VehicleModel i_Model) :
            base(i_Model)
        {
            m_UniqParams = new List<ParamHolder>();
            uniqParams.Add(new ParamHolder("Lisence Type", typeof(eLisenceType)));
            uniqParams.Add(new ParamHolder("Motor Volume", typeof(int)));
        }


        public override void ImplementUniqParams()
        {
            base.ImplementUniqParams();
            m_licenseType = (eLisenceType)m_UniqParams[0].Value;
            m_motorVolume = (int)m_UniqParams[1].Value;
        }

        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Engine volume: {0}{1}License type: {2},{3}", m_motorVolume, Environment.NewLine, m_licenseType, Environment.NewLine);
            return allInfo;
        }
    }
}
