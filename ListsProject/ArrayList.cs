using System;

namespace ListsProject
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[11];
            _array[0] = value;

        }

        public ArrayList(int [] arrayValues)
        {
            Length = arrayValues.Length;

            _array = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                _array[i] = arrayValues[i];
            }

            //Resize(true);

        }

        public void Add(int value)  // Добавление значения в конец
        {
            int countElements = 1;
                Resize(true, countElements);
            _array[Length] = value;
            Length++;
        }
        public void MoveElements(int index, int countElements)
        {
            if (Length + countElements >= _array.Length - 1)
            {
                Resize(true, countElements);
            }

                for (int i = index; i <= Length; i++)
                {
                     int tmp = _array[i];
                    _array[i+1] = _array[i + countElements];
                    
                }

                //for (int i = Length; i <= index; i--)
                //{
                //    _array[i] = _array[i + countElements];
                //}

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


        public void AddFirst(int value) // Добавление значения в начало
        {
            Resize(true, 1);

            for (int i = Length; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array [0] = value;
            ++Length;
        }

        public void AddByIndex(int index, int value) //Добавление значения по индексу
        {
            Resize(true, 1);

            for (int i = Length; i >= index; i--) //TODO: write method to provide single responsibility
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = value;

            Length++;
        }

        public void RemoveLast()//удаляет из конца списка элемент
        {
            if (Length < _array.Length / 2)
            {
                
            }
            Length--;
        }

        public void RemoveFirst()//удаляет из начала списка элемент
        {
            if (Length < _array.Length / 2)
            {
                
            }
            for (int i = Length+1; i > 0; i--) //TODO: write method to provide single responsibility Метод, который убирает Н элементов и из какой позиции
            {
                _array[i] = _array[i+1];
            }

            Length--;

        }


        public void RemoveByIndex(int index) //удаляет из списка элемент по индексу index
        {

        }

        public void RemoveRangeFromEnd(int count) //удаляет из списка count элементов, начиная с конца
        {

        }

        public void RemoveRangeFromBegin(int count) //удаляет из списка count элементов, начиная с начала
        {

        }

        public void RemoveRangeFromIndex(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {

        }

        public int GetLength() //Возврат длинны
        {
            return Length;
        }

        public int this[int index]   //доступ по индексу //изменение по индексу
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
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

        public int[] Reverse() //реверс (123 -> 321)

        {
            for (int i = 0; i < Length / 2; i++)
            {
                var tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
            }
            return _array;
        }

        public int FindIndexOfMaxValue() //поиск индекс максимального элемента
        {
            int arrayIndexMaxValue = 0;
            int arrayMaxValue = _array[0];
            for (int i = 1; i < Length; i++)
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
            int arrayMaxValue = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > arrayMaxValue)
                {
                    arrayMaxValue = _array[i];
                }
            }
            return arrayMaxValue;
        }

        public int FindMinValue() //поиск значения минимального элемента

        {
            int arrayMinValue = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < arrayMinValue)
                {
                    arrayMinValue = _array[i];
                }
            }
            return arrayMinValue;
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

        public void RemoveFirstByValue(int value) //удаление по значению первого
        {

        }

        public void RemoveAllByValue() //удаление по значению всех
        {

        }




        //добавление списка (вашего самодельного) в конец
        //добавление списка в начало
        //добавление списка по индексу

        



        /// <summary>
        /// Increase or Reduce size of list
        /// </summary>
        /// <param name="increase">if true increase list size</param>
        private void Resize(bool increase, int countElements)
        {

            int newLength = _array.Length + countElements;
            if (increase) 
            {
                newLength = (int)(newLength * 1.33d + 1);
            }
            else
            {
                newLength = (int)(newLength * 0.67d + 1);
            }

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        public void Print() //For manual testing
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"List<{i}> = {_array[i]}");
            }
        }
    }
}
