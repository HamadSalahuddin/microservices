using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
            var sortedArray = Program.ShellSort(array, array.Length, string.Empty);
            Console.WriteLine($"Are equal {expected.Equals(sortedArray)}");
            foreach(var obj in Program.SampleArrays())
            {
                Program.ShellSort((int[])obj[0], (int)obj[1], (string)obj[2]);
            }
          

        }

        // new int[] { 73, 57, 49, 99, 133, 20, 1 };
        public static int[] ShellSort(int[] array, int size, string arrayName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int interval = size / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < size; i++)
                {
                    var currentKey = array[i];
                    var k = i;

                    while (k >= interval && array[k - interval] > currentKey)
                    {
                        array[k] = array[k - interval];
                        k -= interval;
                    }

                    array[k] = currentKey;
                }
            }
            Console.WriteLine($"Time spent on {arrayName} is {stopwatch.Elapsed.ToString()}");
            stopwatch.Stop();
            return array;
           
        }

        public static int[] CreateRandomArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(lower, upper);

            return array;
        }

        public static int[] CreateSortedArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }

        public static int[] CreateImbalancedArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
            {
                if ((i % 2) == 0)
                {
                    array[i] = rand.Next(upper / 2, upper);
                }
                else
                {
                    array[i] = rand.Next(lower, 1000);
                }
            }

            return array;
        }

        public static IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateSortedArray(2000000), 2000000, "Best Case" };
            yield return new object[] { CreateRandomArray(2000000, 1, 2000000), 2000000, "Average Case" };
            yield return new object[] { CreateImbalancedArray(2000000, 1, 2000000), 2000000, "Worst Case" };
        }
    }
}
