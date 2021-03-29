using System;


namespace ListsProject
{
    public class SingleLinkedList
    {
        private int _length;
        private Node _head; 
        private Node _tail; 

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
                return GetNodeByIndex(index).Data;
            }
            set
            {
                GetNodeByIndex(index).Data = value;
            }
        }

        public SingleLinkedList()
        {
            ListIsEmpty();
        }

        public SingleLinkedList(int value)
        {
            AddInEmpty(value);
        }

        public SingleLinkedList(int[] values)
        {

            if (values.Length != 0)
            {
                _length = values.Length;
                _head = new Node(values[0]);
                _tail = _head;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
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
            _head = new Node(value);
            _tail = _head;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this._length || this.Empty)
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _head;

            for (int i = 0; i < index; i++)
            {
                tmp = tmp.Next;
            }

            return tmp;

        }

        public void Add(int value)
        {
            if (this.Empty)
            {
                AddInEmpty(value);
            }
            else
            {
                _length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
        }

        public void AddFirst(int value)
        {
            if (Empty)
            {
                AddInEmpty(value);
            }
            else
            {
                _length++;
                Node tmp = new Node(value);
                tmp.Next = this._head;
                _head = tmp;
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
                this.AddFirst(value);
            }
            else
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                current.Next = tmp;
                _length++;
            }
        }

        public void RemoveFirst()
        {
            _head = _head.Next;
            _length--;
        }

        public void RemoveLast()
        {
            RemoveByIndex(_length - 1);
        }

        public void RemoveByIndex(int index)
        {
            if (index == 0)
            {
                this.RemoveFirst();
            }
            else
            {
                Node tmp = this.GetNodeByIndex(index - 1);

                tmp.Next = tmp.Next.Next;
                _length--;

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
            else
            {
                int index = _length - 1 - count;
                Node newTail = GetNodeByIndex(index);
                newTail.Next = null;
                _tail = newTail;
                _length = _length - count;
            }
        }

        public void RemoveRangeFromFirst(int count)
        {
            if (count > _length || count < 0)
            {
                throw new ArgumentException($"You try to remove more elements than you have in list!");
            }

            if (count != 0)
            {
                int index = count - 1;
                Node tmp = GetNodeByIndex(index - 1);

                _head = tmp.Next.Next;
                tmp.Next = null;
                _length -= count;
            }
        }

        public void RemoveRangeFromIndex(int index, int count)
        {
            if (index < 0 || index > this._length || this.Empty)
            {
                throw new IndexOutOfRangeException();
            }
            if (index + count > _length || count < 0)
            {
                throw new ArgumentException("You try to remove more elements than you have in list!");
            }
            if (index == 0)
            {
                RemoveRangeFromFirst(count);
            }
            else
            {
                Node from = null;
                Node to = _head;

                for (int i = 0; i < index + count; i++)
                {
                    if (i == index - 1)
                    {
                        from = to;
                    }
                    to = to.Next;
                }

                from.Next = to;

                if (index + count == _length)
                {
                    _tail = to;
                }

                _length -= count;
            }

        }

        public override string ToString()
        {

            if (this.Empty)
            {
                return String.Empty;
            }
            Node tmp = _head;

            string s = "|" + tmp.Data + "|=>";

            while (!(tmp.Next is null))
            {
                tmp = tmp.Next;
                s += "|" + tmp.Data + "|=>";
            }
            return s;
        }

        public int GetFirstIndexByValue(int value)
        {

            if (Empty)
            {
                return -1;
            }
            Node tmp = _head;

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

        public override bool Equals(object obj)
        {
            SingleLinkedList outcomeList = (SingleLinkedList)obj;


            if (this._length != outcomeList._length)
            {
                return false;
            }

            Node current = this._head;
            Node outcome = outcomeList._head;
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

        public int[] FindMaxValueAndItIndex()
        {
            Node tmp = _head;
            int[] result = new int[2];
            int maxValueIndex = 0;
            int maxValue = tmp.Data;
            for (int i = 0; i < _length; i++)
            {
                if (tmp.Data > maxValue)
                {
                    maxValueIndex = i;
                    maxValue = tmp.Data;
                }

                tmp = tmp.Next;
            }

            result[0] = maxValueIndex;
            result[1] = maxValue;

            return result;
        }

        public int[] FindMinValueAndItIndex()
        {
            Node tmp = _head;
            int[] result = new int[2];
            int minValueIndex = 0;
            int minValue = tmp.Data;
            for (int i = 0; i < _length; i++)
            {
                if (tmp.Data < minValue)
                {
                    minValueIndex = i;
                    minValue = tmp.Data;
                }

                tmp = tmp.Next;
            }

            result[0] = minValueIndex;
            result[1] = minValue;

            return result;
        }

        public int RemoveFirstByValue(int value)
        {
            Node tmp = _head;
            int index = -1;
            if (tmp.Data == value)
            {
                RemoveFirst();
                return 0;

            }

            for (int i = 1; i < _length; i++)
            {
                if (tmp.Next.Data == value)
                {

                    if (_tail != tmp.Next)
                    {
                        tmp.Next = tmp.Next.Next;
                        index = i;
                        _length--;
                        break;
                    }
                    else
                    {
                        tmp.Next = null;
                        _tail = tmp;
                        index = i;
                        _length--;
                    }
                }

                tmp = tmp.Next;
            }

            return index;
        }



        public int RemoveAllByValue(int value)
        {
            int count = 0;
            Node tmp;
            Node current = _head;

            while (!(current is null) && current.Data == value)
            {
                RemoveFirst();
                current = _head;
                count++;
            }

            while (!(current is null))
            {
                tmp = current;
                if (current.Data == value && current != _tail)
                {
                    tmp.Next = current.Next;
                    current = current.Next;
                    count++;
                    _length--;
                }
                if (current == _tail && current.Data == value)
                {
                    tmp.Next = null;
                    _tail = tmp;
                    count++;
                    _length--;
                }
                current = tmp.Next;
            }
                return count;
        }

        public void AddListLast(SingleLinkedList linkedList)
        {

            this._tail.Next = linkedList._head;
            this._tail = linkedList._tail;
            this._length += linkedList._length;
        }
        public void AddListFirst(SingleLinkedList linkedList)
        {
            if (!(linkedList.Empty))
            {
                if (this.Empty)
                {
                    this._head = linkedList._head;
                }
                else
                {
                Node tmp = this._head;

                this._head = linkedList._head;
                linkedList._tail.Next = tmp;
                linkedList._tail = this._tail;
                }

                this._length += linkedList._length;
            }
        }

        public void AddListByIndex(int index, SingleLinkedList linkedList)
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
                Node tmp = GetNodeByIndex(index - 1);
                linkedList._tail.Next = tmp.Next;
                tmp.Next = linkedList._head;
                this._length += linkedList._length;
            }

        }

        public void Reverse()
        {
            if (!(this.Empty))
            { 
            Node previousNode = null;
            Node currentNode = this._head;
            Node nextNode = null;

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

        public void Sort(bool ascending)
        {

            Node sorted = null;
            Node current = _head;

            while (current != null)
            {
                
                Node next = current.Next;
                
                sortedInsert(current);
                
                current = next;
            }

            _head = sorted;

            void sortedInsert(Node newnode)
            {

                if (ascending)
                {
                    if (sorted == null || sorted.Data >= newnode.Data)
                    {
                        newnode.Next = sorted;
                        sorted = newnode;
                    }
                    else
                    {
                        Node current = sorted;

                        while (current.Next != null &&
                               current.Next.Data < newnode.Data)
                        {
                            current = current.Next;
                        }

                        newnode.Next = current.Next;
                        current.Next = newnode;
                    }
                }
                else
                {
                    if (sorted == null || sorted.Data <= newnode.Data)
                    {
                        newnode.Next = sorted;
                        sorted = newnode;
                    }
                    else
                    {
                        Node current = sorted;

                        while (current.Next != null &&
                               current.Next.Data > newnode.Data)
                        {
                            current = current.Next;
                        }

                        newnode.Next = current.Next;
                        current.Next = newnode;
                    }

                }
            }
        }
    }
}


