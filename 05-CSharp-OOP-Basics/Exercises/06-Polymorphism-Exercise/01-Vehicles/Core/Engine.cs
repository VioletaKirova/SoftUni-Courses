using _01_Vehicles.Models;
using System;

namespace _01_Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commandArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0].ToLower();
                string vehicleType = commandArgs[1].ToLower();

                if (commandType == "drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (vehicleType == "car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicleType == "truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (commandType == "refuel")
                {
                    double fuel = double.Parse(commandArgs[2]);

                    if (vehicleType == "car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (vehicleType == "truck")
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
