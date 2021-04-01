using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ListsProject.Tests
{
    class DoublyLinkedListTests
    {
        [TestCase(new[] { 1, 2, 5, 3 }, 6, new[] { 1, 2, 5, 3, 6 })]
        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 9, 11 }, 1, new[] { 1, 9, 11, 1 })]
        public void AddTests_WhenAddElementInList_ListWithNewElementInTheEndReturned(int[] input, int value,
            int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 666, new[] { 666 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 666, new[] { 666, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 0, 1, 2, 3, 4, 5 })]
        public void AddFirstTests_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int[] input,
            int value, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 1, 666, new[] { 1, 666, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 6, 666, new[] { 1, 3, 4, 5, 6, 7, 666 })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 5, 666, new[] { 1, 3, 4, 5, 6, 666, 7  })]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 0, 666, new[] { 666, 1, 3, 4, 5, 6, 7 })]
        public void AddByIndexTests_WhenAddElementByIndexInList_ListWithNewElementInTheIndexPositionReturned(
            int[] input, int index, int value, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, -1, 2)]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 7, 666)]
        public void AddByIndexTests_WhenAddElementByIndexLessThen0OrGreaterThenLength_IndexOutOfRangeExceptionReturned(
            int[] input, int index, int value)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));

        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8 }, new[] { 6, 7, 8, 1, 2 })]
        [TestCase(new[] { 1, 2 }, new int[] { }, new[] { 1, 2 })]
        [TestCase(new int[] { }, new[] { 1, 2 }, new[] { 1, 2 })]
        public void AddListFirstTests_WhenToFirstListAddAnotherListInFirstPosition_ListWithInsertedInFirstPositionListReturned(int[] input,
             int[] arrayElements, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList linkedList = new DoublyLinkedList(arrayElements);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.AddListFirst(linkedList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 2, 6, 7, 8, 9, 1, 2, 3, 4 })]
        public void
            AddListLastTests_WhenToFirstListAddAnotherListInLastPosition_ListWithInsertedInLasttPositionListReturned(
                int[] input,
                int[] arrayElements, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList arrayList = new DoublyLinkedList(arrayElements);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.AddListLast(arrayList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 }, 0, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1 })]
        [TestCase(new int[] { 1 }, 1, new[] { 6, 7, 8, 9 }, new[] { 1, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new int[] { }, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 6, 7, 8, 9 }, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2 }, 1, new[] { 6, 7, 8, 9, 1, 2, 3, 4 }, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 })]
        [TestCase(new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 }, 4, new[] { 1, 6, 7, 8, 9, 1, 2, 3, 4, 2 }, new[] { 1, 6, 7, 8, 1, 6, 7, 8, 9, 1, 2, 3, 4, 2, 9, 1, 2, 3, 4, 2 })]
        public void AddListByIndexTests_WhenToListAddAnotherListByIndex_ListWithInsertedInIndexListReturned(int[] input,
             int index, int[] arrayElements, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList arrayList = new DoublyLinkedList(arrayElements);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.AddListByIndex(index, arrayList);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 2, 3, 4 }, -1, new[] { 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2 }, 3, new[] { 6, 7, 8, 9, 1, 2, 3, 4 })]
        public void AddListByIndexTests_WhenIndexLessThen0OrGreaterThenLength_IndexOutOfRangeExceptionReturned(int[] input,
            int index, int[] arrayElements)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList arrayList = new DoublyLinkedList(arrayElements);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListByIndex(index, arrayList));

        }
        [TestCase(new[] { 1, 1, 1, 1 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 6, 7, 8 }, 7, 5)]
        [TestCase(new[] { 1 }, 1, 0)]
        [TestCase(new[] { 1, 1, 2, 3, 4, 6, 7, 8 }, 9, -1)]
        public void GetFirstIndexByValueTests_WhensingleLinkedListsContainValues_IndexOfFirstFoundValueReturned(int[] input,
            int value, int expected)
        {
            DoublyLinkedList singleLinkedList = new DoublyLinkedList(input);

            int actual = singleLinkedList.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4 })]
        [TestCase(new[] { 3, 4 }, new[] { 4 })]
        [TestCase(new[] { 4 }, new int[] { })]
        public void RemoveFirstTests_WhenRemoveFirstElementInList_ListWithoutElementInFirstPositionReturned(int[] input,
            int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 1 }, new int[] { })]
        public void RemoveLastTests_WhenRemoveLastElementInList_ListWithoutElementInLastPositionReturned(int[] input,
            int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 4 }, 3, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2, 4 })]
        public void RemoveByIndexTests_WhenRemoveElementByIndexInList_ListWithoutElementInTheIndexPositionReturned(
            int[] input, int index, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, -1)]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 7)]
        public void RemoveByIndexTests_WhenRemoveElementByIndexLessThen0OrGreaterThenLength_IndexOutOfRangeExceptionReturned(
            int[] input, int index)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));

        }

        [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromLastTests_WhenRemoveRangeOfElementsFromLastOfList_ListWithoutCountElementsInThisRangeFromEndReturned(
                int[] input, int count, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveRangeFromLast(count);

            Assert.AreEqual(expected, actual);
        }
        public void RemoveRangeFromLastTests_WhenRemoveMoreThenLengthOrLessThen0ElementsFromLast_ArgumentExceptionReturned(
            int[] input, int count)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromLast(count));

        }

        [TestCase(new[] {1, 2, 3, 4}, 2, new[] {3, 4})]
        [TestCase(new[] {1, 2, 3, 4, 6, 5, 4, 2, 1, 4, 5, 1, 2, 6}, 7, new[] { 2, 1, 4, 5, 1, 2, 6 })]
        [TestCase(new[] {1, 2, 3, 4}, 4, new int[] { })]
        [TestCase(new[] {1, 2, 3, 4}, 0, new[] {1, 2, 3, 4})]
        public void
            RemoveRangeFromFirstTests_WhenRemoveRangeOfElementsFromFirstOfList_ListWithoutCountElementsInThisRangeFromBeginReturned(
                int[] input, int count, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveRangeFromFirst(count);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 7)]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, -7)]
        public void RemoveRangeFromFirstTests_WhenRemoveMoreThenLengthOrLessThen0ElementsFromLast_ArgumentExceptionReturned(
            int[] input, int count)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromFirst(count));

        }
        [TestCase(new[] { 1, 10, 5 }, new[] { 1, 10 })]
        [TestCase(new[] { 1, 10, 5, 14, 999 }, new[] { 4, 999 })]
        [TestCase(new[] { 0 }, new[] { 0, 0 })]
        public void FindMaxValueAndItIndexTests_WhenFindListMaxValue_IndexOfMaxValueReturned(int[] input, int[] expected)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(input);
            int[] actual = linkedList.FindMaxValueAndItIndex();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new[] { 4, 1, 15 }, new[] { 1, 1 })]
        [TestCase(new[] { 1, 15, 0 }, new[] { 2, 0 })]
        [TestCase(new[] { 1, 10, 5, 1 }, new[] { 0, 1 })]
        [TestCase(new[] { 0 }, new[] { 0, 0 })]

        public void FindMinValueAndItIndexTests_WhensingleLinkedListHasElements_MaxValueReturned(int[] input, int[] expected)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(input);
            int[] actual = linkedList.FindMinValueAndItIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3, 5 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 5 }, 5, 3)]
        [TestCase(new[] { 1, 2, 2, 5 }, 2, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 3, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, -1)]
        public void RemoveFirstByValueTests_WhenFirstValueFoundRemoveItFromList_IndexOfThatValueReturned(int[] input,
            int value, int expected)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(input);

            int actual = linkedList.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3, 5 }, 5, 1)]
        [TestCase(new[] { 1, 2, 3, 2 }, 2, 2)]
        [TestCase(new[] { 1, 2, 3, 5 }, 7, 0)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, 10)]
        public void RemoveAllByValueTests_WhenValuesFoundRemoveItFromList_CountOfThatValuesReturned(int[] input,
            int value,
            int expected)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(input);

            int actual = linkedList.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 2, new[] { 1, 2, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 5, 2, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, 4, new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4 }, 0, 2, new int[] { 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4 }, 3, 0, new[] { 1, 2, 3, 4 })]
        public void
            RemoveRangeFromIndexTests_WhenRemoveRangeOfElementsFromIndexOfList_ListWithoutCountElementsInThisRangeFromIndexReturned(
                int[] input, int index, int count, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);

            actual.RemoveRangeFromIndex(index, count);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 3, 5)]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 5, -1)]
        public void RemoveRangeFromIndexTests_WhenRemoveMoreThenLengthOrLessThen0ElementsFromLast_ArgumentExceptionReturned(
            int[] input, int index, int count)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<ArgumentException>(() => actual.RemoveRangeFromIndex(index, count));

        }
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, 7, 2)]
        [TestCase(new[] { 1, 3, 4, 5, 6, 7 }, -7, 5)]
        public void RemoveRangeFromIndexTests_WhenRemoveElementsFromIndexLessThen0OrGreaterThenLengthFromLast_IndexOutOfRangeExceptionReturned(
            int[] input, int index, int count)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);


            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveRangeFromIndex(index, count));

        }
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        [TestCase(new[] { 1, 2, 5, 3, 4 }, new[] { 4, 3, 5, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new[] { 0 }, new[] { 0 })]
        public void ReverseTests_WhenArrayList_ReversedArrayListReturned(int[] input, int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            actual.Reverse();
            DoublyLinkedList expected = new DoublyLinkedList(output);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 3, 5, 7, 8 }, false, new[] { 8, 7, 5, 3, 1 })]
        [TestCase(new[] { 8, 7, 5, 3, 1 }, false, new[] { 8, 7, 5, 3, 1 })]
        [TestCase(new[] { 1 }, false, new[] { 1 })]
        [TestCase(new[] { 1 }, true, new[] { 1 })]
        [TestCase(new[] { 1, 3, 5, 7, 8 }, true, new[] { 1, 3, 5, 7, 8 })]
        [TestCase(new[] { 8, 7, 5, 3, 1 }, true, new[] { 1, 3, 5, 7, 8 })]

        public void SortTests_WhenArrayList_SortedArrayListByDescendingReturned(int[] input, bool ascending,
            int[] output)
        {
            DoublyLinkedList actual = new DoublyLinkedList(input);
            DoublyLinkedList expected = new DoublyLinkedList(output);
            actual.Sort(ascending);

            Assert.AreEqual(expected, actual);
        }
        //TODO: Add negative tests and send pull request to Sviatoslav
    }
}
