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

        internal Bike() :
            base()
        {
            m_UniqParams.Add(new ParamHolder("Lisence Type", typeof(eLisenceType))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder("Motor Volume", typeof(int))); m_numberOfBaseParams++;
        }


        public override void ImplementUniqParams()
        {
            base.ImplementUniqParams();
            m_licenseType = (eLisenceType)m_UniqParams[m_initParamCounter].Value; m_initParamCounter++;
            m_motorVolume = (int)m_UniqParams[m_initParamCounter].Value; m_initParamCounter++;
        }

        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Engine volume: {0}{1}License type: {2},{3}", m_motorVolume, Environment.NewLine, m_licenseType, Environment.NewLine);
            return allInfo;
        }
    }
}
