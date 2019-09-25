using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departmetsDict = new Dictionary<string, Dictionary<int, List<string>>>();
            Dictionary<string, List<string>> doctorsDict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Output")
            {
                string[] departmetArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string department = departmetArgs[0];
                string doctor = departmetArgs[1] + " " + departmetArgs[2];
                string patient = departmetArgs[3];

                if (!departmetsDict.ContainsKey(department))
                {
                    departmetsDict[department] = new Dictionary<int, List<string>>();

                    for (int i = 0; i < 20; i++)
                    {
                        departmetsDict[department][i] = new List<string>();
                    }
                }

                foreach (var room in departmetsDict[department])
                {
                    if (room.Value.Count < 3)
                    {
                        room.Value.Add(patient);
                        break;
                    }
                }

                if (!doctorsDict.ContainsKey(doctor))
                {
                    doctorsDict[doctor] = new List<string>();
                }

                doctorsDict[doctor].Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArgs.Length == 1)
                {
                    string departmentForPrint = inputArgs[0];

                    foreach (var room in departmetsDict[departmentForPrint])
                    {
                        foreach (var patient in room.Value)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (inputArgs.Length == 2)
                {
                    if (departmetsDict.ContainsKey(inputArgs[0]))
                    {
                        string departmentForPrint = inputArgs[0];
                        int room = int.Parse(inputArgs[1]);

                        foreach (var patient in departmetsDict[departmentForPrint][room - 1].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        string doctorName = inputArgs[0] + " " + inputArgs[1];

                        foreach (var patient in doctorsDict[doctorName].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
