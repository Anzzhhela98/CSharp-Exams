using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console
                       .ReadLine()
                       .Split(" ")
                       .ToList();
            string command = string.Empty;
            int move = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] indices = command.Split(" ");
                move++;
                int firstIndex = int.Parse(indices[0]);
                int secondIndex = int.Parse(indices[1]);
                if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < sequence.Count && secondIndex < sequence.Count && firstIndex != secondIndex)
                {

                    if (sequence[firstIndex] == sequence[secondIndex])
                    {
                        //work /
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");
                        if (firstIndex > secondIndex)
                        {
                            sequence.RemoveAt(firstIndex);
                            sequence.RemoveAt(secondIndex);
                        }
                        else
                        {
                            sequence.RemoveAt(secondIndex);
                            sequence.RemoveAt(firstIndex);
                        }

                        if (sequence.Count == 0) //work/
                        {
                            Console.WriteLine($"You have won in {move} turns!");
                            return;
                        }
                    }
                    else if (!(sequence[firstIndex] == sequence[secondIndex])) // work/
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    //work
                    sequence.Insert(sequence.Count / 2, $"-{move}a");
                    sequence.Insert(sequence.Count / 2, $"-{move}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                }
            }

            Console.WriteLine($"Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequence));

        }
    }
}
