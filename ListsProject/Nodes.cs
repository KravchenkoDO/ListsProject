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

    public class DLNode
    {
        public int Data { get; set; }
        public DLNode Prev { get; set; }
        public DLNode Next { get; set; }

        public DLNode(int value)
        {
            Data = value;
            Next = null;
            Prev = null;
        }
    }
}
