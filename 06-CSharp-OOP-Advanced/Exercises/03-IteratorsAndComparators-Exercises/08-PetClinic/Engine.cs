namespace _08_PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private List<Pet> pets;
        private List<Clinic> clinics;

        public Engine()
        {
            this.pets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string command = inputArgs[0];

                string clinicName;
                Pet pet;
                Clinic clinic;

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string type = inputArgs[1];
                            if (type == "Pet")
                            {
                                pet = new Pet(inputArgs[2], int.Parse(inputArgs[3]), inputArgs[4]);
                                pets.Add(pet);
                            }
                            else if (type == "Clinic")
                            {
                                Pet[] rooms = new Pet[int.Parse(inputArgs[3])];
                                clinic = new Clinic(inputArgs[2], rooms);
                                clinics.Add(clinic);
                            }
                            break;
                        case "Add":
                            string petName = inputArgs[1];
                            clinicName = inputArgs[2];
                            if (!pets.Any(p => p.Name == petName) || !clinics.Any(c => c.Name == clinicName))
                            {
                                throw new InvalidOperationException("Invalid Operation!");
                            }
                            pet = GetPet(petName);
                            clinic = GetClinic(clinicName);
                            Console.WriteLine(clinic.AddPet(pet));
                            break;
                        case "Release":
                            clinicName = inputArgs[1];
                            ValidateClinic(clinics, inputArgs);
                            clinic = GetClinic(clinicName);
                            Console.WriteLine(clinic.Release());
                            break;
                        case "HasEmptyRooms":
                            clinicName = inputArgs[1];
                            ValidateClinic(clinics, inputArgs);
                            clinic = GetClinic(clinicName);
                            Console.WriteLine(clinic.HasEmptyRooms());
                            break;
                        case "Print":
                            clinicName = inputArgs[1];
                            ValidateClinic(clinics, inputArgs);
                            clinic = GetClinic(clinicName);
                            if (inputArgs.Length == 2)
                            {
                                clinic.PrintAllRooms();
                            }
                            else
                            {
                                int roomNumber = int.Parse(inputArgs[2]);
                                clinic.PrintRoom(roomNumber);
                            }
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private Pet GetPet(string petName)
        {
            return pets.FirstOrDefault(p => p.Name == petName);
        }

        private Clinic GetClinic(string clinicName)
        {
            return clinics.FirstOrDefault(c => c.Name == clinicName);
        }

        private static void ValidateClinic(List<Clinic> clinics, string[] inputArgs)
        {
            string clinicName = inputArgs[1];

            if (!clinics.Any(c => c.Name == clinicName))
            {
                throw new InvalidOperationException("Invalid Operation!");
            }          
        }
    }
}
