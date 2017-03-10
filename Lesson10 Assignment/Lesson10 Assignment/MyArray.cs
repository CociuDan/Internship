using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Assignment
{
    public class MyArray<T> : IMyArray<T> 
    {
        public T[] _items;

        private int _length;

        public int Lenght { get { return _items.Length; } }

        public MyArray(int length)
        {
            _items = new T[length];
            _length = length;
        }

        public T this[int index]
        {
            get
            {
                return _items[index];
            }

            set
            {
                _items[index] = value;
            }
        }

        public void SwapByIndex(int index1, int index2)
        {
            T item = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = item;
        }

        public void SwapByValue(T value1, T value2)
        {
            for(int i = 0; i < Lenght; i++)
            {
                if(_items[i].Equals(value1))
                {
                    _items[i] = value2;
                }
                else if(_items[i].Equals(value2))
                {
                    _items[i] = value1;
                }
            }
        }
    }
}
