using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string pattern = @"@([A-Za-z]+)[^@!:>-]*!([G|N])!";
            List<string> kids = new List<string>();
            while ((input =Console.ReadLine())!="end")
            {
               
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    char cur = (char)((int)input[i] - key);
                    sb.Append(cur);
                }
                MatchCollection matchecs = Regex.Matches(sb.ToString(), pattern);
                sb.Clear();
                foreach (Match match in matchecs)
                {
                    if (match.Groups[2].Value == "G")
                    {
                        kids.Add(match.Groups[1].Value);
                       
                        break;
                    }
                }

            }
            foreach (var name in kids)
            {
                Console.WriteLine(name);
            }

        }
    }
}
