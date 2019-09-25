namespace StorageMester.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster.Core;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [TestFixture]
    public class StorageMesterBusinessLogicTests
    {
        private Type type;
        private Object instance;

        [SetUp]
        public void Initialize()
        {
            this.type = typeof(StorageMaster);
            this.instance = Activator.CreateInstance(this.type);
        }

        [Test]
        public void TestAddProductMethodShouldAddProduct()
        {
            var method = this.type.GetMethod("AddProduct", BindingFlags.Instance | BindingFlags.Public);
            object[] parameters = new object[] { "Ram", 0.9d };

            var actual = method.Invoke(this.instance, parameters);
            string expected = $"Added {parameters[0]} to pool";

            Assert.AreEqual(expected, actual.ToString(),
                "Method AddProduct doesn't add the product to the product pool!");

            var productPool = this.type.GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance);
            int actualCount = ((Dictionary<string, Stack<Product>>)productPool.GetValue(instance))["Ram"].Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount,
                "Method AddProduct doesn't add the product to the product pool!");
        }

        [TestCase(new object[] { "Warehouse", "New Warehouse" })]
        [TestCase(new object[] { "DistributionCenter", "New Distribution Center" })]
        public void TestRegisterStorageMethodShouldRegisterStorage(object[] parameters)
        {
            var method = this.type.GetMethod("RegisterStorage", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, parameters);
            string expected = $"Registered {parameters[1]}";

            Assert.AreEqual(expected, actual.ToString(),
                "Method RegisterStorage doesn't register the storage in the storage registry!");

            var storageRegistry = this.type.GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);

            var isStorageRegistryValid = ((Dictionary<string, Storage>)storageRegistry.GetValue(instance)).ContainsKey(parameters[1].ToString());

            Assert.That(isStorageRegistryValid,
                "Method RegisterStorage doesn't register the storage in the storage registry!");
        }

        [Test]
        public void TestSelectVehicleMethodShouldSelectVehicle()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });

            var method = this.type.GetMethod("SelectVehicle", BindingFlags.Instance | BindingFlags.Public);
            object[] parameters = new object[] { "New Warehouse", 1 };

            var actual = method.Invoke(this.instance, parameters);
            string expected = "Selected";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method SelectVehicle doesn't select the vehicle from the provided storage's slot.");
        }

        [Test]
        public void TestLoadVehicleMethodShouldLoadVehicle()
        {
            TestAddProductMethodShouldAddProduct();

            TestSelectVehicleMethodShouldSelectVehicle();

            object[] parameters = new object[] { new string[] { "Ram" } };

            var method = this.type.GetMethod("LoadVehicle", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, parameters);
            var expected = "Loaded";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method LoadVehicle doesn't load the provided products in the vehicle's trunk.");
        }

        [Test]
        public void TestLoadVehicleMethodThrowsTargetInvocationExceptionWhenTryingToAddProductThatIsNotInProductPool()
        {
            // Adds "Ram" product to the product pool
            TestAddProductMethodShouldAddProduct();

            TestSelectVehicleMethodShouldSelectVehicle();

            // Product "Gpu" isn't present in the product pool
            object[] parameters = new object[] { new string[] { "Gpu" } };

            var method = this.type.GetMethod("LoadVehicle", BindingFlags.Instance | BindingFlags.Public);

            Assert.Throws<TargetInvocationException>(() => method.Invoke(this.instance, parameters),
                "Method LoadVehicle doesn't throw an exception when trying to add a product that isn't present in the product pool!");
        }

        [Test]
        public void TestSendVehicleToMethodShouldSendVehicleToCorrectStorage()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "DistributionCenter", "New Distribution Center" });

            object[] parameters = new object[] { "New Warehouse", 1, "New Distribution Center" };

            var method = this.type.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, parameters);
            var expected = "Sent";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method SendVehicleTo doesn't send the vehicle from the provided source storage to the destination storage!");
        }

        [Test]
        public void TestSendVehicleToMethodThrowsTargetInvocationExceptionWhenTryingToGetInvalidSourceStorage()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "DistributionCenter", "New Distribution Center" });

            object[] parameters = new object[] { "Ivalid Source", 1, "New Distribution Center" };

            var method = this.type.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);

            Assert.Throws<TargetInvocationException>(() => method.Invoke(this.instance, parameters),
                "Method SendVehicleTo doesn't throw an exception when trying to get vehicle from an invalid source storage!");
        }

        [Test]
        public void TestSendVehicleToMethodThrowsTargetInvocationExceptionWhenTryingToGetInvalidDestinationStorage()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "DistributionCenter", "New Distribution Center" });

            object[] parameters = new object[] { "New Warehouse", 1, "Invalid Destination" };

            var method = this.type.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);

            Assert.Throws<TargetInvocationException>(() => method.Invoke(this.instance, parameters),
                "Method SendVehicleTo doesn't throw an exception when trying to send vehicle to an invalid destination storage!");
        }

        [Test]
        public void TestUnloadVehicleMethodShouldUnloadVehicle()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });

            TestLoadVehicleMethodShouldLoadVehicle();

            object[] parameters = new object[] { "New Warehouse" , 1 };

            var method = this.type.GetMethod("UnloadVehicle", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, parameters);
            var expected = "Unloaded";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method UnloadVehicle doesn't unload products from the vehicle!");
        }

        [Test]
        public void TestGetStorageStatusMethodShouldGetStorageStatus()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });

            object[] parameters = new object[] { "New Warehouse" };

            var method = this.type.GetMethod("GetStorageStatus", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, parameters);
            var expected = "Stock";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method GetStorageStatus doesn't get the provided storage's status.");
        }

        [Test]
        public void TestGetSummaryMethodShouldGetSummary()
        {
            TestRegisterStorageMethodShouldRegisterStorage(new object[] { "Warehouse", "New Warehouse" });

            var method = this.type.GetMethod("GetSummary", BindingFlags.Instance | BindingFlags.Public);

            var actual = method.Invoke(this.instance, new object[] { });
            var expected = "New";

            Assert.AreEqual(expected, actual.ToString().Split()[0],
                "Method GetSummary doesn't provide the summary.");
        }
    }    
}
