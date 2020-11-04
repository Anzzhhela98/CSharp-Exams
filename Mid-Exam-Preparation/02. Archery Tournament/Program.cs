using System;
using System.Collections.Generic;
using System.Linq;

namespace check
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console
                        .ReadLine()
                        .Split("|")
                        .Select(int.Parse)
                        .ToList();
            string command = string.Empty;
            int points = 0;
            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] splitted = command.Split("@");
                if (splitted[0] == "Shoot Left")
                {
                    int index = int.Parse(splitted[1]);
                    int length = int.Parse(splitted[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        for (int i = index; i >= 0; i--)
                        {
                            if (length == 0)
                            {
                                if (targets[i] < 5)
                                {
                                    points += targets[i];
                                    targets[i] = 0;
                                    break;
                                }
                                targets[i] -= 5;
                                points += 5;
                                break;
                            }
                            length--;
                            if (i == 0)
                            {
                                i = targets.Count;
                            }
                        }
                    }
                }
                else if (splitted[0] == "Shoot Right")
                {
                    int index = int.Parse(splitted[1]);
                    int length = int.Parse(splitted[2]);
                    if (index >= 0 && index < targets.Count)
                    {
                        for (int i = index; i < targets.Count; i++)
                        {
                            if (length == 0)
                            {
                                if (targets[i] < 5)
                                {
                                    points += targets[i];
                                    targets[i] = 0;
                                    break;
                                }
                                targets[i] -= 5;
                                points += 5;
                                break;

                            }
                            length--;
                            if (i == targets.Count - 1)
                            {
                                i = -1;
                            }
                        }
                    }
                }
                else if (splitted[0] == "Reverse")
                {
                    targets.Reverse();
                }
            }
            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}