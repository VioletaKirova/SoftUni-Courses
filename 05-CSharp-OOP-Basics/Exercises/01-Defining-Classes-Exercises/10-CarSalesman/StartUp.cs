using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineArgs[0];
                string eninePower = engineArgs[1];

                Engine engine = new Engine(engineModel, eninePower);

                if (engineArgs.Length == 3)
                {
                    if (int.TryParse(engineArgs[2], out int result))
                    {
                        engine.Displacement = engineArgs[2];
                    }
                    else
                    {
                        engine.Efficiency = engineArgs[2];
                    }
                }
                else if (engineArgs.Length == 4)
                {
                    engine.Displacement = engineArgs[2];
                    engine.Efficiency = engineArgs[3];
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string carModel = carArgs[0];
                string carEngineModel = carArgs[1];

                Engine carEngine = engines.FirstOrDefault(x => x.Model == carEngineModel);

                Car car = new Car(carModel, carEngine);

                if (carArgs.Length == 3)
                {
                    if (int.TryParse(carArgs[2], out int result))
                    {
                        car.Weight = carArgs[2];
                    }
                    else
                    {
                        car.Color = carArgs[2];
                    }
                }
                else if (carArgs.Length == 4)
                {
                    car.Weight = carArgs[2];
                    car.Color = carArgs[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
