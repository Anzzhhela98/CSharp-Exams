using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            int countMonts = int.Parse(Console.ReadLine());
            int curentMonts = 0;
            double colecctedMoney = 0;
            while (curentMonts < countMonts)
            {
                curentMonts++;

                if (curentMonts % 4 == 0)
                {
                    colecctedMoney += colecctedMoney * 0.25;
                    colecctedMoney += neededMoney * 0.25;
                }
                else if (curentMonts % 2 == 1 && curentMonts != 1)
                {
                    colecctedMoney *= 0.84;
                    colecctedMoney += neededMoney * 0.25;
                }
                else
                {
                    colecctedMoney += neededMoney * 0.25;
                }
            }
            if (colecctedMoney >= neededMoney)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {colecctedMoney - neededMoney:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {neededMoney - colecctedMoney:f2}lv. more.");
            }
        }
    }
}
