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
            for (int i = 0; i < 4; i++)
            {
                arList.Add(random.Next(10, 21));
                
            }
            arList.Print();
            Console.WriteLine(arList.Count());
            arList.AddFirst(125);
            Console.WriteLine(arList.Count());
            arList.Print();
            arList.Insert(3,999);
            Console.WriteLine(arList.Count());
            arList.Print();
        }
    }
}
