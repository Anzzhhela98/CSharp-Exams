using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<string, List<string>>();

            string[] input = Console
                          .ReadLine()
                          .Split(new string[] { " | " },
                           StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            foreach (var wrd in input)
            {
                string[] splitted = wrd
                    .Split(new string[] { ": " },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < splitted.Length; i++)
                {
                    if (!dictionary.ContainsKey(splitted[0]))
                    {
                        dictionary.Add(splitted[0], new List<string>());

                    }
                    dictionary[splitted[0]].Add($" -{splitted[i]}");
                }
            }
            var word = Console.ReadLine().Split(" | ");

            foreach (var newWrd in word)
            {
                if (dictionary.ContainsKey(newWrd))
                {
                    foreach (var item in dictionary.Where(x => x.Key == newWrd))
                    {
                        Console.WriteLine(newWrd);
                        Console.WriteLine(string.Join("\n", item.Value
                            .OrderByDescending(x => x.Length)));
                    }
                }
            }
            string command = Console.ReadLine();
            if (command == "List")
            {
                Console.WriteLine(string.Join(" ", dictionary
                    .Select(x => x.Key)));
            }
        }
    }
}
