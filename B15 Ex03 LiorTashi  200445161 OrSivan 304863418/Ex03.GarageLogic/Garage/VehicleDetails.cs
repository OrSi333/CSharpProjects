using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal struct VehicleDetails
    {
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private Garage.eVehicleState m_vehicleState;
        private Vehicle m_vehicle;

        internal VehicleDetails(string i_OwnerName, string i_OwnerPhoneNum, Vehicle i_Vehicle)
        {
            m_ownerName = i_OwnerName;
            m_ownerPhoneNumber = i_OwnerPhoneNum;
            m_vehicleState = Garage.eVehicleState.Fixing;
            m_vehicle = i_Vehicle;
            
        }

        public Garage.eVehicleState VehicleState
        {
            get
            {
                return m_vehicleState;
            }

            set
            {
                m_vehicleState = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Owner's Name: {0}{1},Owner's Phone Number: {2}{3}Vehical's state: {4}{5}"
                , m_ownerName, Environment.NewLine, m_ownerPhoneNumber, Environment.NewLine, m_vehicleState, Environment.NewLine);
        }
        
    }
}
