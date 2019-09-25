using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];

                try
                {
                    string result = string.Empty;

                    string type;
                    string storageName;
                    int garageSlot;

                    switch (commandType)
                    {
                        case "AddProduct":
                            type = commandArgs[1];
                            double price = double.Parse(commandArgs[2]);
                            result = storageMaster.AddProduct(type, price);
                            break;
                        case "RegisterStorage":
                            type = commandArgs[1];
                            string name = commandArgs[2];
                            result = storageMaster.RegisterStorage(type, name);
                            break;
                        case "SelectVehicle":
                            storageName = commandArgs[1];
                            garageSlot = int.Parse(commandArgs[2]);
                            result = storageMaster.SelectVehicle(storageName, garageSlot);
                            break;
                        case "LoadVehicle":
                            string[] productNames = commandArgs.Skip(1).ToArray();
                            result = storageMaster.LoadVehicle(productNames);
                            break;
                        case "SendVehicleTo":
                            string sourceName = commandArgs[1];
                            int sourceGarageSlot = int.Parse(commandArgs[2]);
                            string destinationName = commandArgs[3];
                            result = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;
                        case "UnloadVehicle":
                            storageName = commandArgs[1];
                            garageSlot = int.Parse(commandArgs[2]);
                            result = storageMaster.UnloadVehicle(storageName, garageSlot);
                            break;
                        case "GetStorageStatus":
                            storageName = commandArgs[1];
                            result = storageMaster.GetStorageStatus(storageName);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
