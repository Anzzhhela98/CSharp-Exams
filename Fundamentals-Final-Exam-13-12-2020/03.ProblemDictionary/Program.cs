using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {

            var flowersInfo = new Dictionary<string, List<double>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] splitted = command
                         .Split(new string[] { ": " },
                         StringSplitOptions.RemoveEmptyEntries)
                         .ToArray();
                string userName = splitted[1];
                switch (splitted[0])
                {
                    case "New follower":
                        userName = splitted[1];
                        if (!flowersInfo.ContainsKey(userName))
                        {
                            flowersInfo.Add(userName, new List<double>());
                            flowersInfo[userName].Add(0);
                            flowersInfo[userName].Add(0);
                        }

                        break;
                    case "Like":
                        int count = int.Parse(splitted[2]);
                        if (!flowersInfo.ContainsKey(userName))
                        {
                            flowersInfo.Add(userName, new List<double>());
                            flowersInfo[userName].Add(count);
                            flowersInfo[userName].Add(0);
                            continue;
                        }
                        flowersInfo[userName][0] += count;//?
                        break;
                    case "Comment":
                        if (!flowersInfo.ContainsKey(userName))
                        {
                            flowersInfo.Add(userName, new List<double>());
                            flowersInfo[userName].Add(0);
                            flowersInfo[userName].Add(1);
                            continue;
                        }
                        flowersInfo[userName][1] += 1;
                        break;
                    case "Blocked":
                        if (flowersInfo.ContainsKey(userName))
                        {
                            flowersInfo.Remove(userName);
                            continue;
                        }
                        Console.WriteLine($"{userName} doesnt't exist.");
                        break;
                }
            }
            foreach (var flowers in flowersInfo)
            {
                double sum = 0;
                sum = flowers.Value[0] + flowers.Value[1];
                flowers.Value[0] = sum;
                flowersInfo[flowers.Key].Remove(flowers.Value[1]);
            }
            Console.WriteLine($"{flowersInfo.Count} followers");
            foreach (var flower in flowersInfo
                .OrderByDescending(x => x.Value[0]).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{flower.Key}: {flower.Value[0]}");
            }

        }
    }
}