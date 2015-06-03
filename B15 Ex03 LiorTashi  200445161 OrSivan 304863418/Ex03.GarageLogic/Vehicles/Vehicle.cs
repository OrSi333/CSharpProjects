using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    abstract public class Vehicle
    {
        private string m_licenseNumber;
        private string m_modelName;
        protected float m_EnergyLeft;
        protected Wheel[] m_WheelSet;
        protected Engine m_Engine;
        protected int m_numberOfBaseParams = 0;
        protected int m_initParamCounter = 0;
        protected List<ParamHolder> m_UniqParams;

        public static readonly string s_LicenseNumberMsg = "License number";
        public static readonly string s_ModelNameMsg = "Model name";
        public static readonly string s_NumOfWheelMsg = "Number of wheels";
        public static readonly string s_WheelMakerName = "Wheel maker name";
        public static readonly string s_WheelMaxAirPressureMsg = "Wheel max air pressure";
        public static readonly string s_EngineCapacityMsg = "Engine Max Capacity";
        public static readonly string s_EngineQuantityMsg = "Engine Current Quantity";

        protected Vehicle()
        {
            m_UniqParams = new List<ParamHolder>();
            m_UniqParams.Add(new ParamHolder(s_LicenseNumberMsg, typeof(string))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder(s_ModelNameMsg, typeof(string))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder(s_NumOfWheelMsg, typeof(int))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder(s_WheelMakerName, typeof(string))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder(s_WheelMaxAirPressureMsg, typeof(float))); m_numberOfBaseParams++;
            m_UniqParams.Add(new ParamHolder(s_EngineCapacityMsg, typeof(float)));
            m_UniqParams.Add(new ParamHolder(s_EngineQuantityMsg, typeof(float)));
        }

        public List<ParamHolder> UniqParams
        {
            get
            {
                return m_UniqParams;
            }
        }

        //Init the variables in the same order as they were added to the list
        public virtual void ImplementUniqParams()
        {
            foreach (ParamHolder parameter in m_UniqParams)
            {
                if (parameter.Value == null)
                {
                    throw new ArgumentNullException(string.Format("{0} was not initialized",parameter.ToString()), parameter.Value.ToString());
                }
            }

            m_licenseNumber = (string)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            m_modelName = (string)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            int numOfWheels = (int)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            string wheelMakerName = (string)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            float wheelMaxAirPressure = (float)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            m_WheelSet = new Wheel[numOfWheels];

            for (int i = 0; i < m_WheelSet.Length; i++)
            {
                m_WheelSet[i] = new Wheel(wheelMakerName, wheelMaxAirPressure);
            }

            m_Engine.MaxCapacity = (float)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
            m_Engine.CurrentQuantity = (float)(m_UniqParams[m_initParamCounter].Value); m_initParamCounter++;
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelSet)
            {
                if (wheel.AirToFill > 0)
                {
                    wheel.InflateWheel(wheel.AirToFill);
                }
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_Engine;
            }
            set { m_Engine = value; }
        }

        public string LicenseNumber
        {
            get { return m_licenseNumber; }
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
                equals = ((Vehicle)obj).m_licenseNumber.Equals(this.m_licenseNumber);
            }
            else if (obj is string)
            {
                equals = ((String)obj).Equals(this.m_licenseNumber);
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
