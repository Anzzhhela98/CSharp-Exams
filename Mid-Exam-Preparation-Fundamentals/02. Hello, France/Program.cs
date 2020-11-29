using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console
                      .ReadLine()
                      .Split("|", StringSplitOptions.RemoveEmptyEntries)
                      .ToList();
            double buget = double.Parse(Console.ReadLine());
            double profit = 0;
            List<double> newPrice = new List<double>();
            for (int i = 0; i < input.Count; i++)
            {
                string[] splitted = input[i].Split("->");
                string item = splitted[0];
                double curentPrice = double.Parse(splitted[1]);
                double maxPrice = 0;

                if (item == "Clothes")
                {
                    maxPrice = 50;
                }
                else if (item == "Shoes")
                {
                    maxPrice = 35;
                }
                else
                {
                    maxPrice = 20.5;
                }
                if (buget >= curentPrice && curentPrice <= maxPrice)
                {
                    buget -= curentPrice;
                    profit += curentPrice * 0.40;
                    newPrice.Add(curentPrice * 1.4);
                }
            }
            Console.WriteLine(string.Join(" ", newPrice.Select(x => string.Format("{0:0.00}", x))));
            Console.WriteLine($"Profit: {profit:f2}");
            double ticketsPayment = 150;
            if ((buget + newPrice.Sum()) >= ticketsPayment)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }



        }
    }
}
