using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> painting = Console
                      .ReadLine()
                      .Split()
                      .Select(int.Parse)
                      .ToList();
            string comand = string.Empty;
            int value1 = 0;
            int value2 = 0;
            while ((comand = Console.ReadLine()) != "END")
            {
                string[] splitted = comand.Split(" ");
                if (splitted[0] != "Reverse" && splitted[0] != "Hide")
                {
                    value1 = int.Parse(splitted[1]);
                    value2 = int.Parse(splitted[2]);
                }
                if (splitted[0] == "Change")
                {
                    Change(value1, value2, painting);
                }
                else if (splitted[0] == "Hide")
                {
                    Hide(splitted, painting); //?
                }
                else if (splitted[0] == "Switch")
                {
                    Switch(value1, value2, painting);
                }
                else if (splitted[0] == "Insert")
                {
                    Insert(value1, value2, painting);
                }
                else if (splitted[0] == "Reverse")
                {
                    Reverse(painting);
                }
            }
            Console.WriteLine(string.Join(" ", painting));
        }
        static void Change(int value1, int value2, List<int> painting)
        {
            if (painting.Contains(value1))
            {
                int index = painting.IndexOf(value1);
                painting.RemoveAt(index);
                painting.Insert(index, value2);
            }
        }
        static void Hide(string[] splitted, List<int> painting)
        {
            int value1 = int.Parse(splitted[1]);
            if (painting.Contains(value1))
            {
                painting.Remove(value1);
            }
        }
        static void Switch(int value1, int value2, List<int> painting)
        {
            if (painting.Contains(value1) && painting.Contains(value2))
            {
                int index1 = painting.IndexOf(value1);
                int index2 = painting.IndexOf(value2);

                painting.Remove(value1);
                painting.Insert(index1, value2);

                painting.RemoveAt(index2);
                painting.Insert(index2, value1);
            }
        }
        static void Insert(int value1, int value2, List<int> painting)
        {
            if (value1 + 1 > 0 && value1 + 1 < painting.Count)
            {
                painting.Insert(value1 + 1, value2);
            }
        }
        static void Reverse(List<int> painting)
        {
            painting.Reverse();
        }
    }
}
