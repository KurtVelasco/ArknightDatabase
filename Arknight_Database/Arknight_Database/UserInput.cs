using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arknight_Database
{
    internal static class UserInput
    {
        public static int UserInputrReturn(string Question)
        {
            string UInputStr = "";
            int UInputInt = 0;
            bool flag = false;
            Console.Write(Question);
            UInputStr = Console.ReadLine();
            flag = int.TryParse(UInputStr, out UInputInt);
            if(flag == true)
            {
                if(UInputInt <= 3)
                {
                    return UInputInt;
                }
                else
                {
                    UserInput.UserInputrReturn("Current Option Doesn't Exist: ");
                }
            }
            else
            {
                UserInput.UserInputrReturn("User Input Invalid: ");
            }
            return UInputInt;
        }
        public static string OperatorName(string Question)
        {
            string UInputStr = "";
            Console.Write(Question);
            UInputStr = Console.ReadLine();
            return UInputStr;
        }
       
    }
}

