using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleDetails> m_vehiclesInGarage;
        private const string vehicleNotFound = "The vehicle doesn't exsist in the garage!";
        private VehiclesMaker vehicleMaker;

        public void addVehicleToGarage(Models.VehicleModel i_Model, string i_OwnerName, string i_OwnerPhoneNum)
        {
            VehicleDetails vehicleDetails;
            if (m_vehiclesInGarage.TryGetValue(i_Model.m_licenseNumber, out vehicleDetails))
            {
                vehicleDetails.VehicleState = eVehicleStatus.Fixed;
                string errorMgs = string.Format("Vehicle alredy exsist in the garage!{0}This operation will cause the vehicle to move back to {1} state",
                    Environment.NewLine, eVehicleStatus.Fixed);
                throw new ArgumentException(errorMgs, i_Model.m_licenseNumber);
            }
            else
            {
                m_vehiclesInGarage.Add(i_Model.m_licenseNumber, new VehicleDetails(i_OwnerName, i_OwnerPhoneNum,vehicleMaker.makeVehicle(i_Model)));
            }
        }

        //TODO:
        public string getAllLisenceNumbers()
        {
            return null;
        }

        public void changeVehicleState(string i_LicenseNum, eVehicleStatus i_State)
        {
            VehicleDetails vehicleDetails;
            if (m_vehiclesInGarage.TryGetValue(i_LicenseNum, out vehicleDetails))
            {
                vehicleDetails.VehicleState = i_State;
            }
            else
            {
                throw new ArgumentException(vehicleNotFound, i_LicenseNum);
            }
        }

        //TODO:
        public void inflateWheelsToMax(string i_LicenseNum)
        {
            
            if (m_vehiclesInGarage.ContainsKey(i_LicenseNum))
            {
                
            }
            else
            {
                throw new ArgumentException(vehicleNotFound, i_LicenseNum);
            }
        }

        public void addFuel(string i_VehicleNumber,eFuelType i_FuelType, float i_FuelToAdd)
        {

        }

        public void charge(string i_VehicleNumber, float i_FuelToAdd)
        {

        }

        public string getAllDataOnVehicle(string i_VehicleNumber)
        {

            return null;
        }
    }
}
