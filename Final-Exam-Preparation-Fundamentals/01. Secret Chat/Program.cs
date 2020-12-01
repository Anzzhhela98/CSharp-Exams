using System;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputMessage = new StringBuilder(Console.ReadLine());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];
                string substring = string.Empty;
                switch (type)
                {
                    case "InsertSpace":
                        int index = int.Parse(cmdArgs[1]);
                        inputMessage.Insert(index, " ");
                        PrintResult(inputMessage);

                        break;
                    case "Reverse":
                        substring = cmdArgs[1];
                        if (inputMessage.ToString().Contains(substring))
                        {
                            int index1 = inputMessage.ToString().IndexOf(substring);
                            inputMessage.Remove(index1, substring.Length);
                            char[] stringReverse = substring.ToCharArray();
                            Array.Reverse(stringReverse);

                            inputMessage.Append(stringReverse);

                            PrintResult(inputMessage);
                            continue;
                        }
                        Console.WriteLine("error");

                        break; ;
                    case "ChangeAll":
                        substring = cmdArgs[1];
                        string replace = cmdArgs[2];
                        inputMessage.Replace(substring, replace);
                        PrintResult(inputMessage);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {inputMessage}");
        }

        private static void PrintResult(StringBuilder input)
        {
            Console.WriteLine(input);
        }
    }
}
