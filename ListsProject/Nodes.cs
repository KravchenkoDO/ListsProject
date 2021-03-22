using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    public class Node
    {
        public int data;
        public Node next;

        public Node ()
        {
            data = 0;
            next = null;
        }
        public Node (int i)
        {
            data = i;

            next = null;
        }

        public void Print()
        {
            Console.Write("|" + data + "|=>");
            if (next != null)
            {
                next.Print();
            }
        }

        public void AddToEnd(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }

        public void setNextNode (Node node)
        {

        }
    }
}
