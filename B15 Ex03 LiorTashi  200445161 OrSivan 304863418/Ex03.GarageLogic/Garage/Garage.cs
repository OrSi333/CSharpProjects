using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleComponents;

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

        public string getAllLisenceNumbers()
        {
            string allNumbers;
            foreach (string currNum in m_vehiclesInGarage.Keys)
            {
                allNumbers += string.Format("{0}{1}", currNum, Environment.NewLine);
            }
            return allNumbers;
        }

        public string getAllLisenceNumbers(eVehicleStatus i_Status)
        {
            string allNumbers;
            foreach (string currNum in m_vehiclesInGarage.Keys)
            {
                VehicleDetails details;
                m_vehiclesInGarage.TryGetValue(currNum, out details);
                if (details.VehicleState == i_Status)
                {
                    allNumbers += string.Format("{0}{1}", currNum, Environment.NewLine);
                }
            }
            return allNumbers;
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

        public void inflateWheelsToMax(string i_LicenseNum)
        {
            VehicleDetails details;
            if (m_vehiclesInGarage.TryGetValue(i_LicenseNum, out details))
            {
                details.Vehicle.InflateAllWheelsToMax();
            }
            else
            {
                throw new ArgumentException(vehicleNotFound, i_LicenseNum);
            }
        }

        public void addFuelOrCharge(string licensePlate, eFuelType? i_FuelType, float i_QuantityToRefulOrCharge)
        {
            VehicleDetails details;
            if (m_vehiclesInGarage.TryGetValue(i_LicenseNum, out details))
            {
                if (i_FuelType == null)//Charge
                {
                    if (details.Vehicle.VehicleEngine is ElectricEngine)
                    {
                        ((ElectricEngine)details.Vehicle.VehicleEngine).chargePower(i_QuantityToRefulOrCharge);
                    }
                    else
                    {
                        throw new ArgumentException("You can't charge electricity a fuel engine", details.Vehicle);
                    }
                }
                else //Refuel
                {
                    if (details.Vehicle.VehicleEngine is FuelEngine)
                    {
                        ((FuelEngine)details.Vehicle.VehicleEngine).addFuel(i_QuantityToRefulOrCharge,i_FuelType);
                    }
                    else
                    {
                        throw new ArgumentException("You can't put fuel in an electric engine", details.Vehicle);
                    }
                }
            }
            else
            {
                throw new ArgumentException(vehicleNotFound, i_LicenseNum);
            }
        }

        public string getAllDataOnVehicle(string i_VehicleNumber)
        {
            VehicleDetails details = null;
            if (m_vehiclesInGarage.TryGetValue(i_VehicleNumber, out details))
            {
                return details.ToString();
            }
            else
            {
                throw new ArgumentException(vehicleNotFound, i_VehicleNumber);
            }
        }
    }
}
