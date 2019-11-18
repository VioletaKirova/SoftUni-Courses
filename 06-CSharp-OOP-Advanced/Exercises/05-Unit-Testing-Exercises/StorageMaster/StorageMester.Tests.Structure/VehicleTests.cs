namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class VehicleTests
    {
        private Type vehicleType;

        [SetUp]
        public void GetVehicleType()
        {
            vehicleType = typeof(Vehicle);
        }

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exist");
            }
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Assert.That(vehicleType.IsAbstract, "Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            Type[] childClasses = new Type[]
            {
                this.GetType("Semi"),
                this.GetType("Truck"),
                this.GetType("Van")
            };

            foreach (var vehicle in childClasses)
            {
                Assert.That(vehicle.BaseType, Is.EqualTo(vehicleType), $"{vehicle.Name} doesn't inherit {vehicleType.Name}.");
            }
        }

        [Test]
        public void TestTrunkFieldOfVehicleType()
        {
            var field = vehicleType.GetField("trunk", BindingFlags.Instance | BindingFlags.NonPublic);

            var fieldType = field.FieldType.Name;

            Assert.That(field, Is.Not.Null,
                "Trunk field isn't found!");
            Assert.That(fieldType, Is.EqualTo(typeof(List<Product>).Name),
                "Type of field isn't correct!");
        }

        [Test]
        public void TestPropertiesOfVehicleType()
        {           
            Dictionary<string, Type> expectedPropertyNames = new  Dictionary<string, Type>()
            {
                { "Capacity", typeof(int)},
                { "Trunk", typeof(IReadOnlyCollection<Product>)},
                { "IsFull",  typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            var actualProperties = vehicleType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in expectedPropertyNames)
            {
                bool isPresent = actualProperties.Any(p => p.Name == property.Key && p.PropertyType == property.Value);

                Assert.That(isPresent, Is.EqualTo(true), $"{property.Key} doesn't exist!");
            }
        }

        [Test]
        public void TestVehicleTypeHasProtectedCtor()
        {
            Type[] types = new Type[] { typeof(int) };
            var constructor = vehicleType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsFamily;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Vehicle type's constructor isn't protecred!");
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = vehicleType.GetMethod(expectedMethod.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{expectedMethod.Name} method doesn't exist!");

                var isReturnTypeValid = currentMethod.ReturnType == expectedMethod.ReturnType;

                Assert.That(isReturnTypeValid, $"{expectedMethod.Name} has invalid return type!");

                var expectedMethodParms = expectedMethod.InputParamateres;
                var actualParms = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParms.Length; i++)
                {
                    var actualParam = actualParms[i].ParameterType;
                    var expectedParam = expectedMethodParms[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void TestSemiTypeHasPublicCtor()
        {
            Type type = this.GetType("Semi");
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { }, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Semi type's constructor isn't public!");
        }

        [Test]
        public void TestTruckTypeHasPublicCtor()
        {
            Type type = this.GetType("Truck");
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { }, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Truck type's constructor isn't public!");
        }

        [Test]
        public void TestVanTypeHasPublicCtor()
        {
            Type type = this.GetType("Van");
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { }, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Van type's constructor isn't public!");
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
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParamateres = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParamateres { get; set; }
        }
    }
}
