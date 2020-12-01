using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carsThemselves =
                new Dictionary<string, List<int>>();
            for (int i = 0; i < num; i++)
            {
                string[] info =
                    Console.ReadLine().Split("|");
                string carName = info[0];
                int distance = int.Parse(info[1]);
                int fuel = int.Parse(info[2]);
                carsThemselves.Add(carName, new List<int>());
                carsThemselves[carName].Add(distance);
                carsThemselves[carName].Add(fuel);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] info = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string carName = info[1];
                int fuel = 0;

                switch (info[0])
                {
                    case "Drive":
                        int distance = int.Parse(info[2]);
                        fuel = int.Parse(info[3]);
                        if (carsThemselves[carName][1] - fuel >= 0)
                        {
                            carsThemselves[carName][0] += distance;
                            carsThemselves[carName][1] -= fuel;
                            Console.WriteLine($"{carName} driven for {distance}" +
                                $" kilometers. {fuel} liters of fuel consumed.");
                            if (carsThemselves[carName][0] >= 100000)
                            {
                                carsThemselves.Remove(carName);
                                Console.WriteLine($"Time to sell the {carName}!");
                            }
                            continue;
                        }
                        Console.WriteLine("Not enough fuel to make that ride");

                        break;
                    case "Refuel":
                        fuel = int.Parse(info[2]);
                        if (carsThemselves[carName][1] + fuel > 75)
                        {
                            carsThemselves[carName][1] += 75 - carsThemselves[carName][1];
                            Console.WriteLine($"{carName} refueled with {75 - fuel} liters");
                        }
                        else
                        {
                            carsThemselves[carName][1] += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                        }
                        break;
                    case "Revert":
                        int kilometers = int.Parse(info[2]); ;
                        carsThemselves[carName][0] -= kilometers;
                        if (carsThemselves[carName][0] < 10000)
                        {
                            carsThemselves[carName][0] = 10000;
                            continue;
                        }
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                        break;
                }
            }
            PrintResult(carsThemselves);
        }

        private static void PrintResult(Dictionary<string, List<int>> carsThemselves)
        {
            foreach (var kvp in carsThemselves.OrderByDescending(m => m.Value[0]).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{kvp.Key} -> Mileage:" +
                    $" {kvp.Value[0]} kms, Fuel in the tank: {kvp.Value[1]} lt.");
            }
        }
    }
}
