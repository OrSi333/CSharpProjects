using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class StringUtils
    {
        //Compare each char in 2 eqaul-length strings
        //Return if the char-value is greater in the first string
        public static bool compareEachCharInString(string i_Str1, string i_Str2)
        {
            bool oneIsGreater = false;
            for (int i = 0; i < i_Str1.Length; i++)
            {
                if (i_Str1[i] > i_Str2[i])
                {
                    oneIsGreater = true;
                    break;
                }

                else if (i_Str1[i] < i_Str2[i])
                {
                    oneIsGreater = false;
                    break;
                }
                
            }

            return oneIsGreater;
        }

    }
}
