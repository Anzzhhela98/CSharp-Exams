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
            int waitingPeople = int.Parse(Console.ReadLine());
            List<int> curentState = Console
                      .ReadLine()
                      .Split(" ")
                      .Select(int.Parse)
                      .ToList();
            int maxPeople = 4;
            for (int i = 0; i < curentState.Count; i++)
            {
                if (waitingPeople >= maxPeople && curentState[i] == 0)
                {
                    waitingPeople -= maxPeople;
                    curentState[i] = maxPeople;
                }
                else if (waitingPeople < maxPeople && curentState[i] == 0)
                {
                    curentState[i] = waitingPeople;
                    waitingPeople -= curentState[i];
                    continue;
                }
                else if (waitingPeople < maxPeople || curentState[i] > 0)
                {
                    waitingPeople -= maxPeople - curentState[i];
                    curentState[i] += maxPeople - curentState[i];
                }
                bool isAvailableSpace = curentState.All(x => x == 4);
                if (isAvailableSpace || waitingPeople == 0)
                {
                    break;
                }
            }
            if (waitingPeople == 0 && curentState.Any(x => x < maxPeople))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", curentState));

            }
            else if (waitingPeople > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
                Console.WriteLine(string.Join(" ", curentState));
            }
            else
            {
                Console.WriteLine(string.Join(" ", curentState));
            }
        }
    }

}

