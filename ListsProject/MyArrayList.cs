using System;
using System.Collections;

namespace ListsProject
{
    public class MyArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public MyArrayList() //Конструктор
        {
            Length = 0;

            _array = new int[10];
        }

        public void Add(int value)  // Добавление значения в конец
        {
            if (Length == _array.Length)
            {
                IncreaseSize();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddFirst(int value) // Добавление значения в начало
        {
            if (Length == _array.Length)
            {
                IncreaseSize();
            }

            int[] tmpArray = new int[_array.Length + 1];
            tmpArray[0] = value;
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i + 1] = _array[i];
            }
            _array = tmpArray;
            Length++;
        }

        public void Insert(int index, int value) //Добавление значения по индексу
        {
            if (Length == _array.Length)
            {
                IncreaseSize();
            }

            int[] tmpArray = new int[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                if (i < index)
                {
                    tmpArray[i] = _array[i];
                }
                else if (i == index)
                {
                    tmpArray[i] = value;
                }
                else
                {
                    tmpArray[i] = _array[i - 1];
                }
            }
            _array = tmpArray;
            Length++;
        }

        public void Remove()//удаляет из конца списка элемент
        {

        }

        public void RemoveFirst()//удаляет из начала списка элемент
        {

        }


        void RemoveAt(int index) //удаляет из списка элемент по индексу index
        {

        }

        void RemoveRangeEnd(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {

        }

        void RemoveRangeBegin(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {

        }

        void RemoveRange(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {

        }

        public int Count() //Возврат длинны
        {
            return Length;
        }


        private void IncreaseSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void ReduceSize()
        {
            int newLength = (int)(_array.Length * 0.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        public void Print() //Вывод списка для ручного тестирования
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"List<{i}> = {_array[i]}");
            }
        }
    }
}
