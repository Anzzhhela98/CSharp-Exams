using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicCards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(":").ToList();

            string input = string.Empty;
            List<string> myDeck = new List<string>();

            while ((input = Console.ReadLine()) != "Ready")
            {
                List<string> command = input.Split(" ").ToList();

                switch (command[0])
                {
                    case "Add":

                        if (!cards.Contains(command[1]))
                        {
                            Console.WriteLine("Card not found.");
                        }
                        else
                        {
                            myDeck.Add(command[1]);
                        }
                        break;

                    case "Insert":

                        if (!cards.Contains(command[1]) || int.Parse(command[2]) > cards.Count || int.Parse(command[2]) < 0)
                        {
                            Console.WriteLine("Error!");
                        }
                        else
                        {
                            myDeck.Insert(int.Parse(command[2]), command[1]);
                        }
                        break;

                    case "Remove":
                        if (!myDeck.Contains(command[1]))
                        {
                            Console.WriteLine("Card not found.");
                        }
                        else
                        {
                            myDeck.Remove(command[1]);
                        }
                        break;

                    case "Swap":

                        string currentArg = command[1];

                        int firstIndex = myDeck.IndexOf(currentArg);
                        int secondIndex = myDeck.IndexOf(command[2]);
                        myDeck[firstIndex] = myDeck[secondIndex];
                        myDeck[secondIndex] = currentArg;
                        break;
                    case "Shuffle":
                        myDeck.Reverse();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", myDeck));
        }
    }
}