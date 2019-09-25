using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treatedPatients = 0;
            int untreatedPatients = 0;
                
            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    doctors++;
                }

                int patientsPerDay = int.Parse(Console.ReadLine());

                if (patientsPerDay >= doctors)
                {
                    treatedPatients += doctors;
                    untreatedPatients += (patientsPerDay - doctors);
                }
                else
                {
                    treatedPatients += patientsPerDay;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
