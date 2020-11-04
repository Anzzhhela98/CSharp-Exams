using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int FircountPeople = int.Parse(Console.ReadLine());
            int SeccountPeople = int.Parse(Console.ReadLine());
            int ThircountPeople = int.Parse(Console.ReadLine());
            int AllPeople = int.Parse(Console.ReadLine());

            int perHour = FircountPeople + SeccountPeople + ThircountPeople;
            int hours = 0;
            while (AllPeople > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }
                else
                {
                    AllPeople -= perHour;
                }

            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
