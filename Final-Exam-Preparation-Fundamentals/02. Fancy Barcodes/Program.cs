using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string pattern = @"@[#]+[A-Z]([A-Za-z\d]{4,})[A-Z]@[#]+";
            for (int i = 0; i < num; i++)
            {
                string barcode = Console.ReadLine();
                Match matchBarcode = Regex.Match(barcode, pattern);
                if (matchBarcode.Success)
                {
                    string patternDIgit = @"[0-9]";
                    MatchCollection matchesDigit = Regex.Matches(matchBarcode.ToString(), patternDIgit);
                    if (matchesDigit.Count > 0)
                    {
                        string digits = string.Empty;
                        foreach (Match digit in matchesDigit)
                        {
                            digits += digit;
                        }
                        Console.WriteLine($"Product group: {digits}");
                        continue;

                    }

                    Console.WriteLine($"Product group: 00");

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}
