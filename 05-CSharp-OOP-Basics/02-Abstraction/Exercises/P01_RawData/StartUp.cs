using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> tires = GetTires(parameters);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintCars(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintCars(flamable);
            }
        }

        private static void PrintCars(List<string> fragile)
        {
            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }

        private static List<Tire> GetTires(string[] parameters)
        {
            List<Tire> tires = new List<Tire>();

            for (int j = 0; j < 8; j += 2)
            {
                double tirePressure = double.Parse(parameters[5 + j]);
                int tireAge = int.Parse(parameters[6 + j]);

                Tire tire = new Tire(tireAge, tirePressure);
                tires.Add(tire);
            }

            return tires;
        }
    }
}
