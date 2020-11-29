using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int countWon = 0;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                if (energy < distance)
                {

                    Console.WriteLine($"Not enough energy! Game ends with {countWon} won battles and {energy} energy");
                    return;
                }
                else
                {
                    energy -= distance;
                    countWon++;
                }
                if (countWon % 3 == 0)
                {
                    energy += countWon;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {countWon}. Energy left: {energy}");

        }

    }
}
