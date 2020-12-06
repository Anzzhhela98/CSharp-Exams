using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=|\/])([A-Z][A-Za-z]{2,})(\1)";

            MatchCollection matchInput = Regex.Matches(input, pattern);
            List<string> destination = new List<string>();

            int travelPoints = 0;
            foreach (Match town in matchInput)
            {
                travelPoints += town.Groups[2].Length;
                destination.Add(town.Groups[2].Value);
            }


            Console.WriteLine($"Destinations: {string.Join(", ", destination)}");
            Console.WriteLine($"Travel Points: {travelPoints}");



        }
    }
}
