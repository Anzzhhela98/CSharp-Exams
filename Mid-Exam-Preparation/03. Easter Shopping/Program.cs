using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console
                      .ReadLine()
                      .Split(" ")
                      .ToList();
            int countCommands = int.Parse(Console.ReadLine());
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < countCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "Include":
                        shops.Add(command[1]);
                        break;
                    case "Visit":
                        int countShop = int.Parse(command[2]);
                        if (command[1] == "first" && shops.Count >= countShop) //?
                        {
                            for (int j = 1; j <= countShop; j++)
                            {

                                shops.RemoveAt(0);
                            }
                        }
                        else if (command[1] == "last" && shops.Count >= countShop) //?)
                        {
                            for (int k = 0; k < countShop; k++)
                            {
                                shops.RemoveAt(shops.Count - 1);
                            }
                        }
                        break;
                    case "Prefer":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        if ((index1 >= 0 && index1 < shops.Count) && (index2 >= 0 && index2 < shops.Count))
                        {
                            string firstShopName = shops[index1];
                            string secondShopName = shops[index2];
                            shops.Remove(firstShopName);
                            shops.Insert(index1, secondShopName);
                            shops.RemoveAt(index2);
                            shops.Insert(index2, firstShopName);
                        }
                        break;
                    case "Place":
                        index2 = int.Parse(command[2]);
                        if (index2 + 1 >= 0 && index2 + 1 < shops.Count)
                        {
                            shops.Insert(index2 + 1, command[1]);
                        }
                        break;
                }

            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
