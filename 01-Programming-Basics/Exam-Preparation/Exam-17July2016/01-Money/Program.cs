using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            double bitCoins = double.Parse(Console.ReadLine());
            double chineseMoney = double.Parse(Console.ReadLine());
            double comissionPercent = double.Parse(Console.ReadLine());

            double bitCoinToEvro = (bitCoins * 1168) / 1.95;
            double chineseMoneyToEvro = (chineseMoney * 0.15 * 1.76) / 1.95;

            double allEvro = bitCoinToEvro + chineseMoneyToEvro;

            double comissionFee = allEvro * (comissionPercent / 100);
            double evroWithComissionFee = allEvro - comissionFee;

            Console.WriteLine($"{evroWithComissionFee:f2}");
        }
    }
}