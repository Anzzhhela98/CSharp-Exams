using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20.check
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> arrayNums = Console
                       .ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList();
            string input = string.Empty;
            int index1 = 0;
            int index2 = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] splitted = input.Split(" ");
                if (splitted[0] != "decrease")
                {
                    index1 = int.Parse(splitted[1]);
                    index2 = int.Parse(splitted[2]);
                }
                switch (splitted[0])
                {
                    case "swap":
                        int firstNum = arrayNums[index1];
                        int secondNum = arrayNums[index2];

                        arrayNums.RemoveAt(index1);
                        arrayNums.Insert(index1, secondNum);

                        arrayNums.RemoveAt(index2);
                        arrayNums.Insert(index2, firstNum);
                        break;
                    case "multiply":
                        int myltiply = arrayNums[index1] * arrayNums[index2];
                        arrayNums.RemoveAt(index1);
                        arrayNums.Insert(index1, myltiply);
                        break;
                    case "decrease":
                        arrayNums = arrayNums.Select(x => x - 1).ToList();
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", arrayNums));
        }
    }

}

