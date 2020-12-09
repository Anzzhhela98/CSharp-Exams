using System;
using System.Collections.Generic;
using System.Linq;

namespace War_Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console
                           .ReadLine()
                           .Split(">")
                           .Select(int.Parse)
                           .ToList();

            List<int> warShip = Console
                      .ReadLine()
                      .Split(">")
                      .Select(int.Parse)
                      .ToList();
            int maxHealt = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int index = 0;
            int endIndex = 0;
            int damage = 0;
            int currHealth = 0;
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] splitted = input.Split(" ");
                string command = splitted[0];
                switch (command)
                {
                    case "Fire":
                        index = int.Parse(splitted[1]);
                        damage = int.Parse(splitted[2]);
                        if (index >= 0 && index < warShip.Count)
                        {
                            warShip[index] -= damage;
                            if (warShip[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        index = int.Parse(splitted[1]);
                        endIndex = int.Parse(splitted[2]);
                        damage = int.Parse(splitted[3]);
                        if (index >= 0 && index <= endIndex && endIndex <= pirateShip.Count - 1)
                        {
                            for (int i = index; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        index = int.Parse(splitted[1]);
                        currHealth = int.Parse(splitted[2]);

                        if (index >= 0 && index <= pirateShip.Count - 1)
                        {
                            if (pirateShip[index] + currHealth < maxHealt)
                            {
                                pirateShip[index] += currHealth;
                            }
                            else
                            {
                                pirateShip[index] = maxHealt;
                            }
                        }
                        break;
                    case "Status":
                        int counter = 0;
                        double lowerPrecent = maxHealt * 0.2;
                        for (int i = 0; i < pirateShip.Count; i++)
                        {
                            if (pirateShip[i] < lowerPrecent)
                            {
                                counter++;
                            }
                        }
                        Console.WriteLine($"{counter} sections need repair.");
                        break;
                }
            }
            int sumPirate = pirateShip.Sum();
            int sumWarShipe = warShip.Sum();
            Console.WriteLine($"Pirate ship status: {sumPirate}");
            Console.WriteLine($"Warship status: {sumWarShipe}");

        }
    }
}
