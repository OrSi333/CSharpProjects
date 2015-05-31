﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex3.GarageManagmentSystem.ConsoleUI
{
    internal static class UserInterfaceHandler
    {
        private const string k_ErrorEmptyInput = "The input you entered is empty. Please try again";
        private const string k_ErrorArgumentException = "Invalid argument or {0} was not found!";
        private const string k_ErrorFormatException = "The input you entered is not valid";

        // Checks if the givin number is within the desired range;
        public static bool checkInputRange(int i_StartNumber, int i_EndNumber, int numberToCheck)
        {
            bool isValid = true;

            if (numberToCheck > i_EndNumber || numberToCheck < i_StartNumber)
            {
                isValid = false;
            }
            return isValid;
        }

        public static T getUserInput<T>()
        {
            T valueToReturn = default(T);
            Type typeOfT = typeof(T);

            if (typeOfT.IsEnum)
            {
                valueToReturn = getValidEnumValue<T>();
            }

            if (typeOfT == typeof(String))
            {
                valueToReturn = (T)Convert.ChangeType(getValidStringValue(), typeOfT);
            }

            if (typeOfT == typeof(float) || typeOfT == typeof(int))
            {
                valueToReturn = (T)Convert.ChangeType(getValidFloatValue(), typeOfT);
            }

            return valueToReturn;
        }

        private static float getValidFloatValue()
        {
            float valueToReturn = 0;
            while (true)
            {
                try
                {
                    valueToReturn = float.Parse(Console.ReadLine());

                    if (valueToReturn < 0)
                    {
                        Console.WriteLine("Invalid input. You cant enter a negative number, please try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again");
                    continue;
                }

                break;
            }

            return valueToReturn;
        }

        private static string getValidStringValue()
        {
            string valueToReturn = string.Empty;

            while (true)
            {
                valueToReturn = Console.ReadLine();

                if (!valueToReturn.Equals(string.Empty))
                {
                    break;
                }

                Console.WriteLine(string.Format(k_ErrorEmptyInput));
            }

            return valueToReturn;
        }

        public static T getValidEnumValue<T>()
        {
            T enumToReturn;
            int inputNumber;

            while (true)
            {
                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out inputNumber);

                if (isNumber)
                {
                    if (!Enum.IsDefined(typeof(T), inputNumber))
                    {
                        Console.WriteLine("Invalid input, please try again");
                        continue;
                    }
                    else
                        enumToReturn = (T)(object)inputNumber;
                    break;
                }
                else
                {
                    try
                    {
                        enumToReturn = (T)System.Enum.Parse(typeof(T), input, true);
                        break;
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }

            return enumToReturn;
        }

        // returns a numbered list of the values in given T.
        public static string getEnumValuesInList<T>()
        {
            StringBuilder listOfValues = new StringBuilder();
            int i = 0;

            foreach (Enum value in Enum.GetValues(typeof(T)))
            {
                listOfValues.AppendLine(string.Format("{0}. {1}", ++i, value));
            }

            return listOfValues.ToString();
        }
    }
}
