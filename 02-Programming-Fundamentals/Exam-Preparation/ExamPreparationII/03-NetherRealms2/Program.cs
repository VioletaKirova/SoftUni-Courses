using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_NetherRealms2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] deamonNames = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<Deamon> deamons = new List<Deamon>();

            foreach (var deamon in deamonNames)
            {
                // get health

                int health = 0;

                string healthCharsPattern = @"[^+\-*\/\.0-9]";
                Regex healthRegex = new Regex(healthCharsPattern);
                MatchCollection matchHealth = healthRegex.Matches(deamon);

                foreach (Match m in matchHealth)
                {
                    health += char.Parse(m.Value);
                }

                // get damage

                double damage = 0.0;

                string damagePattern = @"\-?\d+\.?\d*";
                Regex damageRegex = new Regex(damagePattern);
                MatchCollection matchDamage = damageRegex.Matches(deamon);

                foreach (Match m in matchDamage)
                {
                    damage += double.Parse(m.Value);
                }

                // multiply and divide

                foreach (var symbol in deamon)
                {
                    if (symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damage /= 2;
                    }
                }

                Deamon newDeamon = new Deamon();
                newDeamon.Name = deamon;
                newDeamon.Health = health;
                newDeamon.Damage = damage;

                deamons.Add(newDeamon);
            }

            foreach (var deamon in deamons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{deamon.Name} - {deamon.Health} health, {deamon.Damage:f2} damage");
            }
        }

        class Deamon
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }
        }

    }
}