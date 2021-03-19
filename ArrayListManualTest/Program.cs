using System;
using ListsProject;

namespace ArrayListManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 2 , 8, 9, 10 });
            Console.WriteLine(arrList.GetLength());


            arrList.Print();

            Console.WriteLine(arrList.GetFirstIndexByValue(2));
            
            arrList.Print();
        }
    }
}
