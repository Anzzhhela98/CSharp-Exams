using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console
                      .ReadLine()
                      .Split(' ')
                      .Select(int.Parse)
                      .ToList();
            string[] command = Console.ReadLine().Split(" ");
            while (command[0] != "End")
            {
                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);
                bool isExistIndex = index < targets.Count && index >= 0;
                switch (command[0])
                {
                    case "Shoot": // work
                        if (isExistIndex)
                        {
                            targets[index] -= value;
                            if (targets[index] <= 0)
                            {
                                targets.Remove(targets[index]);
                            }
                        }
                        break;
                    case "Add": // work
                        if (isExistIndex)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        if (isExistIndex)
                        {
                            if (index - value >= 0 && index + value < targets.Count - 1)
                            {
                                targets.RemoveRange(index - value, value * 2 + 1);
                            }
                            else
                            {
                                Console.WriteLine("Strike missed!");
                            }
                            int num = targets.Count - 1;
                        }
                        break;
                }
                command = Console.ReadLine().Split(" ");
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
