using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PhotoPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPhotos = double.Parse(Console.ReadLine());
            string typeOfPhotos = Console.ReadLine();
            string orderType = Console.ReadLine();
            double price = 0;

            if (typeOfPhotos == "9X13")
            {
                price = numberOfPhotos * 0.16;

                if (numberOfPhotos >= 50)
                {
                    price -= price * 0.05;
                }
            }
            else if (typeOfPhotos == "10X15")
            {
                price = numberOfPhotos * 0.16;

                if (numberOfPhotos >= 80)
                {
                    price -= price * 0.03;
                }
            }
            else if (typeOfPhotos == "13X18")
            {
                price = numberOfPhotos * 0.38;

                if (numberOfPhotos >= 50 && numberOfPhotos <= 100)
                {
                    price -= price * 0.03;
                }
                else if (numberOfPhotos > 100)
                {
                    price -= price * 0.05;
                }
            }
            else if (typeOfPhotos == "20X30")
            {
                price = numberOfPhotos * 2.9;

                if (numberOfPhotos >= 10 && numberOfPhotos <= 50)
                {
                    price -= price * 0.07;
                }
                else if (numberOfPhotos > 50)
                {
                    price -= price * 0.09;
                }
            }

            if (orderType == "online")
            {
                price -= price * 0.02;
            }

            Console.WriteLine($"{price:f2}BGN");
        }
    }
}
