using System;
using ListsProject;

namespace ListsProjectManualTests
{
    class Program
    {
        static void Main()
        {
            SingleLinkedList lis1 = new SingleLinkedList(new int[] { 1,2,3,4,54,6,42,3,423,5634,2,2});

            Console.WriteLine(lis1.ToString());

        }

    }
}
