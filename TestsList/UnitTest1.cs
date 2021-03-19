using NUnit.Framework;
using ListsProject;
using System;

namespace TestsList
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        // len 
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 7)]
        [TestCase(new int[] {1}, 1)]
        public void GetLenght_WhenArrayListsHasElements_LenghtOfListReturned(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual); 
            int length = a.GetLength();
            Assert.AreEqual(length, expected);
        }

        //[Theory]
        //public void GetLenght_WhenArrayLists_Exeptions()
        //{
        //    ArrayList actua = new ArrayList(new int[] { });
        //    Assert.Throws<ArgumentException>(() => actua.GetLength());
        //}


        // index 
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4,  3)]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 7, 5)]
        [TestCase(new int[] { 1 }, 1, 0)]
        public void GetFirstIndexByValue_WhenArrayLists_FirstIndexByValu(int[] actual, int value, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int index = a.GetFirstIndexByValue(value);
            Assert.AreEqual(index, expected);
        }

        // revers
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, new int[] { 8, 7, 6, 4, 3, 2, 1})]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void Reverse_WhenArrayLists_ReverseList(int[] a, int[] expected)
        {

        }

        // max index 
        [Theory]
        [TestCase(new int[] { 1, 10, 5 }, 1)]
        public void FindIndexOfMaxValue_WhenArrayLists_IntOfIndexOfMaxValue(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int index = a.FindIndexOfMaxValue();
            Assert.AreEqual(index, expected);
        }

        // min index 
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 55, 10, 5 }, 2)]
        public void FindIndexOfMinValue_WhenArrayLists_IntOfIndexOfMinValue(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int index = a.FindIndexOfMinValue();
            Assert.AreEqual(index, expected);
        }

        // max value 
        [Theory]
        [TestCase(new int[] { 1, 10, 5 }, 10)]
        [TestCase(new int[] { 1, 15, 15 }, 15)]
        [TestCase(new int[] { 1, 10, 5, 1}, 10)]
        public void FindMaxValu_WhenArrayLists_IntOfMaxValu(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int value = a.FindMaxValue();
            Assert.AreEqual(value, expected);
        }

        // min value
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 0)]
        [TestCase(new int[] { 55, 10, 5 }, 2)]
        public void FindMinValue_WhenArrayLists_IntOfMinValue(int[] actual, int expected)
        {
            ArrayList a = new ArrayList(actual);
            int value = a.FindIndexOfMinValue();
            Assert.AreEqual(value, expected);
        }

        // sort 1..10
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 7, 8, 4,3}, new int[] { 1, 2, 3, 3, 4, 7, 8 })]
        [TestCase(new int[] { 1, 0, 10}, new int[] { 0, 1, 10})]
        public void Sort_WhenArrayLists_Sort1_10(int[] actual, int[] expected)
        {
            ArrayList a = new ArrayList(actual);
            bool ascending = true;
            int[] array = a.Sort(ascending);
            Assert.AreEqual(array, expected);
        }

        // sort 10..1
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, new int[] { 8, 7, 6, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void sortt_WhenArrayLists_sortList10_1(int[] actual, int[] expected)
        {
            ArrayList a = new ArrayList(actual);
            bool ascending = false;
            int[] array = a.Sort(ascending);
            Assert.AreEqual(array, expected);
        }

        // add last
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 10, new int[] { 1, 2, 3, 4, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 5, new int[] { 1,2,3,4,6,7,8,5})]
        [TestCase(new int[] { 1 }, 5, new int[] { 1, 5 })]
        public void Addlast_WhenArrayLists_NewList(int[] actual, int value, int[] expected)
        { 
            ArrayList a = new ArrayList(actual);
            ArrayList b = new ArrayList(expected);
            a.Add(value);
            Assert.AreEqual(b, a);
        }

        // add first
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 10, new int[] { 10, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 5, new int[] { 5, 1, 2, 3, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1 }, 5, new int[] { 5, 1 })]
        public void Addfirst_WhenArrayLists_NewList(int[] actual, int value, int[] expected)
        {
            ArrayList a = new ArrayList(actual);
            ArrayList b = new ArrayList(expected);
            a.AddFirst(value);
            Assert.AreEqual(b, a);
        }

        // add by index
        [Theory]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 10, new int[] { 1, 10, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 3, 5, new int[] { 1, 2, 3, 5, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1 }, 1, 5, new int[] { 1, 5 })]
        public void AddValueByIndex_WhenArrayLists_NewList(int[] actual, int index, int value, int[] expected)
        {
            ArrayList a = new ArrayList(actual);
            ArrayList b = new ArrayList(expected);
            a.AddByIndex(index, value);
            Assert.AreEqual(b, a);
        }

    }
}