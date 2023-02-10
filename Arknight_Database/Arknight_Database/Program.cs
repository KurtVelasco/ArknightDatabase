using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace Arknight_Database
{
    class Program
    {
        static void Main(string[] args)
        {
           
           //Kurt Francis O. Velasco
            while (true)
                {
                    Pull_Simulator d = new Pull_Simulator();
                    Console.WriteLine("[1] Operator Search - Raw (Offline Database) \n" + "[2] Operator Search - Raw (Online Database)\n" +
                        "[3] Arknight Pull Simulator");
                    int choice = UserInput.UserInputrReturn("Input a number: ");
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Welcome to the Offline Database (Beta)\n" + "Do note that the Offline Database might be Outdated\n"
                     + "Currently, make sure you write the proper name of each operators (Skadi Alter Is not Valid)");
                            OperatorCallRawData.OperatorDatabase(UserInput.OperatorName("Write The Operator You want: "));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Welcome to the Online Database (Beta)\n" + "Make sure your connected to the internet\n");
                            OperatorCallRawData_Online.CallOperatorOnline(UserInput.OperatorName("Write The Operator: "));
                            break;
                        case 3:
                            Pull_Simulator.Generic_Simulate();
                            break;

                    }
                    Console.Clear();
                }
            
        }
    }
}
