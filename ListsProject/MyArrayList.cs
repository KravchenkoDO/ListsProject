using System;
using System.Collections;

namespace ListsProject
{
    public class MyArrayList
    {
        public int Length { get; private set; }
        
        private int[] _array;

        public MyArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddFirst(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            int[] tmpArray = new int[_array.Length+1];
            tmpArray[0] = value;
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i+1] = _array[i];
            }
            _array = tmpArray;
        }

        public void Insert(int index, int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }



        }
        public void Print()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"List<{i}> = {_array[i]}");
            }
        }

        private void UpSize()
        {
            int newLength = (int) (_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}
