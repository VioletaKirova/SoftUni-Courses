namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ProductTests
    {
        private Type productType;

        [SetUp]
        public void GetProductType()
        {
            productType = this.GetType("Product");
        }

        [Test]
        public void ValidateAllProducts()
        {
            string[] types = new string[]
            {
                "Gpu",
                "HardDrive",
                "Ram",
                "SolidStateDrive",
                "Product"
            };

            foreach (var type in types)
            {
                Type currentType = this.GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exist");
            }
        }

        [Test]
        public void ValidateProductIsAbstract()
        {
            Assert.That(productType.IsAbstract, "Product class must be abstract!");
        }

        [Test]
        public void ValidateProductChildClasses()
        {
            Type[] types = new Type[]
            {
                this.GetType("Gpu"),
                this.GetType("HardDrive"),
                this.GetType("SolidStateDrive"),
                this.GetType("Ram")
            };

            foreach (var product in types)
            {
                Assert.That(product.BaseType, Is.EqualTo(productType), $"{product.Name} doesn't inherit {productType.Name}.");
            }
        }

        [Test]
        public void TestPriceFieldOfProductType()
        {
            var field = productType.GetField("price", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var fieldType = field.FieldType.Name;

            Assert.That(field, Is.Not.Null,
                "Field isn't found!");
            Assert.That(fieldType, Is.EqualTo(typeof(double).Name),
                "Type of field isn't correct!");
        }

        [Test]
        public void TestPropertiesOfProductType()
        {
            var actualProperties = productType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Dictionary<string, Type> expectedProperties = new Dictionary<string, Type>()
            {
                { "Price", typeof(double) },
                { "Weight", typeof(double) }
            };

            foreach (var property in expectedProperties)
            {
                Assert.That(actualProperties.Any(p => p.Name == property.Key && p.PropertyType == property.Value),
                    $"{property.Key} doesn't exist!");
            }
        }

        [Test]
        public void TestProductTypeHasProtectedCtor()
        { 
            Type[] types = new Type[] { typeof(double), typeof(double) };
            var constructor = productType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsFamily;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Product type's constructor isn't protecred!");
        }

        [Test]
        public void TestGpuTypeHasPublicCtor()
        {
            Type type = this.GetType("Gpu");
            Type[] types = new Type[] { typeof(double) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Gpu type's constructor isn't public!");
        }

        [Test]
        public void TestHardDriveTypeHasPublicCtor()
        {
            Type type = this.GetType("HardDrive");
            Type[] types = new Type[] { typeof(double) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "HardDrive type's constructor isn't public!");
        }

        [Test]
        public void TestRamTypeHasPublicCtor()
        {
            Type type = this.GetType("Ram");
            Type[] types = new Type[] { typeof(double) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "Ram type's constructor isn't public!");
        }

        [Test]
        public void TestSolidStateDriveTypeHasPublicCtor()
        {
            Type type = this.GetType("SolidStateDrive");
            Type[] types = new Type[] { typeof(double) };
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);

            bool accessModifier = constructor.IsPublic;

            Assert.That(accessModifier, Is.EqualTo(true),
                "SolidStateDrive type's constructor isn't public!");
        }

        //[Test]
        //public void TestMethodsOfProductType()
        //{
        //    var methods = productType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

        //    string[] expectedMethods = new string[]
        //    {
        //        "get_Price",
        //        "set_Price",
        //        "get_Weight"
        //    };

        //    string[] actualMethods = methods.Select(p => p.Name).ToArray();

        //    Assert.That(actualMethods, Is.EquivalentTo(expectedMethods),
        //        "Methods of Product type aren't correct!");
        //}

        private Type GetType(string typeName)
        {
            Type type = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeName);

            return type;
        }
    }
}
