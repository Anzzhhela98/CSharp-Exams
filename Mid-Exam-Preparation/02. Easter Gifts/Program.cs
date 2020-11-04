using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console
                         .ReadLine()
                         .Split(" ")
                         .ToList();
            string command = string.Empty;
            int count = 0;
            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] splitted = command.Split(" ");

                switch (splitted[0])
                {
                    case "OutOfStock":
                        for (int i = 0; i < gifts.Count; i++)
                        {
                            if (gifts[i] == splitted[1])
                            {
                                gifts[i] = "None";
                                count++;
                            }
                        }
                        break;
                    case "Required":
                        int index = int.Parse(splitted[2]);
                        if (index >= 0 && index < gifts.Count) // work
                        {
                            gifts.RemoveAt(index);
                            gifts.Insert(index, splitted[1]);
                        }
                        break;
                    case "JustInCase":
                        if (true) // work
                        {
                            int lastIndex = gifts.Count - 1;
                            gifts.RemoveAt(lastIndex);
                            gifts.Add(splitted[1]);
                        }
                        break;
                }
               
            }
            for (int i = 0; i < count; i++)
            {
                gifts.Remove("None");
            }
            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}
