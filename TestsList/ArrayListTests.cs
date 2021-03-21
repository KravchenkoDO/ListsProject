using NUnit.Framework;
using System;

namespace ListsProject.Tests
{
    public class ListsProject
    {

        [TestCase(new[] {1,2,5,3}, 6, new[] {1,2,5,3,6})]
        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 9, 11 }, 1, new[] { 1, 9, 11, 1})]
        public void Add_WhenAddElementInList_ListWithNewElementInTheEndReturned(int [] input, int value, int [] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int [] {}, 0,666, new[] {666})]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 1, 2, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 6, 666, new[] { 1, 3, 4, 5, 6, 7, 666 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 0, 666, new[] { 666, 1, 3, 4, 5, 6, 7 })]
        public void AddByIndex_WhenAddElementByIndexInList_ListWithNewElementInTheIndexPositionReturned(int[] input, int index, int value, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] {12,23,34}, -2, 12)]
        [TestCase(new[] { 12, 23, 34 }, 4, 12)]
        public void AddByIndex_WhenAddElementByIndexLessThen0OrGreaterThenListLength_IndexOutOfRangeExceptionReturned(int[] input,
            int index, int value)
        {
            ArrayList actual = new ArrayList(input);

            try
            {
                actual.AddByIndex(index, value);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
            Assert.Fail();
            //Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }
        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 2, 3, 4, 5}, 666, new[] { 666, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int[] input, int value, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] {1,2,3}, new[] {1,2})]
        [TestCase(new[] { 1 }, new int[] { })]
        public void RemoveLast_WhenRemoveLastElementInList_ListWithoutElementInLastPositionReturned(int[] input, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] {})]
        public void RemoveLast_WhenRemoveLastElementInEmptyList_IndexOutOfRangeExceptionReturned(int[] input)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveLast());
        }
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 })]
        [TestCase(new[] { 3, 4 }, new[] { 4 })]
        [TestCase(new[] { 4 }, new int[] { })]

        public void RemoveFirst_WhenRemoveFirstElementInList_ListWithoutElementInFirstPositionReturned(int[] input, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void RemoveFirst_WhenRemoveFirstElementInEmptyList_IndexOutOfRangeExceptionReturned(int[] input)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveFirst());
        }
        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 1, 2, 3})]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2, 4 })]
        public void RemoveByIndex_WhenRemoveElementByIndexInList_ListWithoutElementInTheIndexPositionReturned(
            int[] input, int index, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] {1,2,3}, -1)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        public void RemoveByIndex_WhenRemoveElementByIndexLessThen0OrGreaterThenLastElementIndex_IndexOutOfRangeExceptionReturned(int[] input, int index)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void RemoveRangeFromLast_WhenRemoveRangeOfElementsFromLastOfList_ListWithoutCountElementsInThisRangeFromEndReturned(int[] input, int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromLast(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, -3)]
        public void RemoveRangeFromLast_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(int[] input, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromLast(count));
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void RemoveRangeFromFirst_WhenRemoveRangeOfElementsFromFirstOfList_ListWithoutCountElementsInThisRangeFromBeginReturned(int[] input, int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromFirst(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, -3)]
        public void RemoveRangeFromFirst_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(int[] input, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromFirst(count));
        }
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7}, 2, 2, new[] { 1, 2, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 5, 2, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, 0, new[] { 1, 2, 3, 4 })]
        public void RemoveRangeFromIndex_WhenRemoveRangeOfElementsFromIndexOfList_ListWithoutCountElementsInThisRangeFromIndexReturned(int[] input, int index , int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 2, 3)]
        [TestCase(new[] { 1, 2, 3, 5 }, 1, -1)]
        public void RemoveRangeFromIndex_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(int[] input,
            int index, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromIndex(index, count));
        }
        [TestCase(new[] { 1, 2, 3, 5 }, -2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 4, 1)]
        public void RemoveRangeFromIndex_WhenIndexLessThen0OrGreaterThatLastValueIndex_IndexOutOfRangeExceptionReturned(int[] input,
            int index, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeFromIndex(index, count));
        }
        [TestCase(new[] { 1, 2, 3, 5 }, 5, 3)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, -1)]
        public void RemoveFirstByValue_WhenFirstValueFoundRemoveItFromList_IndexOfThatValueReturned(int[] input, int value, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 5}, 5, 1)]
        [TestCase(new[] {1, 2, 3, 2}, 2, 2)]
        [TestCase(new[] {1, 2, 3, 5}, 7, 0)]
        [TestCase(new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 1, 10)]
        public void RemoveAllByValue_WhenValuesFoundRemoveItFromList_CountOfThatValuesReturned(int[] input, int value,
            int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 7)]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLength_WhenArrayListsHasElements_CountOfElementsReturned(int[] input, int expected)
        {
            ArrayList arrayList = new ArrayList(input);
            int actual = arrayList.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 1, 1, 1 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 7, 5)]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1, 1, 2, 3, 4, 6, 7, 8 }, 9, -1)]
        public void GetFirstIndexByValue_WhenArrayListsContainValues_IndexOfFirstFoundValueReturned(int[] input, int value, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }


















        




        // max index 
        
        [TestCase(new[] { 1, 10, 5 }, 1)]
        public void FindIndexOfMaxValue_WhenFindListMaxValue_IndexOfMaxValueReturned(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int index = a.FindIndexOfMaxValue();
            Assert.AreEqual(index, expected);
        }

        // min index 
        
        [TestCase(new[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 2)]
        public void FindIndexOfMinValue_WhenFindListMinValue_IndexOfMinValueReturned(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int index = a.FindIndexOfMinValue();
            Assert.AreEqual(index, expected);
        }

        // max value 
        
        [TestCase(new[] { 1, 10, 5 }, 10)]
        [TestCase(new[] { 1, 15, 15 }, 15)]
        [TestCase(new[] { 1, 10, 5, 1}, 10)]
        public void FindMaxValue_WhenArrayLists_IntOfMaxValue(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int value = a.FindMaxValue();
            Assert.AreEqual(value, expected);
        }

        // min value
        
        [TestCase(new[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 2)]
        public void FindMinValue_WhenArrayLists_IntOfMinValue(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int value = a.FindIndexOfMinValue();
            Assert.AreEqual(value, expected);
        }
    }
}