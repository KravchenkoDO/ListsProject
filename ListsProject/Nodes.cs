using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    public class Node
    {
        public int Data;

        public Node Next;

        public Node()
        {
            Data = 0;
            Next = null;
        }
        public Node(int value)
        {
            Data = value;
            Next = null;
        }
    }
}
