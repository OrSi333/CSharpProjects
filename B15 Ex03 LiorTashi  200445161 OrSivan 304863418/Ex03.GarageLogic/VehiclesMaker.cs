using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;

namespace Ex03.GarageLogic
{
    public class VehiclesMaker
    {
        internal readonly List<Type> r_allSupportedVehicles = new List<Type>
        {
            typeof(ElectricCarModel),
            typeof(FuelCarModel),
            typeof(ElectricBikeModel),
            typeof(FuelBikeModel),
            typeof(TruckModel)
        };

        public List<Type> AllSupportedVehicles
        {
            get
            {
                return r_allSupportedVehicles;
            }
        }


        internal Vehicle makeVehicle(VehicleModel i_Model)
        {
            return makeVehicle(r_allSupportedVehicles.IndexOf(i_Model.GetType()), i_Model);
        }

        public Vehicle makeVehicle(int typeNumberInList, VehicleModel i_Model)
        {
            switch (typeNumberInList)
            {
                case 0: return (makeElectricCar(i_Model as ElectricCarModel));
                case 1: return (makeRegularCar(i_Model as FuelCarModel));
                case 2: return (makeElectricBike(i_Model as ElectricBikeModel));
                case 3: return (makeRegularBike(i_Model as FuelBikeModel));
                case 4: return (makeTruck(i_Model as TruckModel));
                default: throw new ArgumentException("This type of vehicle is not supported", i_Model.ToString());
            }
        }


        internal FuelBike makeRegularBike(FuelBikeModel i_Model)
        {
            if ((i_Model.m_fuelType != eFuelType.Octan98 || i_Model.m_EngineCapacity != 8f) ||
                (i_Model.m_NumOfWheels != 2 || i_Model.m_WheelMaxAirPressure != 34))
            {
                throw new ArgumentException("This type of fuel bike is not supported", i_Model.ToString());
            }
            
            return new FuelBike(i_Model);
        }

        internal ElectricBike makeElectricBike(ElectricBikeModel i_Model)
        {
            if ((i_Model.m_EngineCapacity != 1.2f) ||
                (i_Model.m_NumOfWheels != 2 || i_Model.m_WheelMaxAirPressure != 31))
            {
                throw new ArgumentException("This type of electric bike is not supported", i_Model.ToString());
            }
                
            return new ElectricBike(i_Model);
        }

        internal FuelCar makeRegularCar(FuelCarModel i_Model)
        {
            if ((i_Model.m_fuelType != eFuelType.Octan96 || i_Model.m_EngineCapacity != 35f) ||
                (i_Model.m_NumOfWheels != 4 || i_Model.m_WheelMaxAirPressure != 31))
            {
                throw new ArgumentException("This type of fuel bike is not supported", i_Model.ToString());
            }
            
            return new FuelCar(i_Model);
        }

        internal ElectircCar makeElectricCar(ElectricCarModel i_Model)
        {
            if ((i_Model.m_EngineCapacity != 2.2f) ||
                (i_Model.m_NumOfWheels != 4 || i_Model.m_WheelMaxAirPressure != 31))
            {
                throw new ArgumentException("This type of electric car is not supported", i_Model.ToString());
            }
            
            return new ElectircCar(i_Model);
        }

        internal Truck makeTruck(TruckModel i_Model)
        {
            if ((i_Model.m_fuelType != eFuelType.Soler || i_Model.m_EngineCapacity != 170f) ||
                (i_Model.m_NumOfWheels != 16 || i_Model.m_WheelMaxAirPressure != 25))
            {
                throw new ArgumentException("This type of truck is not supported", i_Model.ToString());
            }
            
            return new Truck(i_Model);
        }
    }
}
