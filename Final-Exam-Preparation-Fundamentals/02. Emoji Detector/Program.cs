using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string patternDigit = @"[0-9]";
            string patternEmoji = @"([:]{2}|[*]{2})([A-Z]{1}[a-z]{2,})(\1)";

            MatchCollection matchesNum = Regex.Matches(message, patternDigit);

            MatchCollection matchesEmoji = Regex.Matches(message, patternEmoji);

            int threshold = 1;
            foreach (Match num in matchesNum)
            {
                threshold *= int.Parse(num.Value);
            }
            StringBuilder coolOnesEmoji = new StringBuilder();
            foreach (Match emoji in matchesEmoji)
            {
                int sumEmoji = 0;
                char[] chrArrEmoji = emoji.Groups[2].Value.ToArray();
                for (int i = 0; i < chrArrEmoji.Length; i++)
                {
                    sumEmoji += (int)chrArrEmoji[i];
                }
                if (sumEmoji > threshold)
                {
                    coolOnesEmoji.AppendLine(emoji.Value);
                }

            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matchesEmoji.Count}" +
                $" emojis found in the text. The cool ones are:");
            Console.WriteLine(coolOnesEmoji);

        }
    }
}
