using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Department> departments = new List<Department>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] commandArgs = command.Split();

                var departmentName = commandArgs[0];
                Department department = departments.FirstOrDefault(x => x.Name == departmentName);

                var firstName = commandArgs[1];
                var lastName = commandArgs[2];
                Doctor doctor = doctors.FirstOrDefault(x => x.Name == firstName + " " + lastName);

                var patient = commandArgs[3];

                if (doctor == null)
                {
                    doctor = new Doctor(firstName, lastName);
                    doctors.Add(doctor);
                }

                if (department == null)
                {
                    department = new Department(departmentName);
                    departments.Add(department);

                    for (int room = 0; room < 20; room++)
                    {
                        department.Rooms.Add(new Room());
                    }
                }

                if (department.HasFreeBed())
                {
                    doctor.Patients.Add(patient);

                    int targetRoom = 0;

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Beds.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }
                    department.Rooms[targetRoom].Beds.Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length == 1)
                {
                    Department department = departments.FirstOrDefault(x => x.Name == commandArgs[0]);
                    Console.WriteLine(string.Join("\n", department.Rooms.Where(x => x.Beds.Count > 0).SelectMany(x => x.Beds)));
                }
                else if (commandArgs.Length == 2 && int.TryParse(commandArgs[1], out int room))
                {
                    Department department = departments.FirstOrDefault(x => x.Name == commandArgs[0]);
                    Console.WriteLine(string.Join("\n", department.Rooms[room - 1].Beds.OrderBy(x => x)));
                }
                else
                {
                    Doctor doctor = doctors.FirstOrDefault(x => x.Name == commandArgs[0] + " " + commandArgs[1]);
                    Console.WriteLine(string.Join("\n", doctor.Patients.OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
