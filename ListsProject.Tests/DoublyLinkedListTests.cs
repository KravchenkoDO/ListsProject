using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ListsProject.Tests
{
    class DoublyLinkedListTests
    {
        [TestCase(666, 666)]
        
        public void AddFirstTests_WhenAddFirstElementInList_ListWithNewElementInTheFirstPositionReturned(int value, int expectedVal)
        {
            SingleLinkedList actual = new SingleLinkedList();
            SingleLinkedList expected = new SingleLinkedList(expectedVal);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }
    }
}
