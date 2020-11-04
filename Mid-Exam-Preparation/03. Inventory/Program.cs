using System;
using System.Collections.Generic;
using System.Linq;

namespace check
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console
                          .ReadLine()
                          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                          .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] splitted = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                Collect(splitted, list);
                Drop(splitted, list);
                Combine(splitted, list);
                Renew(splitted, list);

            }
            Console.WriteLine(string.Join(", ", list));

        }
        static void Collect(string[] splitted, List<string> list)
        {
            switch (splitted[0])
            {
                case "Collect":
                    if (!list.Contains(splitted[1]))
                    {
                        list.Add(splitted[1]);
                    }
                    break;
            }
        }
        static void Drop(string[] splitted, List<string> list)
        {
            switch (splitted[0])
            {
                case "Drop":
                    if (list.Contains(splitted[1]))
                    {
                        list.Remove(splitted[1]);
                    }
                    break;
            }
        }
        static void Combine(string[] splitted, List<string> list)
        {
            var newSplit = splitted[1].Split(":");
            switch (splitted[0])
            {
                case "Combine Items":
                    if (list.Contains(newSplit[0]))
                    {
                        int index = list.IndexOf(newSplit[0]);
                        list.Insert(index + 1, newSplit[1]);
                    }
                    break;
            }
        }
        static void Renew(string[] splitted, List<string> list)
        {
            switch (splitted[0])
            {
                case "Renew":
                    if (list.Contains(splitted[1]))
                    {

                        list.Remove(splitted[1]);
                        list.Add(splitted[1]);
                    }
                    break;
            }
        }
    }
}
