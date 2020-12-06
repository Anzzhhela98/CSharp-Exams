using System;
using System.Linq;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] splitted = command
                          .Split(":")
                          .ToArray();
                int index = 0;
                switch (splitted[0])
                {
                    case "Add Stop":
                        index = int.Parse(splitted[1]);
                        if (index >= 0 && index < input.Length)
                        {
                            input = input.Insert(index, splitted[2]);
                        }
                        PrintCurrentState(input);
                        break;
                    case "Remove Stop":
                        index = int.Parse(splitted[1]);
                        int endIndex = int.Parse(splitted[2]);
                        if ((index >= 0 && index < input.Length) &&
                            (endIndex >= 0 && endIndex < input.Length))
                        {
                            int count = endIndex - index;
                            input = input.Remove(index, endIndex - index + 1);
                        }
                        PrintCurrentState(input);
                        break;
                    case "Switch":
                        string oldString = splitted[1];
                        string newString = splitted[2];
                        if (input.Contains(oldString))
                        {
                            input = input.Replace(oldString, newString);
                        }
                        PrintCurrentState(input);
                        break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }

        private static void PrintCurrentState(string input)
        {
            Console.WriteLine(input);
        }
    }
}
