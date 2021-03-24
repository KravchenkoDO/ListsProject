using System;
using System.Collections.Generic;
using System.Text;


namespace ListsProject
{
    public class SingleLinkedList
    {

        private int _length;
        private Node _head; //первый элемент списка
        private Node _tail; //последний элемент списка

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
                throw new ArgumentException($"You try to remove more elements than you have in list {count} > {_length}");
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

            if (count !=0)
            {
            int index = count - 1;
            Node tmp = GetNodeByIndex(index - 1);

            _head = tmp.Next.Next;
            tmp.Next = null;
            _length-=count;
            }
        }
        public void RemoveRangeFromIndex(int index, int count)
        {
            if (index < 0 || index > this._length || this.Empty)//TODO: отбить ошибки, переприсвоить голову и хвост, если понадобится
            {
                throw new IndexOutOfRangeException();
            }
            if (index + count > _length || count < 0)
            {
                throw new ArgumentException($"You try to remove more elements than you have in list!");
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
            if (this._length == 0 && current == outcome)
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

       
    }
}
