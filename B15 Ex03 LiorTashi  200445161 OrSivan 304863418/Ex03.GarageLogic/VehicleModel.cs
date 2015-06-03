//using System;
//using System.Collections.Generic;
//using Ex03.GarageLogic.VehicleComponents;

//namespace Ex03.GarageLogic
//{
//    public struct VehicleModel
//    {
        
//        private string m_modelName;
//        private string m_licenseNumber;
//        private int m_NumOfWheels;
//        private string m_WheelMakerName;
//        private float m_WheelMaxAirPressure;
//        private Engine m_Engine;

//        public VehicleModel()
//        {
//            m_modelName = i_ModelName;
//            m_licenseNumber = i_LicenseNum;
//            m_NumOfWheels = i_NumOfWheels;
//            m_WheelMakerName = i_WheelMakerName;
//            m_WheelMaxAirPressure = i_WheelMaxAirPressure;
//            m_Engine = i_Engine;
            
//        }

//        public string ModelName
//        {
//            get { return m_modelName; }
//        }

//        public string LicenseNumber
//        {
//            get { return m_licenseNumber; }
//        }

//        public int NumberOfWheels
//        {
//            get { return m_NumOfWheels; }
//        }

//        public string WheelMakerName
//        {
//            get { return m_WheelMakerName;}
//        }

//        public float WheelMaxPressure
//        {
//            get { return m_WheelMaxAirPressure; }
//        }

//        public Engine VehicleEngine
//        {
//            get { return m_Engine; }
//        }

//        public override string ToString()
//        {
//            return string.Format("Model Name{0}License Number{1}Number of wheels{2}Wheel maker name{3}Wheels max air pressure{4}",
//                Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);

//        }
//    }
//}
