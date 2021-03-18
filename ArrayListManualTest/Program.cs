using System;
using ListsProject;

namespace ArrayListManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList(new int [] {1,2,3,4,5,6,7,8,9});
            Console.WriteLine(arrList.GetLength());
            arrList.Print();

            arrList.MoveElements(5, 1);
            Console.WriteLine(arrList.GetLength());
            arrList.Print();
            

        }
    }
}
