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
            _length = 0;
            _head = null;
            _tail = null;
        }

        public SingleLinkedList(int value)
        {
            _length = 1;
            _head = new Node(value);
            _tail = _head;
        }

        /* Смотрим длинну входного массива, если он не пустой***, то мы создаем новый узел с первым значением массива и пустой ссылкой
         и говорим что это наш первый и последний элемент списка, т.к. он единственный
         дальше в цикле берем значение следующего элемента массива (со второго и до конца массива)
         и говорим что наш первый узел (у него нет указателя на второй) теперь ссылается на новый узел со вторым значением массива и пустой ссылкой
         и говорим что этот новый узел теперь является последним элементом списка
         ***а если он пустой то мы говорим что наш список тоже пустой, т.к. в нем нет ниодного узла*/
        public SingleLinkedList(int[] values)
        {
            _length = values.Length;
            if (values.Length != 0)
            {
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
                _head = null;
                _tail = null;
            }


        }

        public Node GetNodeByIndex(int index)
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
            _length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public void Add(int index, int value)
        {

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

        public override bool Equals(object obj)
        {
            SingleLinkedList outcomeList = (SingleLinkedList)obj;


            if (this._length != outcomeList._length)
            {
                return false;
            }

            Node current = this._head;
            Node outcome = outcomeList._head;
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
