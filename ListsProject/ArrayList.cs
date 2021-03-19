using System;

namespace ListsProject
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public int this[int index]   //доступ по индексу //изменение по индексу
        {
            get
            {
                if (index > Length || index < 0) throw new IndexOutOfRangeException();
                else return _array[index];
            }
            set
            {
                if (index > Length || index < 0) throw new IndexOutOfRangeException();
                else _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[10];
            _array[0] = value;


        }

        public ArrayList(int [] arrayValues)
        {
            Length = arrayValues.Length;

            _array = new int[Length];

            Resize();
            for (int i = 0; i < Length; i++)
            {
                _array[i] = arrayValues[i];
            }

        }

        public void Add(int value) // Добавление значения в конец
        {
            if(Length >= _array.Length)
            {
                Resize();
            }
            _array[Length] = value;
            Length++;

        }



        public void AddByIndex(int index, int value) //Добавление значения по индексу
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Length++;
                if (Length >= _array.Length)
                {
                    Resize();
                }

                MoveElements(index, Length, 1);
                _array[index] = value;
            }
        }

        public void AddFirst(int value) // Добавление значения в начало
        {
            AddByIndex(0, value);
        }

        public void RemoveLast()//удаляет из конца списка элемент
        {
            Length--;
            if (Length < _array.Length / 2)
            {
                Resize();
            }
        }

        public void RemoveFirst()//удаляет из начала списка элемент
        {
            RemoveByIndex(0);
        }


        public void RemoveByIndex(int index) //удаляет из списка элемент по индексу index
        {
            MoveElements(index, Length, -1);
            Length--;
            if (Length < _array.Length / 2)
            {
                Resize();
            }
            
        }

        public void RemoveRangeFromLast(int count) //удаляет из списка count элементов, начиная с конца
        {
            RemoveRangeFromIndex(Length- count, count);
        }

        public void RemoveRangeFromFirst(int count) //удаляет из списка count элементов, начиная с начала
        {
            if (count > Length)
            {
                count = Length;
            }
            RemoveRangeFromIndex(0,count);
        }

        public void RemoveRangeFromIndex(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {
            if (count > (Length - index))
            {
                count = Length - (index+1);
            }
            Length -= count;
            MoveElements(index, Length, -count);

            if (Length <= _array.Length / 2)
            {
                Resize(count);
            }
            
        }

        public void RemoveFirstByValue(int value) //удаление по значению первого
        {

        }

        public void RemoveAllByValue() //удаление по значению всех
        {

        }


        public int GetLength() //Возврат длинны
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("LIST is empty");
            }
            return Length;
           
        }


        public int GetFirstIndexByValue(int value) //Возврат первый индекс по значению
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse() //реверс (123 -> 321)
        {
            for (int i = 0; i < Length / 2; i++)
            {
                var tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
            }
        }

        public int FindIndexOfMaxValue() //поиск индекс максимального элемента
        {
            int arrayIndexMaxValue = 0;
            int arrayMaxValue = _array[0];
            for (int i = 0; i < Length-1; i++)
            {
                if (_array[i] > arrayMaxValue)
                {
                    arrayMaxValue = _array[i];
                    arrayIndexMaxValue = i;
                }
            }
            return arrayIndexMaxValue;
        }

        public int FindIndexOfMinValue() //поиск индекс минимального элемента
        {
            int arrayIndexMinValue = 0;
            int arrayMinValue = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < arrayMinValue)
                {
                    arrayMinValue = _array[i];
                    arrayIndexMinValue = i;
                }
            }
            return arrayIndexMinValue;
        }

        public int FindMaxValue() //поиск значения максимального элемента

        {
            return _array[FindIndexOfMaxValue()];
        }

        public int FindMinValue() //поиск значения минимального элемента

        {
            return _array[FindIndexOfMinValue()];
        }


        public int[] Sort(bool ascending)
        {
            int lessIndex;
            int greateIndex;
            int lessValue;
            int greateValue;
            if (ascending)
            {
                for (int i = 0; i < Length; i++)
                {
                    lessIndex = i;
                    lessValue = _array[i];
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (_array[j] < lessValue)
                        {
                            lessIndex = j;
                            lessValue = _array[j];
                        }
                    }
                    _array[lessIndex] = _array[i];
                    _array[i] = lessValue;
                }
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    greateIndex = i;
                    greateValue = _array[i];
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (_array[j] > greateValue)
                        {
                            greateIndex = j;
                            greateValue = _array[j];
                        }
                    }
                    _array[greateIndex] = _array[i];
                    _array[i] = greateValue;
                }
            }
            return _array;
        }





        //добавление списка (вашего самодельного) в конец
        //добавление списка в начало
        //добавление списка по индексу


        private void Resize(int countElements = 1)
        {
            int newLength = (int)(Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
        private void MoveElements(int indexFrom, int indexTo, int count)
        {
            if (count > 0)
            {
                for (int i = indexTo; (i - count) >= indexFrom; --i)
                {
                    _array[i] = _array[i - count];
                }
            }
            else
            {
                for (int i = indexFrom; i < indexTo; ++i)
                {
                    _array[i] = _array[i - count];
                }
            }

        }

        public void Print()
        {
            this.PrintArray();
            this.PrintList();
        }
        private void PrintArray() //For manual testing
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"Array[{i}] = {_array[i]}");
            }
        }
        private void PrintList() //For manual testing
        {
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"List<{i}> = {_array[i]}");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is ArrayList)
            {
                ArrayList arrayList = (ArrayList)obj;
                if (this.Length != arrayList.Length)
                {
                    return false;
                }
                for (int i = 0; i < Length; i++)
                {
                    if (this._array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
