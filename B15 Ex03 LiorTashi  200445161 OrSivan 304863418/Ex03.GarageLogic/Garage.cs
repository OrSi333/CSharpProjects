using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<Vehicle, VehicleDetails> m_vehiclesInGarage;
        private const string vehicleNotFounderr = "The vehicle doesn't exsist in the garage!";

        public void addVehicleToGarage(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNum)
        {
            VehicleDetails vehicleDetails;
            if (m_vehiclesInGarage.TryGetValue(i_Vehicle, out vehicleDetails))
            {
                vehicleDetails.VehicleState = eVehicleState.Fixing;
                string errorMgs = string.Format("Vehicle alredy exsist in the garage!{0}This operation will cause the vehicle to move back to {1} state",
                    Environment.NewLine, eVehicleState.Fixing);
                throw new ArgumentException(errorMgs, i_LicenseNum);
            }
            else
            {
                m_vehiclesInGarage.Add(i_Vehicle, new VehicleDetails(i_OwnerName, i_OwnerPhoneNum));
            }
        }

        //TODO: present all numbers

        public void changeVehicleState(string i_LicenseNum, eVehicleState i_State)
        {
            VehicleDetails vehicleDetails;
            if (m_vehiclesInGarage.TryGetValue(i_Vehicle, out vehicleDetails))
            {
                vehicleDetails.VehicleState = i_State;
            }
            else
            {
                throw new ArgumentException(vehicleNotFounderr, i_LicenseNum);
            }
        }

        public void inflateWheelsToMax(string i_LicenseNum)
        {
            if (m_vehiclesInGarage.ContainsKey(m_vehiclesInGarage))
            {
                vehicleDetails.VehicleState = i_State;
            }
            else
            {
                throw new ArgumentException(vehicleNotFounderr, i_LicenseNum);
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
