using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

// Example:  EmployeeId ( 4-digit number)
// Pattern: "^\d{4}$" 

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public class Validator
    {
        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidId(string input, int size)
        {
            if (!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i< input.Length; i++)
            {
                if (!(char.IsLetter(input[i])) && !(char.IsWhiteSpace(input[i]))){
                    return false;
                }
            }
            return true;
        }


    }
}