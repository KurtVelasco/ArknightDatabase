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
    class Pull_Simulator
    {
        private static dynamic item = new List<dynamic>();
        public Pull_Simulator()
        {

            //Depending if the database gets updated pls use this link
            //If ever cyclic updates his database and download the database using the webclient
            //string url = $"https://rhodesapi.cyclic.app/api/operator/"

            string data = "";
            string filepath = $"C:\\Users\\karin\\source\\repos\\Arknight_Database\\Arknight_Database\\bin\\Debug\\OperatorDatabase.txt";
            data = File.ReadAllText(filepath);
            item = JsonConvert.DeserializeObject<List<dynamic>>(data);
        }
        public static void Generic_Simulate()
        {
            //Generic Simulation just to test the waters
            //For Information: No Pity and Acces to all operators that can be headhunted

            var characters = new Dictionary<string, double>();
            foreach (var characterlist1 in item)
            {
                if (characterlist1.headhunting == "Yes")
                {
                    string name = characterlist1.name;
                    double rarity = 0;
                    if (characterlist1.rarity == 6)
                    {
                        rarity = 0.02;
                    }
                    else if (characterlist1.rarity == 5)
                    {
                        rarity = 0.08;
                    }
                    else if (characterlist1.rarity == 4)
                    {
                        rarity = 0.50;
                    }
                    if (characterlist1.rarity == 3)
                    {
                        rarity = 0.40;
                    }
                    characters.Add(name, rarity);
                }
            }
            // Create a dictionary to store the rarity and probability for each character
            //var characters = new Dictionary<string, double>()
            //{
            //    { "Skadi", 0.02 },
            //    { "Surtr", 0.02 },
            //    { "Specter", 0.08 },
            //    { "Texas", 0.08 },
            //    { "CliffHeart", 0.08 },
            //    { "Elysium", 0.08 },
            //    { "Lappland", 0.08 },
            //    { "Franka", 0.08 },
            //    { "Jaye", 0.50 },
            //    { "Ambriel", 0.50 },
            //    { "Melantha", 0.40 },
            //    { "Orchid", 0.40 }
            //};
            var rarityMap = new Dictionary<double, List<string>>();
            foreach (var character in characters)
            {
                if (!rarityMap.ContainsKey(character.Value))
                {
                    rarityMap[character.Value] = new List<string>();
                }

                rarityMap[character.Value].Add(character.Key);
            }

            // Loop 10 times to simulate pulling for 10 characters
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Test Pull: No Pity | Every Operator Available");
                var random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    var randomNumber = 0.1;
                    // Loop through the list of rarities and pick a random character from the list of characters with that rarity
                    var result = "";
                    var cumulativeProbability = 0.0;
                    foreach (var rarity in rarityMap.Keys)
                    {
                        cumulativeProbability += rarity;
                        if (randomNumber < cumulativeProbability)
                        {
                            List<string> characterList = rarityMap[rarity];

                            var index = random.Next(characterList.Count);
                            if (rarity == 0.02)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("******");
                            }
                            else if (rarity == 0.08)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("*****");
                            }
                            else if (rarity == 0.5)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("****");
                            }
                            else if (rarity == 0.4)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("***");
                            }
                            result = characterList[index];
                            break;
                        }
                    }

                    // Print the result
                    Console.Write( result + "\n");

                    Console.ResetColor();

                }
                Console.Write("Press [1] To Exit | Press any Key to Retry: ");
                string UInput = Console.ReadLine();
                if(UInput == "1")
                {
                    break;
                }
                Console.ReadLine();
            }
        }
    }
}