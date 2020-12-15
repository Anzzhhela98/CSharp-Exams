using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{7,})\]";
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                if (matches.Count == 0)
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }
                List<int> intChar = new List<int>();
                foreach (Match message in matches)
                {
                    string arr = message.Groups[2].ToString();
                    for (int j = 0; j < arr.Length; j++)
                    {
                        intChar.Add((char)arr[j]);
                    }
                    Console.WriteLine($"{message.Groups[1]}: {String.Join(" ", intChar)}");
                }

            }


        }
    }
}