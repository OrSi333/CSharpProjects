using System;
using System.Collections.Generic;
using System.Text;

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
                vehicleDetails.VehicleState = eVehicleState.Fixing;
                string errorMgs = string.Format("Vehicle alredy exsist in the garage!{0}This operation will cause the vehicle to move back to {1} state",
                    Environment.NewLine, eVehicleState.Fixing);
                throw new ArgumentException(errorMgs, i_Model.m_licenseNumber);
            }
            else
            {
                m_vehiclesInGarage.Add(i_Model.m_licenseNumber, new VehicleDetails(i_OwnerName, i_OwnerPhoneNum,vehicleMaker.makeVehicle(i_Model)));
            }
        }

        //TODO: present all numbers
        public List<string> getAllVehiclesInGarage()
        {
            return null;
        }

        public List<string> getAllVehiclesInGarage(eVehicleState state)
        {
            List<string> allVehiclesInState = new List<string>();
            //foreach (string vehicleNum in m_vehiclesInGarage)
            //{
            //    VehicleDetails details;
            //    if (m_vehiclesInGarage.TryGetValue(vehicleNum, out details))
            //    {
            //        if (details.VehicleState == state)
            //        {
            //            allVehiclesInState.Add(vehicleNum);
            //        }
            //    }
            //}
            return allVehiclesInState;
        }

        public void changeVehicleState(string i_LicenseNum, eVehicleState i_State)
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

        public enum eVehicleState
        {
            Fixing,
            Fixed,
            Payed
        };
    }
}
