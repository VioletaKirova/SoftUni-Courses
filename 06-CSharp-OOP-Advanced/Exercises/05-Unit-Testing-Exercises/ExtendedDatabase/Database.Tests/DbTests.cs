namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DbTests
    {
        private const int Capacity = 16;

        [Test]
        public void TestCtorInitsArrayWithZeroParams()
        {
            IDatabase db = new Database();

            int actual = db.Data.Length;
            int expected = Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCtorInitsArrayWithMaxParamsAndDefaultData()
        {
            IPerson[] value = new Person[Capacity];

            IDatabase db = new Database(value);

            IPerson[] actual = db.Data;
            IPerson[] expected = new Person[Capacity];

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void TestCtorInitsArrayWithCorrectElements()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);

            IPerson[] actualData = db.Data;
            IPerson[] expectedData = value;

            bool actual = true;

            for (int i = 0; i < db.Count; i++)
            {
                if (actualData[i] != expectedData[i])
                {
                    actual = false;
                    break;
                }
            }

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenSettingValueLargerThanCapacity()
        {
            IPerson[] value = new IPerson[Capacity + 1];

            Assert.Throws<InvalidOperationException>(() => new Database(value));
        }       

        [Test]
        public void TestAddMethodAddsElemntAtCorrectIndex()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IPerson newElement = new Person("Misho", 4);

            IDatabase db = new Database(value);
            db.Add(newElement);

            IPerson actual = db.Data[db.Count - 1];
            IPerson expected = newElement;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddMethodAddsElemntAtLastIndex()
        {
            IPerson[] value = new IPerson[Capacity - 1];
            IDatabase db = new Database(value);
            IPerson element = new Person("Pesho", 1);

            for (int i = 0; i < db.Count; i++)
            {
                db.Data[i] = element;
            }

            IPerson elementToAdd = new Person("Sasho", 2);
            db.Add(elementToAdd);

            IPerson actual = db.Data[Capacity - 1];
            IPerson expected = elementToAdd;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenTryingToAddElementWhenDatabaseIsFull()
        {
            IPerson[] value = new IPerson[Capacity];
            IDatabase db = new Database(value);

            for (int i = 0; i < db.Count; i++)
            {
                db.Data[i] = new Person("Sasho", 1);
            }

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person("Gosho", 2)));
        }

        [Test]
        public void TestAddMethodThrowsInvalidOperationExceptionWhenTryingToAddElementWithSameName()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IPerson newElement = new Person("Pesho", 4);

            IDatabase db = new Database(value);

            Assert.That(() => db.Add(newElement),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Person already exists!"));
        }

        [Test]
        public void TestAddMethodThrowsInvalidOperationExceptionWhenTryingToAddElementWithSameId()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IPerson newElement = new Person("Gosho", 1);

            IDatabase db = new Database(value);

            Assert.That(() => db.Add(newElement),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Person already exists!"));
        }

        [Test]
        public void TestRemoveMethodRemovesElemntAtCorrectIndex()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);;
            db.Remove();

            int actual = db.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenTryingToRemoveElementFromEmptyDatabase()
        {
            IDatabase db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void TestMethodFindByUsernameThrowsArgumentNullExceptionWhenParamIsNull()
        {
            IDatabase db = new Database();

            string username = null;

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(username));
        }

        [Test]
        public void TestMethodFindByUsernameReturnsCorrectElement()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);

            IPerson actual = db.FindByUsername("Sasho");
            IPerson expected = value[1];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMethodFindByUsernameThrowsInvalidOperationExceptionWhenElementIsNotFound()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);

            string username = "Misho";

            Assert.That(() => db.FindByUsername(username),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo($"Person with username:{username} doesn't exist!"));
        }

        [Test]
        public void TestMethodFindByIdThrowsArgumentOutOfRangeExceptionWhenParamIsLessThanZero()
        {
            IDatabase db = new Database();

            long id = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(id));
        }

        [Test]
        public void TestMethodFindByIdReturnsCorrectElement()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);

            IPerson actual = db.FindById(2);
            IPerson expected = value[1];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMethodFindByIdThrowsInvalidOperationExceptionWhenElementIsNotFound()
        {
            IPerson[] value = new Person[]
            {
                new Person("Pesho", 1),
                new Person("Sasho", 2),
                new Person("Tosho", 3)
            };

            IDatabase db = new Database(value);

            long id = 4;

            Assert.That(() => db.FindById(id),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo($"Person with ID:{id} doesn't exist!"));
        }
    }
}
