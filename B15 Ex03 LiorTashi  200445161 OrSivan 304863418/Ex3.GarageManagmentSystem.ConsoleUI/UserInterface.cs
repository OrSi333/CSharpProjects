using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Models;

namespace Ex3.GarageManagmentSystem.ConsoleUI
{
    public class UserInterface
    {
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
        private const string k_ErrorInvalidInput = "Invalid input";
        private const string k_ErrorOufOfBound = "invalid input, the value you entered is {0} but the maximum is {1}, please try again";

        private const string k_EnterMaxQuantityOfEnergy = 
@"Enter the car's maximum energy quantity: 
(if its a fuel engine enter the maximum quantity of the fuel tank and if its an electric engine enter the battery maximum capacity)";

        private const string k_Menu =
@"please enter your desired operation: 
1. Enter a new vehicle to the garage.
2. Show the list of the license plates of the vehicles that are in the garage.
3. Change the state of a vehicle in the garage.
4. Inflate vehicle wheels.
5. Refule vehicle.
6. Charge an electirc engine.
7. Enter a vehicle license plate to see his details.";

        private const string k_EnterVehicleStatus = string.Format(
@"Choose status:
{0}
4. All",
    UserInterfaceHandler.getEnumValuesInList<eVehicleStatus>());

        private const string k_KindOfVehicle =
@"What type of vehicle?
1. Bike.
2. Electric Bike.
1. Car.
2. Electric Car
3. Truck.";

        private const string k_CarryToxic =
@"Does the truck carry toxic cargo? 
1. Yes.
2. No.";

        private const string k_ColorOfCar = string.Format(
@"The color of the car is?
{0}",
    UserInterfaceHandler.getEnumValuesInList<eNumberOfDoors>());

        private const string k_NumberOfDoors = string.Format(
@"Please enter the number of doors:
{0}",
    UserInterfaceHandler.getEnumValuesInList<eNumberOfDoors>());

        private const string k_BikeLicenseType = string.Format(
@"What is the bike license type: 
{0}",
    UserInterfaceHandler.getEnumValuesInList<eLisenceType>());

        private const string k_FuleType = string.Format(
@"What is the vehicle fuel type? 
{0}", 
    UserInterfaceHandler.getEnumValuesInList<eFuelType>());
   


        public void openGarage()
        {
            Console.Out.WriteLine(k_WelcomeMsg);
            int userInputInMenu = getUserMenuSelection(1, 7);

            switch (userInputInMenu)
            {
                case 1:
                    enterNewVehicle();
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

        private void changeStateOfVehicle()
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();

            //if....
            // need to check if the vehicle exist in the garage(also in the other methods below).

            Console.WriteLine(k_EnterVehicleStatus);
            eVehicleStatus vehicleStatus = UserInterfaceHandler.getUserInput<eVehicleStatus>();

            // should call the getVehicleFromGarage() and set its status to the desired state above.
        }

        private void seeVehicleDetails()
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();

            // need to call here the getVehicleFromGarage method from garage logic.
        }

        private void refuleVehicle(bool isElectric)
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();

            if (!isElectric)
            {
            Console.WriteLine(k_FuleType);
            eFuelType fuelType = UserInterfaceHandler.getUserInput<eFuelType>();
            }

            Console.WriteLine(k_EnterTheDesiredQuantityToReful);
            float quantityToRefulOrCharge = UserInterfaceHandler.getUserInput<float>();

            // should i create a new vehicle ? or just call the service?
        }

        private void inflateWheels()
        {
            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();

            // need to call here the getVehicleFromGarage method from garage logic.
        }

        private void showList()
        {
            // need to call the getAllVehicles() from garage logic.
        }

        private void enterNewVehicle()
        {
            creatNewVehicle();
            Console.Out.WriteLine(k_KindOfVehicle);
            int userInput = getUserMenuSelection(1, 5);

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
            Console.WriteLine(k_EnterModelName);
            string modelName = UserInterfaceHandler.getUserInput<string>();

            Console.WriteLine(k_EnterLicensePlate);
            string licensePlate = UserInterfaceHandler.getUserInput<string>();


            Console.WriteLine(k_EnterMaximumAirPressure);
            float maxAirPressure = UserInterfaceHandler.getUserInput<float>();

            Console.WriteLine(k_EnterCurrentAirPressure);

            while (true)
            {
                float currentAirPressure = UserInterfaceHandler.getUserInput<float>();

                if (currentAirPressure > maxAirPressure)
                {
                    Console.WriteLine(string.Format(k_ErrorOufOfBound, currentAirPressure, maxAirPressure));
                    continue;
                }

                break;
            }

            Console.WriteLine(k_EnterMaxQuantityOfEnergy);
            float maxQuantityOFfuel = UserInterfaceHandler.getUserInput<float>();

            Console.WriteLine(k_EnterEnergyLeft);

            while (true)
            {
                float energyLeft = UserInterfaceHandler.getUserInput<float>();

                if (energyLeft > maxQuantityOFfuel)
                {
                    Console.WriteLine(k_ErrorOufOfBound, energyLeft, maxAirPressure);
                    continue;
                }

                break;
            }

            Console.WriteLine(k_EnterWheelManifucture);
            string wheelManufucture = UserInterfaceHandler.getUserInput<string>();
        }

        private void createBike(bool i_isElectric)
        {
            Console.Out.WriteLine(k_BikeLicenseType);

            Console.WriteLine(k_BikeLicenseType);
            eLisenceType typeOfLicense = UserInterfaceHandler.getValidEnumValue<eLisenceType>();

            Console.Out.WriteLine(k_EnterEngineDisplacement);
            int engineDisplacement = UserInterfaceHandler.getUserInput<int>();

            if (!i_isElectric)
            {
                Console.WriteLine(k_FuleType);
                eFuelType typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
            }
            else
            {

            }
        }

        private void createCar(bool isElectric)
        {
            Console.WriteLine(k_ColorOfCar);
            eColor colorOfCar = UserInterfaceHandler.getUserInput<eColor>();

            Console.WriteLine(k_NumberOfDoors);
            eNumberOfDoors numberOfDoors = UserInterfaceHandler.getUserInput<eNumberOfDoors>();

            if (!isElectric)
            {
                Console.WriteLine(k_FuleType);
                eFuelType typeOfFuel = UserInterfaceHandler.getUserInput<eFuelType>();
            }
            else
            {

            }
        }

        private void createTruck()
        {
            Console.WriteLine(k_CarryToxic);
            int carryToxic = UserInterfaceHandler.getUserInput<int>();

            Console.WriteLine(k_EnterCurrentCurryLoad);
            float currentCurryLoad = UserInterfaceHandler.getUserInput<float>();
        }
        
        // Should move it to userInterfaceHandler!!!
        private static int getUserMenuSelection(int i_StartMenuValue, int i_EndMenuValue)
        {
            int userInputInMenu = 0;

            while (true) 
            {
                try 
                { 
                    if (int.TryParse(Console.ReadLine(), out userInputInMenu) && UserInterfaceHandler.checkInputRange(i_StartMenuValue, i_EndMenuValue, userInputInMenu))
                    {
                       break;
                    }
                }
                catch (FormatException)
                {
                    Console.Out.WriteLine(k_ErrorInvalidInput);
                }
            }

            return userInputInMenu;
        }
    }
}
