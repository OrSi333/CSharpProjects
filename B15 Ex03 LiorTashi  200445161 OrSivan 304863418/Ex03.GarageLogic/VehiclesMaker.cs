using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class VehiclesMaker
    {

        public Vehicle makeVehicle(SupportedVehicle i_VehicleToCreate,VehicleModel i_Model)
        {
            switch (i_VehicleToCreate)
            {
                case SupportedVehicle.ElectricCar: return makeElectricCar(i_Model);
                
            }
        }

        private Vehicle makeElectricCar(VehicleModel i_Model)
        {
            checkModelParameter(i_Model.NumberOfWheels, 4, "number of wheels", "electric car");
            checkModelParameter(i_Model.WheelMaxPressure, 31, "wheel max air pressure", "electric car");
            checkModelParameter(i_Model.VehicleEngine.MaxCapacity, 2.2f, "hours charge capacity", "electric car");
            return new Car(i_Model);

        }

        private void checkModelParameter(object i_ModelParam, object i_TestParam, string i_ParamName, string i_VehicleName)
        {
            if (i_ModelParam.GetType() == i_TestParam.GetType())
            {
                if (!i_ModelParam.Equals(i_TestParam))
                {
                    throw new ArgumentException(string.Format("Supported {0} must have {1} {2}", i_VehicleName, i_TestParam, i_ParamName), i_ModelParam);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Tester parameter not is not type {0}", i_TestParam.GetType().ToString()), i_ModelParam);
            }
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
