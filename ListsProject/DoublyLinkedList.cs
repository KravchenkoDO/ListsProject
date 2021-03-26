using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    class DoublyLinkedList
    {
        private int _length;
        private DLNode _head; 
        private DLNode _tail; 

        public bool Empty
        {
            get { return this._length == 0; }
        }

        public int Count
        {
            get { return this._length; }
        }

        public DoublyLinkedList()
        {
            _length = 0;
            _head = null;
            _tail = null;
        }

        public DoublyLinkedList(int value)
        {
            _length = 1;
            _head = new DLNode(value);
            _tail = _head;
        }

        public void AddFirst(int value)
        {
            DLNode newNode = new DLNode(value);

            newNode.Next = _head;
            newNode.Prev = null;

            if (!(_head is null))
            {
                _head.Prev = newNode;
            }

            _head = newNode;
        }

        private DLNode GetDLNodeByIndex(int index)
        {
            if (index < 0 || index >= this._length || this.Empty)
            {
                throw new IndexOutOfRangeException();
            }

            DLNode tmp = _head;
            int count = 0;

            while (!(tmp is null))
            {
                if (count == index)
                {
                    return tmp;
                }
                count++;
                tmp = tmp.Next;
            }
            

            return tmp;

        }

    }
}
