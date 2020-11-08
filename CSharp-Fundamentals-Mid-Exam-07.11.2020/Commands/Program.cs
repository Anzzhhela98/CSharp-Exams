using System;
using System.Collections.Generic;
using System.Linq;

namespace Second_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console
                       .ReadLine()
                       .Split(" ")
                       .ToList();
            string input = string.Empty;
            int start = 0;
            int count1 = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] splitted = input.Split(" ");
                switch (splitted[0])
                {
                    case "reverse":
                        start = int.Parse(splitted[2]);
                        count1 = int.Parse(splitted[4]);
                        nums.Reverse(start, count1);

                        break;
                    case "sort":
                        start = int.Parse(splitted[2]);
                        count1 = int.Parse(splitted[4]);
                        nums.Sort(start, count1, null);
                        break;
                    case "remove":
                        count1 = int.Parse(splitted[1]);
                        for (int i = 0; i < count1; i++)
                        {
                            nums.RemoveAt(0);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
