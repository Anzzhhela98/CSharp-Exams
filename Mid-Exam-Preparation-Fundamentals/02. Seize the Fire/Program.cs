using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> fireCells = Console
                       .ReadLine()
                       .Split("#")
                       .ToList();
            int water = int.Parse(Console.ReadLine());

            double effort = 0;
            int totalFire = 0;


            List<int> cells = new List<int>();
            for (int i = 0; i < fireCells.Count; i++)
            {
                string[] splitted = fireCells[i].Split(" = ", StringSplitOptions.RemoveEmptyEntries);
                string type = splitted[0];
                int cell = int.Parse(splitted[1]);
                switch (type)
                {
                    case "High":
                        if (cell >= 81 && cell <= 125 && water >= cell)
                        {
                            water -= cell;
                            effort += cell * 0.25;
                            totalFire += cell;
                            cells.Add(cell);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Medium":
                        if (cell >= 51 && cell <= 80 && water >= cell)
                        {
                            water -= cell;
                            effort += cell * 0.25;
                            totalFire += cell;
                            cells.Add(cell);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Low":
                        if (cell >= 1 && cell <= 50 && water >= cell)
                        {
                            water -= cell;
                            effort += cell * 0.25;
                            totalFire += cell;
                            cells.Add(cell);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }
            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");

        }
    }
}
