using _05_BorderControl.Contracts;
using _05_BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_BorderControl.Core
{
    public class Engine
    {
        private ICollection<IIdentifiable> creatures;

        public Engine()
        {
            creatures = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    string citizenName = inputArgs[0];
                    string citizenAge = inputArgs[1];
                    string citizenId = inputArgs[2];

                    IIdentifiable citizen = new Citizen(citizenName, citizenAge, citizenId);
                    creatures.Add(citizen);
                }
                else if (inputArgs.Length == 2)
                {
                    string robotModel = inputArgs[0];
                    string robotId = inputArgs[1];

                    IIdentifiable robot = new Robot(robotModel, robotId);
                    creatures.Add(robot);  
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (var creature in creatures.Where(c => c.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(creature.Id);
            }

            creatures = creatures.Where(c => !c.Id.EndsWith(fakeId)).ToList();
        }
    }
}
