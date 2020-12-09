using System;
using System.Text.RegularExpressions;

namespace _03._Karate_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-za-z0-9]+[.]{0,1}[A-Za-z0-9]*)@([a-z]+.{1}[a-z]+)";
            string emails = Console.ReadLine();

            MatchCollection matchEmail = Regex.Matches(emails, pattern);

            if (matchEmail.Count > 0)
            {
                int leftValue = 0;
                int rightValue = 0;
                foreach (Match email in matchEmail)
                {
                    char[] arrLeft = email.Groups[1].Value.ToCharArray();
                    char[] arrRight = email.Groups[2].Value.ToCharArray();

                    for (int i = 0; i < arrLeft.Length; i++)
                    {
                        leftValue += arrLeft[i];
                    }
                    for (int i = 0; i < arrRight.Length; i++)
                    {
                        rightValue += arrRight[i];
                    }
                }
                int finalRezult = leftValue - rightValue;
                if (finalRezult < 0)
                {
                    Console.WriteLine("She is not the one.");

                }
                else if (finalRezult >= 0)
                {
                    Console.WriteLine("Call her! ");
                }
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
