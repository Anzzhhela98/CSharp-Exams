using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternEmoji = @"(\*\*[A-Z]{1}[a-z]{2,}\*\*|\:\:[A-Z]{1}[a-z]{2,}\:\:)";
            string patternDigit = @"[\d]";

            string inputText = Console.ReadLine();

            MatchCollection matchesEmoji = Regex.Matches(inputText, patternEmoji);
            MatchCollection matchesDigit = Regex.Matches(inputText, patternDigit);

            int number = 0;
            int tempCountDigit = 0;
            foreach (Match digit in matchesDigit)
            {
                tempCountDigit++;
                if (tempCountDigit == 1)
                {
                    number += int.Parse(digit.Value);
                    continue;
                }
                number *= int.Parse(digit.Value);
            }
            Console.WriteLine($"Cool threshold: {number}");
            Console.WriteLine($"{matchesEmoji.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in matchesEmoji)
            {

                int value = 0;
                char[] arrEmoji = emoji.Value.ToCharArray();
                for (int i = 0; i < arrEmoji.Length; i++)
                {
                    if (arrEmoji[i] != ':' && arrEmoji[i] != '*')
                    {
                        value += arrEmoji[i];
                    }
                }
                if (value >= number)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
