using System;
using System.Collections.Generic;
using System.Linq;

namespace tryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            double totalPrice = 0;
            double taxes = 0;
            while (((command = Console.ReadLine()) != "special" && command != "regular"))
            {
                double itemPrice = double.Parse(command);
                if (itemPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalPrice += itemPrice;
                    taxes += itemPrice * 0.20;
                }
            }
            double allMoney = totalPrice + taxes;
            if (command == "special")
            {
                allMoney *= 0.90;
            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$ ");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {allMoney:f2}$");
            }

        }
    }
}
