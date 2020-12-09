using System;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dayPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dayPlunder;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    totalPlunder += dayPlunder * 0.50;
                    totalPlunder *= 0.70;
                }
                else if (i % 3 == 0)
                {
                    totalPlunder += dayPlunder * 0.50;
                }
                else if (i % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double precent = (totalPlunder / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {precent:f2}% of the plunder.");
            }
        }
    }
}
