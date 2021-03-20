using System;
using ListsProject;

namespace ArrayListManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList(new int[] {0, 1, 2, 3, 4, 2, 6, 7 , 2, 9, 10 });
            Console.WriteLine(arrList.GetLength());


            arrList.Print();

            Console.WriteLine(arrList.RemoveAllByValue(2));
            //arrList.RemoveRangeFromFirst(8);
            
            arrList.Print();
        }
    }
}
