using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> storePlants =
                new Dictionary<string, List<double>>();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console
                         .ReadLine()
                         .Split("<->")
                         .ToArray();
                string namePlant = input[0];
                double rarity = double.Parse(input[1]);
                if (!storePlants.ContainsKey(input[0]))
                {
                    storePlants.Add(input[0], new List<double>());
                    storePlants[namePlant].Add(rarity);
                    storePlants[namePlant].Add(0);
                    storePlants[namePlant].Add(0);
                    continue;
                }
                storePlants[namePlant][0] = rarity;
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] splitted = command
                        .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                string plant = splitted[1];

                switch (splitted[0])
                {
                    case "Rate":
                        if (storePlants.ContainsKey(plant))
                        {
                            double raiting = double.Parse(splitted[2]);
                            storePlants[plant][1] += raiting;
                            storePlants[plant][2] += 1;
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    case "Update":
                        if (storePlants.ContainsKey(plant))
                        {
                            double rarity = double.Parse(splitted[2]);
                            storePlants[plant][0] = rarity;
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    case "Reset":
                        if (storePlants.ContainsKey(plant))
                        {
                            storePlants[plant][1] = 0;
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            foreach (var rating in storePlants)
            {
                double average = rating.Value[1] / rating.Value[2];
                if (rating.Value[1] != 0)
                {
                    rating.Value[1] = average;
                }
                rating.Value.Remove(rating.Value[2]);

            }
            storePlants = storePlants
                .OrderByDescending(x => x.Value[0])
                .ThenByDescending(a => a.Value[1]).ToDictionary(x=>x.Key,a=>a.Value);
                Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in storePlants)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }
        }
    }
}
