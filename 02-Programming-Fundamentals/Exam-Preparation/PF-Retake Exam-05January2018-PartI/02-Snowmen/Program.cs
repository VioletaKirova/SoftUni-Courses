using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Snowmen
{
    // 20/100
    class Program
    {
        class Snowman
        {
            public int AttackerIndex { get; set; }
            public int TargetIndex { get; set; }
            public bool Lost { get; set; }
            public bool Suicide { get; set; }
        }

        static void Main(string[] args)
        {
            int[] snowmen = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<Snowman> snowmenList = new List<Snowman>();

            for (int i = 0; i < snowmen.Length; i++)
            {
                Snowman snowman = new Snowman();
                snowman.AttackerIndex = i;

                if (snowmen[i] > snowmen.Length)
                    snowman.TargetIndex = snowmen[i] % snowmen.Length;
                else
                    snowman.TargetIndex = snowmen[i];

                snowman.Lost = false;
                snowman.Suicide = false;
                snowmenList.Add(snowman);
            }
            while (snowmenList.Count > 1)
            {
                foreach (var s in snowmenList)
                {
                    if (s.Lost == false && s.Suicide == false)
                    {
                        if (s.TargetIndex > snowmenList.Count)
                        {
                            s.TargetIndex = s.TargetIndex % snowmenList.Count;
                        }

                        int diff = Math.Abs(s.AttackerIndex - s.TargetIndex);

                        if (s.AttackerIndex == s.TargetIndex)
                        {
                            s.Suicide = true;
                            Console.WriteLine($"{s.AttackerIndex} performed harakiri");
                        }
                        else if (diff % 2 == 0)
                        {
                            s.Lost = false;
                            snowmenList[s.TargetIndex].Lost = true;
                            Console.WriteLine($"{s.AttackerIndex} x {s.TargetIndex} -> {s.AttackerIndex} wins");
                        }
                        else
                        {
                            s.Lost = true;
                            Console.WriteLine($"{s.AttackerIndex} x {s.TargetIndex} -> {s.TargetIndex} wins");
                        }
                    }
                }

                for (int i = 0; i < snowmenList.Count; i++)
                {
                    if (snowmenList[i].Lost == true || snowmenList[i].Suicide == true)
                    {
                        snowmenList.Remove(snowmenList[i]);
                        i--;
                    }
                }
            }
        }
    }
}