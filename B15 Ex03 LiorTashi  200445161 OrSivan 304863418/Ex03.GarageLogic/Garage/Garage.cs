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
        
        public Garage (){
            m_vehiclesInGarage = new Dictionary<string, VehicleDetails>();
         }

        public void addVehicleToGarage(Vehicles.Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNum)
        {
            VehicleDetails vehicleDetails;
            if (m_vehiclesInGarage.TryGetValue(i_Vehicle.LicenseNumber, out vehicleDetails))
            {
                vehicleDetails.VehicleState = eVehicleStatus.Fixed;
                string errorMgs = string.Format("Vehicle alredy exsist in the garage!{0}This operation will cause the vehicle to move back to {1} state",
                    Environment.NewLine, eVehicleStatus.Fixed);
                throw new ArgumentException(errorMgs, i_Vehicle.LicenseNumber);
            }
            else
            {
                m_vehiclesInGarage.Add(i_Vehicle.LicenseNumber, new VehicleDetails(i_OwnerName, i_OwnerPhoneNum,i_Vehicle));
            }
        }

        public string getAllLisenceNumbers()
        {
            string allNumbers = string.Empty;
            foreach (string currNum in m_vehiclesInGarage.Keys)
            {
                allNumbers += string.Format("{0}{1}", currNum, Environment.NewLine);
            }
            return allNumbers;
        }

        public string getAllLisenceNumbers(eVehicleStatus i_Status)
        {
            string allNumbers = string.Empty;
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

        public void addFuelOrCharge(string i_LicenseNum, eFuelType? i_FuelType, float i_QuantityToRefulOrCharge)
        {
            VehicleDetails details;
            if (m_vehiclesInGarage.TryGetValue(i_LicenseNum, out details))
            {
                if (i_FuelType == null)//Charge
                {
                    if (details.Vehicle.VehicleEngine is ElectricEngine)
                    {
                        try
                        {
                            ((ElectricEngine)details.Vehicle.VehicleEngine).chargePower(i_QuantityToRefulOrCharge);
                        }
                        catch (ValueOutOfRangeException vore)
                        {
                            Console.WriteLine(vore.Message);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("You can't charge electricity a fuel engine", details.Vehicle.VehicleEngine.GetType().ToString());
                    }
                }
                else //Refuel
                {
                    if (details.Vehicle.VehicleEngine is FuelEngine)
                    {
                        ((FuelEngine)details.Vehicle.VehicleEngine).addFuel(i_QuantityToRefulOrCharge,i_FuelType.Value);
                    }
                    else
                    {
                        throw new ArgumentException("You can't put fuel in an electric engine", details.Vehicle.VehicleEngine.GetType().ToString());
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
