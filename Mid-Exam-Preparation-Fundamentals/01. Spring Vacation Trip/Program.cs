using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int countPeople = int.Parse(Console.ReadLine());
            double ffuelPerKM = double.Parse(Console.ReadLine());
            double foodPrice = double.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());

            double spendMoney = 0;
            if (countPeople > 10)
            {
                nightPrice *= 0.75;
            }
            spendMoney += countPeople * daysTrip * (foodPrice + nightPrice);
            for (int i = 1; i <= daysTrip; i++)
            {
                double distance = double.Parse(Console.ReadLine());

                spendMoney += (distance * ffuelPerKM);
                if (i % 3 == 0 || i % 5 == 0)
                {
                    spendMoney *= 1.4;
                }
                else if (i % 7 == 0)
                {
                    spendMoney -= spendMoney / countPeople;
                }
                if (spendMoney > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(spendMoney - budget):f2}$ more.");
                    return;
                }
            }
            Console.WriteLine($"You have reached the destination. You have {budget - spendMoney:F2}$ budget left.");
        }
    }
}

