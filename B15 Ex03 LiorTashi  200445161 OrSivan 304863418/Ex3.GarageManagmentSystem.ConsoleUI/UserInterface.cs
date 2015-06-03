using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic;
using System.Reflection;

namespace Ex3.GarageManagmentSystem.ConsoleUI
{
    public class UserInterface
    {
        Garage m_Garage = new Garage();
        VehiclesMaker m_vehicleMaker = new VehiclesMaker();

        private const int k_ThreadSleepTime = 3000;
        private const string k_WelcomeMsg = "************Welcome to The Garage!************";
        private const string k_EnterModelName = "Enter the model name of the vehicle:";
        private const string k_EnterLicensePlate = "Enter the license plate of the vehicle:";
        private const string k_EnterEnergyLeft = "Enter the percentage left in the vehicle's energy source";
        private const string k_EnterWheelManifucture = "Enter the name of the wheels manifucture:";
        private const string k_EnterMaximumAirPressure = "Enter the maximum air pressure that was set by the manifucture";
        private const string k_EnterMaxBatteryPower = "Enter the battery's maximum battery power (in hours):";
        private const string k_EnterOwnersName = "What is the owner's name:";
        private const string k_EnterOwnersPhoneNumber = "What is the owner's phone number:";
        private const string k_EnterCurrentCurryLoad = "Enter the current curry load of the truck:";
        private const string k_EnterEngineDisplacement = "Enter the Engine displacement:";
        private const string k_EnterCurrentFuelQuantity = "Enter the current quantity of fuel.";
        private const string k_EnterCurrentAirPressure = "Enter the current air pressure of the wheels.";
        private const string k_EnterTheDesiredQuantityToReful = "Enter the desired quantity of fuel you would like to refule or the amount of time(in minutes) you would like to charge the battery with (for example '100')";
        private const string k_ErrorOufOfBound = "invalid input, the value you entered is {0} but the maximum is {1}, please try again";
        private const string k_VehicleCreated = "Vehicle was created!";

        private const string k_EnterMaxQuantityOfEnergy =
@"Enter the car's maximum energy quantity: 
(if its a fuel engine enter the maximum quantity of the fuel tank and if its an electric engine enter the battery maximum capacity)";

        private const string k_Menu =
@"Please enter your desired operation: 
1. Enter a new vehicle to the garage.
2. Show the list of the license plates of the vehicles that are in the garage.
3. Change the state of a vehicle in the garage.
4. Inflate vehicle wheels.
5. Refule vehicle.
6. Charge an electirc engine.
7. Enter a vehicle license plate to see his details.
8. Exit";

        private string k_CarryToxic =
@"Does the truck carry toxic cargo? 
1. Yes.
2. No.";

        public void openGarage()
        {
            int userInputInMenu = 0;

            while (userInputInMenu != 8)
            {
                Console.Clear();
                Console.Out.WriteLine(k_WelcomeMsg);
                Console.WriteLine(k_Menu);
                userInputInMenu = UserInterfaceHandler.getUserMenuSelection(1, 8);

                switch (userInputInMenu)
                {
                    case 1:
                        enterNewVehicle();
                        Console.WriteLine(k_VehicleCreated);
                        System.Threading.Thread.Sleep(k_ThreadSleepTime);
                        break;
                    case 2:
                        showList();
                        break;
                    case 3:
                        changeStateOfVehicle();
                        break;
                    case 4:
                        inflateWheels();
                        break;
                    case 5:
                        refuleVehicle(false);
                        break;
                    case 6:
                        refuleVehicle(true);
                        break;
                    case 7:
                        seeVehicleDetails();
                        Console.Read();
                        break;
                }
            }
        }

        private void changeStateOfVehicle()
        {
            string licensePlate = getLicensePlate();
            Console.WriteLine("Enter the desired status: ");
            eVehicleStatus statusChange = UserInterfaceHandler.getUserInput<eVehicleStatus>();

            try
            {
                m_Garage.changeVehicleState(licensePlate, statusChange);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Console.ReadLine();
            }

        }


        private void seeVehicleDetails()
        {
            string licensePlate = getLicensePlate();

            Console.WriteLine(m_Garage.getAllDataOnVehicle(licensePlate));
        }

        private void refuleVehicle(bool isElectric)
        {
            string licensePlate = getLicensePlate();
            eFuelType? fuelType = null;
            float quantityToRefulOrCharge = 0F;

            if (!isElectric)
            {
                Console.WriteLine("Enter the type of fule: ");
                fuelType = UserInterfaceHandler.getUserInput<eFuelType>();
                Console.Clear();
            }

            Console.WriteLine(k_EnterTheDesiredQuantityToReful);
            quantityToRefulOrCharge = UserInterfaceHandler.getUserInput<float>();

            try
            {
                m_Garage.addFuelOrCharge(licensePlate, fuelType, quantityToRefulOrCharge);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

        private void inflateWheels()
        {
            string licensePlate = getLicensePlate();

            try
            {
                m_Garage.inflateWheelsToMax(licensePlate);
                Console.WriteLine("Wheels were successfully inflated. ");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            System.Threading.Thread.Sleep(k_ThreadSleepTime);
        }

        private void showList()
        {
            Console.WriteLine("Choose status filter: ");
            Console.WriteLine("0. None");
            Console.WriteLine(UserInterfaceHandler.getEnumValuesInList<eVehicleStatus>());

            int numberOfValuesInEnum = Enum.GetNames(typeof(eVehicleStatus)).Length;
            int chosenStatus = UserInterfaceHandler.getUserMenuSelection(0, numberOfValuesInEnum);

            string licensePlateList = string.Empty;

            switch (chosenStatus)
            {
                case 0:
                    licensePlateList = m_Garage.getAllLisenceNumbers();
                    break;
                case 1:
                    licensePlateList = m_Garage.getAllLisenceNumbers(eVehicleStatus.Fixed);
                    break;
                case 2:
                    licensePlateList = m_Garage.getAllLisenceNumbers(eVehicleStatus.Paid);
                    break;
                case 3:
                    licensePlateList = m_Garage.getAllLisenceNumbers(eVehicleStatus.Repairing);
                    break;
            }

            Console.WriteLine(licensePlateList);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private void enterNewVehicle()
        {
            Console.WriteLine("Enter type of vehicle:");
            VehiclesMaker.SupportedVehicle chosenVehicle = UserInterfaceHandler.getValidEnumValue<VehiclesMaker.SupportedVehicle>();
            Vehicle vehicle;
            m_vehicleMaker.makeVehicle(chosenVehicle, out vehicle);
                
            for (int i = 0; i < vehicle.UniqParams.Count; i++)
            {
                ParamHolder param = vehicle.UniqParams[i];
                if (param.Value == null)
                {
                    Console.WriteLine(string.Format("Enter {0}", param.ToString()));
                    param.Value = typeof(UserInterfaceHandler).GetMethod("getUserInput", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(param.ExpectedType).Invoke(null, new object[] { });
                }
            }

            Console.WriteLine(k_EnterOwnersName);
            string ownerName = UserInterfaceHandler.getUserInput<string>();

            Console.WriteLine(k_EnterOwnersPhoneNumber);
            string ownerPhoneNumber = UserInterfaceHandler.getUserInput<string>();

            vehicle.ImplementUniqParams();
            m_Garage.addVehicleToGarage(vehicle, ownerName, ownerPhoneNumber);
        }
        

        
        //private void creatNewVehicle()
        //{
        //    string licensePlate = getLicensePlate();
        //    string modelName = string.Empty;
        //    float maxAirPressure = 0;
        //    float maxQuantityOFfuel = 0;
        //    string wheelManufucture = string.Empty;

        //    Console.WriteLine(k_EnterModelName);
        //    modelName = UserInterfaceHandler.getUserInput<string>();

        //    Console.WriteLine(k_EnterMaximumAirPressure);
        //    maxAirPressure = UserInterfaceHandler.getUserInput<float>();

        //    Console.WriteLine(k_EnterCurrentAirPressure);

        //    while (true)
        //    {
        //        float currentAirPressure = UserInterfaceHandler.getUserInput<float>();

        //        if (currentAirPressure > maxAirPressure)
        //        {
        //            Console.WriteLine(string.Format(k_ErrorOufOfBound, currentAirPressure, maxAirPressure));
        //            continue;
        //        }

        //        Console.Clear();
        //        break;
        //    }

        //    Console.WriteLine(k_EnterMaxQuantityOfEnergy);
        //    maxQuantityOFfuel = UserInterfaceHandler.getUserInput<float>();
        //    Console.Clear();

        //    Console.WriteLine(k_EnterEnergyLeft);

        //    while (true)
        //    {
        //        float energyLeft = UserInterfaceHandler.getUserInput<float>();

        //        if (energyLeft > maxQuantityOFfuel)
        //        {
        //            Console.WriteLine(k_ErrorOufOfBound, energyLeft, maxAirPressure);
        //            continue;
        //        }

        //        Console.Clear();
        //        break;
        //    }

        //    Console.WriteLine(k_EnterWheelManifucture);
        //    wheelManufucture = UserInterfaceHandler.getUserInput<string>();
        //    Console.Clear();
        //}

        //private void createBike(bool i_isElectric)
        //{
        //    eLisenceType? typeOfLicense = null;
        //    int engineDisplacement = 0;
        //    eFuelType? typeOfFuel = null;

        //    Console.WriteLine(k_BikeLicenseType);
        //    typeOfLicense = UserInterfaceHandler.getValidEnumValue<eLisenceType>();


        //    Console.Out.WriteLine(k_EnterEngineDisplacement);
        //    engineDisplacement = UserInterfaceHandler.getUserInput<int>();

        //    if (!i_isElectric)
        //    {
        //        Console.WriteLine(k_FuleType);
        //        typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
        //    }
        //    else
        //    {

        //    }
        //}

        //private void createCar(bool isElectric)
        //{
        //    eColor? colorOfCar = null;
        //    eNumberOfDoors? numberOfDoors = null;
        //    eFuelType? typeOfFuel = null;

        //    Console.WriteLine(k_ColorOfCar);
        //    colorOfCar = UserInterfaceHandler.getUserInput<eColor>();

        //    Console.WriteLine(k_NumberOfDoors);
        //    numberOfDoors = UserInterfaceHandler.getUserInput<eNumberOfDoors>();

        //    if (!isElectric)
        //    {
        //        Console.WriteLine(k_FuleType);
        //        typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
        //    }
        //    else
        //    {

        //    }
        //}

        //private void createTruck()
        //{
        //    int carryToxic = 0;
        //    float currentCurryLoad = 0;

        //    Console.WriteLine(k_CarryToxic);
        //    carryToxic = UserInterfaceHandler.getUserInput<int>();
        //    Console.Clear();

        //    Console.WriteLine(k_EnterCurrentCurryLoad);
        //    currentCurryLoad = UserInterfaceHandler.getUserInput<float>();
        //    Console.Clear();
        //}


        private static string getLicensePlate()
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();
            Console.Clear();

            return licensePlate;
        }
    }
}
