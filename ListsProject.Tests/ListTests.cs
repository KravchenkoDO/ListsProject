using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ListsProject.Tests
{
    [TestFixture("ArrayList")]
    [TestFixture("SingleLinkedList")]
    [TestFixture("DoublyLinkedList")]
    public class ListTests
    {
        string listType = "";

        public ListTests(string type)
        {
            listType = type;
        }

        public IList InitialList(int[] inputArray)
        {
            switch (listType)
            {
                case "ArrayList":
                    return new ArrayList(inputArray);
                case "SingleLinkedList":
                    return new SingleLinkedList(inputArray);
                case "DoublyLinkedList":
                    return new DoublyLinkedList(inputArray);
            }
            return new ArrayList(inputArray);
        }

        [TestCase(new[] { 1, 2, 5, 3 }, 6, new[] { 1, 2, 5, 3, 6 })]
        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 9, 11 }, 1, new[] { 1, 9, 11, 1 })]
        [TestCase(new int[] { }, 0, new[] { 0 })]
        [TestCase(new int[] { 1, 9, 11 }, 0, new[] { 1, 9, 11, 0 })]
        public void Add_WhenAddElementInList_ListWithNewElementInTheEndReturned(int[] input, int value, int[] output)
        {
            IList actual = InitialList(input);
            actual.Add(value);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 1, 2, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 6, 666, new[] { 1, 3, 4, 5, 6, 7, 666 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 0, 666, new[] { 666, 1, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, 0, 666, new[] { 666 })]
        public void AddByIndex_WhenAddElementByIndexInList_ListWithNewElementInTheIndexPositionReturned(
            int[] input, int index, int value, int[] output)
        {
            IList actual = InitialList(input);
            actual.AddByIndex(index, value);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 12, 23, 34 }, -2, 12)]
        [TestCase(new[] { 12, 23, 34 }, 4, 12)]
        public void
            AddByIndex_WhenAddElementByIndexLessThen0OrGreaterThenListLength_IndexOutOfRangeExceptionReturned(
                int[] input,
                int index, int value)
        {
            IList actual = InitialList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 666, new[] { 666, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirst_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int[] input,
            int value, int[] output)
        {
            IList actual = InitialList(input);
            actual.AddFirst(value);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 1 }, new int[] { })]
        public void RemoveLast_WhenRemoveLastElementInList_ListWithoutElementInLastPositionReturned(int[] input,
           int[] output)
        {
            IList actual = InitialList(input);
            actual.RemoveLast();

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveLast_WhenRemoveLastElementInEmptyList_IndexOutOfRangeExceptionReturned(int[] input)
        {
            IList actual = InitialList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveLast());
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 })]
        [TestCase(new[] { 3, 4 }, new[] { 4 })]
        [TestCase(new[] { 4 }, new int[] { })]
        public void RemoveFirst_WhenRemoveFirstElementInList_ListWithoutElementInFirstPositionReturned(int[] input,
            int[] output)
        {
            IList actual = InitialList(input);
            actual.RemoveFirst();

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveFirst_WhenRemoveFirstElementInEmptyList_IndexOutOfRangeExceptionReturned(int[] input)
        {
            IList actual = InitialList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveFirst());
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2, 4 })]
        public void RemoveByIndex_WhenRemoveElementByIndexInList_ListWithoutElementInTheIndexPositionReturned(
            int[] input, int index, int[] output)
        {
            IList actual = InitialList(input);
            actual.RemoveByIndex(index);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, -1)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        public void RemoveByIndex_WhenRemoveElementByIndexLessThen0OrGreaterThenLastElementIndex_IndexOutOfRangeExceptionReturned(
                int[] input, int index)
        {
            IList actual = InitialList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromLast_WhenRemoveRangeOfElementsFromLastOfList_ListWithoutCountElementsInThisRangeFromEndReturned(
                int[] input, int count, int[] output)
        {
            IList actual = InitialList(input);
            actual.RemoveRangeFromLast(count);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, -3)]
        public void RemoveRangeFromLast_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
            int[] input, int count)
        {
            IList actual = InitialList(input); 

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromLast(count));
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromFirst_WhenRemoveRangeOfElementsFromFirstOfList_ListWithoutCountElementsInThisRangeFromBeginReturned(
                int[] input, int count, int[] output)
        {
            IList actual = InitialList(input);
            actual.RemoveRangeFromFirst(count);

            IList expected = InitialList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, -3)]
        public void RemoveRangeFromFirst_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(
            int[] input, int count)
        {
            IList actual = InitialList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromFirst(count));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 2, new[] { 1, 2, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 5, 2, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromIndex_WhenRemoveRangeOfElementsFromIndexOfList_ListWithoutCountElementsInThisRangeFromIndexReturned(
                int[] input, int index, int count, int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);

            actual.RemoveRangeFromIndex(index, count);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 2, 3)]
        [TestCase(new[] { 1, 2, 3, 5 }, 1, -1)]
        public void RemoveRangeFromIndex_WhenRangeGreaterThenLengthOrLessThen0_ArgumentExceptionReturned(int[] input,
            int index, int count)
        {
            IList actual = InitialList(input);

            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] { 1, 2, 3, 5 }, -2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 4, 1)]
        public void
            RemoveRangeFromIndex_WhenIndexLessThen0OrGreaterThatLastValueIndex_IndexOutOfRangeExceptionReturned(
                int[] input, int index, int count)
        {
            IList actual = InitialList(input);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeFromIndex(index, count));
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 5, 3)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, -1)]
        public void RemoveFirstByValue_WhenFirstValueFoundRemoveItFromList_IndexOfThatValueReturned(int[] input,
            int value, int expected)
        {
            IList list = InitialList(input);

            int actual = list.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 5, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, 0)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, 10)]
        public void RemoveAllByValue_WhenValuesFoundRemoveItFromList_CountOfThatValuesReturned(int[] input, int value,
            int expected)
        {
            IList list = InitialList(input);

            int actual = list.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 1, 1, 1 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 7, 5)]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1, 1, 2, 3, 4, 6, 7, 8 }, 9, -1)]
        public void GetFirstIndexByValue_WhenArrayListsContainValues_IndexOfFirstFoundValueReturned(int[] input,
            int value, int expected)
        {
            IList list = InitialList(input);

            int actual = list.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        [TestCase(new[] { 1, 2, 5, 3, 4 }, new[] { 4, 3, 5, 2, 1 })]
        [TestCase(new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 0 }, new[] { 0 })]
        public void Reverse_WhenArrayList_ReversedArrayListReturned(int[] input, int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 10, 5 }, 1)]
        [TestCase(new[] { 1, 10, 5, 14, 999 }, 4)]
        [TestCase(new[] { 0 }, 0)]
        public void FindIndexOfMaxValue_WhenFindListMaxValue_IndexOfMaxValueReturned(int[] input, int expected)
        {
            IList list = InitialList(input);

            int actual = list.FindIndexOfMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 10, 15 }, 15)]
        [TestCase(new[] { 1, 15, 15 }, 15)]
        [TestCase(new[] { 1, 10, 5, 1 }, 10)]
        [TestCase(new[] { 0 }, 0)]
        public void FindMaxValue_WhenArrayListHasElements_MaxValueReturned(int[] input, int expected)
        {
            IList list = InitialList(input);

            int actual = list.FindMaxValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 2)]
        public void FindIndexOfMinValue_WhenFindListMinValue_IndexOfMinValueReturned(int[] input, int expected)
        {
            IList list = InitialList(input);

            int actual = list.FindIndexOfMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new[] { 1, 2, 3, 4, 3, 7, 0 }, 0)]
        [TestCase(new[] { 55, 10, 5 }, 5)]
        public void FindMinValue_WhenArrayListHasElements_MinValueReturned(int[] input, int expected)
        {
            IList list = InitialList(input);

            int actual = list.FindMinValue();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 3, 5, 7, 8 }, false, new[] { 8, 7, 5, 3, 1 })]
        [TestCase(new[] { 8, 7, 5, 3, 1 }, false, new[] { 8, 7, 5, 3, 1 })]
        [TestCase(new[] { 1 }, false, new[] { 1 })]
        [TestCase(new[] { 1 }, true, new[] { 1 })]
        [TestCase(new[] { 1, 3, 5, 7, 8 }, true, new[] { 1, 3, 5, 7, 8 })]
        [TestCase(new[] { 8, 7, 5, 3, 1 }, true, new[] { 1, 3, 5, 7, 8 })]
        public void Sort_WhenArrayList_SortedArrayListByDescendingReturned(int[] input, bool ascending,
            int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);

            actual.Sort(ascending);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, 1, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 })]
        [TestCase(new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 }, 4, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 },
            new[] { 1, 6, 7, 8, 1, 6, 7, 8, 9, 1, 2, 3, 4, 2, 9, 1, 2, 3, 4, 2 })]
        public void AddListByIndex_WhenToListAddAnotherListByIndex_ListWithInsertedInIndexListReturned(int[] input,
            int index, int[] arrayElements, int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);
            IList listForAdd = InitialList(arrayElements);

            actual.AddListByIndex(index, listForAdd);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4, 1, 2 })]
        public void
            AddListFirst_WhenToFirstListAddAnotherListInFirstPosition_ListWithInsertedInFirstPositionListReturned(
                int[] input,
                int[] arrayElements, int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);
            IList listForAdd = InitialList(arrayElements);

            actual.AddListFirst(listForAdd);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 2, 6, 7, 8, 9, 1, 2, 3, 4 })]
        public void
            AddListLast_WhenToFirstListAddAnotherListInLastPosition_ListWithInsertedInLasttPositionListReturned(
                int[] input,
                int[] arrayElements, int[] output)
        {
            IList actual = InitialList(input);
            IList expected = InitialList(output);
            IList listForAdd = InitialList(arrayElements);

            actual.AddListLast(listForAdd);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2 }, -1, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, 3, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        public void AddListByIndex_WhenIndexLessThen0OrGreaterThenLastElementIndex_IndexOutOfRangeExceptionReturned(
        int[] input,
        int index, int[] arrayElements)
        {
            IList actual = InitialList(input);
            IList listForAdd = InitialList(arrayElements);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListByIndex(index, listForAdd));
        }
    }
}
