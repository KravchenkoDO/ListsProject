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
            get { return GetDLNodeByIndex(index).Data; }
            set { GetDLNodeByIndex(index).Data = value; }
        }

        public DoublyLinkedList()
        {
            InitializeEmptyList();
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
                InitializeEmptyList();
            }
        }

        private void InitializeEmptyList()
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
                current.Next.Prev = tmp;
                current.Next = tmp;
                tmp.Prev = current;
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

            if (index <= this._length / 2 + 1) //UNDONE: make this part of code without if\else
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
                count = _length - 1;
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
            if (obj != null)
            {
                DoublyLinkedList outcomeList = (DoublyLinkedList) obj;
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
                } while (!(current.Next is null));

                current = this._tail;
                outcome = outcomeList._tail;
                do
                {
                    if (current.Data != outcome.Data)
                    {
                        return false;
                    }

                    current = current.Prev;
                    outcome = outcome.Prev;
                } while (!(current.Prev is null));

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (this.Empty)
            {
                return string.Empty;
            }

            DLNode tmp = _head;
            StringBuilder sb = new StringBuilder("| ");
            sb.Append(Convert.ToString(tmp.Data));
            sb.Append(" |<=>");

            while (!(tmp.Next is null))
            {
                tmp = tmp.Next;
                sb.Append("| ");
                sb.Append(Convert.ToString(tmp.Data));
                sb.Append(" |<=>");
            }

            return Convert.ToString(sb);
        }

        public void AddListLast(DoublyLinkedList linkedList)
        {
            _tail.Next = linkedList._head;
            linkedList._head.Prev = _tail;
            _tail = linkedList._tail;
            _length += linkedList._length;
        }

        public void AddListFirst(DoublyLinkedList linkedList)
        {
            if (!(linkedList.Empty))
            {
                if (this.Empty)
                {
                    _head = linkedList._head;
                    _tail = linkedList._tail;
                }
                else
                {
                    _head.Prev = linkedList._tail;
                    linkedList._tail.Next = _head;
                    _head = linkedList._head;
                }

                this._length += linkedList._length;
            }
        }

        public void AddListByIndex(int index, DoublyLinkedList linkedList)
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
                tmp.Next.Prev = linkedList._tail;
                tmp.Next = linkedList._head;
                linkedList._head.Prev = tmp;
                this._length += linkedList._length;
            }
        }

        public void RemoveFirst()
        {
            if (!(_length == 1 && Empty))
            {
                _head = _head.Next;
                _length--;
            }
            else
            {
                InitializeEmptyList();
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
                InitializeEmptyList();
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
                InitializeEmptyList();
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
            else if (index + count == _length)
            {
                RemoveRangeFromLast(count);
            }
            else if (count != 0)
            {
                DLNode from = null;
                DLNode to = _head;
                for (int i = 0; i < index + count; i++)
                {
                    if (i == index - 1)
                    {
                        from = to;
                    }

                    to = to.Next;
                }

                from.Next = to;
                to.Prev = from;
                _length -= count;
            }
        }

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
            else if (index == this._length - 1)
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

        public int[] FindMaxValueAndItIndex()
        {
            DLNode tmp = _head;
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
            DLNode tmp = _head;
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
            DLNode tmp = _head;
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
                        tmp.Next.Prev = tmp;
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
            DLNode tmp;
            DLNode current = _head;

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
                    current.Prev = tmp;
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
                    currentNode.Prev = nextNode;
                    previousNode = currentNode;
                    currentNode = nextNode;
                }

                _tail = _head;
                _head = previousNode;
            }
        }

        public void Sort(bool ascending)
        {
            DLNode current = null, index = null;
            int tempData;

            if (!(_head is null))
            {
                for (current = _head; current.Next != null; current = current.Next)
                {
                    for (index = current.Next; index != null; index = index.Next)
                    {
                        if (ascending)
                        {
                            if (current.Data > index.Data)
                            {
                                tempData = current.Data;
                                current.Data = index.Data;
                                index.Data = tempData;
                            }
                        }
                        else
                        {
                            if (current.Data < index.Data)
                            {
                                tempData = current.Data;
                                current.Data = index.Data;
                                index.Data = tempData;
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}   

