using _02_VehiclesExtension.Models;
using System;

namespace _02_VehiclesExtension.Core
{
    public class Engine
    {
        private const int vehiclesCount = 3;

        public void Run()
        {
            Vehicle car = new Car();
            Vehicle truck = new Truck();
            Vehicle bus = new Bus();

            for (int i = 0; i < vehiclesCount; i++)
            {
                string[] inputArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string vehicleType = inputArgs[0].ToLower();

                if (vehicleType == "car")
                {
                    car = new Car(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                }
                else if (vehicleType =="truck")
                {
                    truck = new Truck(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                }
                else if (vehicleType == "bus")
                {
                    bus = new Bus(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                }
            }
        
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
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
                        else if (vehicleType == "bus")
                        {
                            ((Bus)bus).IncreaseFuelConsumption();

                            bus.Drive(distance);
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
                        else if (vehicleType == "bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    else if (commandType == "driveempty")
                    {
                        double distance = double.Parse(commandArgs[2]);

                        bus.Drive(distance);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
