using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TrainersSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            int lections = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double moneyPerLection = budget / lections;
        
            double jelevLections = 0.0;
            double royalLections = 0.0;
            double roliLections = 0.0;
            double trofonLections = 0.0;
            double sinoLections = 0.0;
            double othersLections = 0.0;

            for (int i = 0; i < lections; i++)
            {
                string lectorName = Console.ReadLine().ToLower();

                if (lectorName == "jelev")
                {
                    jelevLections++;
                }
                else if (lectorName == "royal")
                {
                    royalLections++;
                }
                else if (lectorName == "roli")
                {
                    roliLections++;
                }
                else if (lectorName == "trofon")
                {
                    trofonLections++;
                }
                else if (lectorName == "sino")
                {
                    sinoLections++;
                }
                else
                {
                    othersLections++;
                }
            }

            double jelevSalary = jelevLections * moneyPerLection;
            double royalSalary = royalLections * moneyPerLection;
            double roliSalary = roliLections * moneyPerLection;
            double trofonSalary = trofonLections * moneyPerLection;
            double sinoSalary = sinoLections * moneyPerLection;
            double othersSalary = othersLections * moneyPerLection;

            Console.WriteLine($"Jelev salary: {jelevSalary:f2} lv");
            Console.WriteLine($"RoYaL salary: {royalSalary:f2} lv");
            Console.WriteLine($"Roli salary: {roliSalary:f2} lv");
            Console.WriteLine($"Trofon salary: {trofonSalary:f2} lv");
            Console.WriteLine($"Sino salary: {sinoSalary:f2} lv");
            Console.WriteLine($"Others salary: {othersSalary:f2} lv");
        }
    }
}
