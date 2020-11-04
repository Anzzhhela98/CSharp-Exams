using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20.check
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonsRooms = Console
                      .ReadLine()
                      .Split("|")
                      .ToList();
            // healt = 100;
            int healt = 100;
            int currentHealt = 100;
            int bitcoins = 0;
            for (int i = 0; i < dungeonsRooms.Count; i++)
            {
                string[] splitted = dungeonsRooms[i].Split(" ");
                string command = splitted[0];
                int num = int.Parse(splitted[1]);
                if (command == "potion")
                {
                    if (currentHealt + num <= healt)
                    {
                        currentHealt += num;
                    }
                    else
                    {
                        num = healt - currentHealt;
                        currentHealt = 100;

                    }
                    Console.WriteLine($"You healed for {num} hp.");
                    Console.WriteLine($"Current health: {currentHealt} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += num;
                    Console.WriteLine($"You found {num} bitcoins.");
                }
                else
                {
                    if (currentHealt - num <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        currentHealt -= num;
                        Console.WriteLine($"You slayed {command}.");
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {currentHealt}");
        }

    }
}
