using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = Console
                      .ReadLine()
                      .Split(" ")
                      .ToList();
            string input = string.Empty;
            int index = 0;
            string word1 = string.Empty;
            string word2 = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splitted = input.Split(" ");
                string command = splitted[0];
                switch (command)
                {
                    case "Delete":
                        index = int.Parse(splitted[1]) + 1;
                        if (index >= 0 && index < collection.Count)
                        {
                            collection.RemoveAt(index);
                        }
                        break;
                    case "Swap":
                        word1 = splitted[1];
                        word2 = splitted[2];
                        if (collection.Contains(word1) && collection.Contains(word2))
                        {
                            int firstWord = collection.IndexOf(word1);
                            int secondWord = collection.IndexOf(word2);
                            collection[firstWord] = word2;
                            collection[secondWord] = word1;
                        }
                        break;
                    case "Put":
                        word1 = splitted[1];
                        index = int.Parse(splitted[2]) - 1;
                        if (index >= 0 && index <= collection.Count)
                        {
                            collection.Insert(index, word1);
                        }
                        break;
                    case "Sort":
                        collection.Sort();
                        collection.Reverse();
                        break;
                    case "Replace":
                        word1 = splitted[1];
                        word2 = splitted[2];
                        if (collection.Contains(word2))
                        {
                            index = collection.IndexOf(word2);
                            collection.RemoveAt(index);
                            collection.Insert(index, word1);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
