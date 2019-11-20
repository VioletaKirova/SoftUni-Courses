using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();
            double convertedSum = 0;

            if (inputCurrency == "BGN")
            {
                if (outputCurrency == "USD")
                {
                    convertedSum = sum / 1.79549;
                }
                else if (outputCurrency == "EUR")
                {
                    convertedSum = sum / 1.95583;
                }
                else if (outputCurrency == "GBP")
                {
                    convertedSum = sum / 2.53405;
                }

            }
            else if (inputCurrency == "USD")
            {
                if (outputCurrency == "BGN")
                {
                    convertedSum = sum * 1.79549;
                }
                else if (outputCurrency == "EUR")
                {
                    convertedSum = sum * 1.79549 / 1.95583;
                }
                else if (outputCurrency == "GBP")
                {
                    convertedSum = sum * 1.79549 / 2.53405;
                }
            }
            else if (inputCurrency == "EUR")
            {
                if (outputCurrency == "BGN")
                {
                    convertedSum = sum * 1.95583;
                }
                else if (outputCurrency == "USD")
                {
                    convertedSum = sum * 1.95583 / 1.79549;
                }
                else if (outputCurrency == "GBP")
                {
                    convertedSum = sum * 1.95583 / 2.53405;
                }
            }
            else if (inputCurrency == "GBP")
            {
                if (outputCurrency == "BGN")
                {
                    convertedSum = sum * 2.53405;
                }
                else if (outputCurrency == "USD")
                {
                    convertedSum = sum * 2.53405 / 1.79549;
                }
                else if (outputCurrency == "EUR")
                {
                    convertedSum = sum * 2.53405 / 1.95583;
                }
            }

            Console.WriteLine($"{convertedSum:f2} {outputCurrency}");

        }
    }
}
