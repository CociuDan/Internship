using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lesson6_Assignment
{
    class Program
    {


        static void Main(string[] args)
        {
            #region One Dimensional Arrays
            Console.WriteLine("One Dimensional Arrays");

            #region First Method For One Dimensional Array
            int[] firstMethodArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            DeleteEven(firstMethodArray);
            #endregion

            #region Second Method For One Dimensional Array
            int[] secondMethodArray = { 1, 3, 5, 0, 5, 7, 0, 0, 0, 3 };
            CompressArray(secondMethodArray);
            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();

            #region Two Dimensioanl Arrays
            Console.WriteLine("Two Dimensional Arrays");

            #region First Method With Two Dimensional Array;
            int[,] firstBiArray = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            AddingLine(firstBiArray);
            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();

            #region Operations With Strings
            Console.WriteLine("Strings");

            #region First Method For Strings

            string justText = "Looking for letter a and adding the dollar sign after each occurrence.";
            InsertCharAfter(justText, 'a', '$');
            #endregion

            #region Second Method For Strings
            string anothertext = "Just a text to check char statistic occurrence";
            Statistics(anothertext);
            #endregion

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();

            #region Third Method For Strings
            string text = "A text for finding the a substring inside every word.";
            WordsThatContains(text, "in");
            #endregion


            #region Fourth Method For String
            string anotherText = "We need to check the words lenght and display them in a order";
            WordsInOrder(anotherText);
            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();

            #region Misc
            Console.WriteLine("Misc");
            Point p1 = new Point { x = 1, y = 1 };
            Point p2 = new Point { x = 6, y = 6 };
            Distance(p1, p2);






            Console.WriteLine();
            Console.WriteLine("5.6 Write recursive method Power( base, exponent )...");
            Console.WriteLine("Insert values");
            int num;
            int power;
            Console.Write("num = ");
            int.TryParse(Console.ReadLine().ToString(), out num);
            Console.Write("power = ");
            int.TryParse(Console.ReadLine().ToString(), out power);
            int value = Power(num, power);
            Console.WriteLine("Result: " + value);
            #endregion
            
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        #region One Dimensional Arryas Methods
        //1.1 Delete all even numbers.
        public static void DeleteEven(int[] array)
        {
            Console.WriteLine();
            Console.WriteLine("1.1 Delete all even numbers.");
            DisplayArray(array);
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    array[i] = 0;
                }
            }
            DisplayArray(array);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }



        //1.5 Compress array by deleting all zero-value elements.
        public static void CompressArray(int[] array)
        {
            Console.WriteLine();
            Console.WriteLine("1.5 Compress array by deleting all zero-value elements.");
            DisplayArray(array);
            Console.WriteLine();
            int outArraySize = CalculateSecondArraySize(array);
            int skippedElements = 0;
            int[] outArray = new int[outArraySize];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    outArray[i - skippedElements] = array[i];
                }
                else
                {
                    skippedElements++;
                }
            }
            DisplayArray(array);
            Console.ReadKey();
        }
        //Calculating second array size depending on how many zero are in the first one
        public static int CalculateSecondArraySize(int[] firstArray)
        {

            int secondArraySize = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != 0)
                {
                    secondArraySize++;
                }
            }
            return secondArraySize;
        }
        
        
        //Printing the array to console.
        public static void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
        }
        #endregion






        #region Two Dimensional Arrays Methods
        //2.1 Insert new line after line containing the first occurrence of the minimal element.
        public static void AddingLine(int[,] array)
        {
            Console.WriteLine();
            Console.WriteLine("2.1 Insert new line after line containing the first occurrence of the minimal element.");
            DisplayArray(array);
            Console.WriteLine();
            int minValue = array[0, 0];
            int lineWithMinValue = 0;
            bool isLineAdded = false;
            int[,] outArray = new int[array.GetLength(0) + 1, array.GetLength(1)];
            MinValueAndIndex(ref array, ref minValue, ref lineWithMinValue);
            for (int i = 0; i < array.GetLength(0) + 1; i++)
            {
                if (i - 1 == lineWithMinValue)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        outArray[i, j] = 0;
                    }
                    isLineAdded = true;
                }
                else
                {
                    if (isLineAdded)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            outArray[i, j] = array[i - 1, j];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            outArray[i, j] = array[i, j];
                        }
                    }
                }
            }
            DisplayArray(array);
            Console.ReadKey();
        }
        //Finding the min value, and the line that contains it.
        public static void MinValueAndIndex(ref int[,] array, ref int minValue, ref int lineWithMinValue)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < minValue)
                    {
                        minValue = array[i, j];
                        lineWithMinValue = i;
                    }
                }
            }
        }

        public static void DisplayArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion





        
        #region String Operations Methods
        //3.1 Insert  character <x> after every occurrence of character <y>; 
        public static void InsertCharAfter(string text, char charToFind, char charToInsert)
        {
            Console.WriteLine();
            Console.WriteLine("3.1 Insert  character <x> after every occurrence of character <y>; ");
            Console.WriteLine(text);
            Console.WriteLine();
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c == charToFind)
                {
                    sb.Append(c);
                    sb.Append(charToInsert);
                }
                else
                {
                    sb.Append(c);
                }
            }
            Console.WriteLine(text = sb.ToString());
            Console.WriteLine();
            Console.ReadKey();
        }



        //3.20 Count and display statistics of character occurrences in the string.
        public static void Statistics(string text)
        {
            Console.WriteLine();
            Console.WriteLine("3.20 Count and display statistics of character occurrences in the string.");
            Console.WriteLine();
            Console.WriteLine("Text: " + text);
            List<char> charsInString = new List<char>();

            foreach (char c in text)
            {
                if (charsInString.Contains(c) == false)
                {
                    charsInString.Add(c);
                }
            }

            int[] charOccurrence = new int[charsInString.Count];

            for (int i = 0; i < charsInString.Count; i ++)
            {
                for(int j = 0; j < text.Length; j++)
                {
                    if(charsInString[i] == text[j])
                    {
                        charOccurrence[i]++;
                    }
                }
            }

            for (int i = 0; i < charsInString.Count; i++)
            {
                Console.WriteLine(charsInString[i] + ": " + charOccurrence[i]);
            }
            Console.ReadKey();
        }



        //4.1 Display only words containing the indicated substring.
        public static void WordsThatContains(string text, string subString)
        {
            Console.WriteLine();
            Console.WriteLine("4.1 Display only words containing the indicated substring.");
            Console.WriteLine("Text: " + text);
            List<string> allWords = new List<string>();
            foreach(string word in text.Split(' '))
            {
                allWords.Add(word);
            }

            List<string> wordsWith = new List<string>();
            foreach(string word in allWords)
            {
                if (word.Contains(subString))
                {
                    wordsWith.Add(word);
                }
            }

            Console.WriteLine("Words that contains: " + subString);
            foreach(string word in wordsWith)
            {
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }



        //4.20 Display words from the message in ascending order of their lengths.
        public static void WordsInOrder(string text)
        {
            Console.WriteLine();
            Console.WriteLine("4.20 Display words from the message in ascending order of their lengths.");
            Console.WriteLine("Text: " + text);
            List<string> allWords = new List<string>();
            foreach (string word in text.Split(' '))
            {
                allWords.Add(word);
            }
            var sortedWords = allWords.OrderBy(x => x.Length);            
            foreach(string word in sortedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
        #endregion






        #region Misc Methods
        //5.1.1 Write C# program calculating: Distance between points with indicated coordinates.
        public static void Distance(Point p1, Point p2)
        {
            Console.WriteLine();
            Console.WriteLine("5.1.1 Write C# program calculating: Distance between points with indicated coordinates.");
            Console.WriteLine("p1(" + p1.x + ", " + p1.y + ")");
            Console.WriteLine("p2(" + p2.x + ", " + p2.y + ")");
            double distance = Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2);
            Console.WriteLine("Distance between them: " + distance);
            Console.ReadKey();
        }

        //5.6 Write recursive method Power( base, exponent )...
        public static int Power(int num, int power)
        {
            if(power == 0)
            {
                return 1;
            }
            else
            {
                return num * Power(num, power - 1);
            }
        }
        #endregion
    }
}