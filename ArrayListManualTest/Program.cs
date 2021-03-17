using System;
using ListsProject;

namespace ArrayListManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList(new int [] {1,2,3,4,5,3,6,7,8,9});
            Console.WriteLine(arrList.GetLength());
            arrList.Print();

            arrList.Add(999);
            Console.WriteLine(arrList.GetLength());
            arrList.Print();
            
            arrList.AddFirst(123);
            Console.WriteLine(arrList.GetLength());
            arrList.Print();

            arrList.AddByIndex(4, 666);
            Console.WriteLine(arrList.GetLength());
            arrList.Print();

            arrList.Reverse();
            arrList.Print();

            arrList.Sort(true);
            arrList.Print();

            arrList.RemoveFirstByValue(3);
            arrList.Print();

        }
    }
}
