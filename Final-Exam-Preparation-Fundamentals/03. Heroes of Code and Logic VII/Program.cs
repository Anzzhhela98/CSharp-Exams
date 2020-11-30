using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            //максимум 100 HP и 200 MP
            Dictionary<string, List<int>> heroesPoints =
               new Dictionary<string, List<int>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] splitted = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                FillDictionary(heroesPoints, splitted);

            }
            string cmdArgs = string.Empty;
            while ((cmdArgs = Console.ReadLine()) != "End")
            {
                string[] splitted = cmdArgs
                  .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitted[0];
                string name = splitted[1];
                int amount = 0;
                switch (command)
                {
                    case "CastSpell":
                        int MPneeded = int.Parse(splitted[2]);
                        string spellName = splitted[3];
                        if (heroesPoints[name][1] >= MPneeded)
                        {
                            heroesPoints[name][1] -= MPneeded;
                            Console.WriteLine($"{name} has successfully cast " +
                                $"{spellName} and now has {heroesPoints[name][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast " +
                                $"{spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(splitted[2]);
                        string attacker = splitted[3];
                        heroesPoints[name][0] -= damage;
                        if (heroesPoints[name][0] > 0)
                        {
                            Console.WriteLine($"{name} was hit for " +
                                $"{damage} HP by {attacker} and now has {heroesPoints[name][0]} HP left!");
                            continue;
                        }
                        heroesPoints.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        break;
                    case "Recharge":
                        amount = int.Parse(splitted[2]);
                        if (heroesPoints[name][1] + amount >= 200)
                        {
                            Console.WriteLine($"{name} recharged for {200 - heroesPoints[name][1]} MP!");
                            heroesPoints[name][1] += 200 - heroesPoints[name][1];//?
                            continue;
                        }
                        heroesPoints[name][1] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");

                        break;
                    case "Heal":
                        amount = int.Parse(splitted[2]);
                        if (heroesPoints[name][0] + amount > 100)
                        {
                            Console.WriteLine($"{name} healed for {100 - heroesPoints[name][0]} HP!");
                            heroesPoints[name][0] += 100 - heroesPoints[name][0];//?
                            continue;
                        }
                        heroesPoints[name][0] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");

                        break;
                }
            }
            foreach (var kvp in heroesPoints
                .OrderByDescending(h=>h.Value[0])
                .ThenBy(n=>n.Key))
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"  HP: {kvp.Value[0]}");
                Console.WriteLine($"  MP: {kvp.Value[1]}");
            }
        }

        private static void FillDictionary(Dictionary<string, List<int>> heroesPoints, string[] splitted)
        {
            string name = splitted[0];
            int HPpoints = int.Parse(splitted[1]);
            int MPpoints = int.Parse(splitted[2]);

            if (HPpoints <= 100 && MPpoints <= 200)
            {
                heroesPoints[name] = new List<int>();
                heroesPoints[name].Add(HPpoints);
                heroesPoints[name].Add(MPpoints);

            }
        }
    }
}
