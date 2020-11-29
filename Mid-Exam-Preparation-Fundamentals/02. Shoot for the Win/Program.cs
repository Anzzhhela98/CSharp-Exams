using System;
using System.Collections.Generic;
using System.Linq;

namespace Mid_Exam_Prepartion_Archive
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console
                       .ReadLine()
                       .Split()
                       .Select(int.Parse)
                       .ToList();
            string command = Console.ReadLine();
            int count = 0;
            while (command != "End")
            {
                int index = int.Parse(command);
                if (index < targets.Count) // that work
                {
                    count++;
                    int num = targets[index];
                    targets.Remove(num);
                    targets.Insert(index, -1);
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] > num && targets[i] != -1)
                        {
                            targets[i] -= num;
                        }
                        else if (targets[i] <= num && targets[i] != -1)
                        {
                            targets[i] += num;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {count} -> {String.Join(" ", targets)}");
        }
    }
}
