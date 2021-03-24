using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Data = value;
            Next = null;
        }
    }
}
