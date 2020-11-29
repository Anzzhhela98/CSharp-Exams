using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console
                             .ReadLine()
                             .Split("!")
                             .ToList();

            string[] command = Console.ReadLine().Split(" ");
            while (command[0] != "Go")
            {
                switch (command[0])
                {
                    case "Urgent":
                        if (!groceries.Contains(command[1]))
                        {
                            groceries.Insert(0, command[1]);
                        }
                        break;
                    case "Unnecessary":
                        if (groceries.Contains(command[1]))
                        {
                            groceries.Remove(command[1]);
                        }
                        break;
                    case "Correct":
                        if (groceries.Contains(command[1]))
                        {
                            int index = groceries.IndexOf(command[1]);
                            groceries.Remove(command[1]);
                            groceries.Insert(index, command[2]);
                        }
                        break;
                    case "Rearrange":
                        if (groceries.Contains(command[1]))
                        {
                            groceries.Remove(command[1]);
                            groceries.Add(command[1]);
                        }
                        break;
                }


                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
