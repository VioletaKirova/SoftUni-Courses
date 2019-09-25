using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                string carModelToMove = commandArgs[1];
                double distanceToMove = double.Parse(commandArgs[2]);

                Car carToMove = cars.FirstOrDefault(x => x.Model == carModelToMove);

                if (carToMove.CanMove(distanceToMove))
                {
                    carToMove.FuelAmount -= carToMove.FuelConsumption * distanceToMove;
                    carToMove.TravelledDistance += distanceToMove;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
