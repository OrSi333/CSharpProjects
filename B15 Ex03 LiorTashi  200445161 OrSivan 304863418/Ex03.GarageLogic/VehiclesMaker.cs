using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehiclesMaker
    {
        

        internal VehiclesMaker()
        {
            
        }

        

        internal FuelBike makeRegularBike(Bike.eLisenceType i_LicenseType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber,string i_WheelMakerName)
        {
            return new FuelBike(i_LicenseType, i_MotorVolume, new FuelEngine(8f, eFuelType.Octan98), i_ModelName, i_LicenseNumber, 2, i_WheelMakerName, 34f);
        }

        internal ElectricBike makeElectricBike(Bike.eLisenceType i_LicenseType, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new ElectricBike(i_LicenseType, i_MotorVolume, new ElectricEngine(1.2f), i_ModelName, i_LicenseNumber, 2, i_WheelMakerName, 31f);
        }

        internal FuelCar makeRegularCar(Car.eColor i_CarColor, Car.eNumberOfDoors i_NumOfDoors,int i_MotorVolume, string i_ModelName, string i_LicenseNumber,string i_WheelMakerName)
        {
            return new FuelCar(i_CarColor, i_NumOfDoors, new FuelEngine(35f, eFuelType.Octan96), i_ModelName, i_LicenseNumber, 4, i_WheelMakerName, 31f);
        }

        internal ElectircCar makeElectricCar(Car.eColor i_CarColor, Car.eNumberOfDoors i_NumOfDoors, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new ElectircCar(i_CarColor, i_NumOfDoors, new ElectricEngine(2.2f), i_ModelName, i_LicenseNumber, 4, i_WheelMakerName, 31f);
        }

        internal Truck makeTruck(bool i_ContainsHazard, float i_BagageWeight, int i_MotorVolume, string i_ModelName, string i_LicenseNumber, string i_WheelMakerName)
        {
            return new Truck(i_ContainsHazard, i_BagageWeight, new FuelEngine(170f, eFuelType.Soler), i_ModelName, i_LicenseNumber, 16, i_WheelMakerName, 25f);
        }
    }
}
