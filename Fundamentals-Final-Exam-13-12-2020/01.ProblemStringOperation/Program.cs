using System;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] splitted = command
                          .Split(" ")
                          .ToArray();
                int startIndex = 0;
                int endIndex = 0;
                switch (splitted[0])
                {
                    case "Replace":
                        string currChar = splitted[1];
                        string newChar = splitted[2];
                        message = message.Replace(currChar, newChar);
                        Console.WriteLine(message);
                        break;
                    case "Cut"://?
                        startIndex = int.Parse(splitted[1]);
                        endIndex = int.Parse(splitted[2]);
                        if ((startIndex >= 0 && startIndex < message.Length) &&
                            endIndex >= 0 && endIndex < message.Length)
                        {
                            message = message.Remove(startIndex, endIndex - startIndex + 1);

                            Console.WriteLine(message);
                            continue;
                        }
                        Console.WriteLine("Invalid indices!");
                        break;
                    case "Make":
                        string upperOrLower = splitted[1];
                        if (upperOrLower == "Upper")
                        {
                            message = message.ToUpper();
                            Console.WriteLine(message);
                            continue;
                        }
                        message = message.ToLower();
                        Console.WriteLine(message);
                        break;
                    case "Check":
                        string substring = splitted[1];
                        if (message.Contains(substring))
                        {
                            Console.WriteLine($"Message contains {substring}");
                            continue;
                        }
                        Console.WriteLine($"Message doesn't contain {substring}");
                        break;
                    case "Sum":
                        startIndex = int.Parse(splitted[1]);
                        endIndex = int.Parse(splitted[2]);
                        if ((startIndex >= 0 && startIndex < message.Length) &&
                            endIndex >= 0 && endIndex < message.Length)
                        {
                            string subString = message.Substring(startIndex, endIndex);
                            int sum = 0;
                            for (int i = 0; i < subString.Length; i++)
                            {
                                sum += (char)subString[i];
                            }
                            Console.WriteLine(sum);
                            continue;
                        }
                        Console.WriteLine("Invalid indices!");
                        break;
                }
            }

        }
    }
}