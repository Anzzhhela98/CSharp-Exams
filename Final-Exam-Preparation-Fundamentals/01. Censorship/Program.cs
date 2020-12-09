using System;
using System.Linq;

namespace _01._Censorship
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string sentence = Console.ReadLine();

            if (sentence.Contains(word))
            {
                string curr = string.Empty;
                for (int i = 0; i < word.Length; i++)
                {
                    curr += "*";
                }
                sentence = sentence.Replace(word, curr);
            }
            Console.WriteLine(sentence);

        }
    }
}
