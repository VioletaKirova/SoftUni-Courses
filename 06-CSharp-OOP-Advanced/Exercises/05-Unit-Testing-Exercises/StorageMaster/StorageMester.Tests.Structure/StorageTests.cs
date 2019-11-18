namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageTests
    {
        private Type storageType;

        [SetUp]
        public void GetStorageType()
        {
            storageType = this.GetType("Storage");
        }

        [Test]
        public void ValidateAllStorages()
        {
            string[] types = new string[]
            {
                "AutomatedWarehouse",
                "DistributionCenter",
                "Warehouse",
                "Storage"
            };

            foreach (var type in types)
            {
                Type currentType = this.GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exist.");
            }
        }

        [Test]
        public void ValidateStorageIsAbstract()
        {
            Assert.That(storageType.IsAbstract, "Storage class must be abstract!");
        }

        [Test]
        public void ValidateStorageChildClasses()
        {
            Type[] types = new Type[]
            {
                this.GetType("AutomatedWarehouse"),
                this.GetType("DistributionCenter"),
                this.GetType("Warehouse")
            };

            foreach (var storage in types)
            {
                Assert.That(storage.BaseType, Is.EqualTo(storageType), $"{storage.Name} doesn't inherit {storageType.Name}.");
            }
        }

        [Test]
        public void TestFiledsOfStorageType()
        {
            var garageField = storageType.GetField("garage", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var productsField = storageType.GetField("products", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var garageFieldType = garageField.FieldType.Name;
            var productsFieldType = productsField.FieldType.Name;

            Assert.That(garageField, Is.Not.Null,
                "Field isn't found!");
            Assert.That(garageFieldType, Is.EqualTo(typeof(Vehicle[]).Name),
                "Type of garage field isn't correct!");

            Assert.That(productsField, Is.Not.Null,
                 "Field isn't found!");
            Assert.That(productsFieldType, Is.EqualTo(typeof(List<Product>).Name),
                "Type of products field isn't correct!");
        }

        [Test]
        public void TestPropertiesOfStorageType()
        {
            var actualProperties = storageType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Dictionary<string, Type> expectedProperties = new Dictionary<string, Type>()
            {
                { "Name", typeof(string) },
                { "Capacity", typeof(int) },
                { "GarageSlots", typeof(int) },
                { "IsFull",typeof(bool) },
                { "Garage", typeof(IReadOnlyCollection<Vehicle>) },
                { "Products", typeof(IReadOnlyCollection<Product>) }
            };

            foreach (var property in expectedProperties)
            {
                Assert.That(actualProperties.Any(p => p.Name == property.Key && p.PropertyType == property.Value), 
                    $"{property.Key} doesn't exist!");
            }
        }

        [Test]
        public void TestStorageTypeHasProtectedCtor()
        {
            Type[] types = new Type[] { typeof(string), typeof(int), typeof(int), typeof(IEnumerable<Vehicle>) };
            var constructor = storageType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsFamily;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Storage type's constructor isn't protecred!");
        }

        [Test]
        public void TestMethodsOfStorageType()
        {
            List<Method> expectedMethods = new List<Method>()
            {
                new Method(typeof(Vehicle), "GetVehicle", new Type[]{ typeof(int)}),
                new Method(typeof(int), "SendVehicleTo", new Type[]{ typeof(int), typeof(Storage)}),
                new Method(typeof(int), "UnloadVehicle", new Type[]{ typeof(int) }),
                new Method(typeof(void), "InitializeGarage", new Type[]{ typeof(IEnumerable<Vehicle>) }),
                new Method(typeof(int), "AddVehicle", new Type[]{ typeof(Vehicle) })
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var actualMethod = storageType.GetMethod(expectedMethod.Name, (BindingFlags)62);

                Assert.That(actualMethod, Is.Not.Null, $"{expectedMethod.Name} doesn't exist.");

                Assert.That(actualMethod.ReturnType == expectedMethod.ReturnType, $"{expectedMethod.Name} has incorrect return type!");

                var actualMethodParams = actualMethod.GetParameters();

                for (int i = 0; i < expectedMethod.InputPrameters.Length; i++)
                {
                    var actualParam = actualMethodParams[i].ParameterType;
                    var expectedParam = expectedMethod.InputPrameters[i];

                    Assert.That(actualParam, Is.EqualTo(expectedParam), $"{expectedMethod.Name} has invalid parameters!");
                }
            }

            
        }

        //[Test]
        //public void TestReturnTypeOfStorageMethodGetVehicle()
        //{
        //    var method = storageType.GetMethod("GetVehicle", BindingFlags.Instance | BindingFlags.Public);

        //    var returnType = method.ReturnType;

        //    Assert.That(returnType, Is.EqualTo(typeof(Vehicle)),
        //        "Return type of method GetVehicle should be Vehicle!");
        //}

        //[Test]
        //public void TestReturnTypeOfStorageMethodSendVehicleTo()
        //{
        //    var method = storageType.GetMethod("SendVehicleTo", BindingFlags.Instance | BindingFlags.Public);

        //    var returnType = method.ReturnType;

        //    Assert.That(returnType, Is.EqualTo(typeof(int)),
        //        "Return type of method SendVehicleTo should be int!");
        //}

        //[Test]
        //public void TestReturnTypeOfStorageMethodUnloadVehicle()
        //{
        //    var method = storageType.GetMethod("UnloadVehicle", BindingFlags.Instance | BindingFlags.Public);

        //    var returnType = method.ReturnType;

        //    Assert.That(returnType, Is.EqualTo(typeof(int)),
        //        "Return type of method UnloadVehicle should be int!");
        //}

        //[Test]
        //public void TestReturnTypeOfStorageMethodInitializeGarage()
        //{
        //    var method = storageType.GetMethod("InitializeGarage", BindingFlags.Instance | BindingFlags.NonPublic);

        //    var returnType = method.ReturnType;

        //    Assert.That(returnType, Is.EqualTo(typeof(void)),
        //        "Return type of method InitializeGarage should be void!");
        //}

        //[Test]
        //public void TestReturnTypeOfStorageMethodAddVehicle()
        //{
        //    var method = storageType.GetMethod("AddVehicle", BindingFlags.Instance | BindingFlags.NonPublic);

        //    var returnType = method.ReturnType;

        //    Assert.That(returnType, Is.EqualTo(typeof(int)),
        //        "Return type of method AddVehicle should be int!");
        //}

        [Test]
        public void TestAutomatedWarehouseTypeHasPublicCtor()
        {
            Type type = this.GetType("AutomatedWarehouse");
            Type[] types = new Type[] { typeof(string) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "AutomatedWarehouse type's constructor isn't public!");
        }

        [Test]
        public void TestDistributionCenterTypeHasPublicCtor()
        {
            Type type = this.GetType("DistributionCenter");
            Type[] types = new Type[] { typeof(string) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "DistributionCenter type's constructor isn't public!");
        }

        [Test]
        public void TestWarehouseTypeHasPublicCtor()
        {
            Type type = this.GetType("Warehouse");
            Type[] types = new Type[] { typeof(string) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Warehouse type's constructor isn't public!");
        }

        private Type GetType(string typeName)
        {
            Type type = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeName);

            return type;
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputPrameters)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputPrameters = inputPrameters;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputPrameters { get; set; }
        }
    }
}
