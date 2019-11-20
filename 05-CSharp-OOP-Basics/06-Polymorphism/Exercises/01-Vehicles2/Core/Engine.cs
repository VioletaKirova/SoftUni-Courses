using _01_Vehicles2.Models;
using _01_Vehicles2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles2.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumpion = double.Parse(carInfo[2]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumpion = double.Parse(truckInfo[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumpion);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumpion);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                try
                {
                    string[] commandArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string commandType = commandArgs[0].ToLower();
                    string vehicleType = commandArgs[1].ToLower();
                    double value = double.Parse(commandArgs[2]);

                    if (commandType == "drive")
                    {
                        if (vehicleType == "car")
                        {
                            car.Drive(value);
                        }
                        else if (vehicleType == "truck")
                        {
                            truck.Drive(value);
                        }
                    }
                    else if (commandType == "refuel")
                    {
                        if (vehicleType == "car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "truck")
                        {
                            truck.Refuel(value);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
