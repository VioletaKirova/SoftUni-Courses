using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Master;
using StorageMaster.Models.Products;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StoreMaster storageMaster;

        public Engine()
        {
            storageMaster = new StoreMaster();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //AddProduct {type} {price}
                //RegisterStorage {type} {name}
                //SelectVehicle {storageName} {garageSlot}
                //LoadVehicle {productName1} {productName2} {productNameN}
                //SendVehicleTo {sourceName} {sourceGarageSlot} {destinationName}
                //UnloadVehicle {storageName} {garageSlot}
                //GetStorageStatus {storageName}

                string output;

                string commandType = commandArgs[0];

                try
                {
                    switch (commandType)
                    {
                        case "AddProduct":
                            string newProductType = commandArgs[1];
                            double newProductPrice = double.Parse(commandArgs[2]);
                            output = storageMaster.AddProduct(newProductType, newProductPrice);
                            Console.WriteLine(output);
                            break;
                        case "RegisterStorage":
                            string newStorageType = commandArgs[1];
                            string newStorageName = commandArgs[2];
                            output = storageMaster.RegisterStorage(newStorageType, newStorageName);
                            Console.WriteLine(output);
                            break;
                        case "SelectVehicle":
                            string targetStorageName = commandArgs[1];
                            int targetGarageSlot = int.Parse(commandArgs[2]);
                            output = storageMaster.SelectVehicle(targetStorageName, targetGarageSlot);
                            Console.WriteLine(output);
                            break;
                        case "LoadVehicle":
                            List<string> productNames = new List<string>();
                            for (int i = 1; i < commandArgs.Length; i++)
                            {
                                productNames.Add(commandArgs[i]);
                            }
                            output = storageMaster.LoadVehicle(productNames);
                            Console.WriteLine(output);
                            break;
                        case "SendVehicleTo":
                            string sourceStorageName = commandArgs[1];
                            int sourceGarageSlot = int.Parse(commandArgs[2]);
                            string destinationStorageName = commandArgs[3];
                            output = storageMaster.SendVehicleTo(sourceStorageName, sourceGarageSlot, destinationStorageName);
                            Console.WriteLine(output);
                            break;
                        case "UnloadVehicle":
                            string currentStorageName = commandArgs[1];
                            int currentGarageSlot = int.Parse(commandArgs[2]);
                            output = storageMaster.UnloadVehicle(currentStorageName, currentGarageSlot);
                            Console.WriteLine(output);
                            break;
                        case "GetStorageStatus":
                            string storageNameForStatus = commandArgs[1];
                            output = storageMaster.GetStorageStatus(storageNameForStatus);
                            Console.WriteLine(output);
                            break;
                    }
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
