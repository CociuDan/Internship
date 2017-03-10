using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> array = new MyArray<int>(5);
            //for(int i = 0; i < array.Lenght; i++)
            //{
            //    array[i] = i+10;
            //    Console.WriteLine(array[i]);
            //}

            array[0] = 10;
            array[1] = 10;
            array[2] = 2;
            array[3] = 5;
            array[4] = 14;
            Console.WriteLine();
            array.SwapByValue(10, 14);
            for (int i = 0; i < array.Lenght; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
