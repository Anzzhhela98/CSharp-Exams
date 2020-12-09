using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\||#])([A-Za-z\s]+)(\1)([0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)([0-9]+)(\1)";
            string input = Console.ReadLine();

            MatchCollection matchesFoods = Regex.Matches(input, pattern);
            int calories = 0;

            foreach (Match food in matchesFoods)
            {
                calories += int.Parse(food.Groups[6].Value);
            }
            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");
            foreach (Match item in matchesFoods)
            {
                Console.WriteLine($"Item: {item.Groups[2].Value}, Best before: " +
                    $"{item.Groups[4].Value}, Nutrition: {item.Groups[6].Value}");
            }

        }
    }
}
