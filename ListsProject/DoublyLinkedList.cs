using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    public class DoublyLinkedList
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
        public int this[int index]
        {
            get
            {
                return GetDLNodeByIndex(index).Data;
            }
            set
            {
                GetDLNodeByIndex(index).Data = value;
            }
        }
        public DoublyLinkedList()
        {
            ListIsEmpty();
        }
        public DoublyLinkedList(int value)
        {
            AddInEmpty(value);
        }
        public DoublyLinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                _length = values.Length;
                _head = new DLNode(values[0]);
                _tail = _head;

                for (int i = 1; i < values.Length; i++)
                {
                    DLNode tmp = new DLNode(values[i]);
                    _tail.Next = tmp;
                    tmp.Prev = _tail;
                    _tail = tmp;
                    _tail.Next = null;
                }
            }
            else
            {
                ListIsEmpty();
            }
        }
        private void ListIsEmpty()
        {
            _length = 0;
            _head = null;
            _tail = null;
        }
        private void AddInEmpty(int value)
        {
            _length = 1;
            _head = new DLNode(value);
            _tail = _head;
        }

        public void Add(int value)
        {
            if (this.Empty)
            {
                AddInEmpty(value);
            }
            else
            {

                DLNode newNode = new DLNode(value);
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
                _length++;
            }
        }

        public void AddFirst(int value)
        {
            if (this.Empty)
            {
                AddInEmpty(value);
            }
            else
            {
                DLNode newNode = new DLNode(value);
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                _length++;
            }
        }
        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > this._length || this.Empty)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == _length)
            {
                Add(value);
            }
            else
            {
                DLNode current = GetDLNodeByIndex(index - 1);
                DLNode tmp = new DLNode(value);
                tmp.Next = current.Next;
                tmp.Prev = current;
                current.Next = tmp;
                current.Next.Prev = tmp;
                _length++;
            }
        }
        private DLNode GetDLNodeByIndex(int index)
        {
            if (index < 0 || index >= this._length || this.Empty)
            {
                throw new IndexOutOfRangeException();
            }

            DLNode tmp;
            int count;

            if (index <= this._length / 2 + 1)
            {
                count = 0;
                tmp = _head;
                while (!(tmp is null))
                {
                    if (count == index)
                    {
                        return tmp;
                    }

                    count++;
                    tmp = tmp.Next;
                }
            }
            else
            {
                count = _length-1;
                tmp = _tail;
                while (!(tmp is null))
                {
                    if (count == index)
                    {
                        return tmp;
                    }

                    count--;
                    tmp = tmp.Prev;
                }
            }
            return tmp;
        }
        public override bool Equals(object obj)
        {
            DoublyLinkedList outcomeList = (DoublyLinkedList)obj;


            if (this._length != outcomeList._length)
            {
                return false;
            }

            DLNode current = this._head;
            DLNode outcome = outcomeList._head;
            if (this.Empty && current == outcome)
            {
                return true;
            }
            if (this._length == 1 && current.Data == outcome.Data)
            {
                return true;
            }

            do
            {
                if (current.Data != outcome.Data)
                {
                    return false;
                }
                current = current.Next;
                outcome = outcome.Next;
            }
            while (!(current.Next is null));

            return true;
        }

        public override string ToString()
        {

            if (this.Empty)
            {
                return String.Empty;
            }
            DLNode tmp = _head;

            string s = "|" + tmp.Data + "|<=>";

            while (!(tmp.Next is null))
            {
                tmp = tmp.Next;
                s += "|" + tmp.Data + "|<=>";
            }
            return s;
        }

        public void AddListLast(DoublyLinkedList linkedList)
        {
            _tail.Next = linkedList._head;
            linkedList._head.Prev = _tail;
            _tail = linkedList._tail;
            _length += linkedList._length;
        }
        public void AddListFirst(DoublyLinkedList linkedList) //UNDONE: fail when want to add into empty list
        {            
            if(!(linkedList.Empty))
            {
                if (this.Empty)
                {
                    _head = linkedList._head;
                    _tail = linkedList._tail;
                }
                else
                {
                linkedList._tail.Next = _head;
                _head.Prev = linkedList._tail;
                _head = linkedList._head;
                _tail = linkedList._tail;
                }

                this._length += linkedList._length;
            }
        }

        public void AddListByIndex(int index, DoublyLinkedList linkedList)//UNDONE: fail when want to add into empty list
        {
            if (index < 0 || index > this._length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddListFirst(linkedList);
            }
            else if (index == this._length)
            {
                AddListLast(linkedList);
            }
            else if (this.Empty)
            {
                linkedList.ToString();
            }
            else
            {
                DLNode tmp = GetDLNodeByIndex(index - 1);
                linkedList._tail.Next = tmp.Next;
                tmp.Prev = linkedList._tail;
                tmp.Next = linkedList._head;
                linkedList._head.Prev = tmp;
                this._length += linkedList._length;
            }
        }

        public void RemoveFirst()
        {
            if (!(_length == 1) && !Empty)
            {
            _head = _head.Next;
            _length--;
            }
            else
            {
                ListIsEmpty();
            }
        }
        public void RemoveLast()
        {
            if (!(_length == 1) && !Empty)
            {
                _tail = _tail.Prev;
                _tail.Next = null;
                _length--;
            }
            else
            {
                ListIsEmpty();
            }

        }
        public void RemoveRangeFromLast(int count)
        {
            if (count > _length || count < 0)
            {
                throw new ArgumentException("You try to remove more elements than you have in list");
            }
            if (count == _length)
            {
                ListIsEmpty();
            }
            else if (count != 0)
            {
                int index = _length - 1 - count;
                DLNode newTail = GetDLNodeByIndex(index);
                _tail = newTail;
                _length = _length - count;
            }
        }

        public void RemoveRangeFromFirst(int count)
        {
            if (count > _length || count < 0)
            {
                throw new ArgumentException("You try to remove more elements than you have in list!");
            }

            if (count != 0)
            {
                int index = count - 1;
                DLNode tmp = GetDLNodeByIndex(index - 1);

                _head = tmp.Next.Next;
                tmp.Next = null;
                _length -= count;
            }
        }

        //public void RemoveRangeFromIndex(int index, int count)
        //{
        //    if (index < 0 || index > this._length || this.Empty)
        //    {
        //        throw new IndexOutOfRangeException();
        //    }

        //    if (index + count > _length || count < 0)
        //    {
        //        throw new ArgumentException("You try to remove more elements than you have in list!");
        //    }

        //    if (index == 0)
        //    {
        //        RemoveRangeFromFirst(count);
        //    }

        //    if (count !=0)
        //    {
        //        DLNode from = null;
        //        DLNode to = _head;

        //        for (int i = 0; i < index + count; i++)
        //        {
        //            if (i == index - 1)
        //            {
        //                from = to;
        //            }
        //            to = to.Next;
        //        }

        //        from.Next = to;

        //        if (index + count == _length)
        //        {
        //            _tail = to;
        //        }

        //        _length -= count;
        //    }

        //}
       
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > this._length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                this.RemoveFirst();
            }
            else if (index == this._length)
            {
                RemoveLast();
            }
            else
            {

                DLNode tmp = GetDLNodeByIndex(index - 1);
                if (!(tmp.Next.Next is null))
                {
                tmp.Next.Next.Prev = tmp;
                tmp.Next = tmp.Next.Next;
                _length--;
                }
                else
                {
                    tmp.Next = null;
                    _length--;
                }
            }
        }
        public int GetFirstIndexByValue(int value)
        {

            if (Empty)
            {
                return -1;
            }
            DLNode tmp = _head;

            for (int i = 0; i < _length; i++)
            {
                if (tmp.Data == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }

            return -1;
        }

        public void Reverse()
        {
            if (!(this.Empty))
            {
                DLNode previousNode = null;
                DLNode currentNode = this._head;
                DLNode nextNode = null;

                while (currentNode != null)
                {
                    nextNode = currentNode.Next;
                    currentNode.Next = previousNode;
                    previousNode = currentNode;
                    currentNode = nextNode;
                }
                _head = previousNode;
            }
        }
    }
}
