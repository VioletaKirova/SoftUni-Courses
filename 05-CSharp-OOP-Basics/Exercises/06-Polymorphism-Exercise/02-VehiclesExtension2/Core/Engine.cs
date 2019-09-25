using _02_VehiclesExtension2.Models;
using _02_VehiclesExtension2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_VehiclesExtension2.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] busInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumpion = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumpion = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumpion = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);


            IVehicle car = new Car(carFuelQuantity, carFuelConsumpion, carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumpion, truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumpion, busTankCapacity);

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
                        else if (vehicleType == "bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(value);
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
                        else if (vehicleType == "bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (commandType == "driveempty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Drive(value);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
