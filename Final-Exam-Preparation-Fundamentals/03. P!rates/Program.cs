using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> citiesGoldPopul =
                new Dictionary<string, List<int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] splitted = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
                string town = splitted[0];
                int people = int.Parse(splitted[1]);
                int gold = int.Parse(splitted[2]);

                if (!citiesGoldPopul.ContainsKey(town))
                {
                    citiesGoldPopul[town] = new List<int>();
                    citiesGoldPopul[town].Add(people);
                    citiesGoldPopul[town].Add(gold);
                }
                else
                {
                    citiesGoldPopul[town][1] += gold;
                    citiesGoldPopul[town][0] += people;
                }

            }
            string input2 = string.Empty;
            while ((input2 = Console.ReadLine()) != "End")
            {
                string[] splitted = input2
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string town = splitted[1];
                int gold = 0;
                switch (splitted[0])
                {
                    case "Plunder":
                        gold = int.Parse(splitted[3]);
                        int people = int.Parse(splitted[2]);
                        citiesGoldPopul[town][0] -= people;
                        citiesGoldPopul[town][1] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (citiesGoldPopul[town][0] <= 0 || citiesGoldPopul[town][1] <= 0)
                        {
                            citiesGoldPopul.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        gold = int.Parse(splitted[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        citiesGoldPopul[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {citiesGoldPopul[town][1]} gold.");
                        break;
                }
            }
            if (citiesGoldPopul.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesGoldPopul.Count}" +
                      $" wealthy settlements to go to:");

                foreach (var kvp in citiesGoldPopul.OrderByDescending(g=>g.Value[1]).ThenBy(n=>n.Key))
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
        }
    }
}
