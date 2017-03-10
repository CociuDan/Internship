using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Assignment
{
    public interface IMyArray<T>
    {
        int Lenght { get; }
        void SwapByIndex(int index1, int index2);
        void SwapByValue(T value1, T value2);
    }
}
