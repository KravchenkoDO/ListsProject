using System;
using ListsProject;

namespace ListsProjectManualTests
{
    class Program
    {
        static void Main()
        {
            Node firstNode = new Node(4);
            firstNode.AddToEnd(11);
            firstNode.AddToEnd(15);
            firstNode.AddToEnd(1);
            firstNode.Print();

        }
    }
}
