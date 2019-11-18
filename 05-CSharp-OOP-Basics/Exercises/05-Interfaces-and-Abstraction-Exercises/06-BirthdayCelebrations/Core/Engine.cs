using _06_BirthdayCelebrations.Contracts;
using _06_BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_BirthdayCelebrations.Core
{
    public class Engine
    {
        private ICollection<IIdentifiable> creatures;
        private ICollection<IBirthable> birthdates;

        public Engine()
        {
            creatures = new List<IIdentifiable>();
            birthdates = new List<IBirthable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = inputArgs[0];

                if (type == "Citizen")
                {
                    string citizenName = inputArgs[1];
                    string citizenAge = inputArgs[2];
                    string citizenId = inputArgs[3];
                    string citizenBirthdate = inputArgs[4];

                    IBirthable citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                    birthdates.Add(citizen);
                }
                else if (type == "Robot")
                {
                    string robotModel = inputArgs[0];
                    string robotId = inputArgs[1];

                    IIdentifiable robot = new Robot(robotModel, robotId);
                    creatures.Add(robot);
                }
                else if (type == "Pet")
                {
                    string petName = inputArgs[1];
                    string petBirthdate = inputArgs[2];

                    IBirthable pet = new Pet(petName, petBirthdate);
                    birthdates.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var b in birthdates.Where(c => c.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(b.Birthdate);
            }
        }
    }
}
