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
            List<int> neighborhood = Console
                      .ReadLine()
                      .Split("@", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                      .ToList();
            string input = string.Empty;
            int decreased = 2;
            int index = 0;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] command = input.Split(" ");
                index += int.Parse(command[1]);

                if (!(index < neighborhood.Count))
                {
                    index = 0;
                }
                if (neighborhood[index] == 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }
                else
                {
                    neighborhood[index] -= decreased;
                    if (neighborhood[index] == 0)
                    {
                        Console.WriteLine($"Place {index} has Valentine's day.");
                    }
                }
            }
            Console.WriteLine($"Cupid's last position was {index}.");
            int count = 0;
            for (int i = 0; i < neighborhood.Count; i++)
            {
                if (neighborhood[i] != 0)
                {
                    count++;
                }
            }
            if (neighborhood.All(x => x == 0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }

}

