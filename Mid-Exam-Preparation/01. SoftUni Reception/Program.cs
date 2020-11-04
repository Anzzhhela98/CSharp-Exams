using System;

namespace _01._SoftUni_Reception_archive
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeEfficiency1 = int.Parse(Console.ReadLine());
            int employeeEfficiency2 = int.Parse(Console.ReadLine());
            int employeeEfficiency3 = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());
            double studentsPerHour = employeeEfficiency1 + employeeEfficiency2 + employeeEfficiency3;
            double hour = 0;

            while (studentsCount > 0)
            {
                studentsCount -= (int)studentsPerHour;
                hour++;

                if (hour % 4 == 0)
                {
                    hour++;
                }

            }
            Console.WriteLine($"Time needed: {hour}h.");
        }
    }
}
