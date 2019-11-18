using _08_MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_MilitaryElite.Core
{
    public class Engine
    {
        private List<Private> privates;

        public Engine()
        {
            this.privates = new List<Private>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] soldierArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string soldierType = soldierArgs[0].ToLower();
                string id = soldierArgs[1];
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];
                decimal salary = 0.0m;

                if (soldierType == "private" ||
                    soldierType == "lieutenantgeneral" || 
                    soldierType == "engineer" || 
                    soldierType == "commando")
                {
                    salary = decimal.Parse(soldierArgs[4]);
                }

                switch (soldierType)
                {
                    case "private":
                        Private privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(privateSoldier);
                        Console.WriteLine(privateSoldier);
                        break;
                    case "lieutenantgeneral":
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < soldierArgs.Length; i++)
                        {
                            Private currentPrivate = privates.FirstOrDefault(p => p.Id == soldierArgs[i]);
                            lieutenantGeneral.Privates.Add(currentPrivate);
                        }

                        Console.WriteLine(lieutenantGeneral);
                        break;
                    case "engineer":
                        try
                        {
                            Corps engineerCorps = new Corps(soldierArgs[5]);
                            Engineer engineer = new Engineer(id, firstName,lastName, salary, engineerCorps);

                            for (int i = 6; i < soldierArgs.Length; i += 2)
                            {
                                string repairPart = soldierArgs[i];
                                int repairHours = int.Parse(soldierArgs[i + 1]);
                                Repair repair = new Repair(repairPart, repairHours);
                                engineer.Repairs.Add(repair);
                            }

                            Console.WriteLine(engineer);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                        break;
                    case "commando":
                        Corps commandoCorps = new Corps();

                        try
                        {
                            commandoCorps = new Corps(soldierArgs[5]);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }

                        Commando commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                        for (int i = 6; i < soldierArgs.Length; i += 2)
                        {
                            string codeName = soldierArgs[i];
                            string state = soldierArgs[i + 1];

                            Mission mission = new Mission();

                            try
                            {
                                mission = new Mission(codeName, state);
                                commando.Missions.Add(mission);

                            }
                            catch (ArgumentException)
                            {
                                continue;
                            }
                        }

                        Console.WriteLine(commando);
                        break;
                    case "spy":
                        int codeNumber = int.Parse(soldierArgs[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
