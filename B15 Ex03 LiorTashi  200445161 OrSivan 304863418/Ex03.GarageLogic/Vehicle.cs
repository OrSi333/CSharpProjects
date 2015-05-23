using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract internal class Vehicle
    {
        private string m_modelName;
        private string m_licenseNumber;
        protected float m_EnergyLeft;
        protected Wheel[] m_WheelSet;
        protected Engine m_Engine;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, PowerSource i_Engine, int i_NumOfWheels, string i_WheelMakerName, float i_WheelMaxAirPressure)
        {
            m_licenseNumber = i_LicenseNumber;
            m_modelName = i_ModelName;
            m_Engine = i_Engine;
            m_WheelSet = new Wheel[i_NumOfWheels];
            foreach (Wheel wheel in m_WheelSet)
            {
                wheel = new Wheel(i_WheelMakerName, i_WheelMaxAirPressure);
            }

        }

        internal void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelSet)
            {
                if (wheel.AirToFill > 0)
                {
                    wheel.InflateWheel(wheel.AirToFill);
                }
            }
        }

        //We are overriding the toString method in order to present the vehicle's information.
        public override string ToString()
        {
            string allInfo = string.Format("License number: {0}{1} Model: {2}{3}",m_licenseNumber,Environment.NewLine,m_modelName,Environment.NewLine);
            allInfo += string.Format("Wheels info:{0}", Environment.NewLine);
            foreach (Wheel wheel in m_WheelSet)
            {
                allInfo += wheel.ToString();
            }

            allInfo += string.Format("Engine info:{0}{1}", Environment.NewLine, m_Engine.ToString());
            return allInfo;
            
        }

        //The following methods will override comparison operators in order to allow collections to sort them.
        //The comparison will be preformed by the vehicles license number.

        public override bool Equals(object obj)
        {
            (obj as Vehicle).m_licenseNumber.Equals(this.m_licenseNumber);
        }

        public static bool operator ==(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            bool vehiclesAreEqual = false;
            if (i_Vehicle1.Equals(i_Vehicle2))
            {
                vehiclesAreEqual = true;
            }

            return vehiclesAreEqual;
        }

        public static bool operator !=(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            bool vehiclesAreNotEqual = false;
            if (!i_Vehicle1.Equals(i_Vehicle2))
            {
                vehiclesAreNotEqual = true;
            }

            return vehiclesAreNotEqual;
        }

        public static bool operator >(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            bool v1IsBigger = false;
            if (int.Parse(i_Vehicle1.m_licenseNumber)>int.Parse(i_Vehicle2.m_licenseNumber))
            {
                v1IsBigger = true;
            }

            return v1IsBigger;
        }

        public static bool operator <(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            bool v1IsSmaller = false;
            if (int.Parse(i_Vehicle1.m_licenseNumber) < int.Parse(i_Vehicle2.m_licenseNumber))
            {
                v1IsSmaller = true;
            }

            return v1IsSmaller;
        }





    }
}
