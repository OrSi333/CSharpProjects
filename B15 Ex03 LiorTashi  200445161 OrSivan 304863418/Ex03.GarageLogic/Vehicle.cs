using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract internal class Vehicle
    {
        private string m_modelName;
        private string m_LicenseNumber;
        protected float m_EnergyLeft;
        protected Wheel[] m_WheelSet;
    }
}
