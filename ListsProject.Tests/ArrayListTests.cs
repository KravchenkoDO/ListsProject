using NUnit.Framework;
using System;

namespace ListsProject.Tests
{
    public class ArrayListTests
    {
        [TestCase(new[] {1, 2, 5, 3}, 6, new[] {1, 2, 5, 3, 6})]
        [TestCase(new int[] { }, 666, new[] {666})]
        [TestCase(new[] {1, 9, 11}, 1, new[] {1, 9, 11, 1})]
        public void Add_WhenAddElementInList_ListWithNewElementInTheEndReturned(int[] input, int value, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 0, 666, new[] {666})]
        [TestCase(new[] {1, 3, 4, 5, 6, 7}, 1, 2, new[] {1, 2, 3, 4, 5, 6, 7})]
        [TestCase(new[] {1, 3, 4, 5, 6, 7}, 6, 666, new[] {1, 3, 4, 5, 6, 7, 666})]
        [TestCase(new[] {1, 3, 4, 5, 6, 7}, 0, 666, new[] {666, 1, 3, 4, 5, 6, 7})]
        public void AddByIndex_WhenAddElementByIndexInList_ListWithNewElementInTheIndexPositionReturned(
            int[] input, int index, int value, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {12, 23, 34}, -2, 12)]
        [TestCase(new[] {12, 23, 34}, 4, 12)]
        public void
            AddByIndex_WhenAddElementByIndexLessThen0OrGreaterThenListLength_IndexOutOfRangeExceptionReturned(
                int[] input,
                int index, int value)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(new int[] { }, 666, new[] {666})]
        [TestCase(new[] {1, 2, 3, 4, 5}, 666, new[] {666, 1, 2, 3, 4, 5})]
        [TestCase(new[] {1, 2, 3, 4, 5}, 0, new[] {0, 1, 2, 3, 4, 5})]
        public void AddFirst_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int[] input,
            int value, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2})]
        [TestCase(new[] {1}, new int[] { })]
        public void RemoveLast_WhenRemoveLastElementInList_ListWithoutElementInLastPositionReturned(int[] input,
            int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveLast_WhenRemoveLastElementInEmptyList_IndexOutOfRangeExceptionReturned(int[] input)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveLast());
        }

        [TestCase(new[] {1, 2, 3, 4}, new[] {2, 3, 4})]
        [TestCase(new[] {3, 4}, new[] {4})]
        [TestCase(new[] {4}, new int[] { })]
        public void RemoveFirst_WhenRemoveFirstElementInList_ListWithoutElementInFirstPositionReturned(int[] input,
            int[] output)
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

        [TestCase(new[] {1, 2, 3, 4}, 3, new[] {1, 2, 3})]
        [TestCase(new[] {1, 2, 3, 4}, 0, new[] {2, 3, 4})]
        [TestCase(new[] {1, 2, 3, 4}, 2, new[] {1, 2, 4})]
        public void RemoveByIndex_WhenRemoveElementByIndexInList_ListWithoutElementInTheIndexPositionReturned(
            int[] input, int index, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3}, -1)]
        [TestCase(new[] {1, 2, 3}, 3)]
        public void
            RemoveByIndex_WhenRemoveElementByIndexLessThen0OrGreaterThenLastElementIndex_IndexOutOfRangeExceptionReturned(
                int[] input, int index)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(new[] {1, 2, 3, 4}, 2, new[] {1, 2})]
        [TestCase(new[] {1, 2, 3, 4}, 4, new int[] { })]
        [TestCase(new[] {1, 2, 3, 4}, 0, new[] {1, 2, 3, 4})]
        public void
            RemoveRangeFromLast_WhenRemoveRangeOfElementsFromLastOfList_ListWithoutCountElementsInThisRangeFromEndReturned(
                int[] input, int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromLast(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3}, 4)]
        [TestCase(new[] {1, 2, 3}, -3)]
        public void RemoveRangeFromLast_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
            int[] input, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromLast(count));
        }

        [TestCase(new[] {1, 2, 3, 4}, 2, new[] {3, 4})]
        [TestCase(new[] {1, 2, 3, 4}, 4, new int[] { })]
        [TestCase(new[] {1, 2, 3, 4}, 0, new[] {1, 2, 3, 4})]
        public void
            RemoveRangeFromFirst_WhenRemoveRangeOfElementsFromFirstOfList_ListWithoutCountElementsInThisRangeFromBeginReturned(
                int[] input, int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromFirst(count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3}, 4)]
        [TestCase(new[] {1, 2, 3}, -3)]
        public void RemoveRangeFromFirst_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
            int[] input, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromFirst(count));
        }

        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7}, 2, 2, new[] {1, 2, 5, 6, 7})]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7}, 5, 2, new[] {1, 2, 3, 4, 5})]
        [TestCase(new[] {1, 2, 3, 4}, 0, 4, new int[] { })]
        [TestCase(new[] {1, 2, 3, 4}, 3, 0, new[] {1, 2, 3, 4})]
        public void
            RemoveRangeFromIndex_WhenRemoveRangeOfElementsFromIndexOfList_ListWithoutCountElementsInThisRangeFromIndexReturned(
                int[] input, int index, int count, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.RemoveRangeFromIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 5}, 2, 3)]
        [TestCase(new[] {1, 2, 3, 5}, 1, -1)]
        public void RemoveRangeFromIndex_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(int[] input,
            int index, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] {1, 2, 3, 5}, -2, 2)]
        [TestCase(new[] {1, 2, 3, 5}, 4, 1)]
        public void
            RemoveRangeFromIndex_WhenIndexLessThen0OrGreaterThatLastValueIndex_IndexOutOfRangeExceptionReturned(
                int[] input, int index, int count)
        {
            ArrayList actual = new ArrayList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] {1, 2, 3, 5}, 5, 3)]
        [TestCase(new[] {1, 2, 3, 2}, 2, 1)]
        [TestCase(new[] {1, 2, 3, 5}, 7, -1)]
        public void RemoveFirstByValue_WhenFirstValueFoundRemoveItFromList_IndexOfThatValueReturned(int[] input,
            int value, int expected)
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

        [TestCase(new[] {1, 1, 1, 1}, 1, 0)]
        [TestCase(new[] {1, 2, 3, 4, 6, 7, 8}, 7, 5)]
        [TestCase(new[] {1}, 1, 0)]
        [TestCase(new[] {1, 1, 2, 3, 4, 6, 7, 8}, 9, -1)]
        public void GetFirstIndexByValue_WhenArrayListsContainValues_IndexOfFirstFoundValueReturned(int[] input,
            int value, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 4}, new[] {4, 3, 2, 1})]
        [TestCase(new[] {1, 2, 5, 3, 4}, new[] {4, 3, 5, 2, 1})]
        [TestCase(new[] {1}, new[] {1})]
        [TestCase(new[] {0}, new[] {0})]
        public void Reverse_WhenArrayList_ReversedArrayListReturned(int[] input, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 10, 5}, 1)]
        [TestCase(new[] {1, 10, 5, 14, 999}, 4)]
        [TestCase(new[] {0}, 0)]
        public void FindIndexOfMaxValue_WhenFindListMaxValue_IndexOfMaxValueReturned(int[] input, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.FindIndexOfMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 10, 15}, 15)]
        [TestCase(new[] {1, 15, 15}, 15)]
        [TestCase(new[] {1, 10, 5, 1}, 10)]
        [TestCase(new[] {0}, 0)]
        public void FindMaxValue_WhenArrayListHasElements_MaxValueReturned(int[] input, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.FindMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 4}, 0)]
        [TestCase(new[] {1, 2, 3, 4, 6, 7, 8}, 0)]
        [TestCase(new[] {55, 10, 5}, 2)]
        public void FindIndexOfMinValue_WhenFindListMinValue_IndexOfMinValueReturned(int[] input, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.FindIndexOfMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 4}, 1)]
        [TestCase(new[] {1, 2, 3, 4, 3, 7, 0}, 0)]
        [TestCase(new[] {55, 10, 5}, 5)]
        public void FindMinValue_WhenArrayListHasElements_MinValueReturned(int[] input, int expected)
        {
            ArrayList arrayList = new ArrayList(input);

            int actual = arrayList.FindMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 3, 5, 7, 8}, false, new[] {8, 7, 5, 3, 1})]
        [TestCase(new[] {8, 7, 5, 3, 1}, false, new[] {8, 7, 5, 3, 1})]
        [TestCase(new[] {1}, false, new[] {1})]
        [TestCase(new[] {1}, true, new[] {1})]
        [TestCase(new[] {1, 3, 5, 7, 8}, true, new[] {1, 3, 5, 7, 8})]
        [TestCase(new[] {8, 7, 5, 3, 1}, true, new[] {1, 3, 5, 7, 8})]
        public void Sort_WhenArrayList_SortedArrayListByDescendingReturned(int[] input, bool ascending,
            int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList expected = new ArrayList(output);

            actual.Sort(ascending);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 4}, 0, new[] {6, 7, 8, 9}, new[] {6, 7, 8, 9, 1, 2, 3, 4})]
        [TestCase(new[] {1, 2}, 1, new[] {6, 7, 8, 9, 1, 2, 3, 4}, new[] {1, 6, 7, 8, 9, 1, 2, 3, 4, 2})]
        [TestCase(new[] {1, 6, 7, 8, 9, 1, 2, 3, 4, 2}, 4, new[] {1, 6, 7, 8, 9, 1, 2, 3, 4, 2},
            new[] {1, 6, 7, 8, 1, 6, 7, 8, 9, 1, 2, 3, 4, 2, 9, 1, 2, 3, 4, 2})]
        public void AddListByIndex_WhenToListAddAnotherListByIndex_ListWithInsertedInIndexListReturned(int[] input,
            int index, int[] arrayElements, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList arrayList = new ArrayList(arrayElements);
            ArrayList expected = new ArrayList(output);

            actual.AddListByIndex(index, arrayList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2}, -1, new[] {6, 7, 8, 9, 1, 2, 3, 4})]
        [TestCase(new[] {1, 2}, 3, new[] {6, 7, 8, 9, 1, 2, 3, 4})]
        public void AddListByIndex_WhenIndexLessThen0OrGreaterThenLastElementIndex_IndexOutOfRangeExceptionReturned(
            int[] input,
            int index, int[] arrayElements)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList arrayList = new ArrayList(arrayElements);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListByIndex(index, arrayList));
        }

        [TestCase(new[] {1, 2, 3, 4}, new[] {6, 7, 8, 9}, new[] {6, 7, 8, 9, 1, 2, 3, 4})]
        [TestCase(new[] {1, 2}, new[] {6, 7, 8, 9, 1, 2, 3, 4}, new[] {6, 7, 8, 9, 1, 2, 3, 4, 1, 2})]
        public void
            AddListFirst_WhenToFirstListAddAnotherListInFirstPosition_ListWithInsertedInFirstPositionListReturned(
                int[] input,
                int[] arrayElements, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList arrayList = new ArrayList(arrayElements);
            ArrayList expected = new ArrayList(output);

            actual.AddListFirst(arrayList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] {1, 2, 3, 4}, new[] {6, 7, 8, 9}, new[] {1, 2, 3, 4, 6, 7, 8, 9})]
        [TestCase(new[] {1, 2}, new[] {6, 7, 8, 9, 1, 2, 3, 4}, new[] {1, 2, 6, 7, 8, 9, 1, 2, 3, 4})]
        public void
            AddListLast_WhenToFirstListAddAnotherListInLastPosition_ListWithInsertedInLasttPositionListReturned(
                int[] input,
                int[] arrayElements, int[] output)
        {
            ArrayList actual = new ArrayList(input);
            ArrayList arrayList = new ArrayList(arrayElements);
            ArrayList expected = new ArrayList(output);

            actual.AddListLast(arrayList);

            Assert.AreEqual(expected, actual);
        }
    }
}