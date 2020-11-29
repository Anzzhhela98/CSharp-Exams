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
            int countStudents = int.Parse(Console.ReadLine());
            int countLectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            int maxBonus = int.MinValue;
            if (countStudents == 0 || countLectures == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }
            for (int i = 0; i < countStudents; i++)
            {
                int atendance = int.Parse(Console.ReadLine());
                if (maxBonus < atendance)
                {
                    maxBonus = atendance;
                }

            }
            double totalBonus = ((maxBonus * 1.0) / countLectures) * (5 + bonus);
            Console.WriteLine($"Max Bonus: {Math.Round(totalBonus)}.");
            Console.WriteLine($"The student has attended {maxBonus} lectures.");
        }

    }
}
