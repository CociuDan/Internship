using System;
using System.Collections.Generic;
using System.Threading;

namespace Lesson4_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Instances of Value & Reference Types
            Console.WriteLine("Hello World!");
            int lesson = 4;
            string lessonName = "C# Language Basic";
            double lunchPrice = 35.00;
            float something = 0.3333333f;
            decimal ceva = (decimal)5.00;
            Intern firstIntern = new Intern("Dan Cociu", 9.0);
            #endregion

            #region Reference Type value changing
            Intern secondIntern = firstIntern;
            secondIntern.ChangeAverageMark(8.5);
            Console.WriteLine(firstIntern);
            Console.WriteLine(secondIntern);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Value Type value changing
            string anotherLesson = lessonName;
            anotherLesson = "OOP. Meaning of a type.";
            Console.WriteLine(lessonName);
            Console.WriteLine(anotherLesson);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Using Static Method & No Parameter Modifier
            int x = 1;
            int y = ClassWithStatic.IncreaseInt(x);
            Console.WriteLine(y);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Using Static Method & ref Parameter Modifier
            int z = 17;
            ClassWithStatic.DecreaseInt(ref z);
            Console.WriteLine("Ref case: " + z);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Using Static Method & out Parameter Modifier
            int k = 1;
            int l = 15;
            int m;
            ClassWithStatic.Add(k, l, out m);
            Console.WriteLine("Out case: " + m);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Boxing & Unboxing Examples
            int varToBox1 = 161;
            double varToBox2 = 20.0;
            string varToBox3 = "Text";

            Console.WriteLine("Values before boxing");
            Console.WriteLine(varToBox1);
            Console.WriteLine(varToBox2);
            Console.WriteLine(varToBox3);

            List<object> listOfObjects = new List<object>();
            listOfObjects.Add(varToBox1);
            listOfObjects.Add(varToBox2);
            listOfObjects.Add(varToBox3);

            Console.WriteLine("Boxed values");
            foreach(var item in listOfObjects)
            {
                Console.WriteLine(item.ToString());
            }

            int unboxedVar1 = (int)listOfObjects[0];
            double unboxedVar2 = (double)listOfObjects[1];
            string unboxedVar3 = (string)listOfObjects[2];

            Console.WriteLine("Unboxed values");
            Console.WriteLine(unboxedVar1);
            Console.WriteLine(unboxedVar2);
            Console.WriteLine(unboxedVar3);
            Console.WriteLine("--------------------------------------");
            Console.ReadKey();
            #endregion

            #region Threads & Static Fields
            Thread t1 = new Thread(secondThread);
            t1.Start();
            Console.WriteLine("First Thread with old value: " + ClassWithStatic.i);
            Console.WriteLine();
            Thread t2 = new Thread(thirdThread);
            t2.Start();
            Console.WriteLine("First Thread with changed value: " + ClassWithStatic.i);
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("First Thread with changed value: " + ClassWithStatic.i);
            Console.WriteLine();
            Console.ReadKey();
            #endregion
        }

        static void secondThread()
        {
            ClassWithStatic.i = 10;
            Console.WriteLine("Another thread with changed value: " + ClassWithStatic.i);
            Console.WriteLine();
        }

        static void thirdThread()
        {
            ClassWithStatic.i = 20;
            Console.WriteLine("Another thread with changed value: " + ClassWithStatic.i);
            Console.WriteLine();
        }
    }
}
