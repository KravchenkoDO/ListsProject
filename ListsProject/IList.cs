using System;
using System.Collections.Generic;
using System.Text;

namespace ListsProject
{
    public interface IList
    {
        void Add(int value);
        void AddFirst(int value);
        void AddByIndex(int index, int value);
        void RemoveLast();
        void RemoveFirst();
        void RemoveByIndex(int index);
        void RemoveRangeFromLast(int count);
        void RemoveRangeFromFirst(int count);
        void RemoveRangeFromIndex(int index, int count);
        int GetFirstIndexByValue(int value);
        void Reverse();
        int FindMaxValue();
        int FindMinValue();
        int FindIndexOfMaxValue();
        int FindIndexOfMinValue();
        void Sort(bool ascending);
        int RemoveFirstByValue(int value);
        int RemoveAllByValue(int value);
        void AddListLast(IList listForAdd);
        void AddListFirst(IList listForAdd);
        void AddListByIndex(int index, IList listForAdd);
    }
}
