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
    internal static class OperatorCallRawData
    {
        public static string data = " ";
     
        public static void OperatorDatabase(string Opname)
        {

            string url = $"https://rhodesapi.cyclic.app/api/operator/";
            string data = "";
            string filepath = $"C:\\Users\\karin\\source\\repos\\Arknight_Database\\Arknight_Database\\bin\\Debug\\OperatorDatabase.txt";
            
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    //data = client.DownloadString(url);
                    data = File.ReadAllText(filepath);
                     //File.WriteAllText(filepath, data);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            int count = 0;
            dynamic item = JsonConvert.DeserializeObject<List<dynamic>>(data);
            foreach (var items in item)
            {
                
                if (items.name == Opname)
                {
                    Console.WriteLine(items.rarity);
                    Console.OutputEncoding = Encoding.GetEncoding(936);
                    Console.WriteLine("Processed in: " + count + " Steps");
                    Console.WriteLine(items);
                    Console.SetWindowPosition(0, 0);
                    break;
                }
                else
                {
                    count++;                                      
                }
            }

            //Console.OutputEncoding = Encoding.GetEncoding(936);
            //if (item == null)
            //{
            //    Console.WriteLine("ERROR - Operator Doesn't Exist: ");
            //}
            //else
            //{
            //    Console.Clear();                
            //    Console.WriteLine("Display Operator Information: " + Name );
            //    Console.WriteLine(item);
            //    Console.SetWindowPosition(0, 0);
            //}

            Console.ReadKey();
        }
    }
}
