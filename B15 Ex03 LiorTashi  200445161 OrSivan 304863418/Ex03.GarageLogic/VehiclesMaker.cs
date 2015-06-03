using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic
{
    public class VehiclesMaker
    {
        ParamHolder currentParamHolder;
        public void makeVehicle(SupportedVehicle i_VehicleToCreate, out Vehicle o_CreatedVehicle)
        {
            switch (i_VehicleToCreate)
            {
                case SupportedVehicle.ElectricCar: 
                    makeElectricCar(out o_CreatedVehicle); 
                    break;
                default: o_CreatedVehicle = null;
                    throw new ArgumentException("The garage doesn't support this kind of vehicle yes", i_VehicleToCreate.ToString());
            }
        }

        private void makeElectricCar(out Vehicle o_CreatedVehicle)
        {
            o_CreatedVehicle = new Car();
            o_CreatedVehicle.VehicleEngine = new ElectricEngine();
            currentParamHolder = o_CreatedVehicle.UniqParams.Find(item => item.Equals(Vehicle.s_EngineCapacityMsg));
            currentParamHolder.Value = 2.2f;
            currentParamHolder = o_CreatedVehicle.UniqParams.Find(item => item.Equals(Vehicle.s_NumOfWheelMsg));
            currentParamHolder.Value = 4;
            currentParamHolder = o_CreatedVehicle.UniqParams.Find(item => item.Equals(Vehicle.s_WheelMaxAirPressureMsg));
            currentParamHolder.Value = 31.0f;
        }

        public enum SupportedVehicle
        {
            ElectricCar = 1,
            ElectricBike,
            FuelCar,
            FuelBike,
            Truck
        }
    }
}
