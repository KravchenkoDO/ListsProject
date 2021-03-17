using System;
using ListsProject;

namespace ArrayListManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            MyArrayList arList = new MyArrayList();
            Console.WriteLine(arList.Length);
            for (int i = 0; i < 4; i++)
            {
                arList.Add(random.Next(10, 21));
                
            }
            Console.WriteLine(arList.Length);
            arList.Print();
            arList.AddFirst(125);
            arList.Print();
            arList.Insert(3,999);
            arList.Print();
        }
    }
}
