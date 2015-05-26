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
        

        protected Vehicle(Models.VehicleModel i_Model)
        {
            m_licenseNumber = i_Model.m_licenseNumber;
            m_modelName = i_Model.m_modelName;
            m_WheelSet = new Wheel[i_Model.m_NumOfWheels];
            for (int i = 0; i < m_WheelSet.Length; i++)
            {
                m_WheelSet[i] = new Wheel(i_Model.m_WheelMakerName, i_Model.m_WheelMaxAirPressure);
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
        //The comparison also supports comparing with another string contning the license number, to enable collection comparison

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj is Vehicle)
            {
                equals = (Vehicle)obj.m_licenseNumber.Equals(this.m_licenseNumber);
            }
            else if (obj is string)
            {
                equals = (String)obj.Equals(this.m_licenseNumber);
            }

            else
            {
                throw new InvalidCastException();
            }
            return equals;
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

    }
}
