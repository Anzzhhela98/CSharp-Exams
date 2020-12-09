using System;
using System.Collections.Generic;
using System.Linq;

namespace Chek_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weapon = Console
                       .ReadLine()
                       .Split("|")
                       .ToList();
            string input = string.Empty;
            int index = 0;
            bool isOdd = false;
            bool isTrue = false;
            List<string> odd = new List<string>();
            List<string> even = new List<string>();
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] splitted = input.Split(" ");
                string command = splitted[0];
                switch (command)
                {
                    case "Move":
                        index = int.Parse(splitted[2]);
                        if (splitted[1] == "Left")
                        {
                            if (index > 0 && index  < weapon.Count)
                            {
                                string firstWord = weapon[index];

                                weapon.RemoveAt(index );
                                weapon.Insert(index - 1, firstWord);
                                
                            }
                        }
                        else
                        {
                            if (index  >= 0 && index  < weapon.Count)
                            {
                                string firstWord = weapon[index];
                                weapon.RemoveAt(index);
                                weapon.Insert(index + 1, firstWord);
                            }
                        }
                        break;
                    case "Check":
                        if (splitted[1] == "Odd")
                        {
                            isOdd = true;
                            for (int i = 0; i < weapon.Count; i++)
                            {
                                if (i % 2 == 1)
                                {
                                    string word = weapon[i];
                                    odd.Add(word);
                                }
                            }
                        }
                        else
                        {
                            isTrue = true;

                            for (int i = 0; i < weapon.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    string word = weapon[i];
                                    even.Add(word);
                                }

                            }
                        }
                        break;

                }
            }
            if (isOdd)
            {
                Console.WriteLine(string.Join(" ", odd));
            }
            else if (isTrue)
            {
                Console.WriteLine(string.Join(" ", even));
            }
            Console.WriteLine($"You crafted {string.Join("", weapon)}!");




        }

    }
}
