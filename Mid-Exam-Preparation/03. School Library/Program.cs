using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelfBook = Console
                      .ReadLine()
                      .Split("&")
                      .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] input = command.Split(" | ");
                string bookName = input[1];


                switch (input[0])
                {
                    case "Add Book":
                        if (!shelfBook.Contains(bookName))
                        {
                            shelfBook.Insert(0, bookName);
                        }
                        break;
                    case "Take Book":
                        if (shelfBook.Contains(bookName))
                        {
                            shelfBook.Remove(bookName);
                        }
                        break;
                    case "Swap Books":
                        string bookName2 = input[2];
                        if (shelfBook.Contains(bookName) && shelfBook.Contains(bookName2))
                        {
                            int indexfirst = shelfBook.IndexOf(bookName);
                            int indexSecond = shelfBook.IndexOf(bookName2);

                            string temp1 = shelfBook[indexfirst];
                            string temp2 = shelfBook[indexSecond];

                            shelfBook[indexfirst] = temp2;
                            shelfBook[indexSecond] = temp1;
                        }
                        break;
                    case "Insert Book":
                        shelfBook.Add(bookName);
                        break;
                    case "Check Book":
                        int index = int.Parse(input[1]);
                        if (index < shelfBook.Count)
                        {
                            string printBook = shelfBook[index];
                            Console.WriteLine(printBook);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", shelfBook));
        }
    }
}
