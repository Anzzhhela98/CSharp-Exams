using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string command = string.Empty;
            int startIndex = 0;
            int endIndex = 0;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] splitted = command
                 .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string instruction = splitted[0];
                switch (instruction)
                {
                    case "Contains":
                        string substring = splitted[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                            continue;
                        }
                        Console.WriteLine("Substring not found!");
                        break;
                    case "Flip":
                        string upperOrLower = splitted[1];
                        startIndex = int.Parse(splitted[2]);
                        endIndex = int.Parse(splitted[3]);
                        string type = string.Empty;
                        if (upperOrLower == "Upper")
                        {
                            type = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                        }
                        else
                        {
                            type = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                        }
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        activationKey = activationKey.Insert(startIndex, type);
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(splitted[1]);
                        endIndex = int.Parse(splitted[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                }
            }
                Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
