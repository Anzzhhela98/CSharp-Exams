using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace __Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var plantsExhibition = new Dictionary<string, List<double>>();
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split("<->");
                if (!plantsExhibition.ContainsKey(input[0]))
                {
                    plantsExhibition.Add(input[0], new List<double>());
                    plantsExhibition[input[0]].Add(double.Parse(input[1]));
                    plantsExhibition[input[0]].Add(0);
                    plantsExhibition[input[0]].Add(0);
                    continue;
                }
                plantsExhibition[input[0]].Add(double.Parse(input[1]));
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                var cmdArgs = command
                    .Split(new String[] { ": ", " - " },
                    StringSplitOptions.RemoveEmptyEntries);
                string plant = cmdArgs[1];
                switch (cmdArgs[0])
                {
                    case "Rate":
                        if (plantsExhibition.ContainsKey(plant))
                        {
                            plantsExhibition[plant][1] += double.Parse(cmdArgs[2]);
                            plantsExhibition[plant][2]++;
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    case "Update":
                        if (plantsExhibition.ContainsKey(plant))
                        {
                            plantsExhibition[plant][0] = double.Parse(cmdArgs[2]);
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    case "Reset":
                        if (plantsExhibition.ContainsKey(plant))
                        {
                            plantsExhibition[plant][1] = 0;
                            plantsExhibition[plant][2] = 0;
                            continue;
                        }
                        Console.WriteLine("error");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            foreach (var plant in plantsExhibition)
            {
                if (plant.Value[1] != 0)
                {
                    double averageRaiting = plant.Value[1] / plant.Value[2];
                    plantsExhibition[plant.Key][1] = averageRaiting;
                    continue;
                }
                plantsExhibition[plant.Key][1] = 0;
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plantsExhibition
                .OrderByDescending(v => v.Value[0]).ThenByDescending(r => r.Value[1]))
            {

                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; " +
                    $"Rating: {(item.Value[1]):f2}");
            }
        }
    }
}
