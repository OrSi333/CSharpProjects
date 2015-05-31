using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;

namespace Ex03.GarageLogic
{
    internal class VehiclesMaker
    {
        

        internal VehiclesMaker()
        {
            
        }

        //TODO:
        internal Vehicle makeVehicle(VehicleModel i_Model)
        {
            Type modelType = i_Model.GetType();



            switch (typeof(i_Model))
            {
                case typeof(ElectricCarModel): return (makeElectricCar(i_Model as ElectricBikeModel)); break;
                case typeof(FuelCarModel): return (makeRegularCar(i_Model as FuelCarModel));
                case typeof(ElectricBikeModel): return (makeElectricBike(i_Model as ElectricBikeModel));
                case typeof(FuelBikeModel): return (makeRegularCar(i_Model as FuelBikeModel));
                case typeof(TruckModel): return (makeTruck(i_Model as TruckModel));
                default: throw new ArgumentException("This type of vehicle is not supported", i_Model.GetType().FullName);
            }
        }
        

        internal FuelBike makeRegularBike(BikeModel io_model)
        {
            
            return new FuelBike(i_LicenseType, i_MotorVolume, new FuelEngine(8f, eFuelType.Octan98), i_ModelName, i_LicenseNumber, 2, i_WheelMakerName, 34f);
        }

        internal ElectricBike makeElectricBike(eLisenceType i_LicenseType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new ElectricBike(i_LicenseType, i_MotorVolume, new ElectricEngine(1.2f), i_ModelName, i_LicenseNumber, 2, i_WheelMakerName, 31f);
        }

        internal FuelCar makeRegularCar(eColor i_CarColor, eNumberOfDoors i_NumOfDoors,int i_MotorVolume, string i_ModelName, string i_LicenseNumber,string i_WheelMakerName)
        {
            return new FuelCar(i_CarColor, i_NumOfDoors, new FuelEngine(35f, eFuelType.Octan96), i_ModelName, i_LicenseNumber, 4, i_WheelMakerName, 31f);
        }

        internal ElectircCar makeElectricCar(eColor i_CarColor, eNumberOfDoors i_NumOfDoors, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new ElectircCar(i_CarColor, i_NumOfDoors, new ElectricEngine(2.2f), i_ModelName, i_LicenseNumber, 4, i_WheelMakerName, 31f);
        }

        internal Truck makeTruck(bool i_ContainsHazard, float i_BagageWeight, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new Truck(i_ContainsHazard, i_BagageWeight, new FuelEngine(170f, eFuelType.Soler), i_ModelName, i_LicenseNumber, 16, i_WheelMakerName, 25f);
        }
    }
}
