using System;
using System.Collections.Generic;

namespace first_c_
{
    class Program
    {
        // print 1-255
        public static void print1_255()
        {
            for (int val = 1; val <= 255; val++)
            {
                Console.WriteLine(val);
            }
        }

        // print odd numbers between 1-255
        public static void printOdd()
        {
            for (int val = 1; val <= 255; val++)
            {
                if (val % 2 != 0)
                {
                    System.Console.WriteLine(val);
                }
            }
        }

        // print sum
        public static void printSum()
        {
            int sum = 0;
            for (int val = 1; val <= 255; val++)
            {
                sum += val;
                System.Console.WriteLine("the sum right now is {0}", sum);
            }
        }

        // iterating thru an array
        public static void iteratingThruArray(int[] arr)
        {
            foreach (int element in arr)
            {
                System.Console.WriteLine("the element right now is {0} ", element);
            }
        }

        // find max
        public static int findMax(int[] arr)
        {
            int max = arr[0];
            foreach (int el in arr)
            {
                if (el > max)
                {
                    max = el;
                }
            }
            System.Console.WriteLine(max);
            return max;
        }

        // get sum of arr
        public static int getSum(int[] arr)
        {
            int sum = 0;
            foreach (int el in arr)
            {
                sum += el;
            }
            return sum;
        }

        // get average
        public static float getAvg(int[] arr)
        {
            int sum = getSum(arr);
            int len = arr.Length;
            float avg = (float)sum / len;
            System.Console.WriteLine(avg);
            return avg;
        }

        //array with odd numbers
        public static int[] arrWithOdd()
        {
            List<int> oddList = new List<int>();
            for (int val = 1; val <= 255; val++)
            {
                if (val % 2 != 0)
                {
                    oddList.Add(val);
                }
            }
            return oddList.ToArray();
        }

        // greater than y
        public static int[] greaterThanY(int[] arr, int y)
        {
            List<int> result = new List<int>();
            foreach (int el in arr)
            {
                if (el > y)
                {
                    result.Add(el);
                }
            }
            // foreach(int el in result)
            // {
            //     System.Console.WriteLine($"greater than y now is: {el} ");
            // }
            return result.ToArray();
        }

        // square the values
        public static int[] squareArrVals(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                arr[i] = arr[i] ^ 2;
            }
            return arr;
        }

        // elinimate the negative numbers
        public static int[] noNeg(int[] arr)
        {
            List<int> result = new List<int>();
            foreach (int el in arr)
            {
                if (el >= 0)
                {
                    result.Add(el);
                }
            }
            return result.ToArray();
        }

        // weird array shifting
        public static int[] weirdShift(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[len - 1] = 0;
            return arr;
        }

        // number to string
        public static string[] numToStr(int[] arr)
        {
            int len = arr.Length;
            List<string> result = new List<string>();
            foreach (int el in arr)
            {
                if (el < 0)
                {
                    result.Add("neg");
                }
                else
                {
                    string newEl = el.ToString();
                    result.Add(newEl);
                }
            }
            return result.ToArray();
        }

        //Multiplication table
        public static int[,] multiTable()
        {
            int[,] tableArray = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tableArray[i, j] = (i + 1) * (j + 1);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(tableArray[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
            return tableArray;
        }





        static void Main(string[] args)
        {
            //print1_255();
            //printOdd();
            //printSum();
            //int[] arr = { 0, -1, 1, 2, 3, 4, 5, -99 };
            //iteratingThruArray(arr);
            //findMax(arr);
            //getAvg(arr);
            //arrWithOdd();
            //int y = 4;
            //greaterThanY(arr, y);
            //squareArrVals(arr);
            //noNeg(arr);
            //weirdShift(arr);
            //numToStr(arr);
            multiTable();

        }
    }
}