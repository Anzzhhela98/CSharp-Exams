using System;
using System.Linq;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder newInput = new StringBuilder(Console.ReadLine());

            string cmdArg = string.Empty;
            while ((cmdArg = Console.ReadLine()) != "Done")
            {
                string[] splitted = cmdArg
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitted[0];
                switch (command)
                {
                    case "TakeOdd":
                        //Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr  
                        for (int i = 0; i < newInput.Length; i++)
                        {


                            newInput.Remove(i, 1);

                        };
                        PrintOnTheConsole(newInput);

                        break;
                    case "Cut":
                        int index = int.Parse(splitted[1]);
                        int length = int.Parse(splitted[2]);
                        newInput.Remove(index, length);
                        PrintOnTheConsole(newInput);
                        break;
                    case "Substitute":
                        string substring = splitted[1];
                        string substitute = splitted[2];
                        if (newInput.ToString().Contains(substring))
                        {
                            newInput.Replace(substring, substitute);
                            PrintOnTheConsole(newInput);
                        }
                        else
                        {

                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }
            Console.WriteLine($"Your password is: {newInput}");
        }

        private static void PrintOnTheConsole(StringBuilder newInput)
        {
            Console.WriteLine(newInput);
        }

    }
}
