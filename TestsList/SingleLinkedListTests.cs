using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ListsProject.Tests
{
    class SingleLinkedListTests
    {
        [TestCase(new int [] {1,2,3,5}, new int[] { 1, 2,3,5})]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void EaqualsTests_WhenOurListLengthAndElementsEaqualToOutcomeListLengthAndElements_TrueReturned(int[] input, int[] output)
        {
            SingleLinkedList actual = new SingleLinkedList(input);
            SingleLinkedList expected = new SingleLinkedList(output);

            Assert.AreEqual(expected, actual);
        }
    }
}
