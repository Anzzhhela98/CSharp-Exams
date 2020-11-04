using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDays = int.Parse(Console.ReadLine());
            int countPalyer = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());
            double amountFood = countDays * countPalyer * foodPerPerson;
            double amountwater = countDays * countPalyer * waterPerPerson;
            for (int i = 1; i <= countDays; i++)
            {
                double energyLose = double.Parse(Console.ReadLine());
                    energy -= energyLose;

                if (energy <= 0)
                {
                    break;
                }
               
                if (i % 2 == 0) // water drink
                {
                    energy *= 1.05;
                    amountwater *= 0.70;
                }
                 if (i % 3 == 0)
                {
                    amountFood -= amountFood / countPalyer;
                    energy *= 1.1;
                }
            }
            if (energy >0 )
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {amountFood:f2} food and {amountwater:f2} water.");
            }

        }
    }
}
