using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    //TODO: Make the class
    internal class Bike : Vehicle
    {
        private eLisenceType m_licenseType;
        private int m_motorVolume;

        internal Bike(Models.BikeModel i_Model) :
            base(i_Model)
        {
            m_licenseType = i_Model.m_licenseType;
            m_motorVolume = i_Model.m_motorVolume;
        }


        public override string ToString()
        {
            string allInfo = base.ToString();
            allInfo += string.Format("Engine volume: {0}{1}License type: {2},{3}", m_motorVolume, Environment.NewLine, m_licenseType, Environment.NewLine);
            return allInfo;
        }
    }
}
