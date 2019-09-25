using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_RawData
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

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 8; j += 2)
                {
                    double tirePressure = double.Parse(input[5 + j]);
                    int tireAge = int.Parse(input[6 + j]);

                    Tire tire = new Tire(tireAge, tirePressure);

                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            List<Car> filteredCars = new List<Car>();

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                filteredCars = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(t => t.TirePressure < 1))
                    .ToList();
            }
            else
            {
                filteredCars = cars
                    .Where((x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250))
                    .ToList();
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
