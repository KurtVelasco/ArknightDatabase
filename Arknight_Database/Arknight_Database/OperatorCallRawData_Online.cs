using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Arknight_Database
{
    class OperatorCallRawData_Online
    {

        private static string url = "";
        //private string data = "";
        public static void CallOperatorOnline(string Userinput)
        {
            string data = "";
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        //string name = UserInput.OperatorName("Input a Operator Name");
            //        string url = $"https://raw.githubusercontent.com/Kengxxiao/ArknightsGameData/master/en_US/gamedata/excel/character_table.json";

            //        data = client.DownloadString(url);
            //    }
            //    catch (Exception ErrorMsg)
            //    {
            //        Console.WriteLine(ErrorMsg);
            //    }
            //}

            //dynamic OperatorDetails = JsonConvert.DeserializeObject(data);
            //using (StreamWriter sr = new StreamWriter("Operator_Database_1.txt"))
            //{
            //    sr.WriteLine(OperatorDetails);
            //}
            data = File.ReadAllText("Operator_Database_1.txt");
            dynamic OperatorDetails = JsonConvert.DeserializeObject(data);
            int count = 0;
            foreach (var items in OperatorDetails)
            {
                string ValueName = items.Value.name;
                string lowerValue = ValueName.ToLower();
                string lower = Userinput.ToLower();
                if (lowerValue == Userinput.ToLower())
                {                                 
                    Console.WriteLine("Processed in: " + count + " Steps");
                    //Console.WriteLine(items.Value.rarity + 1);
                    Console.WriteLine(items);
                    Console.SetWindowPosition(0, 0);
                    break;
                }
                else
                {
                    count++;
                    Console.Write("");
                }
            }
            if (OperatorDetails == null)
            {

            }
            
            Console.ReadLine();
        }
    
    }
}

