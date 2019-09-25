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

        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void TestCtorInitsArrayWithDifferentLengthParams(params int[] value)
        {
            IDatabase db = new Database(value);

            int[] actual = db.Data;

            int[] expected = new int[Capacity];

            for (int i = 0; i < value.Length; i++)
            {
                expected[i] = value[i];
            }

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenSettingValueLargerThanCapacity()
        {
            int[] value = new int[Capacity + 1];

            Assert.Throws<InvalidOperationException>(() => new Database(value));
        }

        [Test]
        public void TestAddMethodAddsElemntAtCorrectIndex()
        {
            IDatabase db = new Database(1, 2, 3);
            db.Add(4);

            int actual = db.Data[3];
            int expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddMethodAddsElemntAtLastIndex()
        {
            IDatabase db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            db.Add(16);

            int actual = db.Data[Capacity - 1];
            int expected = 16;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenTryingToAddElementWhenDatabaseIsFull()
        {
            IDatabase db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }
        
        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void TestRemoveMethodRemovesCorrectElement(params int[] value)
        {
            IDatabase db = new Database(value);

            db.Remove();

            int actual = db.Count;
            int expected = value.Length - 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestThrowsInvalidOperationExceptionWhenTryingToRemoveElementFromEmptyDatabase()
        {
            IDatabase db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [TestCase()]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void TestFetchMethodReturnsArrayWithCorrectSize(params int[] value)
        {
            IDatabase db = new Database(value);

            int actual = db.Fetch().Length;
            int expected = value.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase()]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void TestFetchMethodReturnsArrayWithCorrectElements(params int[] value)
        {
            IDatabase db = new Database(value);

            int[] actual = db.Fetch();
            int[] expected = value;

            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
