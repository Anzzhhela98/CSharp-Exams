using System;
using System.Collections.Generic;
using System.Linq;

namespace Chek_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console
                       .ReadLine()
                       .Split(", ")
                       .ToList();

            int n = int.Parse(Console.ReadLine());
            string cardName = "";
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                switch (command)
                {
                    case "Add":
                        cardName = input[1];
                        if (cards.Contains(cardName))
                        {
                            Console.WriteLine("Card is already bought");
                        }
                        else
                        {
                            cards.Add(cardName);
                            Console.WriteLine("Card successfully bought");
                        }
                        break;
                    case "Remove":
                        cardName = input[1];
                        if (cards.Contains(cardName))
                        {
                            Console.WriteLine("Card successfully sold");
                            index = cards.IndexOf(cardName);
                            cards.RemoveAt(index);
                        }
                        else
                        {
                            Console.WriteLine("Card not found");
                        }
                        break;
                    case "Remove At":
                        index = int.Parse(input[1]);
                        if (index >= 0 && index < cards.Count)
                        {
                            cards.RemoveAt(index);
                            Console.WriteLine("Card successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }
                        break;
                    case "Insert":
                        index = int.Parse(input[1]);
                        cardName = input[2];
                        if (index >= 0 && index < cards.Count && !(cards.Contains(cardName)))
                        {
                            cards.Insert(index, cardName);
                            Console.WriteLine("Card successfully bought");
                        }
                        else if (!(index >= 0 && index < cards.Count))
                        {
                            Console.WriteLine("Index out of range");
                        }
                        else if (cards.Contains(cardName))
                        {
                            Console.WriteLine("Card is already bought");
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", cards));

        }

    }
}