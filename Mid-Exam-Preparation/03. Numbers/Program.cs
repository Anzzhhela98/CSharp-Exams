using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceIntegers = Console
                     .ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToList();

            List<int> nums = new List<int>();
            double averageSum = sequenceIntegers.Average();

            nums = sequenceIntegers
              .OrderByDescending(x => x)
              .Where(num => num > averageSum)
              .Take(5)
              .ToList();

            if (nums.Count <= 0)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
