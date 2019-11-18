namespace CustomLinkedList.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DynamicLinkedListTests
    {
        [Test]
        public void TestAddMethodCreatesHeadAndTailWhenAddingItemToEmptyDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);

            var type = typeof(DynamicList<int>);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var head = fields.FirstOrDefault(x => x.Name == "head");
            var tail = fields.FirstOrDefault(x => x.Name == "tail");

            bool actual = head != null && tail != null && dynamicList.Count == 1;
            bool expected = true;

            Assert.AreEqual(expected, actual, 
                "Add method doesn't create head and tail nodes when adding an item to an empty dynamic list.");
        }

        [Test]
        public void TestAddMethodAddsItemToDynamicListWithExistingItems()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.Count;
            int expected = 3;

            Assert.AreEqual(expected, actual, 
                "Add method doesn't add an item to a dynamic list with existing items.");
        }

        [Test]
        public void TestIndexerReturnsCorrectElement()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList[2];
            int expected = 3;

            Assert.AreEqual(expected, actual,
                "Indexer's getter doesn't return correct element.");
        }

        [Test]
        public void TestIndexerSetsCorrectValue()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            dynamicList[2] = 4;
            int actual = dynamicList[2];
            int expected = 4;

            Assert.AreEqual(expected, actual,
                "Indexer's setter doesn't set the correct value.");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void TestRemoveAtMethodThrowsArgumentOutOfRangeExceptionWhenTryingToAccessInvalidIndex(int index)
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicList.RemoveAt(index),
                "RemoveAt method doesn't throw an Argument Out Of Range Exception when trying to access an invalid index.");
        }

        [Test]
        public void TestRemoveAtMethodReturnsCorrectElement()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.RemoveAt(1);
            int expected = 2;

            Assert.AreEqual(expected, actual,
                "RemoveAt method doesn't return correct element.");
        }

        [Test]
        public void TestRemoveAtMethodReducesDynamicListCount()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            dynamicList.RemoveAt(1);

            int actual = dynamicList.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual,
                "RemoveAt method doesn't reduce dynamic list's count");
        }

        [Test]
        public void TestRemoveMethodReturnsCorrectIndexOfRemovedElement()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.Remove(1);
            int expected = 0;

            Assert.AreEqual(expected, actual,
                "Remove method doesn't return the correct index of the removed element.");
        }

        [Test]
        public void TestRemoveMethodReturnsMinusOneIfElementIsNotPresentInDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.Remove(4);
            int expected = -1;

            Assert.AreEqual(expected, actual,
                "Remove method doesn't return -1 if the element isn't present in the dynamic list.");
        }

        [Test]
        public void TestRemoveMethodReducesDynamicListCount()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            dynamicList.Remove(1);

            int actual = dynamicList.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual,
                "Remove method doesn't reduce dynamic list's count.");
        }

        [Test]
        public void TestIndexOfMethodReturnsCorrectIndex()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.IndexOf(3);
            int expected = 2;

            Assert.AreEqual(expected, actual,
                "IndeOf method doesn't return the correct index.");
        }

        [Test]
        public void TestIndexOfMethodReturnsMinusOneIfElementIsNotPresentInDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            int actual = dynamicList.IndexOf(4);
            int expected = -1;

            Assert.AreEqual(expected, actual,
                "IndexOf method doesn't return -1 if element isn't present in the dynamic list.");
        }

        [Test]
        public void TestContainsMethodReturnsTrueIfElementIsPresentInDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            bool actual = dynamicList.Contains(2);
            bool expected = true;

            Assert.AreEqual(expected, actual,
                "Contains method doesn't return True if element is present in the dynamic list.");
        }

        [Test]
        public void TestContainsMethodReturnsFalseIfElementIsNotPresentInDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);
            dynamicList.Add(2);
            dynamicList.Add(3);

            bool actual = dynamicList.Contains(4);
            bool expected = false;

            Assert.AreEqual(expected, actual,
                "Contains method doesn't return False if element isn't present in the dynamic list.");
        }
    }
}
