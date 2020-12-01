using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02.Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patternPairs = @"([@]|[#]{1})(?<first>[A-Za-z]{3,})(\1)(\1)(?<second>[A-Z-a-z]{3,})(\1)";
            MatchCollection validPairs = Regex.Matches(input, patternPairs);
            List<string> mirrorWords = new List<string>();
            if (validPairs.Count > 0)
            {

                Console.WriteLine($"{validPairs.Count} word pairs found!");
                foreach (Match mirrorWd in validPairs)
                {
                    string firtsWord = mirrorWd.Groups["first"].Value;

                    char[] word = mirrorWd.Groups["second"].Value.ToCharArray();
                    Array.Reverse(word);
                    StringBuilder secondWord = new StringBuilder();
                    secondWord.Append(word);

                    if (firtsWord == secondWord.ToString())
                    {
                        string miror = firtsWord + " <=> " + secondWord;
                        mirrorWords.Add(miror);
                    }
                }
                if (mirrorWords.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");

                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }

            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
