using System;
using System.Collections.Generic;
using System.Linq;

namespace check
{
    class Program
    {
        static void Main(string[] args)
        {

            double buget = double.Parse(Console.ReadLine());

            double priceKiloFlour = double.Parse(Console.ReadLine());
            double priceEggs = priceKiloFlour * 0.75;
            double priceMilk = (priceKiloFlour * 1.25);

            int coloredEggs = 0;
            int countCozanac = 0;
            double costCozanac = costCozanac = priceEggs + priceKiloFlour + (priceMilk / 4);
            while (buget > 0)
            {
                if (costCozanac > buget)
                {
                    break;

                }
                buget -= costCozanac;
                if (buget > 0)
                {
                    countCozanac++;
                    coloredEggs += 3;
                }
                if (countCozanac % 3 == 0)
                {
                    coloredEggs -= countCozanac - 2;
                }
            }
            Console.WriteLine($"You made {countCozanac} cozonacs! Now you have {coloredEggs} eggs and {buget:f2}BGN left.");
        }
    }
}
