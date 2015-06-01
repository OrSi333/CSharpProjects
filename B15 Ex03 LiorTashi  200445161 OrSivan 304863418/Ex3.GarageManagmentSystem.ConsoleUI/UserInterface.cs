using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;
using Ex03.GarageLogic;

namespace Ex3.GarageManagmentSystem.ConsoleUI
{
    public class UserInterface
    {
        Garage m_Garage = new Garage();

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


        private string k_EnterVehicleStatus = UserInterfaceHandler.getEnumValuesInList<eVehicleStatus>("Choose status:");

        private const string k_KindOfVehicle =

            // should eVehicleType???!?
@"What type of vehicle?
1. Bike.
2. Electric Bike.
3. Car.
4. Electric Car
5. Truck.";

        private string k_CarryToxic =
@"Does the truck carry toxic cargo? 
1. Yes.
2. No.";

        private string k_ColorOfCar = UserInterfaceHandler.getEnumValuesInList<eColor>("The color of the car is?");

        private string k_NumberOfDoors =  UserInterfaceHandler.getEnumValuesInList<eNumberOfDoors>("Please enter the number of doors:");

        private string k_BikeLicenseType = UserInterfaceHandler.getEnumValuesInList<eLisenceType>("What is the bike license type:");

        private string k_FuleType = UserInterfaceHandler.getEnumValuesInList<eFuelType>("What is the vehicle fuel type?");

       

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
                       System.Threading.Thread.Sleep(3000);
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
                        break;
               }
            }
        }

        private void changeStateOfVehicle()
        {
            string licensePlate = getLicensePlate();

            
            //if....
            // need to check if the vehicle exist in the garage(also in the other methods below).

            Console.WriteLine(k_EnterVehicleStatus);
            eVehicleStatus vehicleStatus = UserInterfaceHandler.getUserInput<eVehicleStatus>();

            // should call the getVehicleFromGarage() and set its status to the desired state above.
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
                Console.WriteLine(k_FuleType);
                fuelType = UserInterfaceHandler.getUserInput<eFuelType>();
                Console.Clear();
            }

            Console.WriteLine(k_EnterTheDesiredQuantityToReful);
            quantityToRefulOrCharge = UserInterfaceHandler.getUserInput<float>();

            m_Garage.addFuelOrCharge(licensePlate, fuelType, quantityToRefulOrCharge);
        }

        private void inflateWheels()
        {
            string licensePlate = getLicensePlate();

            m_Garage.inflateWheelsToMax(licensePlate);

            // should i print something ? 
        }

        private void showList()
        {
            // need to call the getAllVehicles() from garage logic.
        }

        private void enterNewVehicle()
        {
            Console.Clear();
            creatNewVehicle();
            Console.Out.WriteLine(k_KindOfVehicle);
            // THIS SHOULD BE CHANGE, IF WE'LL SUPPORT A NEW VEHICLE TYPE THE SWITCH WILL FAIL HERE.
            int userInput = UserInterfaceHandler.getUserMenuSelection(1, 5);

            switch (userInput)
            {
                case 1:
                    createBike(false);
                    break;
                case 2:
                    createBike(true);
                    break;
                case 3:
                    createCar(false);
                    break;
                case 4:
                    createCar(true);
                    break;
                case 5:
                    createTruck();
                    break;
            }
        }

        private void creatNewVehicle()
        {
            string licensePlate = getLicensePlate();
            string modelName = string.Empty;
            float maxAirPressure = 0;
            float maxQuantityOFfuel = 0;
            string wheelManufucture = string.Empty;

            Console.WriteLine(k_EnterModelName);
            modelName = UserInterfaceHandler.getUserInput<string>();

            Console.WriteLine(k_EnterMaximumAirPressure);
            maxAirPressure = UserInterfaceHandler.getUserInput<float>();

            Console.WriteLine(k_EnterCurrentAirPressure);

            while (true)
            {
                float currentAirPressure = UserInterfaceHandler.getUserInput<float>();

                if (currentAirPressure > maxAirPressure)
                {
                    Console.WriteLine(string.Format(k_ErrorOufOfBound, currentAirPressure, maxAirPressure));
                    continue;
                }

                Console.Clear();
                break;
            }

            Console.WriteLine(k_EnterMaxQuantityOfEnergy);
            maxQuantityOFfuel = UserInterfaceHandler.getUserInput<float>();
            Console.Clear();

            Console.WriteLine(k_EnterEnergyLeft);

            while (true)
            {
                float energyLeft = UserInterfaceHandler.getUserInput<float>();

                if (energyLeft > maxQuantityOFfuel)
                {
                    Console.WriteLine(k_ErrorOufOfBound, energyLeft, maxAirPressure);
                    continue;
                }

                Console.Clear();
                break;
            }

            Console.WriteLine(k_EnterWheelManifucture);
            wheelManufucture = UserInterfaceHandler.getUserInput<string>();
            Console.Clear();
        }

        private void createBike(bool i_isElectric)
        {
            eLisenceType? typeOfLicense = null; 
            int engineDisplacement = 0;
            eFuelType? typeOfFuel = null;

            Console.WriteLine(k_BikeLicenseType);
            typeOfLicense = UserInterfaceHandler.getValidEnumValue<eLisenceType>();
  

            Console.Out.WriteLine(k_EnterEngineDisplacement);
            engineDisplacement = UserInterfaceHandler.getUserInput<int>();

            if (!i_isElectric)
            {
                Console.WriteLine(k_FuleType);
                typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
            }
            else
            {

            }
        }

        private void createCar(bool isElectric)
        {
            eColor? colorOfCar = null;
            eNumberOfDoors? numberOfDoors = null;
            eFuelType? typeOfFuel = null;

            Console.WriteLine(k_ColorOfCar);
            colorOfCar = UserInterfaceHandler.getUserInput<eColor>();

            Console.WriteLine(k_NumberOfDoors);
            numberOfDoors = UserInterfaceHandler.getUserInput<eNumberOfDoors>();

            if (!isElectric)
            {
                Console.WriteLine(k_FuleType);
                typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
            }
            else
            {

            }
        }

        private void createTruck()
        {
            int carryToxic = 0;
            float currentCurryLoad = 0;

            Console.WriteLine(k_CarryToxic);
            carryToxic = UserInterfaceHandler.getUserInput<int>();
            Console.Clear();

            Console.WriteLine(k_EnterCurrentCurryLoad);
            currentCurryLoad = UserInterfaceHandler.getUserInput<float>();
            Console.Clear();
        }
        

        private static string getLicensePlate()
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();
            Console.Clear();

            return licensePlate;
        }
    }
}
