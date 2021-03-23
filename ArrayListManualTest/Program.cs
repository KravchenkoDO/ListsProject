using System;
using ListsProject;

namespace ListsProjectManualTests
{
    class Program
    {
        static void Main()
        {
            SingleLinkedList lis1 = new SingleLinkedList(new [] {0,1,2,3,4,555,6,7,8 });
            lis1[0] = 12;
            lis1[8] = 888;
            Console.WriteLine(lis1.GetNodeByIndex(5).Data);
            if (lis1.GetNodeByIndex(8).Next is null)
                Console.WriteLine("It Is NULL");
            Console.WriteLine(lis1.GetNodeByIndex(5).Next.Next.Data);
            Console.WriteLine(lis1.GetNodeByIndex(8).Next);
            int a = lis1.Count;
            Console.WriteLine(a);

            Console.WriteLine(lis1.ToString());
        }

    }
}
