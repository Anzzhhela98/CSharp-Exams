using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> information =
                new Dictionary<string, List<string>>();
            int countPieces = int.Parse(Console.ReadLine());
            for (int i = 0; i < countPieces; i++)
            {
                string[] input = Console.ReadLine()
                         .Split("|")
                         .ToArray();
                string key = input[2];
                string composer = input[1];
                string piece = input[0];

                FillDict(information, key, composer, piece);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splitted = command
                        .Split("|")
                        .ToArray();
                string piece = splitted[1];
                switch (splitted[0])
                {
                    case "Add":
                        string composer = splitted[2];
                        string key = splitted[3];
                        if (!information.ContainsKey(piece))
                        {
                            FillDict(information, key, composer, piece);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                            continue;
                        }
                        Console.WriteLine($"{piece} is already in the collection!");
                        break;
                    case "Remove":
                        if (information.ContainsKey(piece))
                        {
                            information.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                            continue;
                        }
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                    case "ChangeKey":
                        key = splitted[2];
                        if (information.ContainsKey(piece))
                        {
                            information[piece][1] = key;
                            Console.WriteLine($"Changed the key of {piece} to {key}!");
                            continue;
                        }
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;
                }
            }
            information = information
                .OrderBy(n => n.Key)
                .ThenBy(c => c.Value[1])
                .ToDictionary(x => x.Key, v => v.Value);
            foreach (var pieces in information)
            {
                Console.WriteLine($"{pieces.Key} -> Composer: {pieces.Value[0]}, Key: {pieces.Value[1]}");
            }

        }

        private static void FillDict(Dictionary<string, List<string>> information, string key, string composer, string piece)
        {
            information.Add(piece, new List<string>());
            information[piece].Add(composer);
            information[piece].Add(key);
        }
    }
}
